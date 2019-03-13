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
        public DriveInfo[] allDrives = null;

        public SensorStorageExtendedPanel(SensorStorage sensorStorage) {
            InitializeComponent();
            this.sensorStorage = sensorStorage;
            SystemUtils.HideFromAltTab(this);
        }

        private void CloseExtendedInfosPictureBox_Click(object sender, EventArgs e) {
            Hide();
        }

        public void Init() {
            SuspendLayout();
            allDrives = DriveInfo.GetDrives();
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            detailStoragePanel.Controls.Add(detailStorageUserControl);
            
            flowLayoutPanel.Visible = false;
            flowLayoutPanel.Controls.Clear();

            drivesComboBox.Items.Clear();

            if (allDrives != null) {
                foreach (DriveInfo device in allDrives) {
                    if (device.IsReady) {
                        if (device.DriveType == DriveType.Fixed) { 
                            drivesComboBox.Items.Add(device);
                        }
                        flowLayoutPanel.Controls.Add(new StorageUserControl(device));
                    }
                }
            }
            flowLayoutPanel.Visible = true;
            drivesComboBox.SelectedIndex = 0;
            ResumeLayout();
        }

        private void DrivesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            detailStorageUserControl.SetDevice((DriveInfo)drivesComboBox.SelectedItem);
            detailStorageUserControl.UpdateData();
            detailStorageUserControl.Refresh();
        }
    }
}