using System;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using XtreamToolbox.Utils;

namespace XtreamToolbox.Sensors
{
    public partial class StorageUserControl : UserControl
    {

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private DriveInfo device = null;

        // constructeur
        public StorageUserControl(DriveInfo device)
        {
            InitializeComponent();
            this.device = device;
            switch (device.DriveType)
            {
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
                default:
                    devicePictureBox.Image = Properties.Resources.Drive_harddisc;
                    break;
            }

            ToolBoxUtils.ConfigureTooltips(helpToolTip);
            UpdateData();
        }

        public void UpdateData()
        {
            if ((device != null) && (device.IsReady))
            {
                deviceNameLabel.Text = device.Name + " " + device.VolumeLabel;
                deviceFormatLabel.Text = device.DriveFormat;

                if (device.DriveType != DriveType.CDRom)
                {
                    Int64 usedSpace = (100 * (device.TotalSize - device.TotalFreeSpace)) / device.TotalSize;
                    if (usedSpace < 0) usedSpace = 0;
                    if (usedSpace > 100) usedSpace = 100;
                    deviceSpacePictureBox.Width = (int)(usedSpace / 2);
                    sizeInfoLabel.Text = String.Format(resources.GetString("StorageUserControlSize"), SystemUtils.GetFriendlyBytesSize(device.TotalSize, "auto"), usedSpace, SystemUtils.GetFriendlyBytesSize(device.TotalFreeSpace, "auto"));
                }
                else
                {
                    deviceSpacePictureBox.Visible = false;
                    sizeInfoLabel.Visible = false;
                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                UpdateData();
            }
        }
    }
}
