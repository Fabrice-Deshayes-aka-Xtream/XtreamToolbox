using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Xtream_ToolBox.Utils;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorStorageExtendedPanel : Form {
        
        private SensorStorage sensorStorage = null;
        private DetailStorageUserControl detailStorageUserControl = new DetailStorageUserControl();        

        public SensorStorageExtendedPanel(SensorStorage sensorStorage) {
            InitializeComponent();
            this.sensorStorage = sensorStorage;
            SystemUtils.HideFromAltTab(this);
        }

        private void CloseExtendedInfosPictureBox_Click(object sender, EventArgs e) {
            Hide();
        }

        public void Init() {
            long totalSpace = 0;
            long totalFreeSpace = 0;
            SuspendLayout();            
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            detailStoragePanel.Controls.Add(detailStorageUserControl);
            
            flowLayoutPanel.Visible = false;
            flowLayoutPanel.Controls.Clear();

            if (sensorStorage.allDrives != null) {
                foreach (DriveInfo device in sensorStorage.allDrives) {
                    if (device.DriveType == DriveType.Fixed) {
                        totalSpace += device.TotalSize;
                        totalFreeSpace += device.AvailableFreeSpace;
                        flowLayoutPanel.Controls.Add(new StorageUserControl(device));
                        drivesComboBox.Items.Add(device);
                    }
                }
            }
            flowLayoutPanel.Visible = true;
            drivesComboBox.SelectedIndex = 0;
            totalSizeValueLabel.Text = SystemUtils.GetFriendlyBytesSize(totalSpace, "auto");
            occupiedSpaceValueLabel.Text = Math.Floor((Double)((totalSpace - totalFreeSpace) * 100) / totalSpace) + "%";
            deviceSpacePictureBox.Width = (int)Math.Floor((Double)((totalSpace - totalFreeSpace) * 50) / totalSpace);
            ResumeLayout();
        }

        private void DrivesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            detailStorageUserControl.setDevice((DriveInfo)drivesComboBox.SelectedItem);
            detailStorageUserControl.updateData();
            detailStorageUserControl.Refresh();
        }
    }
}