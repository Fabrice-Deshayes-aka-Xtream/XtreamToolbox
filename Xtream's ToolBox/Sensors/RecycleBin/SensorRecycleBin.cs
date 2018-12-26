using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using Xtream_ToolBox.Utils;
using System.IO;

namespace Xtream_ToolBox {
    public partial class SensorRecycleBin : UserControl, ISensor {
        
        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorRecycleBin(ToolBox toolbox) {
            InitializeComponent();
            this.toolbox = toolbox;
            initUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form getExtendedPanel() {
            return null;
        }

        // init UI
        public void initUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            ToolBoxUtils.configureTooltips(helpToolTip);

            // options
            if (Properties.Settings.Default.recycleBinRefreshTime == 0) {
                Properties.Settings.Default.recycleBinRefreshTime = 1000;
            }
            recycleBinTimer.Interval = Properties.Settings.Default.recycleBinRefreshTime;
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void initSensorData() {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
            long numItemsInRecycleBin = SystemUtils.getInfosFromRecycleBin().i64NumItems;
            long sizeOfItemsInRecycleBin = SystemUtils.getInfosFromRecycleBin().i64Size;

            if (numItemsInRecycleBin > 0) {
                this.BackgroundImage = Properties.Resources.TrashFull;
                if (!helpToolTip.Active) {
                    helpToolTip.RemoveAll();
                }
                ToolBoxUtils.setTooltips(helpToolTip, this, String.Format(resources.GetString("RecycleBin_Infos"), SystemUtils.getFriendlyBytesSize(sizeOfItemsInRecycleBin, "auto"), numItemsInRecycleBin.ToString(), Environment.NewLine));                
                this.Cursor = Cursors.Hand;
            } else {
                this.BackgroundImage = Properties.Resources.TrashEmpty;
                if (!helpToolTip.Active) {
                    helpToolTip.RemoveAll();
                }
                ToolBoxUtils.setTooltips(helpToolTip, this, resources.GetString("RecycleBin_Empty"));
                this.Cursor = Cursors.Default;
            }
        }

        // update location of extended panel if needed
        public void updateLocation() {
            // nothing to do on this sensor
        }

        // Left click to open trash, right click to empty
        private void trashFull_MouseClick(object sender, MouseEventArgs e) {
            if (this.Cursor == Cursors.Hand) {
                if (e.Button.Equals(MouseButtons.Right)) {
                    SystemUtils.emptyRecycleBin(Properties.Settings.Default.disableDeleteConfirmation);
                    refreshUI();
                } else if (e.Button.Equals(MouseButtons.Left)) {
                    String errMsg = SystemUtils.StartProcess("Explorer", "/N,::{645FF040-5081-101B-9F08-00AA002F954E}", null);
                    if (errMsg != null) {
                        MessageBox.Show(errMsg);
                    }
                }
            }
        }

        // refresh size and status of trash on timer tick
        private void recycleBinTimer_Tick(object sender, EventArgs e) {
            refreshUI();
        }

        private void SensorRecycleBin_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Move;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void SensorRecycleBin_DragDrop(object sender, DragEventArgs e) {
            FileInfo mobjFileInfo;
            DirectoryInfo mobjDirectoryInfo;

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                foreach (String filename in (String[])e.Data.GetData(DataFormats.FileDrop)) {
                    try {
                        mobjDirectoryInfo = new DirectoryInfo(filename);
                        if (!(mobjDirectoryInfo.Extension.Length == 0)) {
                            mobjFileInfo = new FileInfo(filename);
                            mobjFileInfo.Delete();
                        } else {
                            mobjDirectoryInfo.Delete();
                        }
                    } catch (Exception exception) {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }
    }
}
