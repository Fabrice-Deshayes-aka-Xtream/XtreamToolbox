using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Reflection;
using System.Resources;
using Xtream_ToolBox.Utils;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorPowerStatus : UserControl, ISensor {
        
        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour acc�der aux chaines localis�es
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorPowerStatus(ToolBox toolbox) {
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

            // tooltips
            ToolBoxUtils.setTooltips(helpToolTip, this, resources.GetString("PowerStatus_Tips1"));
            ToolBoxUtils.configureTooltips(helpToolTip);

            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            refreshUI();
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void initSensorData() {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
            if (SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery) {
                String batteryFullLifetime = "n/a";
                if (SystemInformation.PowerStatus.BatteryFullLifetime!=-1) {
                    batteryFullLifetime = SystemUtils.getFriendlyTimespan(SystemInformation.PowerStatus.BatteryFullLifetime, "auto");
                }
                String batteryLifeRemaining = "n/a";
                if (SystemInformation.PowerStatus.BatteryLifeRemaining!=-1) {
                    batteryLifeRemaining = SystemUtils.getFriendlyTimespan(SystemInformation.PowerStatus.BatteryLifeRemaining, "auto");
                }
                double batteryLifePercent = Math.Truncate(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                ToolBoxUtils.setTooltips(helpToolTip, this, String.Format(resources.GetString("PowerStatus_Tips2"), batteryFullLifetime, batteryLifeRemaining, batteryLifePercent, Environment.NewLine));
            }

            switch (SystemInformation.PowerStatus.PowerLineStatus) {
                case PowerLineStatus.Offline:
                    // unplugged
                    switch ((int)Math.Truncate(SystemInformation.PowerStatus.BatteryLifePercent * 10)) {
                        case 0:
                            this.BackgroundImage = Properties.Resources.battery_0;
                            break;
                        case 1:
                            this.BackgroundImage = Properties.Resources.battery_1;
                            break;
                        case 2:
                            this.BackgroundImage = Properties.Resources.battery_2;
                            break;
                        case 3:
                            this.BackgroundImage = Properties.Resources.battery_3;
                            break;
                        case 4:
                            this.BackgroundImage = Properties.Resources.battery_4;
                            break;
                        case 5:
                            this.BackgroundImage = Properties.Resources.battery_5;
                            break;
                        case 6:
                            this.BackgroundImage = Properties.Resources.battery_6;
                            break;
                        case 7:
                            this.BackgroundImage = Properties.Resources.battery_7;
                            break;
                        default:
                            this.BackgroundImage = Properties.Resources.battery_8;
                            break;
                    }
                    break;
                case PowerLineStatus.Online:
                    // plugged
                    switch ((int)Math.Truncate(SystemInformation.PowerStatus.BatteryLifePercent * 10)) {
                        case 0:
                            this.BackgroundImage = Properties.Resources.battery_c0;
                            break;
                        case 1:
                            this.BackgroundImage = Properties.Resources.battery_c1;
                            break;
                        case 2:
                            this.BackgroundImage = Properties.Resources.battery_c2;
                            break;
                        case 3:
                            this.BackgroundImage = Properties.Resources.battery_c3;
                            break;
                        case 4:
                            this.BackgroundImage = Properties.Resources.battery_c4;
                            break;
                        case 5:
                            this.BackgroundImage = Properties.Resources.battery_c5;
                            break;
                        case 6:
                            this.BackgroundImage = Properties.Resources.battery_c6;
                            break;
                        case 7:
                            this.BackgroundImage = Properties.Resources.battery_c7;
                            break;
                        case 8:
                            this.BackgroundImage = Properties.Resources.battery_c8;
                            break;
                        default:
                            this.BackgroundImage = Properties.Resources.battery_charged;
                            break;
                    }
                    break;
                default:
                    // unknow
                    this.BackgroundImage = Properties.Resources.battery_na;
                    break;
            }
        }

        // update location of extended panel if needed
        public void updateLocation() {
            // nothing to do on this sensor
        }

        // rafraichi le power status � chaque �venement li� � l'alimentation
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e) {
            refreshUI();
        }

        // Launch power managment configuration panel
        private void SensorPowerStatus_Click(object sender, EventArgs e) {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\powercfg.cpl", null, null);
            if (errMsg != null) {
                MessageBox.Show(errMsg);
            }                                    
        }
    }
}
