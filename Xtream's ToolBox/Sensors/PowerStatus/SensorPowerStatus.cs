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
using XtreamToolbox.Utils;
using System.Globalization;

namespace XtreamToolbox.Sensors
{
    public partial class SensorPowerStatus : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorPowerStatus(Toolbox toolbox)
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

            // tooltips
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            ToolBoxUtils.SetTooltips(helpToolTip, this, resources.GetString("PowerStatus_Tips1", culture));
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);

            RefreshUI();
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            if (SystemInformation.PowerStatus.BatteryChargeStatus != BatteryChargeStatus.NoSystemBattery)
            {
                String batteryFullLifetime = "n/a";
                if (SystemInformation.PowerStatus.BatteryFullLifetime != -1)
                {
                    batteryFullLifetime = SystemUtils.GetFriendlyTimespan(SystemInformation.PowerStatus.BatteryFullLifetime, "auto");
                }
                String batteryLifeRemaining = "n/a";
                if (SystemInformation.PowerStatus.BatteryLifeRemaining != -1)
                {
                    batteryLifeRemaining = SystemUtils.GetFriendlyTimespan(SystemInformation.PowerStatus.BatteryLifeRemaining, "auto");
                }
                double batteryLifePercent = Math.Truncate(SystemInformation.PowerStatus.BatteryLifePercent * 100);
                ToolBoxUtils.SetTooltips(helpToolTip, this, String.Format(resources.GetString("PowerStatus_Tips2"), batteryFullLifetime, batteryLifeRemaining, batteryLifePercent));
            }

            switch (SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Offline:
                    // unplugged
                    switch ((int)Math.Truncate(SystemInformation.PowerStatus.BatteryLifePercent * 10))
                    {
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
                    switch ((int)Math.Truncate(SystemInformation.PowerStatus.BatteryLifePercent * 10))
                    {
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
        public void UpdateLocation()
        {
            // nothing to do on this sensor
        }

        // rafraichi le power status é chaque évenement lié é l'alimentation
        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            RefreshUI();
        }

        // Launch power managment configuration panel
        private void SensorPowerStatus_Click(object sender, EventArgs e)
        {
            String errMsg = SystemUtils.StartProcess(Environment.SystemDirectory + "\\powercfg.cpl", null, null);
            if (errMsg != null)
            {
                MessageBox.Show(errMsg);
            }
        }

        private void RefreshUiTimer_Tick(object sender, EventArgs e)
        {
            RefreshUI();
        }
    }
}
