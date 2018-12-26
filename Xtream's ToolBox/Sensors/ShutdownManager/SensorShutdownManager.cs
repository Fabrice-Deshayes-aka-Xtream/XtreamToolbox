using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using Xtream_ToolBox.Utils;
using Xtream_ToolBox.Sensors.ShutdownManager;

namespace Xtream_ToolBox {
    public partial class SensorShutdownManager : UserControl, ISensor {

        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private ShutdownOptions shutdownOptions = new ShutdownOptions();

        // constructor
        public SensorShutdownManager(ToolBox toolbox) {
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

            // Tooltips
            helpToolTip.SetToolTip(upperButton, String.Format(resources.GetString("ShutdownManager_Tip"), Environment.NewLine));
            helpToolTip.SetToolTip(lowerButton, String.Format(resources.GetString("ShutdownManager_Tip"), Environment.NewLine));
            ToolBoxUtils.configureTooltips(helpToolTip);

            switch (Properties.Settings.Default.shutdownManagerDefaultActionUpperButton) {
                case ShutdownOptions.SHUTDOWN:
                    upperButton.Image = Properties.Resources.shutdownManager_shutdown;
                    break;
                case ShutdownOptions.RESTART:
                    upperButton.Image = Properties.Resources.shutdownManager_restart;
                    break;
                case ShutdownOptions.HIBERNATE:
                    upperButton.Image = Properties.Resources.shutdownManager_hibernate;
                    break;
                case ShutdownOptions.LOGOFF:
                    upperButton.Image = Properties.Resources.shutdownManager_logoff;
                    break;
                case ShutdownOptions.LOCK:
                    upperButton.Image = Properties.Resources.shutdownManager_lock;
                    break;
                case ShutdownOptions.SWITCH_USER:
                    upperButton.Image = Properties.Resources.shutdownManager_switch_user;
                    break;
            }

            switch (Properties.Settings.Default.shutdownManagerDefaultActionLowerButton) {
                case ShutdownOptions.SHUTDOWN:
                    lowerButton.Image = Properties.Resources.shutdownManager_shutdown;
                    break;
                case ShutdownOptions.RESTART:
                    lowerButton.Image = Properties.Resources.shutdownManager_restart;
                    break;
                case ShutdownOptions.HIBERNATE:
                    lowerButton.Image = Properties.Resources.shutdownManager_hibernate;
                    break;
                case ShutdownOptions.LOGOFF:
                    lowerButton.Image = Properties.Resources.shutdownManager_logoff;
                    break;
                case ShutdownOptions.LOCK:
                    lowerButton.Image = Properties.Resources.shutdownManager_lock;
                    break;
                case ShutdownOptions.SWITCH_USER:
                    lowerButton.Image = Properties.Resources.shutdownManager_switch_user;
                    break;
            }
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

        private void UpperButton_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Left)) {
                if (!Properties.Settings.Default.shutdownManagerLowerActionConfirmation) {
                    shutdownOptions.doAction(Properties.Settings.Default.shutdownManagerDefaultActionUpperButton, true);
                }
                else {
                    shutdownOptions.doAction(Properties.Settings.Default.shutdownManagerDefaultActionUpperButton, false);
                }
            }
            else if (e.Button.Equals(MouseButtons.Right)) {
                // display menu for other or timed actions
                shutdownOptions.ShowDialog();
            }
        }

        private void LowerButton_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button.Equals(MouseButtons.Left)) {
                if (!Properties.Settings.Default.shutdownManagerUpperActionConfirmation) {
                    shutdownOptions.doAction(Properties.Settings.Default.shutdownManagerDefaultActionLowerButton, true);
                }
                else {
                    shutdownOptions.doAction(Properties.Settings.Default.shutdownManagerDefaultActionLowerButton, false);
                }
            }
            else if (e.Button.Equals(MouseButtons.Right)) {
                shutdownOptions.Show();
            }
        }
    }
}
