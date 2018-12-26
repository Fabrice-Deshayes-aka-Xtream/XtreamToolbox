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
    public partial class StorageUserControl : UserControl {

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private DriveInfo device = null;

        // constructeur
        public StorageUserControl(DriveInfo device) {
            InitializeComponent();
            this.device = device;
            ToolBoxUtils.configureTooltips(helpToolTip);
            updateData();
        }

        public void updateData() {
            if ((device != null) && (device.IsReady)) {
                deviceNameLabel.Text = device.Name + " " + device.VolumeLabel;
                Int64 usedSpace = (100 * (device.TotalSize - device.TotalFreeSpace)) / device.TotalSize;
                if (usedSpace < 0) usedSpace = 0;
                if (usedSpace > 100) usedSpace = 100;
                deviceSpacePictureBox.Width = (int)(usedSpace / 2);
                sizeInfoLabel.Text = String.Format(resources.GetString("StorageUserControlSize"), SystemUtils.getFriendlyBytesSize(device.TotalSize, "auto"), usedSpace, SystemUtils.getFriendlyBytesSize(device.TotalFreeSpace, "auto"));
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (this.Visible) {
                updateData();
            }
        }
    }
}
