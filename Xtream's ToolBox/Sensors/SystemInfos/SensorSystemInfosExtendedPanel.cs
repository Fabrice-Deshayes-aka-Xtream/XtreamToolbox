using Microsoft.Win32;
using System;
using System.Resources;
using System.Windows.Forms;
using XtreamToolbox.Sensors;
using XtreamToolbox.Utils;

namespace XtreamToolbox
{
    public partial class SensorSystemInfosMore : Form
    {

        private SensorSystemInfos sensorSystemInfos = null;


        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        // Consrtructeur
        public SensorSystemInfosMore(SensorSystemInfos psensorSystemInfos)
        {
            InitializeComponent();
            ToolBoxUtils.ConfigureTooltips(helpToolTip);
            this.Text = resources.GetString("FormName_SysInfos");
            SystemUtils.HideFromAltTab(this);
            sensorSystemInfos = psensorSystemInfos;
        }

        // initialisation (one shot)
        public void Initialisation()
        {
            if (sensorSystemInfos.SystemInformations != null)
            {
                string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "").ToString();

                osLabel1.Text = String.Format(resources.GetString("SysInfos_01"), sensorSystemInfos.SystemInformations.OsCaption, releaseId);
                osLabel3.Text = String.Format(resources.GetString("SysInfos_02"), sensorSystemInfos.SystemInformations.OsSerialNumber);

                procRamLabel1.Text = String.Format(resources.GetString("SysInfos_03"), sensorSystemInfos.SystemInformations.ProcessorManufacturer, sensorSystemInfos.SystemInformations.ProcessorCaption);
                procRamLabel4.Text = String.Format(resources.GetString("SysInfos_04"), SystemUtils.GetFriendlyBytesSize(sensorSystemInfos.SystemInformations.MemoryTotalPageFileSpace, "auto"));

                netUserLabel1.Text = String.Format(resources.GetString("SysInfos_05"), sensorSystemInfos.SystemInformations.ComputerUserName, sensorSystemInfos.SystemInformations.ComputerMachineName);
                netUserLabel2.Text = String.Format(resources.GetString("SysInfos_06"), sensorSystemInfos.SystemInformations.NetworkLocalIpAdresse, sensorSystemInfos.SystemInformations.ComputerDomain);
                netUserLabel3.Text = String.Format(resources.GetString("SysInfos_06_v6"), sensorSystemInfos.SystemInformations.NetworkLocalIpAdresseV6);
                netUserLabel4.Text = String.Format(resources.GetString("SysInfos_07"), sensorSystemInfos.SystemInformations.NetworkConnectionType, (sensorSystemInfos.SystemInformations.NetworkConnectionSpeed / 1000000));

                cgLabel1.Text = String.Format(resources.GetString("SysInfos_08"), sensorSystemInfos.SystemInformations.VideoControllerName, SystemUtils.GetFriendlyBytesSize(sensorSystemInfos.SystemInformations.VideoControllerRam, "auto"));
                cgLabel2.Text = String.Format(resources.GetString("SysInfos_09"), sensorSystemInfos.SystemInformations.DisplayNbScreen);

                if (string.IsNullOrEmpty(sensorSystemInfos.SystemInformations.DisplaySecondaryScreenInfos))
                {
                    cgLabel3.Text = String.Format(resources.GetString("SysInfos_10"), sensorSystemInfos.SystemInformations.DisplayPrimaryScreenInfos);
                }
                else
                {
                    cgLabel3.Text = String.Format(resources.GetString("SysInfos_10"), sensorSystemInfos.SystemInformations.DisplayPrimaryScreenInfos) + " / " + String.Format(resources.GetString("SysInfos_11"), sensorSystemInfos.SystemInformations.DisplaySecondaryScreenInfos);
                }

                biosLabel1.Text = sensorSystemInfos.SystemInformations.BiosCaption;
                biosLabel2.Text = String.Format(resources.GetString("SysInfos_12"), sensorSystemInfos.SystemInformations.BiosVersion);
            }
        }

        // initialisation des infos volatiles
        public void RefreshSystemInformation(String ramUsedStr, String cpuUsedStr, String processAndThreadStr)
        {
            if (sensorSystemInfos.SystemInformations != null)
            {

                procRamLabel5.Text = processAndThreadStr;
                procRamLabel3.Text = String.Format(resources.GetString("SysInfos_14"), ramUsedStr);
                procRamLabel2.Text = String.Format(resources.GetString("SysInfos_15"), SystemUtils.FormatSpeedInHertz(Convert.ToInt64(sensorSystemInfos.SystemInformations.ProcessorMaxClockSpeed)), cpuUsedStr);

                TimeSpan timespan = TimeSpan.FromMilliseconds(Environment.TickCount);
                osLabel2.Text = String.Format(resources.GetString("SysInfos_16"), sensorSystemInfos.SystemInformations.OsInstallDate.ToString(resources.GetString("SysInfos_InstalleDateFormat")), timespan.Hours.ToString().PadLeft(2, '0'), timespan.Minutes.ToString().PadLeft(2, '0'), timespan.Seconds.ToString().PadLeft(2, '0'));
            }
        }

        // cache le paneau d'extension
        private void CloseExtendedInfosPictureBox_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}