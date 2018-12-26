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
using Xtream_ToolBox.Utils;
using System.Threading;
using System.Globalization;
using System.Net.Sockets;
using System.Diagnostics;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorSystemInfos : UserControl, ISensor {

        // reference on toolbox
        private ToolBox toolbox = null;

        // information system supplémentaires affichées lors du survol de la souris
        private SensorSystemInfosMore extendedPanel = null;

        // resources manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        public SystemInformations systemInformations = null;

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

        // constructor
        public SensorSystemInfos(ToolBox toolbox) {
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
            initUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form getExtendedPanel() {
            return extendedPanel;
        }

        // init sensor data in asynch mode
        private void initialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            initSensorData();
        }

        // after init sensor data, refresh ui
        private void initialisationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            cpuRamTimer.Enabled = true;
        }

        // init UI
        public void initUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // tips
            helpToolTip.SetToolTip(this, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(cpuLabel, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(ramLabel, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(lanLabel, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(wanLabel, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(c2DPushGraph, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(lanVumeterDBg, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(lanVumeterD, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(lanVumeterUBg, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(lanVumeterU, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(cpuVumeterBg, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(cpuVumeter, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(ramVumeterBg, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));
            helpToolTip.SetToolTip(ramVumeter, String.Format(resources.GetString("SysInfosTips"), Environment.NewLine));

            // option            
            cpuRamTimer.Interval = Properties.Settings.Default.sysInfosRefreshTime;

            ToolBoxUtils.configureTooltips(helpToolTip);

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
            
            if (Properties.Settings.Default.sysInfoDisplayMode == 0) {
                c2DPushGraph.Visible = true;
                this.ContextMenuStrip = graphContextMenuStrip;
            } else {
                c2DPushGraph.Visible = false;
                this.ContextMenuStrip = vumeterContextMenuStrip;
            }

            if (!initialisationBackgroundWorker.IsBusy) {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void initSensorData() {
            // init network value and card
            if (NetworkInterface.GetIsNetworkAvailable()) {
                foreach (NetworkInterface myNetworkInterface in NetworkInterface.GetAllNetworkInterfaces()) {
                    if (myNetworkInterface.GetPhysicalAddress().ToString().Equals(Properties.Settings.Default.networkLanConnexion)) {
                        lanNetworkInterface = myNetworkInterface;
                        lanBitsReceivedOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                        lanBitsSentOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    }
                    if (myNetworkInterface.GetPhysicalAddress().ToString().Equals(Properties.Settings.Default.networkInternetConnexion)) {
                        wanNetworkInterface = myNetworkInterface;
                        wanBitsReceivedOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                        wanBitsSentOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    }
                }
            }

            /*
            lanReceivedRateToolStripMenuItem.Enabled = (lanNetworkInterface != null);
            lanSendRateToolStripMenuItem.Enabled = (lanNetworkInterface != null);
            lanLabel.Enabled = (lanNetworkInterface != null);
            lanVumeterD.Visible = (lanNetworkInterface != null);
            lanVumeterU.Visible = (lanNetworkInterface != null);
            */
             
            /*
            wanReceivedRateToolStripMenuItem.Enabled = (wanNetworkInterface != null);
            wanSendRateToolStripMenuItem.Enabled = (wanNetworkInterface != null);
            wanLabel.Enabled = (wanNetworkInterface != null);
            wanVumeterD.Visible = (wanNetworkInterface != null);
            wanVumeterU.Visible = (wanNetworkInterface != null);
            */

            lanNetworkConnectionSpeed = Properties.Settings.Default.networkLanBandwith * 1000000;
            wanNetworkConnectionSpeedDownload = Properties.Settings.Default.networkInternetDownload * 1000;
            wanNetworkConnectionSpeedUpload = Properties.Settings.Default.networkInternetUpload * 1000;

            // populate system information objects and init extended panel
            systemInformations = SystemUtils.getSystemInfo();
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
            // set cpu vumeter
            cpuUsed = (Int64)cpu_used_counter.NextValue();
            if (cpuUsed < 0) cpuUsed = 0;
            if (cpuUsed > 100) cpuUsed = 100;
            if (cpuLineToolStripMenuItem.Checked) {
                if (Properties.Settings.Default.sysInfoDisplayMode == 1) {
                    cpuVumeter.Width = Convert.ToInt16(cpuUsed / 2);
                }
                else {
                    c2DPushGraph.Push((int)cpuUsed, LINE_CPU);
                }
            }
            cpuUsedStr = String.Format(resources.GetString("SysInfos_17"), cpuUsed);

            // set ram vumeter
            ramUsedbyte = systemInformations.memoryTotalPhysicalMemory - ram_physical_free.RawValue;
            ramUsed = Convert.ToInt64((ramUsedbyte * 100) / systemInformations.memoryTotalPhysicalMemory);
            if (ramUsed < 0) ramUsed = 0;
            if (ramUsed > 100) ramUsed = 100;
            if (ramLineToolStripMenuItem.Checked) {
                if (Properties.Settings.Default.sysInfoDisplayMode == 1) {
                    ramVumeter.Width = Convert.ToInt16(ramUsed / 2);
                }
                else {
                    c2DPushGraph.Push((int)ramUsed, LINE_RAM);
                }
            }
            ramUsedStr = String.Format(resources.GetString("SysInfos_18"), ramUsed, SystemUtils.getFriendlyBytesSize(systemInformations.memoryTotalPhysicalMemory, "mbyte"));

            // process & threads informations
            Process[] allProcess = Process.GetProcesses();
            int nbTotalThread = 0;

            foreach (Process process in allProcess) {             
                nbTotalThread += process.Threads.Count;
            }

            if (allProcess.Length > maxProcess) maxProcess = allProcess.Length;
            if (nbTotalThread > maxThread) maxThread = nbTotalThread;
            processAndThreadStr = String.Format(resources.GetString("SysInfos_13"), allProcess.Length, maxProcess, nbTotalThread, maxThread);

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
            if ((lanNetworkInterface != null) && (lanReceivedRateToolStripMenuItem.Enabled) && (lanReceivedRateToolStripMenuItem.Checked)) {
                try {
                    lanBitsReceived = lanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                    lanBitsReceivedSinceLastTick = lanBitsReceived - lanBitsReceivedOnLastTick;
                    lanBitsReceivedOnLastTick = lanBitsReceived;
                    lanBitsReceivedBySecond = (Int64)(lanBitsReceivedSinceLastTick * 1000) / cpuRamTimer.Interval;

                    lanBusyRateByPercent = (Int64)((lanBitsReceivedBySecond * 100) / lanNetworkConnectionSpeed);
                    if (lanBusyRateByPercent < 0) lanBusyRateByPercent = 0;
                    if (lanBusyRateByPercent > 100) lanBusyRateByPercent = 100;
                    if (Properties.Settings.Default.sysInfoDisplayMode == 1) {
                        try {
                            lanVumeterD.Width = Convert.ToInt16(lanBusyRateByPercent / 2);
                        }
                        catch (Exception e) {
                            lanVumeterD.Width = 0;
                            MessageBox.Show("Problem on lanVumeter.Width. busyRateByPercent=" + lanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else {
                        c2DPushGraph.Push((int)lanBusyRateByPercent, LINE_LAN_D);
                    }
                }
                catch (NetworkInformationException networkInformationException) {
                    Console.WriteLine(networkInformationException);
                }
                catch (SocketException socketException) {
                    Console.WriteLine(socketException);
                }
            }
            // set lan upload
            if ((lanNetworkInterface != null) && (lanSendRateToolStripMenuItem.Enabled) && (lanSendRateToolStripMenuItem.Checked)) {
                try {
                    lanBitsSent = lanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    lanBitsSentSinceLastTick = lanBitsSent - lanBitsSentOnLastTick;
                    lanBitsSentOnLastTick = lanBitsSent;
                    lanBitsSentBySecond = (Int64)(lanBitsSentSinceLastTick * 1000) / cpuRamTimer.Interval;

                    lanBusyRateByPercent = (Int64)((lanBitsSentBySecond * 100) / lanNetworkConnectionSpeed);
                    if (lanBusyRateByPercent < 0) lanBusyRateByPercent = 0;
                    if (lanBusyRateByPercent > 100) lanBusyRateByPercent = 100;
                    if (Properties.Settings.Default.sysInfoDisplayMode == 1) {
                        try {
                            lanVumeterU.Width = Convert.ToInt16(lanBusyRateByPercent / 2);
                        }
                        catch (Exception e) {
                            lanVumeterU.Width = 0;
                            MessageBox.Show("Problem on lanVumeter.Width. busyRateByPercent=" + lanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else {
                        c2DPushGraph.Push((int)lanBusyRateByPercent, LINE_LAN_U);
                    }
                } catch (NetworkInformationException networkInformationException) {
                    Console.WriteLine(networkInformationException);
                } catch (SocketException socketException) {
                    Console.WriteLine(socketException);
                }
            }

            // set wan download
            if ((wanNetworkInterface != null) && (wanReceivedRateToolStripMenuItem.Enabled) && (wanReceivedRateToolStripMenuItem.Checked)){
                try {
                    wanBitsReceived = wanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
                    wanBitsReceivedSinceLastTick = wanBitsReceived - wanBitsReceivedOnLastTick;
                    wanBitsReceivedOnLastTick = wanBitsReceived;
                    wanBitsReceivedBySecond = (Int64)(wanBitsReceivedSinceLastTick * 1000) / cpuRamTimer.Interval;

                    wanBusyRateByPercent = (Int64)((wanBitsReceivedBySecond * 100) / wanNetworkConnectionSpeedDownload);

                    if (wanBusyRateByPercent < 0) wanBusyRateByPercent = 0;
                    if (wanBusyRateByPercent > 100) wanBusyRateByPercent = 100;

                    if (Properties.Settings.Default.sysInfoDisplayMode == 1) {
                        try {
                            wanVumeterD.Width = Convert.ToInt16(wanBusyRateByPercent / 2);
                        }
                        catch (Exception e) {
                            wanVumeterD.Width = 0;
                            MessageBox.Show("Problem on wanVumeter.Width. busyRateByPercent=" + wanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else {
                        c2DPushGraph.Push((int)wanBusyRateByPercent, LINE_WAN_D);
                    }
                }
                catch (NetworkInformationException networkInformationException) {
                    Console.WriteLine(networkInformationException);
                }
                catch (SocketException socketException) {
                    Console.WriteLine(socketException);
                }
            }

            // set wan upload
            if ((wanNetworkInterface != null) && (wanSendRateToolStripMenuItem.Enabled) && (wanSendRateToolStripMenuItem.Checked)) {
                try {
                    wanBitsSent = wanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
                    wanBitsSentSinceLastTick = wanBitsSent - wanBitsSentOnLastTick;
                    wanBitsSentOnLastTick = wanBitsSent;
                    wanBitsSentBySecond = (Int64)(wanBitsSentSinceLastTick * 1000) / cpuRamTimer.Interval;

                    wanBusyRateByPercent = (Int64)((wanBitsSentBySecond * 100) / wanNetworkConnectionSpeedUpload);
                    if (wanBusyRateByPercent < 0) wanBusyRateByPercent = 0;
                    if (wanBusyRateByPercent > 100) wanBusyRateByPercent = 100;
                    if (Properties.Settings.Default.sysInfoDisplayMode == 1) {
                        try {
                            wanVumeterU.Width = Convert.ToInt16(wanBusyRateByPercent / 2);
                        }
                        catch (Exception e) {
                            wanVumeterU.Width = 0;
                            MessageBox.Show("Problem on wanVumeter.Width. busyRateByPercent=" + wanBusyRateByPercent.ToString() + " / " + e.Message);
                        }
                    }
                    else {
                        c2DPushGraph.Push((int)wanBusyRateByPercent, LINE_WAN_U);
                    }
                } catch (NetworkInformationException networkInformationException) {
                    Console.WriteLine(networkInformationException);
                } catch (SocketException socketException) {
                    Console.WriteLine(socketException);
                }
            }

            // set extendedPanel cpu & ram infos
            if ((extendedPanel!=null) && (!extendedPanel.IsDisposed) && (extendedPanel.Visible)) {
                extendedPanel.refreshSystemInformation(ramUsedStr, cpuUsedStr, processAndThreadStr);
            }

            if (Properties.Settings.Default.sysInfoDisplayMode == 0) {
                c2DPushGraph.UpdateGraph();
            }
        }

        // update location of extended panel if needed
        public void updateLocation() {
            ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
        }

        // processing on each timer tick
        private void cpuRamTimer_Tick(object sender, EventArgs e) {
            refreshUI();
        }

        // Open or closed more infos panel
        private void SensorSystemInfos_Click(object sender, EventArgs e) {
            if ((extendedPanel == null) || (extendedPanel.IsDisposed)) {
                extendedPanel = new SensorSystemInfosMore(this);
                extendedPanel.initialisation();
                extendedPanel.refreshSystemInformation("", "", "");
            }

            if (extendedPanel.Visible) {
                extendedPanel.Hide();
            } else {
                ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
                extendedPanel.Show();
            }
        }

        private void cpuLineToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            lineHandleCpu.Visible = cpuLineToolStripMenuItem.Checked;
            Properties.Settings.Default.lineCpu = cpuLineToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void ramLineToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            lineHandleRam.Visible = ramLineToolStripMenuItem.Checked;
            Properties.Settings.Default.lineRam = ramLineToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void lanReceivedRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            lineHandleLanD.Visible = lanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineLanD = lanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (lanNetworkInterface != null) lanBitsReceivedOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
        }

        private void lanSendRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            lineHandleLanU.Visible = lanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineLanU = lanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (lanNetworkInterface != null) lanBitsSentOnLastTick = lanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
        }

        private void wanReceivedRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            lineHandleWanD.Visible = wanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineWanD = wanReceivedRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (wanNetworkInterface!=null) wanBitsReceivedOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesReceived * 8;
        }

        private void wanSendRateToolStripMenuItem_CheckedChanged(object sender, EventArgs e) {
            lineHandleWanU.Visible = wanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.lineWanU = wanSendRateToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            if (wanNetworkInterface!=null) wanBitsSentOnLastTick = wanNetworkInterface.GetIPv4Statistics().BytesSent * 8;
        }

        private void switchToGraphModeToolStripMenuItem_Click(object sender, EventArgs e) {
            switchDisplayMode(MODE_GRAPH);
        }

        private void SwithToVumeterToolStripMenuItem_Click(object sender, EventArgs e) {
            switchDisplayMode(MODE_VUMETERS);
        }

        private void switchDisplayMode(int mode) {
            if (mode == MODE_GRAPH) {
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
            } else {
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
