using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Xtream_ToolBox {
    public partial class SensorSpacer : UserControl, ISensor {
        
        // reference on toolbox
        private ToolBox toolbox = null;

        // constructor
        public SensorSpacer(ToolBox toolbox) {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel() {
            return null;
        }

        // init UI
        public void InitUI() {
            // nothing to do on this sensor
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData() {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI() {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void UpdateLocation() {
            // nothing to do on this sensor
        }
    }
}
