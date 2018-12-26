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

namespace Xtream_ToolBox.Sensors {
    public partial class SensorNotepad : UserControl, ISensor {
        
        // reference on toolbox
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // Extended notepad panel
        private SensorNotepadExtendedPanel extendedPanel = null;

        // constructor
        public SensorNotepad(ToolBox toolbox) {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel (for activate and hide/show)
        public Form GetExtendedPanel() {
            return extendedPanel;
        }

        // init UI
        public void InitUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // tips
            helpToolTip.SetToolTip(this, resources.GetString("NotePad_tip"));
            ToolBoxUtils.configureTooltips(helpToolTip);
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData() {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI() {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void UpdateLocation() {
            ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
        }

        // Open or closed more infos panel
        private void SensorNotepad_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                // Launch prefered text editor
                if (File.Exists(Properties.Settings.Default.defaultTextEditor)) {
                    SystemUtils.StartProcess(Properties.Settings.Default.defaultTextEditor, null, null);
                } else {
                    MessageBox.Show("Your prefered text editor isn't well defined in ToolBox options and was not found");
                }
            } else {
                if ((extendedPanel == null) || (extendedPanel.IsDisposed)) {
                    extendedPanel = new SensorNotepadExtendedPanel();
                }

                if (extendedPanel.Visible) {
                    extendedPanel.Hide();
                } else {
                    ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
                    extendedPanel.Show();
                }
            }
        }
    }
}
