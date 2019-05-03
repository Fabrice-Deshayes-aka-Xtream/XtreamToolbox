using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using System.Net.NetworkInformation;
using XtreamToolbox.Utils;
using XtreamToolbox.Sensors;
using TimeSync;
using System.Configuration;
using System.IO;

namespace XtreamToolbox
{

    public partial class OptionsForm : Form
    {

        Toolbox toolBox = null;

        // constructor
        public OptionsForm(Toolbox toolBox)
        {
            InitializeComponent();
            this.toolBox = toolBox;
        }

        // Initialisation des options et paramétres
        public void Initialisation()
        {
            // General options
            launchWithWindowsCheckBox.Checked = SystemUtils.RunOnStart("Xtream's ToolBox", Environment.GetCommandLineArgs()[0], "isSet?");

            proxyUrlTextBox.Text = Properties.Settings.Default.proxyUrl;
            proxyPortTextBox.Text = Properties.Settings.Default.proxyPort.ToString();
            proxyUserTextBox.Text = Properties.Settings.Default.proxyUser;
            proxyPasswordTextBox.Text = Properties.Settings.Default.proxyPassword;

            proxyOnRadioButton.Checked = Properties.Settings.Default.useProxy;
            proxyOffRadioButton.Checked = !Properties.Settings.Default.useProxy;

            timeServerComboBox.Items.Clear();
            timeServerComboBox.Items.Add("time.windows.com");
            timeServerComboBox.Items.Add("ntps1-0.cs.tu-berlin.de");
            timeServerComboBox.Items.Add("swisstime.ethz.ch");
            timeServerComboBox.Items.Add("clock.uregina.ca");
            if (!string.IsNullOrEmpty(Properties.Settings.Default.timeServerUrl))
            {
                if (!timeServerComboBox.Items.Contains(Properties.Settings.Default.timeServerUrl))
                {
                    timeServerComboBox.Items.Add(Properties.Settings.Default.timeServerUrl);
                }
                timeServerComboBox.Text = Properties.Settings.Default.timeServerUrl;
            }
            timeAutoSynchronizeCheckBox.Checked = Properties.Settings.Default.timeAutoSynch;
            if (Properties.Settings.Default.timeLastSynch == new DateTime())
            {
                timeLastSynchroDatetimeLabel.Text = "never";
            }
            else
            {
                timeLastSynchroDatetimeLabel.Text = Properties.Settings.Default.timeLastSynch.ToString();
            }

            langageComboBox.Items.Clear();
            langageComboBox.Items.Add("english");
            langageComboBox.Items.Add("français");
            switch (Properties.Settings.Default.language)
            {
                case "en-US":
                    langageComboBox.SelectedItem = "english";
                    break;
                case "fr-FR":
                default:
                    langageComboBox.SelectedItem = "français";
                    break;
            }

            // TimeICalManager
            CalendarUrlTextBox.Text = Properties.Settings.Default.calendarUrl;
            ContactUrlTextBox.Text = Properties.Settings.Default.contactsUrl;

            // auto mount network drive
            nd1_driveLetterComboBox.Text = Properties.Settings.Default.nd1DriveLetter;
            nd1_pathTextBox.Text = Properties.Settings.Default.nd1Path;

            nd2_driveLetterComboBox.Text = Properties.Settings.Default.nd2DriveLetter;
            nd2_pathTextBox.Text = Properties.Settings.Default.nd2Path;

            nd3_driveLetterComboBox.Text = Properties.Settings.Default.nd3DriveLetter;
            nd3_pathTextBox.Text = Properties.Settings.Default.nd3Path;

            // Display options
            if (Properties.Settings.Default.displayMode == 1)
            {
                displayModeComboBox.SelectedIndex = Properties.Settings.Default.displayMode;
            }
            else
            {
                displayModeComboBox.SelectedIndex = 0;
            }
            opacityComboBox.SelectedIndex = 10 - (Convert.ToInt16(Properties.Settings.Default.opacity * 10));
            positionLabel.Text = "Position : X = " + Properties.Settings.Default.posX + " / Y = " + Properties.Settings.Default.posY;
            lockPositionCheckBox.Checked = Properties.Settings.Default.lockPosition;
            magneticScreenBorderCheckBox.Checked = Properties.Settings.Default.magneticScreenBorder;
            testFontColorLabel.ForeColor = Properties.Settings.Default.textColor;
            spaceBetweenSensorsNumericUpDown.Value = Properties.Settings.Default.spaceBetweenSensor;
            displayMoreInfosComboBox.SelectedIndex = Properties.Settings.Default.extendedInfosPanel;

            tooltipsDisableCheckBox.Checked = !Properties.Settings.Default.hintsActive;
            tooltipsAppearComboBox.Text = Properties.Settings.Default.hintsAfter.ToString();
            tooltipsDisappearComboBox.Text = Properties.Settings.Default.hintsLength.ToString();

            // liste des sensors présent sur la toolbox
            sensorsListBox.Items.Clear();
            foreach (String sensor in Properties.Settings.Default.sensors)
            {
                sensorsListBox.Items.Add(sensor);
            }

            // refresh avalaible sensors
            RefreshAvailableSensors();

            // Recycle Bin controller options
            refreshTimeRecycleBinComboBox.Text = Properties.Settings.Default.recycleBinRefreshTime.ToString();
            deleteConfirmationcheckBox.Checked = Properties.Settings.Default.disableDeleteConfirmation;

            // System informations options
            refreshTimeSysInfosComboBox.Text = Properties.Settings.Default.sysInfosRefreshTime.ToString();

            internetConnexionComboBox.Items.Clear();
            internetConnexionComboBox.Items.Add("disable");
            internetConnexionComboBox.SelectedIndex = 0;
            lanConnexionComboBox.Items.Clear();
            lanConnexionComboBox.Items.Add("disable");
            lanConnexionComboBox.SelectedIndex = 0;
            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((!networkInterface.GetType().Equals(NetworkInterfaceType.Loopback)) && (!"MS TCP Loopback interface".Equals(networkInterface.Name)))
                {
                    lanConnexionComboBox.Items.Add(networkInterface);
                    if (networkInterface.GetPhysicalAddress().ToString().Equals(Properties.Settings.Default.networkLanConnexion))
                    {
                        lanConnexionComboBox.SelectedItem = networkInterface;
                    }
                    internetConnexionComboBox.Items.Add(networkInterface);
                    if (networkInterface.GetPhysicalAddress().ToString().Equals(Properties.Settings.Default.networkInternetConnexion))
                    {
                        internetConnexionComboBox.SelectedItem = networkInterface;
                    }
                }
            }
            lanMaxBandwithTextBox.Text = Properties.Settings.Default.networkLanBandwith.ToString();
            internetDownloadTextBox.Text = Properties.Settings.Default.networkInternetDownload.ToString();
            internetUploadTextBox.Text = Properties.Settings.Default.networkInternetUpload.ToString();
            defaultDisplayComboBox.SelectedIndex = Properties.Settings.Default.sysInfoDisplayMode;

            // pop3 specific options
            popListBox.Items.Clear();
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
                                popListBox.Items.Add(location);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            popRefreshTimeComboBox.Text = Properties.Settings.Default.popCheckerRefreshTime.ToString();
            if (string.IsNullOrEmpty(Properties.Settings.Default.defaultEmailClient))
            {
                Properties.Settings.Default.defaultEmailClient = "default";
            }
            emailClientTextBox.Text = Properties.Settings.Default.defaultEmailClient;
            spamRuleComboBox1.SelectedIndex = Properties.Settings.Default.spamRule1;
            spamRuleTextBox1.Text = Properties.Settings.Default.spamRule1Data;
            spamRuleComboBox2.SelectedIndex = Properties.Settings.Default.spamRule2;
            spamRuleTextBox2.Text = Properties.Settings.Default.spamRule2Data;
            spamRuleComboBox3.SelectedIndex = Properties.Settings.Default.spamRule3;
            spamRuleTextBox3.Text = Properties.Settings.Default.spamRule3Data;
            spamRuleComboBox4.SelectedIndex = Properties.Settings.Default.spamRule4;
            spamRuleTextBox4.Text = Properties.Settings.Default.spamRule4Data;
            spamRuleComboBox5.SelectedIndex = Properties.Settings.Default.spamRule5;
            spamRuleTextBox5.Text = Properties.Settings.Default.spamRule5Data;
            spamRuleComboBox6.SelectedIndex = Properties.Settings.Default.spamRule6;
            spamRuleTextBox6.Text = Properties.Settings.Default.spamRule6Data;

            // shutdown/restart/logoff options
            upperActionComboBox.SelectedIndex = Properties.Settings.Default.shutdownManagerDefaultActionUpperButton;
            upperActionDisableConfirmationCheckBox.Checked = Properties.Settings.Default.shutdownManagerLowerActionConfirmation;
            lowerActionDisableConfirmationCheckBox.Checked = Properties.Settings.Default.shutdownManagerUpperActionConfirmation;
            lowerActionComboBox.SelectedIndex = Properties.Settings.Default.shutdownManagerDefaultActionLowerButton;

            // QuickLauncher options
            quickLauncherOnlyOneLineCheckBox.Checked = Properties.Settings.Default.quickLauncherOnlyOneLine;
            separatorWidthNumericUpDown.Value = Properties.Settings.Default.QuicklaunchSeparatorWidth;

            // Notpad sensor prefered text editor
            textEditorPathTextBox.Text = Properties.Settings.Default.defaultTextEditor;

            // Empty formulaire
            EmptyPopLocationForm();
        }

        // refresh available sensors
        private void RefreshAvailableSensors()
        {
            availableSensorsComboBox.Items.Clear();
            if (!sensorsListBox.Items.Contains("SensorSystemInfos"))
            {
                availableSensorsComboBox.Items.Add("SensorSystemInfos");
            }

            if (!sensorsListBox.Items.Contains("SensorFavoriteLocations"))
            {
                availableSensorsComboBox.Items.Add("SensorFavoriteLocations");
            }

            if (!sensorsListBox.Items.Contains("SensorQuickLauncher"))
            {
                availableSensorsComboBox.Items.Add("SensorQuickLauncher");
            }

            if (!sensorsListBox.Items.Contains("SensorRecycleBin"))
            {
                availableSensorsComboBox.Items.Add("SensorRecycleBin");
            }

            if (!sensorsListBox.Items.Contains("SensorShutdownManager"))
            {
                availableSensorsComboBox.Items.Add("SensorShutdownManager");
            }

            if (!sensorsListBox.Items.Contains("SensorPowerStatus"))
            {
                availableSensorsComboBox.Items.Add("SensorPowerStatus");
            }

            if (!sensorsListBox.Items.Contains("SensorTimeIcalManager"))
            {
                availableSensorsComboBox.Items.Add("SensorTimeIcalManager");
            }

            if (!sensorsListBox.Items.Contains("SensorNotepad"))
            {
                availableSensorsComboBox.Items.Add("SensorNotepad");
            }

            if (!sensorsListBox.Items.Contains("SensorWeather"))
            {
                availableSensorsComboBox.Items.Add("SensorWeather");
            }

            if (!sensorsListBox.Items.Contains("SensorMyComputer"))
            {
                availableSensorsComboBox.Items.Add("SensorMyComputer");
            }

            if (!sensorsListBox.Items.Contains("SensorCalc"))
            {
                availableSensorsComboBox.Items.Add("SensorCalc");
            }

            if (!sensorsListBox.Items.Contains("SensorKeyStatus"))
            {
                availableSensorsComboBox.Items.Add("SensorKeyStatus");
            }

            if (!sensorsListBox.Items.Contains("SensorInbox"))
            {
                availableSensorsComboBox.Items.Add("SensorInbox");
            }

            if (!sensorsListBox.Items.Contains("SensorStorage"))
            {
                availableSensorsComboBox.Items.Add("SensorStorage");
            }

            if (!sensorsListBox.Items.Contains("SensorAnalogClock"))
            {
                availableSensorsComboBox.Items.Add("SensorAnalogClock");
            }

            availableSensorsComboBox.Items.Add("SensorSpacer");
            availableSensorsComboBox.SelectedIndex = 0;
        }

        // cancel and Close options form
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // reset toolbox position to x=0, y=0
        private void ResetPositionButton_Click(object sender, EventArgs e)
        {
            positionLabel.Text = "Position : X = 0 / Y = 0";
            toolBox.Left = 0;
            toolBox.Top = 0;
        }

        // save all options in properties
        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateSystemProperties();
            Close();

            toolBox.Action = "relaunch";
        }


        private void UpdateSystemProperties()
        {
            // General option
            // auto launch
            if (launchWithWindowsCheckBox.Checked)
            {
                SystemUtils.RunOnStart("Xtream's ToolBox", Environment.GetCommandLineArgs()[0], "add");
            }
            else
            {
                SystemUtils.RunOnStart("Xtream's ToolBox", Environment.GetCommandLineArgs()[0], "remove");
            }
            // proxy conf
            Properties.Settings.Default.useProxy = proxyOnRadioButton.Checked;
            Properties.Settings.Default.proxyUrl = proxyUrlTextBox.Text;
            Properties.Settings.Default.proxyPort = Convert.ToInt16(proxyPortTextBox.Text);
            Properties.Settings.Default.proxyUser = proxyUserTextBox.Text;
            Properties.Settings.Default.proxyPassword = proxyPasswordTextBox.Text;

            // sntp server
            Properties.Settings.Default.timeServerUrl = timeServerComboBox.Text;
            Properties.Settings.Default.timeAutoSynch = timeAutoSynchronizeCheckBox.Checked;

            // current langage
            switch (langageComboBox.SelectedItem.ToString())
            {
                case "english":
                    Properties.Settings.Default.language = "en-US";
                    break;
                case "français":
                default:
                    Properties.Settings.Default.language = "fr-FR";
                    break;
            }

            // TimeICalManager
            Properties.Settings.Default.calendarUrl = CalendarUrlTextBox.Text;
            Properties.Settings.Default.contactsUrl = ContactUrlTextBox.Text;

            // auto mount network drive
            Properties.Settings.Default.nd1DriveLetter = nd1_driveLetterComboBox.Text;
            Properties.Settings.Default.nd1Path = nd1_pathTextBox.Text;

            Properties.Settings.Default.nd2DriveLetter = nd2_driveLetterComboBox.Text;
            Properties.Settings.Default.nd2Path = nd2_pathTextBox.Text;

            Properties.Settings.Default.nd3DriveLetter = nd3_driveLetterComboBox.Text;
            Properties.Settings.Default.nd3Path = nd3_pathTextBox.Text;

            // Display option
            Properties.Settings.Default.displayMode = displayModeComboBox.SelectedIndex;
            toolBox.TopMost = (displayModeComboBox.SelectedIndex == 1);
            Properties.Settings.Default.lockPosition = lockPositionCheckBox.Checked;
            Properties.Settings.Default.magneticScreenBorder = magneticScreenBorderCheckBox.Checked;
            if (Properties.Settings.Default.magneticScreenBorder)
            {
                if (Math.Abs(toolBox.Top - Screen.PrimaryScreen.WorkingArea.Top) < 32)
                {
                    toolBox.Top = Screen.PrimaryScreen.WorkingArea.Top;
                }
                else if (Math.Abs(toolBox.Bottom - Screen.PrimaryScreen.WorkingArea.Bottom) < 32)
                {
                    toolBox.Top = Screen.PrimaryScreen.WorkingArea.Bottom - toolBox.Height;
                }
            }

            Properties.Settings.Default.extendedInfosPanel = displayMoreInfosComboBox.SelectedIndex;
            Properties.Settings.Default.hintsActive = !tooltipsDisableCheckBox.Checked;
            try
            {
                Properties.Settings.Default.hintsAfter = Convert.ToInt16(tooltipsAppearComboBox.Text);
            }
            catch (FormatException)
            {
                Properties.Settings.Default.hintsAfter = 500;
            }
            try
            {
                Properties.Settings.Default.hintsLength = Convert.ToInt16(tooltipsDisappearComboBox.Text);
            }
            catch (FormatException)
            {
                Properties.Settings.Default.hintsLength = 60000;
            }
            Properties.Settings.Default.textColor = testFontColorLabel.ForeColor;
            try
            {
                Properties.Settings.Default.opacity = Convert.ToDouble(opacityComboBox.Text) / 100;
            }
            catch (FormatException)
            {
                Properties.Settings.Default.opacity = 1;
            }
            Properties.Settings.Default.posX = toolBox.Left;
            Properties.Settings.Default.posY = toolBox.Top;
            StringCollection sensors = new StringCollection();
            foreach (String sensor in sensorsListBox.Items)
            {
                sensors.Add(sensor);
            }
            Properties.Settings.Default.sensors = sensors;
            try
            {
                Properties.Settings.Default.spaceBetweenSensor = Convert.ToInt16(spaceBetweenSensorsNumericUpDown.Value);
            }
            catch (FormatException)
            {
                Properties.Settings.Default.spaceBetweenSensor = 2;
            }

            // Recycle bin options
            Properties.Settings.Default.disableDeleteConfirmation = deleteConfirmationcheckBox.Checked;
            try
            {
                Properties.Settings.Default.recycleBinRefreshTime = Convert.ToInt16(refreshTimeRecycleBinComboBox.Text);
            }
            catch (FormatException)
            {
                Properties.Settings.Default.recycleBinRefreshTime = 1000;
            }

            Properties.Settings.Default.shutdownManagerLowerActionConfirmation = upperActionDisableConfirmationCheckBox.Checked;
            Properties.Settings.Default.shutdownManagerDefaultActionUpperButton = upperActionComboBox.SelectedIndex;
            Properties.Settings.Default.shutdownManagerUpperActionConfirmation = lowerActionDisableConfirmationCheckBox.Checked;
            Properties.Settings.Default.shutdownManagerDefaultActionLowerButton = lowerActionComboBox.SelectedIndex;

            // Locations : init location list with quicklaunch shortcut and separator and calendars
            StringCollection locations = new StringCollection();
            Location currentLocation;
            foreach (String locationStr in Properties.Settings.Default.location)
            {
                currentLocation = XtreamToolbox.Location.FromString(locationStr);
                if ((currentLocation.Type == XtreamToolbox.Location.APPLICATION) || (currentLocation.Type == XtreamToolbox.Location.CALENDAR))
                {
                    locations.Add(locationStr);
                }
            }

            // add Pop Location
            foreach (Location location in popListBox.Items)
            {
                locations.Add(location.ToDelimitedString());
            }

            Properties.Settings.Default.location = locations;

            // pop3 specific options
            try
            {
                Properties.Settings.Default.popCheckerRefreshTime = Convert.ToInt16(popRefreshTimeComboBox.Text);
            }
            catch (FormatException)
            {
                Properties.Settings.Default.popCheckerRefreshTime = 5;
            }

            if (string.IsNullOrEmpty(emailClientTextBox.Text))
            {
                emailClientTextBox.Text = "default";
            }

            Properties.Settings.Default.defaultEmailClient = emailClientTextBox.Text;
            Properties.Settings.Default.spamRule1 = spamRuleComboBox1.SelectedIndex;
            Properties.Settings.Default.spamRule1Data = spamRuleTextBox1.Text;
            Properties.Settings.Default.spamRule2 = spamRuleComboBox2.SelectedIndex;
            Properties.Settings.Default.spamRule2Data = spamRuleTextBox2.Text;
            Properties.Settings.Default.spamRule3 = spamRuleComboBox3.SelectedIndex;
            Properties.Settings.Default.spamRule3Data = spamRuleTextBox3.Text;
            Properties.Settings.Default.spamRule4 = spamRuleComboBox4.SelectedIndex;
            Properties.Settings.Default.spamRule4Data = spamRuleTextBox4.Text;
            Properties.Settings.Default.spamRule5 = spamRuleComboBox5.SelectedIndex;
            Properties.Settings.Default.spamRule5Data = spamRuleTextBox5.Text;
            Properties.Settings.Default.spamRule6 = spamRuleComboBox6.SelectedIndex;
            Properties.Settings.Default.spamRule6Data = spamRuleTextBox6.Text;

            // SysInfos options
            try
            {
                Properties.Settings.Default.sysInfosRefreshTime = Convert.ToInt16(refreshTimeSysInfosComboBox.Text);
            }
            catch (FormatException)
            {
                Properties.Settings.Default.sysInfosRefreshTime = 500;
            }

            if ((lanConnexionComboBox.SelectedItem != null) && (lanConnexionComboBox.SelectedIndex != 0))
            {
                Properties.Settings.Default.networkLanConnexion = ((NetworkInterface)lanConnexionComboBox.SelectedItem).GetPhysicalAddress().ToString();
                try
                {
                    Properties.Settings.Default.networkLanBandwith = Convert.ToInt16(lanMaxBandwithTextBox.Text);
                }
                catch (OverflowException)
                {
                    Properties.Settings.Default.networkLanBandwith = 100;
                }
            }
            else
            {
                Properties.Settings.Default.networkLanConnexion = Properties.Resources.not_available;
            }

            if ((internetConnexionComboBox.SelectedItem != null) && (internetConnexionComboBox.SelectedIndex != 0))
            {
                Properties.Settings.Default.networkInternetConnexion = ((NetworkInterface)internetConnexionComboBox.SelectedItem).GetPhysicalAddress().ToString();
                try
                {
                    Properties.Settings.Default.networkInternetDownload = Convert.ToInt32(internetDownloadTextBox.Text);
                }
                catch (OverflowException)
                {
                    Properties.Settings.Default.networkInternetDownload = 8192;
                }
                try
                {
                    Properties.Settings.Default.networkInternetUpload = Convert.ToInt32(internetUploadTextBox.Text);
                }
                catch (OverflowException)
                {
                    Properties.Settings.Default.networkInternetUpload = 1024;
                }
            }
            else
            {
                Properties.Settings.Default.networkInternetConnexion = Properties.Resources.not_available;
            }

            Properties.Settings.Default.sysInfoDisplayMode = defaultDisplayComboBox.SelectedIndex;

            // notepad sensor prefered text editor
            Properties.Settings.Default.defaultTextEditor = textEditorPathTextBox.Text;

            // Empty formulaire
            EmptyPopLocationForm();

            // QuickLauncher
            Properties.Settings.Default.quickLauncherOnlyOneLine = quickLauncherOnlyOneLineCheckBox.Checked;
            try
            {
                Properties.Settings.Default.QuicklaunchSeparatorWidth = Convert.ToInt16(separatorWidthNumericUpDown.Value);
            }
            catch (FormatException)
            {
                Properties.Settings.Default.QuicklaunchSeparatorWidth = 10;
            }

            Properties.Settings.Default.Save();
        }

        // choose default text color
        private void ChangeFontColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                testFontColorLabel.ForeColor = colorDialog.Color;
            }
        }

        /* ---------------------- */
        /* manage SENSOR list box */
        /* ---------------------- */
        // déplace le sensor selectionné vers le bas
        private void MoveSensorDownButton_Click(object sender, EventArgs e)
        {
            ToolBoxUtils.MoveSelectedItem(sensorsListBox, ToolBoxUtils.DOWN);
        }

        // déplace le sensor selectionné vers le haut
        private void MoveSensorUpButton_Click(object sender, EventArgs e)
        {
            ToolBoxUtils.MoveSelectedItem(sensorsListBox, ToolBoxUtils.UP);
        }

        // ajoute un sensor a la liste des sensors a afficher
        private void AddSensorButton_Click(object sender, EventArgs e)
        {
            sensorsListBox.Items.Add(availableSensorsComboBox.SelectedItem);
            RefreshAvailableSensors();
            sensorsListBox.SelectedIndex = sensorsListBox.Items.Count - 1;
        }

        // remove sensor with keyboard
        private void SensorsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode.Equals(Keys.Delete)) && (sensorsListBox.SelectedItem != null))
            {
                sensorsListBox.Items.RemoveAt(sensorsListBox.SelectedIndex);
                RefreshAvailableSensors();
            }
        }

        // remove sensor with button
        private void DeleteSensorButton_Click(object sender, EventArgs e)
        {
            if (sensorsListBox.SelectedItem != null)
            {
                sensorsListBox.Items.RemoveAt(sensorsListBox.SelectedIndex);
                RefreshAvailableSensors();
            }
        }

        // active ou desactive les bouton "up"/"down"/"delete" selon l'item selectionné
        private void SensorsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteSensorButton.Enabled = (sensorsListBox.SelectedItem != null);
            moveSensorUpButton.Enabled = ToolBoxUtils.ManageUpDownButton(sensorsListBox, ToolBoxUtils.UP);
            moveSensorDownButton.Enabled = ToolBoxUtils.ManageUpDownButton(sensorsListBox, ToolBoxUtils.DOWN);
        }

        /* ----------------------------- */
        /* manage POP3 Location list box */
        /* ----------------------------- */
        private void EmptyPopLocationForm()
        {
            popServerTextBox.Text = "";
            popPortTextBox.Text = "110";
            popLoginTextBox.Text = "";
            popPasswordTextBox.Text = "";
        }

        private String ControlPopLocation()
        {
            String msg = null;

            if ("".Equals(popServerTextBox.Text))
            {
                msg = "You must enter a server url";
            }
            else if ("".Equals(popLoginTextBox.Text))
            {
                msg = "You must enter a login";
            }
            else if ("".Equals(popPasswordTextBox.Text))
            {
                msg = "You must enter a password";
            }

            return msg;
        }

        private void PopUpButton_Click(object sender, EventArgs e)
        {
            ToolBoxUtils.MoveSelectedItem(popListBox, ToolBoxUtils.UP);
        }

        private void PopDeleteButton_Click(object sender, EventArgs e)
        {
            if (popListBox.SelectedItem != null)
            {
                popListBox.Items.RemoveAt(popListBox.SelectedIndex);
            }
        }

        private void PopDownButton_Click(object sender, EventArgs e)
        {
            ToolBoxUtils.MoveSelectedItem(popListBox, ToolBoxUtils.DOWN);
        }

        private void PopAddButton_Click(object sender, EventArgs e)
        {
            String response = ControlPopLocation();
            if (response == null)
            {
                Location newLocation = new Location(popServerTextBox.Text + " on account " + popLoginTextBox.Text, XtreamToolbox.Location.POP3ACCOUNT, popServerTextBox.Text);
                newLocation.Parameters.Add("user", popLoginTextBox.Text);
                newLocation.Parameters.Add("password", popPasswordTextBox.Text);
                if (string.IsNullOrEmpty(popPortTextBox.Text))
                {
                    popPortTextBox.Text = "110";
                }
                newLocation.Parameters.Add("port", popPortTextBox.Text);
                popListBox.Items.Add(newLocation);
                EmptyPopLocationForm();
                popListBox.SelectedIndex = popListBox.Items.Count - 1;
            }
            else
            {
                MessageBox.Show(response);
            }
        }

        private void PopListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            popDeleteButton.Enabled = (popListBox.SelectedItem != null);
            popUpButton.Enabled = ToolBoxUtils.ManageUpDownButton(popListBox, ToolBoxUtils.UP);
            popDownButton.Enabled = ToolBoxUtils.ManageUpDownButton(popListBox, ToolBoxUtils.DOWN);
        }

        private void ProxyOnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            proxyUrlLabel.Enabled = proxyOnRadioButton.Checked;
            proxyUrlTextBox.Enabled = proxyOnRadioButton.Checked;

            proxyPortLabel.Enabled = proxyOnRadioButton.Checked;
            proxyPortTextBox.Enabled = proxyOnRadioButton.Checked;

            proxyUserLabel.Enabled = proxyOnRadioButton.Checked;
            proxyUserTextBox.Enabled = proxyOnRadioButton.Checked;

            proxyPasswordLabel.Enabled = proxyOnRadioButton.Checked;
            proxyPasswordTextBox.Enabled = proxyOnRadioButton.Checked;
        }

        private void SynchronizeButton_Click(object sender, EventArgs e)
        {
            if (!timeSyncBackgroundWorker.IsBusy)
            {
                timeSyncBackgroundWorker.RunWorkerAsync(timeServerComboBox.Text);
            }
        }

        // synchronize with selected time server
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            String retour = null;
            String timeServer = doWorkEventArgs.Argument.ToString();

            if (string.IsNullOrEmpty(timeServer))
            {
                retour = "you must choose a time server";
            }
            else
            {
                NTPClient client;
                try
                {
                    client = new NTPClient(timeServer);
                    client.Connect(true);
                }
                catch (Exception exception)
                {
                    retour = exception.Message;
                }
            }
            doWorkEventArgs.Result = retour;
        }

        private void TimeSyncBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                Properties.Settings.Default.timeLastSynch = DateTime.Now;
                Properties.Settings.Default.Save();
                timeLastSynchroDatetimeLabel.Text = String.Format("Success on {0}", DateTime.Now.ToString());
            }
            else
            {
                timeLastSynchroDatetimeLabel.Text = String.Format("Failed on {0}", DateTime.Now.ToString());
            }
        }

        private void BrowseEmailClientButton_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".exe";
            openFileDialog.Title = "Choose your default email client";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                emailClientTextBox.Text = openFileDialog.FileName;
            }
        }

        public void SetTimeLastSynchroDatetimeLabel(DateTime date)
        {
            timeLastSynchroDatetimeLabel.Text = String.Format("Success on {0}", date.ToString());
        }

        private void LanConnexionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            lanMaxBandwithTextBox.Enabled = (lanConnexionComboBox.SelectedIndex != 0);
        }

        private void InternetConnexionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            internetUploadTextBox.Enabled = (internetConnexionComboBox.SelectedIndex != 0);
            internetDownloadTextBox.Enabled = (internetConnexionComboBox.SelectedIndex != 0);
        }

        private void ExportOptionsButton_Click(object sender, EventArgs e)
        {
            exportOptionFileDialog.FileName = "XtreamToolbox_Configuration_" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".xml";
            if (exportOptionFileDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateSystemProperties();
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                String backupConfigFile = exportOptionFileDialog.FileName;
                String configFile = config.FilePath;

                // export options to file
                System.IO.File.Copy(configFile, backupConfigFile, true);
            }
        }

        private void ImportOptionsButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
                System.IO.File.Copy(openFileDialog.FileName, config.FilePath, true);
                Properties.Settings.Default.Reload();
                Initialisation();
            }
        }

        private void TextEditorPathBrowseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".exe";
            openFileDialog.Title = "Choose your prefered text editor";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                textEditorPathTextBox.Text = openFileDialog.FileName;
            }
        }
    }
}