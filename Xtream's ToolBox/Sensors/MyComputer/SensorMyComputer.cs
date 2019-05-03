using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using XtreamToolbox.Utils;

namespace XtreamToolbox.Sensors
{
    public partial class SensorMyComputer : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorMyComputer(Toolbox toolbox)
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

        // init UI
        public void InitUI()
        {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // Tooltips
            helpToolTip.SetToolTip(this, String.Format(resources.GetString("MyComputer_tip"), Environment.NewLine));
            ToolBoxUtils.ConfigureTooltips(helpToolTip);
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
            // nothing to do on this sensor
        }

        private void SystemPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:about", null);
        }

        private void WindowsUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:windowsupdate", null);
        }

        private void MicrosoftManagmentConsoleMMCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess(Environment.SystemDirectory + "\\compmgmt.msc", "/s");
        }

        private void ServicesManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess(Environment.SystemDirectory + "\\services.msc", "/s");
        }

        private void EventsViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess(Environment.SystemDirectory + "\\eventvwr.msc", "/s");
        }

        private void SensorMyComputer_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:MyComputerFolder", null);
        }

        private void OpenControlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:ControlPanelFolder", null);
        }

        private void AddOrRemoveProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:ChangeRemoveProgramsFolder", null);
        }

        private void WindowsSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:", null);
        }

        private void MicrosoftStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-windows-store://home", null);
        }

        private void DisplaySettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:display", null);
        }

        private void PrintersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:printers", null);
        }

        private void OptionalFeaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:optionalfeatures", null); 
        }

        private void DefaultApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:defaultapps", null);
        }

        private void ApplicationLaunchedOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:startupapps", null);
        }

        private void ApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:appsfeatures", null);
        }

        private void SystemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("ms-settings:about", null);
        }
    }
}
