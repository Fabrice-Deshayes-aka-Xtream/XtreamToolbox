using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Resources;
using Xtream_ToolBox.Utils;
using System.Runtime.InteropServices;
using Xtream_ToolBox.Sensors;

namespace Xtream_ToolBox {
    public partial class SensorSystemInfosMore : Form {

        private SensorSystemInfos sensorSystemInfos = null;
        

        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        // Consrtructeur
        public SensorSystemInfosMore(SensorSystemInfos psensorSystemInfos) {
            InitializeComponent();
            ToolBoxUtils.configureTooltips(helpToolTip);
            this.Text = resources.GetString("FormName_SysInfos");
            SystemUtils.hideFromAltTab(this);
            sensorSystemInfos = psensorSystemInfos;
        }

        // initialisation (one shot)
        public void initialisation(){
            if (sensorSystemInfos.systemInformations != null) {
                osLabel1.Text = String.Format(resources.GetString("SysInfos_01"), sensorSystemInfos.systemInformations.osCaption, Environment.OSVersion.ServicePack);
                osLabel3.Text = String.Format(resources.GetString("SysInfos_02"), sensorSystemInfos.systemInformations.osSerialNumber);

                procRamLabel1.Text = String.Format(resources.GetString("SysInfos_03"), sensorSystemInfos.systemInformations.processorManufacturer, sensorSystemInfos.systemInformations.processorCaption);
                procRamLabel4.Text = String.Format(resources.GetString("SysInfos_04"), SystemUtils.getFriendlyBytesSize(sensorSystemInfos.systemInformations.memoryTotalPageFileSpace, "auto"));

                netUserLabel1.Text = String.Format(resources.GetString("SysInfos_05"), sensorSystemInfos.systemInformations.computerUserName, sensorSystemInfos.systemInformations.computerMachineName);
                netUserLabel2.Text = String.Format(resources.GetString("SysInfos_06"), sensorSystemInfos.systemInformations.networkLocalIpAdresse, sensorSystemInfos.systemInformations.computerDomain);
                netUserLabel3.Text = String.Format(resources.GetString("SysInfos_06_v6"), sensorSystemInfos.systemInformations.networkLocalIpAdresseV6);
                netUserLabel4.Text = String.Format(resources.GetString("SysInfos_07"), sensorSystemInfos.systemInformations.networkConnectionType, (sensorSystemInfos.systemInformations.networkConnectionSpeed / 1000000));

                cgLabel1.Text = String.Format(resources.GetString("SysInfos_08"), sensorSystemInfos.systemInformations.videoControllerName, SystemUtils.getFriendlyBytesSize(sensorSystemInfos.systemInformations.videoControllerRam, "auto"));
                cgLabel2.Text = String.Format(resources.GetString("SysInfos_09"), sensorSystemInfos.systemInformations.displayNbScreen);

                if (sensorSystemInfos.systemInformations.displaySecondaryScreenInfos.Equals("")) {
                    cgLabel3.Text = String.Format(resources.GetString("SysInfos_10"), sensorSystemInfos.systemInformations.displayPrimaryScreenInfos);
                }
                else {
                    cgLabel3.Text = String.Format(resources.GetString("SysInfos_10"), sensorSystemInfos.systemInformations.displayPrimaryScreenInfos) + " / " + String.Format(resources.GetString("SysInfos_11"), sensorSystemInfos.systemInformations.displaySecondaryScreenInfos);
                }

                biosLabel1.Text = sensorSystemInfos.systemInformations.biosCaption;
                biosLabel2.Text = String.Format(resources.GetString("SysInfos_12"), sensorSystemInfos.systemInformations.biosVersion);
            }
        }

        // initialisation des infos volatiles
        public void refreshSystemInformation(String ramUsedStr, String cpuUsedStr, String processAndThreadStr) {
            if (sensorSystemInfos.systemInformations != null) {
                
                procRamLabel5.Text = processAndThreadStr;
                procRamLabel3.Text = String.Format(resources.GetString("SysInfos_14"), ramUsedStr);
                procRamLabel2.Text = String.Format(resources.GetString("SysInfos_15"), SystemUtils.formatSpeedInHertz(Convert.ToInt64(sensorSystemInfos.systemInformations.processorMaxClockSpeed)), cpuUsedStr);

                TimeSpan timespan = TimeSpan.FromMilliseconds(Environment.TickCount);
                osLabel2.Text = String.Format(resources.GetString("SysInfos_16"), sensorSystemInfos.systemInformations.osInstallDate.ToString(resources.GetString("SysInfos_InstalleDateFormat")), timespan.Hours.ToString().PadLeft(2, '0'), timespan.Minutes.ToString().PadLeft(2, '0'), timespan.Seconds.ToString().PadLeft(2, '0'));
            }
        }

        // cache le paneau d'extension
        private void closeExtendedInfosPictureBox_Click(object sender, EventArgs e) {
            Hide();
        }
   }
}