using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Specialized;
using XtreamToolbox.Sensors;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using XtreamToolbox.Utils;
using TimeSync;
using System.Resources;

namespace XtreamToolbox
{
    delegate void myDelegate();

    public partial class Toolbox : Form
    {

        /** déclaration des form utilisée par la toolbox */
        private About aboutBox = null;
        private OptionsForm optionsForm = null;
        private PhotosRenamerForm photosRenamerForm = null;
        private bool lastIsInternetConnected = false;


        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        public string Action { get; set; } = "";
        public bool InternetConnectionChangeState { get; set; } = false;
        public List<int> MagneticYPositions { get; } = new List<int>();
        public List<int> MagneticXPositions { get; } = new List<int>();

        // constructeur
        public Toolbox()
        {
            InitializeComponent();
            this.Opacity = 0;
            Initialisation();
        }

        // initialisations
        public void Initialisation()
        {
            this.Icon = Properties.Resources.icoHome;
            notifyIcon.Icon = Properties.Resources.icoHome;


            if (Properties.Settings.Default.firstLaunch)
            {
                Properties.Settings.Default.firstLaunch = false;
                Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2);
                Top = 0;
                SystemUtils.RunOnStart("Xtream's ToolBox", Environment.GetCommandLineArgs()[0], "add");
            }
            else
            {
                Left = Properties.Settings.Default.posX;
                Top = Properties.Settings.Default.posY;
                this.MinimumSize = new Size(Properties.Settings.Default.lastToolboxWidth, 48);
            }

            this.Text = resources.GetString("FormName_Toolbox", new CultureInfo(Properties.Settings.Default.language));

            if (Properties.Settings.Default.location == null)
            {
                Properties.Settings.Default.location = new StringCollection();
            }

            if (Properties.Settings.Default.sensors == null)
            {
                Properties.Settings.Default.sensors = new StringCollection
                {
                    "SensorKeyStatus",
                    "SensorSystemInfos",
                    "SensorSpacer",
                    "SensorPowerStatus",
                    "SensorStorage",
                    "SensorAnalogClock",
                    "SensorTimeIcalManager",
                    "SensorWeather",
                    "SensorSpacer",
                    "SensorCalc",
                    "SensorNotepad",
                    "SensorInbox",
                    "SensorSpacer",
                    "SensorFavoriteLocations",
                    "SensorMyComputer",
                    "SensorQuickLauncher",
                    "SensorSpacer",
                    "SensorRecycleBin",
                    "SensorShutdownManager"
                };
            }

            if (Properties.Settings.Default.sysInfosRefreshTime == 0)
            {
                Properties.Settings.Default.sysInfosRefreshTime = 250;
            }
            InitSensorContainer();
        }

        public void InitSensorContainer()
        {
            // construct the ToolBox
            TopMost = (Properties.Settings.Default.displayMode == 1);

            if (Properties.Settings.Default.useProxy)
            {
                System.Net.WebRequest.DefaultWebProxy = new System.Net.WebProxy(Properties.Settings.Default.proxyUrl, Properties.Settings.Default.proxyPort);
                if (Properties.Settings.Default.proxyUser.Length > 0)
                {
                    System.Net.WebRequest.DefaultWebProxy.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.proxyUser, Properties.Settings.Default.proxyPassword);
                }
            }

            if (Properties.Settings.Default.language == null)
            {
                Properties.Settings.Default.language = "fr-FR";
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);

            foreach (Control control in toolBoxFlowLayoutPanel.Controls)
            {
                control.Dispose();
            }
            toolBoxFlowLayoutPanel.Controls.Clear();
            toolBoxFlowLayoutPanel.Controls.Add(new ToolBoxStarter(this));

            foreach (String sensorName in Properties.Settings.Default.sensors)
            {
                ManageSensorInFlowPanel(toolBoxFlowLayoutPanel, sensorName);
            }
            toolBoxFlowLayoutPanel.Controls.Add(new ToolBoxEnder(this));
            this.MinimumSize = new Size(48, 48);
            initBackgroundWorker.RunWorkerAsync();
            Action = "fade in";
        }

        // quitte la toolbox
        private void QuiterLaToolBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // mémorise la largeur de la toolbox pour l'afficher dans la bonne taille lors de la prochaine ouverture
        private void ToolBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.lastToolboxWidth = this.Width;
            Properties.Settings.Default.Save();
        }

        // affiche la form a propos...
        private void AProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((aboutBox == null) || (aboutBox.IsDisposed))
            {
                aboutBox = new About();
            }

            aboutBox.Show();
            aboutBox.Activate();
        }

        // Affiche les options
        private void ContextMenu_options_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            Properties.Settings.Default.lastToolboxWidth = this.Width;
            Properties.Settings.Default.Save();

            if ((optionsForm == null) || (optionsForm.IsDisposed))
            {
                optionsForm = new OptionsForm(this);
                optionsForm.Initialisation();
            }

            optionsForm.Show();
            optionsForm.Activate();
        }

        private void PhotosRenamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);

            if ((photosRenamerForm != null) && (!photosRenamerForm.IsDisposed))
            {
                if (photosRenamerForm.WindowState == FormWindowState.Minimized)
                {
                    photosRenamerForm.WindowState = FormWindowState.Normal;
                    photosRenamerForm.Activate();
                }
                else
                {
                    photosRenamerForm.Show();
                }
            }
            else
            {
                photosRenamerForm = new PhotosRenamerForm();
                photosRenamerForm.Show();
            }
        }

        // repercute le mouvements sur les extended panels
        private void ToolBox_Move(object sender, EventArgs e)
        {
            foreach (Control control in toolBoxFlowLayoutPanel.Controls)
            {
                ((ISensor)control).UpdateLocation();
            }
        }

        private void AutoTimeSynchTimer_Tick(object sender, EventArgs e)
        {
            if (!timeSyncBackgroundWorker.IsBusy)
            {
                timeSyncBackgroundWorker.RunWorkerAsync(Properties.Settings.Default.timeServerUrl);
            }
        }

        // synchronize with selected time server
        private void TimeSyncBackgroundWorker_DoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            String retour = null;
            String timeServer = doWorkEventArgs.Argument.ToString();

            if (!string.IsNullOrEmpty(timeServer))
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
                if ((optionsForm != null) && (!optionsForm.IsDisposed))
                {
                    optionsForm.SetTimeLastSynchroDatetimeLabel(DateTime.Now);
                }
            }
        }

        private void InitBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // magnetic borders
            foreach (Screen currentScreen in Screen.AllScreens)
            {
                MagneticYPositions.Add(currentScreen.WorkingArea.Top);
                MagneticYPositions.Add(currentScreen.WorkingArea.Bottom);
                MagneticXPositions.Add(currentScreen.WorkingArea.Left);
                MagneticXPositions.Add(currentScreen.WorkingArea.Right);
                MagneticXPositions.Add(currentScreen.WorkingArea.Left + (currentScreen.WorkingArea.Width / 2));
                MagneticYPositions.Add(currentScreen.WorkingArea.Top + (currentScreen.WorkingArea.Height / 2));
            }

            autoTimeSynchTimer.Enabled = Properties.Settings.Default.timeAutoSynch;
            if ((autoTimeSynchTimer.Enabled) && (!timeSyncBackgroundWorker.IsBusy))
            {
                timeSyncBackgroundWorker.RunWorkerAsync(Properties.Settings.Default.timeServerUrl);
            }

            // mount network drives
            if (Properties.Settings.Default.nd1DriveLetter != null && !Properties.Settings.Default.nd1DriveLetter.Equals("none"))
            {
                SystemUtils.MountNetworkDrive(Properties.Settings.Default.nd1DriveLetter, Properties.Settings.Default.nd1Path);
            }
            if (Properties.Settings.Default.nd2DriveLetter != null && !Properties.Settings.Default.nd2DriveLetter.Equals("none"))
            {
                SystemUtils.MountNetworkDrive(Properties.Settings.Default.nd2DriveLetter, Properties.Settings.Default.nd2Path);
            }
            if (Properties.Settings.Default.nd3DriveLetter != null && !Properties.Settings.Default.nd3DriveLetter.Equals("none"))
            {
                SystemUtils.MountNetworkDrive(Properties.Settings.Default.nd3DriveLetter, Properties.Settings.Default.nd3Path);
            }

            Properties.Settings.Default.Save();
        }

        private void ActionTimer_Tick(object sender, EventArgs e)
        {
            if (Action == "fade in")
            {
                for (double i = 0; i <= Properties.Settings.Default.opacity; i += 0.1)
                {
                    this.Opacity = i;
                    Thread.Sleep(100);
                }
                Action = "";
            }
            else if (Action == "relaunch")
            {
                notifyIcon.Dispose();
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void ManageSensorInFlowPanel(FlowLayoutPanel toolBoxFlowLayoutPanel, String sensorName)
        {
            switch (sensorName)
            {
                case "SensorSystemInfos":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorSystemInfos(this));
                    break;
                case "SensorFavoriteLocations":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorFavoriteLocations(this));
                    break;
                case "SensorQuickLauncher":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorQuickLauncher(this));
                    break;
                case "SensorRecycleBin":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorRecycleBin(this));
                    break;
                case "SensorShutdownManager":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorShutdownManager(this));
                    break;
                case "SensorSpacer":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorSpacer(this));
                    break;
                case "SensorPowerStatus":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorPowerStatus(this));
                    break;
                case "SensorTimeIcalManager":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorTimeIcalManager(this));
                    break;
                case "SensorNotepad":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorNotepad(this));
                    break;
                case "SensorWeather":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorWeather(this));
                    break;
                case "SensorMyComputer":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorMyComputer(this));
                    break;
                case "SensorCalc":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorCalc(this));
                    break;
                case "SensorKeyStatus":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorKeyStatus(this));
                    break;
                case "SensorInbox":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorInbox(this));
                    break;
                case "SensorStorage":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorStorage(this));
                    break;
                case "SensorAnalogClock":
                    toolBoxFlowLayoutPanel.Controls.Add(new SensorAnalogClock(this));
                    break;
            }
        }

        private void NetworkDetectorTimer_Tick(object sender, EventArgs e)
        {
            bool isInternetConnected = SystemUtils.IsInternetConnected();
            if (!isInternetConnected.Equals(lastIsInternetConnected))
            {
                lastIsInternetConnected = isInternetConnected;
                if (isInternetConnected)
                {
                    // on vient de récupérer la connection internet, on rafraichi certain sensors
                    ISensor currentSensor;
                    foreach (Control sensor in toolBoxFlowLayoutPanel.Controls)
                    {
                        currentSensor = (ISensor)sensor;
                        if (
                            (currentSensor.GetType().ToString().EndsWith("SensorInbox")) ||
                            (currentSensor.GetType().ToString().EndsWith("SensorWeather")) ||
                            (currentSensor.GetType().ToString().EndsWith("SensorTimeIcalManager"))
                            )
                        {
                            currentSensor.InitUI();
                        }
                    }
                }
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.SuspendLayout();
                foreach (Control sensor in toolBoxFlowLayoutPanel.Controls)
                {
                    ISensor currentSensor;
                    currentSensor = (ISensor)sensor;
                    if ((currentSensor.GetExtendedPanel() != null) && (currentSensor.GetExtendedPanel().Visible == true))
                    {
                        currentSensor.GetExtendedPanel().Activate();
                    }
                }

                this.Activate();
                this.ResumeLayout();
            }
        }
    }
}