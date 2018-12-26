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
using Xtream_ToolBox.Sensors;
using System.Drawing.Imaging;
using System.Globalization;
using System.Threading;
using Xtream_ToolBox.Utils;
using TimeSync;
using System.Resources;

namespace Xtream_ToolBox {
    delegate void myDelegate();

    public partial class ToolBox : Form {

        /** d�claration des form utilis�e par la toolbox */
        private About aboutBox = null;
        private OptionsForm optionsForm = null;
        private PhotosRenamerForm photosRenamerForm = null;
        public List<int> magneticXPositions = new List<int>();
        public List<int> magneticYPositions = new List<int>();
        public String action = "";
        private bool lastIsInternetConnected = false;
        public bool internetConnectionChangeState = false;


        // ressource manager pour acc�der aux chaines localis�es
        ResourceManager resources = Properties.Resources.ResourceManager;

        // constructeur
        public ToolBox() {
            InitializeComponent();
            this.Opacity = 0;
            Initialisation();
        }

        // initialisations
        public void Initialisation() {
            this.Icon = Properties.Resources.icoHome;
            notifyIcon.Icon = Properties.Resources.icoHome;


            if (Properties.Settings.Default.firstLaunch) {
                Properties.Settings.Default.firstLaunch = false;
                Left = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (Width / 2);
                Top = 0;
                SystemUtils.RunOnStart("Xtream's ToolBox", Environment.GetCommandLineArgs()[0], "add");
            }
            else {
                Left = Properties.Settings.Default.posX;
                Top = Properties.Settings.Default.posY;
                this.MinimumSize = new Size(Properties.Settings.Default.lastToolboxWidth, 48);
            }

            this.Text = resources.GetString("FormName_Toolbox");

            if (Properties.Settings.Default.location == null) {
                Properties.Settings.Default.location = new StringCollection();
            }

            if (Properties.Settings.Default.sensors == null) {
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

            if (Properties.Settings.Default.sysInfosRefreshTime == 0) {
                Properties.Settings.Default.sysInfosRefreshTime = 250;
            }
            InitSensorContainer();
        }

        public void InitSensorContainer() {
            // construct the ToolBox
            TopMost = (Properties.Settings.Default.displayMode == 1);

            if (Properties.Settings.Default.useProxy) {
                System.Net.WebRequest.DefaultWebProxy = new System.Net.WebProxy(Properties.Settings.Default.proxyUrl, Properties.Settings.Default.proxyPort);
                if (Properties.Settings.Default.proxyUser.Length > 0) {
                    System.Net.WebRequest.DefaultWebProxy.Credentials = new System.Net.NetworkCredential(Properties.Settings.Default.proxyUser, Properties.Settings.Default.proxyPassword);
                }
            }

            if (Properties.Settings.Default.language == null) {
                Properties.Settings.Default.language = "fr-FR";
            }
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);

            foreach (Control control in toolBoxFlowLayoutPanel.Controls) {
                control.Dispose();
            }
            toolBoxFlowLayoutPanel.Controls.Clear();
            toolBoxFlowLayoutPanel.Controls.Add(new ToolBoxStarter(this));

            foreach (String sensorName in Properties.Settings.Default.sensors) {
                ManageSensorInFlowPanel(toolBoxFlowLayoutPanel, sensorName);
            }
            toolBoxFlowLayoutPanel.Controls.Add(new ToolBoxEnder(this));
            this.MinimumSize = new Size(48, 48);
            initBackgroundWorker.RunWorkerAsync();
            action = "fade in";
        }

        // quitte la toolbox
        private void QuiterLaToolBoxToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        // m�morise la largeur de la toolbox pour l'afficher dans la bonne taille lors de la prochaine ouverture
        private void ToolBox_FormClosing(object sender, FormClosingEventArgs e) {
            Properties.Settings.Default.lastToolboxWidth = this.Width;
            Properties.Settings.Default.Save();
        }

        // affiche la form a propos...
        private void AProposToolStripMenuItem_Click(object sender, EventArgs e) {
            if ((aboutBox == null) || (aboutBox.IsDisposed)) {
                aboutBox = new About();
            }

            aboutBox.Show();
            aboutBox.Activate();
        }

        // Affiche les options
        private void ContextMenu_options_Click(object sender, EventArgs e) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            Properties.Settings.Default.lastToolboxWidth = this.Width;
            Properties.Settings.Default.Save();

            if ((optionsForm == null) || (optionsForm.IsDisposed)) {
                optionsForm = new OptionsForm(this);
                optionsForm.Initialisation();
            }

            optionsForm.Show();
            optionsForm.Activate();
        }

        private void PhotosRenamerToolStripMenuItem_Click(object sender, EventArgs e) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);

            if ((photosRenamerForm != null) && (!photosRenamerForm.IsDisposed)) {
                if (photosRenamerForm.WindowState == FormWindowState.Minimized) {
                    photosRenamerForm.WindowState = FormWindowState.Normal;
                    photosRenamerForm.Activate();
                }
                else {
                    photosRenamerForm.Show();
                }
            }
            else {
                photosRenamerForm = new PhotosRenamerForm();
                photosRenamerForm.Show();
            }
        }

        // repercute le mouvements sur les extended panels
        private void ToolBox_Move(object sender, EventArgs e) {
            foreach (Control control in toolBoxFlowLayoutPanel.Controls) {
                ((ISensor)control).updateLocation();
            }
        }

        private void AutoTimeSynchTimer_Tick(object sender, EventArgs e) {
            if (!timeSyncBackgroundWorker.IsBusy) {
                timeSyncBackgroundWorker.RunWorkerAsync(Properties.Settings.Default.timeServerUrl);
            }
        }

        // synchronize with selected time server
        private void TimeSyncBackgroundWorker_DoWork(object sender, DoWorkEventArgs doWorkEventArgs) {
            String retour = null;
            String timeServer = doWorkEventArgs.Argument.ToString();

            if ((timeServer != null) && (!timeServer.Equals(""))) {
                NTPClient client;
                try {
                    client = new NTPClient(timeServer);
                    client.Connect(true);
                }
                catch (Exception exception) {
                    retour = exception.Message;
                }
            }
            doWorkEventArgs.Result = retour;
        }

        private void TimeSyncBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Result == null) {
                Properties.Settings.Default.timeLastSynch = DateTime.Now;
                Properties.Settings.Default.Save();
                if ((optionsForm != null) && (!optionsForm.IsDisposed)) {
                    optionsForm.SetTimeLastSynchroDatetimeLabel(DateTime.Now);
                }
            }
        }

        private void InitBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            // magnetic borders
            foreach (Screen currentScreen in Screen.AllScreens) {
                magneticYPositions.Add(currentScreen.WorkingArea.Top);
                magneticYPositions.Add(currentScreen.WorkingArea.Bottom);
                magneticXPositions.Add(currentScreen.WorkingArea.Left);
                magneticXPositions.Add(currentScreen.WorkingArea.Right);
                magneticXPositions.Add(currentScreen.WorkingArea.Left + (currentScreen.WorkingArea.Width / 2));
                magneticYPositions.Add(currentScreen.WorkingArea.Top + (currentScreen.WorkingArea.Height / 2));
            }

            autoTimeSynchTimer.Enabled = Properties.Settings.Default.timeAutoSynch;
            if ((autoTimeSynchTimer.Enabled) && (!timeSyncBackgroundWorker.IsBusy)) {
                timeSyncBackgroundWorker.RunWorkerAsync(Properties.Settings.Default.timeServerUrl);
            }

            // mount network drives
            if (Properties.Settings.Default.nd1DriveLetter != null && !Properties.Settings.Default.nd1DriveLetter.Equals("none")) {
                SystemUtils.mountNetworkDrive(Properties.Settings.Default.nd1DriveLetter, Properties.Settings.Default.nd1Path);
            }
            if (Properties.Settings.Default.nd2DriveLetter != null && !Properties.Settings.Default.nd2DriveLetter.Equals("none")) {
                SystemUtils.mountNetworkDrive(Properties.Settings.Default.nd2DriveLetter, Properties.Settings.Default.nd2Path);
            }
            if (Properties.Settings.Default.nd3DriveLetter != null && !Properties.Settings.Default.nd3DriveLetter.Equals("none")) {
                SystemUtils.mountNetworkDrive(Properties.Settings.Default.nd3DriveLetter, Properties.Settings.Default.nd3Path);
            }

            Properties.Settings.Default.Save();
        }

        private void ActionTimer_Tick(object sender, EventArgs e) {
            if (action == "fade in") {
                for (double i = 0; i <= Properties.Settings.Default.opacity; i += 0.1) {
                    this.Opacity = i;
                    Thread.Sleep(100);
                }
                action = "";
            }
            else if (action == "relaunch") {
                toolBoxFlowLayoutPanel.SuspendLayout();
                List<Control> sensors = new List<Control>();
                foreach (Control sensor in toolBoxFlowLayoutPanel.Controls) {
                    sensors.Add(sensor);
                }
                toolBoxFlowLayoutPanel.Controls.Clear();

                toolBoxFlowLayoutPanel.Controls.Add(new ToolBoxStarter(this));
                foreach (String sensorName in Properties.Settings.Default.sensors) {
                    bool found = false;
                    // reinject sensors which was there before at their new position
                    foreach (Control sensor in sensors) {
                        if (sensor.GetType().ToString().EndsWith(sensorName)) {
                            toolBoxFlowLayoutPanel.Controls.Add(sensor);
                            ((ISensor)sensor).initUI();
                            sensors.Remove(sensor);
                            found = true;
                            break;
                        }
                    }
                    // add new sensor
                    if (!found) {
                        ManageSensorInFlowPanel(toolBoxFlowLayoutPanel, sensorName);
                    }
                }
                toolBoxFlowLayoutPanel.Controls.Add(new ToolBoxEnder(this));
                toolBoxFlowLayoutPanel.ResumeLayout();
                action = "";
            }
        }

        private void ManageSensorInFlowPanel(FlowLayoutPanel toolBoxFlowLayoutPanel, String sensorName) {
            switch (sensorName) {
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

        private void NetworkDetectorTimer_Tick(object sender, EventArgs e) {
            bool isInternetConnected = SystemUtils.IsInternetConnected();
            if (!isInternetConnected.Equals(lastIsInternetConnected)) {
                lastIsInternetConnected = isInternetConnected;
                if (isInternetConnected) {
                    // on vient de r�cup�rer la connection internet, on rafraichi certain sensors
                    ISensor currentSensor;
                    foreach (Control sensor in toolBoxFlowLayoutPanel.Controls) {
                        currentSensor = (ISensor)sensor;
                        if (
                            (currentSensor.GetType().ToString().EndsWith("SensorInbox")) ||
                            (currentSensor.GetType().ToString().EndsWith("SensorWeather")) ||
                            (currentSensor.GetType().ToString().EndsWith("SensorTimeIcalManager"))
                            ) {
                            currentSensor.initUI();
                        }
                    }
                }
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                this.SuspendLayout();
                foreach (Control sensor in toolBoxFlowLayoutPanel.Controls) {
                    ISensor currentSensor;
                    currentSensor = (ISensor)sensor;
                    if ((currentSensor.getExtendedPanel() != null) && (currentSensor.getExtendedPanel().Visible == true)) {
                        currentSensor.getExtendedPanel().Activate();
                    }
                }

                this.Activate();
                this.ResumeLayout();
            }
        }
    }
}