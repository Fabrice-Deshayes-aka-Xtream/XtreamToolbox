using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Net.NetworkInformation;
using System.Resources;
using XtreamToolbox.Utils;
using System.Threading;
using System.Globalization;
using System.Net.Sockets;
using System.Diagnostics;

namespace XtreamToolbox.Sensors
{
    public partial class SensorSystemInfos : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        // information system supplémentaires affichées lors du survol de la souris
        private SensorSystemInfosMore extendedPanel = null;

        // resources manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private const int LINE_CPU = 1;
        private const int LINE_RAM = 2;
        private const int LINE_LAN_D = 3;
        private const int LINE_LAN_U = 4;
        private const int LINE_WAN_D = 5;
        private const int LINE_WAN_U = 6;

        private const int MODE_GRAPH = 0;
        private const int MODE_VUMETERS = 1;

        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleCpu = null;
        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleRam = null;
        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleLanD = null;
        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleLanU = null;
        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleWanD = null;
        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleWanU = null;

        // Specific sensor working variables
        private Int64 cpuUsed = 0;
        private Int64 ramUsedbyte = 0;
        private Int64 ramUsed = 0;
        private String cpuUsedStr = null;
        private String ramUsedStr = null;
        private String processAndThreadStr = null;

        private int maxProcess = 0;
        private int maxThread = 0;

        private NetworkInterface lanNetworkInterface = null;
        private NetworkInterface wanNetworkInterface = null;

        private Int64 lanBitsReceivedOnLastTick = 0;
        private Int64 lanBitsSentOnLastTick = 0;
        private Int64 lanBitsReceivedSinceLastTick = 0;
        private Int64 lanBitsSentSinceLastTick = 0;
        private Int64 lanBitsReceived = 0;
        private Int64 lanBitsSent = 0;
        private Int64 lanBitsReceivedBySecond = 0;
        private Int64 lanBitsSentBySecond = 0;
        private Int64 lanBusyRateByPercent = 0;
        private Int64 lanNetworkConnectionSpeed = 0;

        private Int64 wanBitsReceivedOnLastTick = 0;
        private Int64 wanBitsSentOnLastTick = 0;
        private Int64 wanBitsReceivedSinceLastTick = 0;
        private Int64 wanBitsSentSinceLastTick = 0;
        private Int64 wanBitsReceived = 0;
        private Int64 wanBitsSent = 0;
        private Int64 wanBitsReceivedBySecond = 0;
        private Int64 wanBitsSentBySecond = 0;
        private Int64 wanBusyRateByPercent = 0;
        private Int64 wanNetworkConnectionSpeedDownload = 0;
        private Int64 wanNetworkConnectionSpeedUpload = 0;

        public SystemInformations SystemInformations { get; set; } = null;

        // constructor
        public SensorSystemInfos(Toolbox toolbox)
        {
            InitializeComponent();
            this.toolbox = toolbox;
            lineHandleRam = c2DPushGraph.AddLine(LINE_RAM, Color.Yellow);
            lineHandleRam.Thickness = 1;
            lineHandleLanD = c2DPushGraph.AddLine(LINE_LAN_D, Color.Blue);
            lineHandleLanD.Thickness = 1;
            lineHandleLanU = c2DPushGraph.AddLine(LINE_LAN_U, Color.Turquoise);
            lineHandleLanU.Thickness = 1;
            lineHandleWanD = c2DPushGraph.AddLine(LINE_WAN_D, Color.Red);
            lineHandleWanD.Thickness = 1;
            lineHandleWanU = c2DPushGraph.AddLine(LINE_WAN_U, Color.Pink);
            lineHandleWanU.Thickness = 1;
            lineHandleCpu = c2DPushGraph.AddLine(LINE_CPU, Color.Green);
            lineHandleCpu.Thickness = 1;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel()
        {
            return extendedPanel;
        }

        // init sensor data in asynch mode
        private void InitialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            InitSensorData();
        }

        // after init sensor data, refresh ui
        private void InitialisationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cpuRamTimer.Enabled = true;
        }

        // init UI
        public void InitUI()
        {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);


            // tips
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            helpToolTip.SetToolTip(this, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(cpuLabel, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(ramLabel, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(lanLabel, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(wanLabel, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(c2DPushGraph, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(lanVumeterDBg, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(lanVumeterD, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(lanVumeterUBg, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(lanVumeterU, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(cpuVumeterBg, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(cpuVumeter, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(ramVumeterBg, resources.GetString("SysInfosTips", culture));
            helpToolTip.SetToolTip(ramVumeter, resources.GetString("SysInfosTips", culture));

            // option            
            cpuRamTimer.Interval = Properties.Settings.Default.sysInfosRefreshTime;

            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            // couleur du text
            cpuLabel.ForeColor = Properties.Settings.Default.textColor;
            ramLabel.ForeColor = Properties.Settings.Default.textColor;
            lanLabel.ForeColor = Properties.Settings.Default.textColor;
            wanLabel.ForeColor = Properties.Settings.Default.textColor;

            cpuLineToolStripMenuItem.Checked = Properties.Settings.Default.lineCpu;
            ramLineToolStripMenuItem.Checked = Properties.Settings.Default.lineRam;
            lanReceivedRateToolStripMenuItem.Checked = Properties.Settings.Default.lineLanD;
            lanSendRateToolStripMenuItem.Checked = Properties.Settings.Default.lineLanU;
            wanReceivedRateToolStripMenuItem.Checked = Properties.Settings.Default.lineWanD;
            wanSendRateToolStripMenuItem.Checked = Properties.Settings.Default.lineWanU;

            if (Properties.Settings.Default.sysInfoDisplayMode == 0)
            {
                c2DPushGraph.Visible = true;
                this.ContextMenuStrip = graphContextMenuStrip;
            }
            else
            {
                c2DPushGraph.Visible = false;
                this.ContextMenuStrip = vumeterContextMenuStrip;
            }

            if (!initialisationBackgroundWorker.IsBusy)
            {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            // init network value and card
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                foreach (NetworkInterface myNetworkInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (myNetworkInterface.GetPhysicalAddress().ToString().Equals(Properties.Settings.Default.networkLanConnexion))
                    {
                        lanNetworkInterface = myNetworkInterface;
                        lanBitsReceivedOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                        lanBitsSentOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    }
                    if (myNetworkInterface.GetPhysicalAddress().ToString().Equals(Properties.Settings.Default.networkInternetConnexion))
                    {
                        wanNetworkInterface = myNetworkInterface;
                        wanBitsReceivedOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                        wanBitsSentOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    }
                }
            }

            lanNetworkConnectionSpeed = Properties.Settings.Default.networkLanBandwith * 1000000;
            wanNetworkConnectionSpeedDownload = Properties.Settings.Default.networkInternetDownload * 1000;
            wanNetworkConnectionSpeedUpload = Properties.Settings.Default.networkInternetUpload * 1000;

            // populate system information objects and init extended panel
            SystemInformations = SystemUtils.GetSystemInfo();
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);

            // set cpu vumeter
            cpuUsed = (Int64)cpu_used_counter.NextValue();
            if (cpuUsed < 0) cpuUsed = 0;
            if (cpuUsed > 100) cpuUsed = 100;
            if (cpuLineToolStripMenuItem.Checked)
            {
                if (Properties.Settings.Default.sysInfoDisplayMode == 1)
                {
                    cpuVumeter.Width = Convert.ToInt16(cpuUsed / 2);
                }
                else
                {
                    c2DPushGraph.Push((int)cpuUsed, LINE_CPU);
                }
            }

            // set ram vumeter
            ramUsedbyte = SystemInformations.MemoryTotalPhysicalMemory - ram_physical_free.RawValue;
            ramUsed = Convert.ToInt64((ramUsedbyte * 100) / SystemInformations.MemoryTotalPhysicalMemory);
            if (ramUsed < 0) ramUsed = 0;
            if (ramUsed > 100) ramUsed = 100;
            if (ramLineToolStripMenuItem.Checked)
            {
                if (Properties.Settings.Default.sysInfoDisplayMode == 1)
                {
                    ramVumeter.Width = Convert.ToInt16(ramUsed / 2);
                }
                else
                {
                    c2DPushGraph.Push((int)ramUsed, LINE_RAM);
                }
            }

            lanReceivedRateToolStripMenuItem.Enabled = (lanNetworkInterface != null);
            lanSendRateToolStripMenuItem.Enabled = (lanNetworkInterface != null);
            lanLabel.Enabled = (lanNetworkInterface != null);
            lanVumeterD.Visible = (lanNetworkInterface != null);
            lanVumeterU.Visible = (lanNetworkInterface != null);

            wanReceivedRateToolStripMenuItem.Enabled = (wanNetworkInterface != null);
            wanSendRateToolStripMenuItem.Enabled = (wanNetworkInterface != null);
            wanLabel.Enabled = (wanNetworkInterface != null);
            wanVumeterD.Visible = (wanNetworkInterface != null);
            wanVumeterU.Visible = (wanNetworkInterface != null);

            // set lan download
            if ((lanNetworkInterface != null) && (lanReceivedRateToolStripMenuItem.Enabled) && (lanReceivedRateToolStripMenuItem.Checked))
            {
                try
                {
                    lanBitsReceived = lanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                    lanBitsReceivedSinceLastTick = lanBitsReceived - lanBitsReceivedOnLastTick;
                    lanBitsReceivedOnLastTick = lanBitsReceived;
                    lanBitsReceivedBySecond = (Int64)(lanBitsReceivedSinceLastTick * 1000) / cpuRamTimer.Interval;

                    lanBusyRateByPercent = (Int64)((lanBitsReceivedBySecond * 100) / lanNetworkConnectionSpeed);
                    if (lanBusyRateByPercent < 0) lanBusyRateByPercent = 0;
                    if (lanBusyRateByPercent > 100) lanBusyRateByPercent = 100;
                    if (Properties.Settings.Default.sysInfoDisplayMode == 1)
                    {
                        try
                        {
                            lanVumeterD.Width = Convert.ToInt16(lanBusyRateByPercent / 2);
                        }
                        catch (Exception e)
                        {
                            lanVumeterD.Width = 0;
                            MessageBox.Show("Problem on lanVumeter.Width. busyRateByPercent=" + lanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else
                    {
                        c2DPushGraph.Push((int)lanBusyRateByPercent, LINE_LAN_D);
                    }
                }
                catch (NetworkInformationException networkInformationException)
                {
                    Console.WriteLine(networkInformationException);
                }
                catch (SocketException socketException)
                {
                    Console.WriteLine(socketException);
                }
            }
            // set lan upload
            if ((lanNetworkInterface != null) && (lanSendRateToolStripMenuItem.Enabled) && (lanSendRateToolStripMenuItem.Checked))
            {
                try
                {
                    lanBitsSent = lanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    lanBitsSentSinceLastTick = lanBitsSent - lanBitsSentOnLastTick;
                    lanBitsSentOnLastTick = lanBitsSent;
                    lanBitsSentBySecond = (Int64)(lanBitsSentSinceLastTick * 1000) / cpuRamTimer.Interval;

                    lanBusyRateByPercent = (Int64)((lanBitsSentBySecond * 100) / lanNetworkConnectionSpeed);
                    if (lanBusyRateByPercent < 0) lanBusyRateByPercent = 0;
                    if (lanBusyRateByPercent > 100) lanBusyRateByPercent = 100;
                    if (Properties.Settings.Default.sysInfoDisplayMode == 1)
                    {
                        try
                        {
                            lanVumeterU.Width = Convert.ToInt16(lanBusyRateByPercent / 2);
                        }
                        catch (Exception e)
                        {
                            lanVumeterU.Width = 0;
                            MessageBox.Show("Problem on lanVumeter.Width. busyRateByPercent=" + lanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else
                    {
                        c2DPushGraph.Push((int)lanBusyRateByPercent, LINE_LAN_U);
                    }
                }
                catch (NetworkInformationException networkInformationException)
                {
                    Console.WriteLine(networkInformationException);
                }
                catch (SocketException socketException)
                {
                    Console.WriteLine(socketException);
                }
            }

            // set wan download
            if ((wanNetworkInterface != null) && (wanReceivedRateToolStripMenuItem.Enabled) && (wanReceivedRateToolStripMenuItem.Checked))
            {
                try
                {
                    wanBitsReceived = wanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                    wanBitsReceivedSinceLastTick = wanBitsReceived - wanBitsReceivedOnLastTick;
                    wanBitsReceivedOnLastTick = wanBitsReceived;
                    wanBitsReceivedBySecond = (Int64)(wanBitsReceivedSinceLastTick * 1000) / cpuRamTimer.Interval;

                    wanBusyRateByPercent = (Int64)((wanBitsReceivedBySecond * 100) / wanNetworkConnectionSpeedDownload);

                    if (wanBusyRateByPercent < 0) wanBusyRateByPercent = 0;
                    if (wanBusyRateByPercent > 100) wanBusyRateByPercent = 100;

                    if (Properties.Settings.Default.sysInfoDisplayMode == 1)
                    {
                        try
                        {
                            wanVumeterD.Width = Convert.ToInt16(wanBusyRateByPercent / 2);
                        }
                        catch (Exception e)
                        {
                            wanVumeterD.Width = 0;
                            MessageBox.Show("Problem on wanVumeter.Width. busyRateByPercent=" + wanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else
                    {
                        c2DPushGraph.Push((int)wanBusyRateByPercent, LINE_WAN_D);
                    }
                }
                catch (NetworkInformationException networkInformationException)
                {
                    Console.WriteLine(networkInformationException);
                }
                catch (SocketException socketException)
                {
                    Console.WriteLine(socketException);
                }
            }

            // set wan upload
            if ((wanNetworkInterface != null) && (wanSendRateToolStripMenuItem.Enabled) && (wanSendRateToolStripMenuItem.Checked))
            {
                try
                {
                    wanBitsSent = wanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    wanBitsSentSinceLastTick = wanBitsSent - wanBitsSentOnLastTick;
                    wanBitsSentOnLastTick = wanBitsSent;
                    wanBitsSentBySecond = (Int64)(wanBitsSentSinceLastTick * 1000) / cpuRamTimer.Interval;

                    wanBusyRateByPercent = (Int64)((wanBitsSentBySecond * 100) / wanNetworkConnectionSpeedUpload);
                    if (wanBusyRateByPercent < 0) wanBusyRateByPercent = 0;
                    if (wanBusyRateByPercent > 100) wanBusyRateByPercent = 100;
                    if (Properties.Settings.Default.sysInfoDisplayMode == 1)
                    {
                        try
                        {
                            wanVumeterU.Width = Convert.ToInt16(wanBusyRateByPercent / 2);
                        }
                        catch (Exception e)
                        {
                            wanVumeterU.Width = 0;
                            MessageBox.Show("Problem on wanVumeter.Width. busyRateByPercent=" + wanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else
                    {
                        c2DPushGraph.Push((int)wanBusyRateByPercent, LINE_WAN_U);
                    }
                }
                catch (NetworkInformationException networkInformationException)
                {
                    Console.WriteLine(networkInformationException);
                }
                catch (SocketException socketException)
                {
                    Console.WriteLine(socketException);
                }
            }

            // set extendedPanel cpu & ram infos
            if ((extendedPanel != null) && (!extendedPanel.IsDisposed) && (extendedPanel.Visible))
            {
                // process & threads informations
                Process[] allProcess = Process.GetProcesses();
                int nbTotalThread = 0;

                foreach (Process process in allProcess)
                {
                    nbTotalThread += process.Threads.Count;
                }

                if (allProcess.Length > maxProcess) maxProcess = allProcess.Length;
                if (nbTotalThread > maxThread) maxThread = nbTotalThread;
                processAndThreadStr = String.Format(resources.GetString("SysInfos_13", culture), allProcess.Length, maxProcess, nbTotalThread, maxThread);

                cpuUsedStr = String.Format(resources.GetString("SysInfos_17", culture), cpuUsed);
                ramUsedStr = String.Format(resources.GetString("SysInfos_18", culture), ramUsed, SystemUtils.GetFriendlyBytesSize(SystemInformations.MemoryTotalPhysicalMemory, "mbyte"));
                extendedPanel.RefreshSystemInformation(ramUsedStr, cpuUsedStr, processAndThreadStr);
            }

            if (Properties.Settings.Default.sysInfoDisplayMode == 0)
            {
                c2DPushGraph.UpdateGraph();
            }
        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            ToolBoxUtils.ManageExtendedPanelPosition(this, toolbox, extendedPanel);
        }

        // processing on each timer tick
        private void CpuRamTimer_Tick(object sender, EventArgs e)
        {
            RefreshUI();
        }

        // Open or closed more infos panel
        private void SensorSystemInfos_Click(object sender, EventArgs e)
        {
            if ((extendedPanel == null) || (extendedPanel.IsDisposed))
            {
                extendedPanel = new SensorSystemInfosMore(this);
                extendedPanel.Initialisation();
                extendedPanel.RefreshSystemInformation("", "", "");
            }

            if (extendedPanel.Visible)
            {
                extendedPanel.Hide();
            }
            else
            {
                ToolBoxUtils.ManageExtendedPanelPosition(this, toolbox, extendedPanel);
                extendedPanel.Show();
            }
        }

        private void CpuLineToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            lineHandleCpu.Visible = cpuLineToolStripMenuItem.Checked;
            Properties.Settings.Default.lineCpu = cpuLineToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void RamLineToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            lineHandleRam.Visible = ramLineToolStripMenuItem.Checked;
            Properties.Settings.Default.lineRam = ramLineToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void LanReceivedRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            lineHandleLanD.Visible = lanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineLanD = lanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (lanNetworkInterface != null) lanBitsReceivedOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
        }

        private void LanSendRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            lineHandleLanU.Visible = lanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineLanU = lanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (lanNetworkInterface != null) lanBitsSentOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
        }

        private void WanReceivedRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            lineHandleWanD.Visible = wanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineWanD = wanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (wanNetworkInterface != null) wanBitsReceivedOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
        }

        private void WanSendRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            lineHandleWanU.Visible = wanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineWanU = wanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (wanNetworkInterface != null) wanBitsSentOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
        }

        private void SwitchToGraphModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchDisplayMode(MODE_GRAPH);
        }

        private void SwithToVumeterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwitchDisplayMode(MODE_VUMETERS);
        }

        private void SwitchDisplayMode(int mode)
        {
            if (mode == MODE_GRAPH)
            {
                // graph mode
                c2DPushGraph.Visible = true;
                this.ContextMenuStrip = graphContextMenuStrip;
                lanLabel.Visible = false;
                wanLabel.Visible = false;
                cpuLabel.Visible = false;
                ramLabel.Visible = false;
                lanVumeterDBg.Visible = false;
                lanVumeterD.Visible = false;
                lanVumeterUBg.Visible = false;
                lanVumeterU.Visible = false;
                cpuVumeterBg.Visible = false;
                cpuVumeter.Visible = false;
                ramVumeterBg.Visible = false;
                ramVumeter.Visible = false;
            }
            else
            {
                // vu meter mode
                c2DPushGraph.Visible = false;
                this.ContextMenuStrip = vumeterContextMenuStrip;
                lanLabel.Visible = true;
                wanLabel.Visible = true;
                cpuLabel.Visible = true;
                ramLabel.Visible = true;
                lanVumeterDBg.Visible = true;
                lanVumeterD.Visible = true;
                lanVumeterUBg.Visible = true;
                lanVumeterU.Visible = true;
                cpuVumeterBg.Visible = true;
                cpuVumeter.Visible = true;
                ramVumeterBg.Visible = true;
                ramVumeter.Visible = true;
            }

            Properties.Settings.Default.sysInfoDisplayMode = mode;
            Properties.Settings.Default.Save();
        }
    }
}
