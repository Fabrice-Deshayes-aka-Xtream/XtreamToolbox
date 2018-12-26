using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Xtream_ToolBox {
    public partial class SensorFavoriteLocations : UserControl, ISensor {
        
        // reference on toolbox
        private ToolBox toolbox = null;

        // constructor
        public SensorFavoriteLocations(ToolBox toolbox) {
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

            fileLocationComboBox.SelectedIndex = 0;
            for (int i = fileLocationComboBox.Items.Count-1; i > 0; i--) fileLocationComboBox.Items.RemoveAt(i);

            webLocationComboBox.SelectedIndex = 0;
            for (int i = webLocationComboBox.Items.Count - 1; i > 0; i--) webLocationComboBox.Items.RemoveAt(i);

            if (Properties.Settings.Default.location != null) {
                foreach (String locationStr in Properties.Settings.Default.location) {
                    Location location = Xtream_ToolBox.Location.fromString(locationStr);
                    if (location != null) {
                        switch (location.type) {
                            case Xtream_ToolBox.Location.FILESYSTEM:
                                fileLocationComboBox.Items.Add(location);
                                break;
                            case Xtream_ToolBox.Location.WEBSITE:
                                webLocationComboBox.Items.Add(location);
                                break;
                        }
                    }
                }
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void initSensorData() {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void updateLocation() {
            // nothing to do on this sensor
        }

        // go to a favorite filesystem location
        private void fileLocationComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (fileLocationComboBox.SelectedIndex > 0) {
                SystemUtils.StartProcess(((Location)fileLocationComboBox.SelectedItem).location, null, null);
            }
            fileLocationComboBox.SelectedIndex = 0;
        }

        // go to a favorite web site location
        private void webLocationComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (webLocationComboBox.SelectedIndex > 0) {
                SystemUtils.openInDefaultBrowser(((Location)webLocationComboBox.SelectedItem).location);
            }
            webLocationComboBox.SelectedIndex = 0;
        }
    }
}
