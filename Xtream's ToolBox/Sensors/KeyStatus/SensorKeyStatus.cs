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
    public partial class SensorKeyStatus : UserControl, ISensor {
        
        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorKeyStatus(ToolBox toolbox) {
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
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // Tips
            helpToolTip.SetToolTip(capsLockStatusPictureBoxON, resources.GetString("KeyStatus_Caps_ON"));
            helpToolTip.SetToolTip(capsLockStatusPictureBoxOFF, resources.GetString("KeyStatus_Caps_OFF"));
            helpToolTip.SetToolTip(numLockStatusPictureBoxON, resources.GetString("KeyStatus_Num_ON"));
            helpToolTip.SetToolTip(numLockStatusPictureBoxOFF, resources.GetString("KeyStatus_Num_OFF"));
            ToolBoxUtils.ConfigureTooltips(helpToolTip);
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

        private void updateKeyStatusTimer_Tick(object sender, EventArgs e) {
            updateKeyStatus();
        }

        private void updateKeyStatus() {
            capsLockStatusPictureBoxON.Visible = SystemUtils.IsKeyPressedOrToggleOn(Keys.CapsLock);
            capsLockStatusPictureBoxOFF.Visible = !capsLockStatusPictureBoxON.Visible;

            numLockStatusPictureBoxON.Visible = SystemUtils.IsKeyPressedOrToggleOn(Keys.NumLock);
            numLockStatusPictureBoxOFF.Visible = !numLockStatusPictureBoxON.Visible;
        }
    }
}
