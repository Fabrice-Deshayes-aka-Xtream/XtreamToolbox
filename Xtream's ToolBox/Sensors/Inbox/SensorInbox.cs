using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using Microsoft.Win32;
using System.Diagnostics;
using System.Resources;
using XtreamToolbox.Utils;
using XtreamToolbox.Utils.Mail;
using System.Collections.Specialized;

namespace XtreamToolbox.Sensors
{
    public partial class SensorInbox : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        private int nbEmail;
        private int nbSpam;

        private String hints;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private const int DONT_USE_THIS_RULE = 0;
        private const int MAIL_HEADER_CONTAINS = 1;
        private const int MAIL_SUBJECT_CONTAINS = 2;
        private const int SENDER_DNS_EXTENSION_NOT_IN = 3;
        private const int SMTP_DNS_EXTENSION_NOT_IN = 4;

        private const int SAFE_MAIL = 1;
        private const int SPAM_MAIL = 3;

        // constructor
        public SensorInbox(Toolbox toolbox)
        {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel()
        {
            return null;
        }

        // init sensor data in asynch mode
        private void InitialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            InitSensorData();
        }

        // after init sensor data, refresh ui
        private void InitialisationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshUI();
        }

        // init UI
        public void InitUI()
        {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // tips
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            // text color
            emailLabel.ForeColor = Properties.Settings.Default.textColor;
            spamLabel.ForeColor = Properties.Settings.Default.textColor;

            // Timer
            checkMailTimer.Interval = Properties.Settings.Default.popCheckerRefreshTime * 60000;

            if (!initialisationBackgroundWorker.IsBusy)
            {
                emailLabel.Visible = false;
                spamLabel.Visible = false;
                progressPictureBox.Visible = true;
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            String user, password, port;
            int currentNbEmail, currentNbSpam;
            IMailClient currentMailClient;
            hints = "";
            nbEmail = 0;
            nbSpam = 0;
            Dictionary<String, StringCollection> mailHeader;

            if (Properties.Settings.Default.location != null)
            {
                foreach (String locationStr in Properties.Settings.Default.location)
                {
                    Location location = XtreamToolbox.Location.FromString(locationStr);
                    if (location != null)
                    {
                        switch (location.Type)
                        {
                            case XtreamToolbox.Location.POP3ACCOUNT:
                                location.Parameters.TryGetValue("user", out user);
                                location.Parameters.TryGetValue("password", out password);
                                location.Parameters.TryGetValue("port", out port);
                                if (string.IsNullOrEmpty(port))
                                {
                                    port = "110";
                                }

                                currentMailClient = new Pop3Client();
                                currentMailClient.Connect(location.Loc, user, password, Int16.Parse(port));
                                currentNbEmail = 0;
                                currentNbSpam = 0;

                                for (int i = 1; i <= currentMailClient.GetNbMailInbox(); i++)
                                {
                                    mailHeader = currentMailClient.GetMailHeader(i);
                                    switch (ApplySpamRules(mailHeader))
                                    {
                                        case SPAM_MAIL:
                                            currentNbSpam++;
                                            break;
                                        default: // SAFE_MAIL
                                            currentNbEmail++;
                                            break;
                                    }
                                }
                                currentMailClient.Disconnect();

                                nbEmail += currentNbEmail;
                                nbSpam += currentNbSpam;
                                if ((currentNbSpam > 0) || (currentNbEmail > 0))
                                {
                                    hints += String.Format(resources.GetString("Pop3Checker_Hint"), location.Loc, user, currentNbEmail, currentNbSpam, Environment.NewLine);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            hints += String.Format(resources.GetString("Pop3Checker_OpenIt"),Environment.NewLine);
        }

        private int ApplySpamRules(Dictionary<String, StringCollection> mailHeader)
        {
            int retour = SAFE_MAIL;

            retour = ApplySpamRule(retour, Properties.Settings.Default.spamRule1, Properties.Settings.Default.spamRule1Data, mailHeader);
            retour = ApplySpamRule(retour, Properties.Settings.Default.spamRule2, Properties.Settings.Default.spamRule2Data, mailHeader);
            retour = ApplySpamRule(retour, Properties.Settings.Default.spamRule3, Properties.Settings.Default.spamRule3Data, mailHeader);
            retour = ApplySpamRule(retour, Properties.Settings.Default.spamRule4, Properties.Settings.Default.spamRule4Data, mailHeader);
            retour = ApplySpamRule(retour, Properties.Settings.Default.spamRule5, Properties.Settings.Default.spamRule5Data, mailHeader);
            retour = ApplySpamRule(retour, Properties.Settings.Default.spamRule6, Properties.Settings.Default.spamRule6Data, mailHeader);

            return retour;
        }

        private int ApplySpamRule(int lastState, int ruleType, String ruleData, Dictionary<String, StringCollection> mailHeader)
        {
            int retour = SAFE_MAIL;
            StringCollection value;
            String[] allowedDnsExtension;
            bool atLeastOne;

            if ((lastState == SAFE_MAIL) && (ruleType != DONT_USE_THIS_RULE))
            {
                switch (ruleType)
                {
                    case MAIL_HEADER_CONTAINS:
                        String tagName = ruleData.Substring(0, ruleData.IndexOf(':')).Trim().ToUpper();
                        String tagValue = ruleData.Substring(ruleData.IndexOf(':') + 1, ruleData.Length - (ruleData.IndexOf(':') + 1)).Trim().ToUpper();
                        mailHeader.TryGetValue(tagName, out value);
                        if (value != null)
                        {
                            foreach (String strValue in value)
                            {
                                if (strValue.IndexOf(tagValue) != -1)
                                {
                                    retour = SPAM_MAIL;
                                    mailHeader.TryGetValue("SUBJECT", out value);
                                }
                            }
                        }
                        break;
                    case MAIL_SUBJECT_CONTAINS:
                        mailHeader.TryGetValue("SUBJECT", out value);
                        if (value != null)
                        {
                            foreach (String strValue in value)
                            {
                                if (strValue.IndexOf(ruleData.ToUpper()) != -1)
                                {
                                    retour = SPAM_MAIL;
                                }
                            }
                        }
                        break;
                    case SENDER_DNS_EXTENSION_NOT_IN:
                        mailHeader.TryGetValue("FROM", out value);
                        if (value != null)
                        {
                            int pos1, pos2;
                            foreach (String strValue in value)
                            {
                                pos1 = strValue.IndexOf('<');
                                if (pos1 != -1)
                                {
                                    pos2 = strValue.Substring(pos1 + 1, strValue.Length - (pos1 + 1)).IndexOf('>');
                                    if (pos2 != -1)
                                    {
                                        String realFrom = strValue.Substring(pos1 + 1, pos2);

                                        allowedDnsExtension = ruleData.ToUpper().Split();
                                        atLeastOne = false;
                                        foreach (String ext in allowedDnsExtension)
                                        {
                                            if (realFrom.IndexOf(ext) != -1)
                                            {
                                                atLeastOne = true;
                                            }
                                        }
                                        if (!atLeastOne)
                                        {
                                            mailHeader.TryGetValue("SUBJECT", out value);
                                            retour = SPAM_MAIL;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case SMTP_DNS_EXTENSION_NOT_IN:
                        mailHeader.TryGetValue("RECEIVED", out value);
                        if (value != null)
                        {
                            allowedDnsExtension = ruleData.ToUpper().Split();

                            foreach (String strValue in value)
                            {
                                atLeastOne = false;
                                foreach (String ext in allowedDnsExtension)
                                {
                                    if (strValue.IndexOf(ext) != -1)
                                    {
                                        atLeastOne = true;
                                    }
                                    else
                                    {
                                    }
                                }
                                if (!atLeastOne)
                                {
                                    mailHeader.TryGetValue("SUBJECT", out value);
                                    retour = SPAM_MAIL;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                retour = lastState;
            }

            return retour;
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            emailLabel.Visible = true;
            spamLabel.Visible = true;
            progressPictureBox.Visible = false;
            helpToolTip.RemoveAll();
            ToolBoxUtils.SetTooltips(helpToolTip, this, hints);
            ToolBoxUtils.SetTooltips(helpToolTip, emailLabel, hints);
            ToolBoxUtils.SetTooltips(helpToolTip, spamLabel, hints);
            if ((nbEmail > 0) || (nbSpam > 0))
            {
                this.BackgroundImage = Properties.Resources.InboxFull;
            }
            else
            {
                this.BackgroundImage = Properties.Resources.InboxEmpty;
            }

            if (nbEmail == 0)
            {
                emailLabel.Text = resources.GetString("Pop3Checker_nomail", culture);
            }
            else
            {
                emailLabel.Text = String.Format(resources.GetString("Pop3Checker_nbmails", culture), nbEmail);
            }

            if (nbSpam == 0)
            {
                spamLabel.Text = resources.GetString("Pop3Checker_nospam", culture);
            }
            else
            {
                spamLabel.Text = String.Format(resources.GetString("Pop3Checker_nbspam", culture), nbSpam);
            }
        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            // nothing to do on this sensor
        }

        // Refresh nb unread email each timer tick
        private void CheckMailTimer_Tick(object sender, EventArgs e)
        {
            if (!initialisationBackgroundWorker.IsBusy)
            {
                emailLabel.Visible = false;
                spamLabel.Visible = false;
                progressPictureBox.Visible = true;
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        private void SensorInbox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                CheckMailTimer_Tick(sender, e);
            }
            else
            {
                SystemUtils.LaunchDefaultMailClient(Properties.Settings.Default.defaultEmailClient);
            }
        }
    }
}
