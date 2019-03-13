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

namespace Xtream_ToolBox.Sensors
{
    public partial class SensorStorage : UserControl, ISensor
    {

        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour acc�der aux chaines localis�es
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private SensorStorageExtendedPanel extendedPanel = null;

        // constructor
        public SensorStorage(ToolBox toolbox)
        {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel()
        {
            return extendedPanel;
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

            if (!initialisationBackgroundWorker.IsBusy)
            {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            ToolBoxUtils.ManageExtendedPanelPosition(this, toolbox, extendedPanel);
        }

        private void SensorStorage_Click(object sender, EventArgs e)
        {
            if ((extendedPanel == null) || (extendedPanel.IsDisposed))
            {
                extendedPanel = new SensorStorageExtendedPanel(this);
                extendedPanel.Init();
            }

            if (extendedPanel.Visible)
            {
                extendedPanel.Hide();
            }
            else
            {
                ToolBoxUtils.ManageExtendedPanelPosition(this, toolbox, extendedPanel);
                extendedPanel.Init();                
                extendedPanel.Show();
            }
        }
    }
}
