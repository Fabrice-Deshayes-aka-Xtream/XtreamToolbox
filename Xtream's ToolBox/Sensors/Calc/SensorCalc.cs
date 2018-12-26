using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using Xtream_ToolBox.Utils;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorCalc : UserControl, ISensor {
                        
        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorCalc(ToolBox toolbox) {
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

            // tips
            helpToolTip.SetToolTip(this, resources.GetString("Calc_tip"));
            ToolBoxUtils.configureTooltips(helpToolTip);
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

        // open calc on click
        private void SensorCalc_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess("Calc", null, null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }
        }
    }
}
