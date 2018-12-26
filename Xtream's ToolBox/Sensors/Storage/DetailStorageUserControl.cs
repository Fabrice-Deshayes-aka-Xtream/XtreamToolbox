using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.IO;
using Xtream_ToolBox.Utils;

namespace Xtream_ToolBox.Sensors {
    public partial class DetailStorageUserControl : UserControl {

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private DriveInfo device = null;

        private const int LINE_READ = 1;
        private const int LINE_WRITE = 2;
        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleRead;
        private CustomUIControls.Graphing.C2DPushGraph.LineHandle lineHandleWrite;
        private int maxRead = 0;
        private int maxWrite = 0;
        private int currentReadFlow;
        private int currentWriteFlow;

        // constructeur
        public DetailStorageUserControl() {
            InitializeComponent();
            ToolBoxUtils.configureTooltips(helpToolTip);

            readMaxLabel.Left = readLegendLabel.Right;
            writeMaxLabel.Left = writeLegendLabel.Right;
        }
        
        public void setDevice(DriveInfo device) {
            this.device = device;
            initSensorInfos();
            updateData();
        }

        private void initSensorInfos() {
            switch (device.DriveType) {
                case DriveType.Fixed:
                    devicePictureBox.Image = Properties.Resources.Drive_harddisc;
                    break;
                case DriveType.CDRom:
                    devicePictureBox.Image = Properties.Resources.Drive_cd_rom;
                    break;
                case DriveType.Removable:
                    devicePictureBox.Image = Properties.Resources.Drive_USB;
                    break;
                case DriveType.Network:
                    devicePictureBox.Image = Properties.Resources.Drive_network;
                    break;
                case DriveType.Ram:
                    devicePictureBox.Image = Properties.Resources.Drive;
                    break;
                default:
                    devicePictureBox.Image = Properties.Resources.Drive_harddisc;
                    break;
            }

            if (device.Name.StartsWith("A:") || device.Name.StartsWith("B:")) {
                devicePictureBox.Image = Properties.Resources.Drive_floppy;
            }

            if (readWriteGraph.LineExists(LINE_READ)) {
                readWriteGraph.RemoveLine(LINE_READ);
            }
            lineHandleRead = readWriteGraph.AddLine(LINE_READ, Color.Red);
            lineHandleRead.Thickness = 1;

            if (readWriteGraph.LineExists(LINE_WRITE)) {
                readWriteGraph.RemoveLine(LINE_WRITE);
            }
            lineHandleWrite = readWriteGraph.AddLine(LINE_WRITE, Color.Blue);
            lineHandleWrite.Thickness = 1;

            maxRead = 0;
            maxWrite = 0;
        }

        public void updateData() {
            if (device != null) {
                if (device.IsReady) {
                    bytesReadBySecPerformanceCounter.InstanceName = device.Name.Substring(0, 2);
                    bytesWriteBySecPerformanceCounter.InstanceName = device.Name.Substring(0, 2);
                    readWriteGraph.Visible = true;
                    readLegendLabel.Visible = true;
                    writeLegendLabel.Visible = true;
                    readLegendPictureBox.Visible = true;
                    writeLegendPictureBox.Visible = true;
                    readMaxLabel.Visible = true;
                    writeMaxLabel.Visible = true;
                    deviceSpacePictureBox.Visible = true;
                    deviceSpaceBackgroundPictureBox.Visible = true;
                    sizeInfoLabel.Visible = true;

                    deviceNameLabel.Text = device.Name + " " + device.VolumeLabel;
                    deviceFormatLabel.Text = device.DriveFormat;
                    Int64 usedSpace = (100 * (device.TotalSize - device.TotalFreeSpace)) / device.TotalSize;
                    if (usedSpace < 0) usedSpace = 0;
                    if (usedSpace > 100) usedSpace = 100;
                    deviceSpacePictureBox.Width = (int)(usedSpace / 2);
                    sizeInfoLabel.Text = String.Format(resources.GetString("StorageUserControlSize"), SystemUtils.GetFriendlyBytesSize(device.TotalSize, "auto"), usedSpace, SystemUtils.GetFriendlyBytesSize(device.TotalFreeSpace, "auto"));
                    devicePictureBox.Cursor = Cursors.Hand;
                    devicePictureBox.Click += new EventHandler(this.devicePictureBox_Click);

                    currentReadFlow = (int)Math.Ceiling(bytesReadBySecPerformanceCounter.NextValue() / 1024);
                    currentWriteFlow = (int)Math.Ceiling(bytesWriteBySecPerformanceCounter.NextValue() / 1024);

                    if (currentReadFlow > maxRead) maxRead = currentReadFlow;
                    if (currentWriteFlow > maxWrite) maxWrite = currentWriteFlow;
                    readWriteGraph.Push(currentReadFlow, LINE_READ);
                    readWriteGraph.Push(currentWriteFlow, LINE_WRITE);
                    readMaxLabel.Text = "(max " + maxRead + " kb/s)";
                    writeMaxLabel.Text = "(max " + maxWrite + " kb/s)";
                    readWriteGraph.UpdateGraph();
                } else {
                    bytesReadBySecPerformanceCounter.InstanceName = null; ;
                    bytesWriteBySecPerformanceCounter.InstanceName = null;
                    readWriteGraph.Visible = false;
                    readLegendLabel.Visible = false;
                    writeLegendLabel.Visible = false;
                    readLegendPictureBox.Visible = false;
                    writeLegendPictureBox.Visible = false;
                    readMaxLabel.Visible = false;
                    writeMaxLabel.Visible = false;
                    deviceSpacePictureBox.Visible = false;
                    deviceSpaceBackgroundPictureBox.Visible = false;
                    sizeInfoLabel.Visible = false;

                    deviceNameLabel.Text = device.Name;
                    deviceFormatLabel.Text = resources.GetString("StorageUserControlNotReady");
                    devicePictureBox.Cursor = Cursors.Arrow;
                    helpToolTip.SetToolTip(devicePictureBox, null);
                }
            }
        }

        private void devicePictureBox_Click(object sender, EventArgs e) {
            if (device != null) {
                SystemUtils.StartProcess(device.Name, null, null);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (this.Visible) {
                updateData();
            }
        }
    }
}
