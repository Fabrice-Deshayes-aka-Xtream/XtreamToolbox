using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using Xtream_ToolBox.Utils;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorMyComputer : UserControl, ISensor {
        
        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorMyComputer(ToolBox toolbox) {
            InitializeComponent();
            this.toolbox = toolbox;
            initUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form getExtendedPanel() {
            return null;
        }

        // init UI
        public void initUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // Tooltips
            helpToolTip.SetToolTip(this, String.Format(resources.GetString("MyComputer_tip"), Environment.NewLine));
            ToolBoxUtils.configureTooltips(helpToolTip);

            // cache les raccourcis non disponibles
            microsoftUpdateToolStripMenuItem.Visible = File.Exists(Environment.SystemDirectory + "\\muweb.dll");
            windowsUpdateToolStripMenuItem.Visible = File.Exists(Environment.SystemDirectory + "\\wupdmgr.exe") || File.Exists(Environment.SystemDirectory + "\\wuapp.exe");
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void initSensorData() {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void updateLocation() {
            // nothing to do on this sensor
        }

        private void systemPropertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\sysdm.cpl", null, null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }                        
        }

        private void microsoftUpdateToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\rundll32.exe", Environment.SystemDirectory + "\\muweb.dll,LaunchMUSite", null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }            
        }

        private void windowsUpdateToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = null;
            if (File.Exists(Environment.SystemDirectory + "\\wupdmgr.exe")){
                errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\wupdmgr.exe", null, null);
            } else if (File.Exists(Environment.SystemDirectory + "\\wuapp.exe")){
                errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\wuapp.exe", null, null);
            }
            
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }                        
        }

        private void microsoftManagmentConsoleMMCToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\compmgmt.msc", "/s", null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }
        }

        private void servicesManagementToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\services.msc", "/s", null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }
        }

        private void eventsViewerToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\eventvwr.msc", "/s", null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }
        }

        private void SensorMyComputer_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess("Explorer", "/N,::{20D04FE0-3AEA-1069-A2D8-08002B30309D}", null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }
        }

        private void openControlPanelToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess("Explorer", "/N,::{20D04FE0-3AEA-1069-A2D8-08002B30309D}\\::{21EC2020-3AEA-1069-A2DD-08002B30309D}", null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }
        }

        private void viewDisplayAndDesktopPropertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\desk.cpl", null, null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }                                    
        }

        private void addOrRemoveProgramToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\appwiz.cpl", null, null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }                                                
        }

        private void defraToolStripMenuItem_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\dfrg.msc", "/s", null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }            
        }
    }
}
