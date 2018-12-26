using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Threading;
using System.Globalization;
using Xtream_ToolBox.Utils;
using System.IO;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorStorage : UserControl, ISensor {

        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private SensorStorageExtendedPanel extendedPanel = null;

        public DriveInfo[] allDrives = null;

        // constructor
        public SensorStorage(ToolBox toolbox) {
            InitializeComponent();
            this.toolbox = toolbox;
            initUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form getExtendedPanel() {
            return extendedPanel;
        }

        // init sensor data in asynch mode
        private void initialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            initSensorData();
        }

        // after init sensor data, refresh ui
        private void initialisationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            refreshUI();
        }

        // init UI
        public void initUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // tips
            ToolBoxUtils.configureTooltips(helpToolTip);

            if (!initialisationBackgroundWorker.IsBusy) {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void initSensorData() {
            allDrives = DriveInfo.GetDrives();
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void updateLocation() {
            ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
        }

        private void SensorStorage_Click(object sender, EventArgs e) {
            if ((extendedPanel == null) || (extendedPanel.IsDisposed)) {
                extendedPanel = new SensorStorageExtendedPanel(this);
                extendedPanel.init();
            }

            if (extendedPanel.Visible) {
                extendedPanel.Hide();
            } else {
                ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
                extendedPanel.Show();
            }
        }
    }
}
