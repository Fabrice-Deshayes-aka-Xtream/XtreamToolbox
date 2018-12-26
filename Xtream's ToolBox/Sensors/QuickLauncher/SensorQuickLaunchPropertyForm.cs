using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorQuickLaunchPropertyForm : Form {

        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        public Location currentLocation = null;

        // constructor
        public SensorQuickLaunchPropertyForm(Location currentLocation) {
            InitializeComponent();

            this.Text = resources.GetString("FormName_QuickLaunchProperty");
            this.currentLocation = currentLocation;
            populateForm();
        }

        // populate form data with location informations
        private void populateForm(){
            String imagePath;
            String arguments;
            String workingDirectory;
            String description;

            quicklaunchDisplayNameTextBox.Text = currentLocation.Name;
            quicklaunchPathTextBox.Text = currentLocation.Loc;

            currentLocation.Parameters.TryGetValue("imagePath", out imagePath);
            currentLocation.Parameters.TryGetValue("arguments", out arguments);
            currentLocation.Parameters.TryGetValue("workingDirectory", out workingDirectory);
            currentLocation.Parameters.TryGetValue("description", out description);
            quicklaunchImagePathTextBox.Text = imagePath;
            quickLaunchArgumentsTextBox.Text = arguments;
            quickLaunchWorkingDirTextBox.Text = workingDirectory;
            quickLaunchDescriptionTextBox.Text = description;
        }

        // cancel : close and do nothing
        private void cancelButton_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        // save location modifications
        private void saveButton_Click(object sender, EventArgs e) {
            currentLocation.Name = quicklaunchDisplayNameTextBox.Text;
            currentLocation.Loc = quicklaunchPathTextBox.Text;
            currentLocation.Parameters.Remove("imagePath");
            currentLocation.Parameters.Add("imagePath", quicklaunchImagePathTextBox.Text);
            currentLocation.Parameters.Remove("arguments");
            currentLocation.Parameters.Add("arguments", quickLaunchArgumentsTextBox.Text);
            currentLocation.Parameters.Remove("workingDirectory");
            currentLocation.Parameters.Add("workingDirectory", quickLaunchWorkingDirTextBox.Text);
            currentLocation.Parameters.Remove("description");
            currentLocation.Parameters.Add("description", quickLaunchDescriptionTextBox.Text);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        // browse for executable filename
        private void quickLaunchBrowseButton_Click(object sender, EventArgs e) {
            if (quicklaunchOpenFileDialog.ShowDialog(this) == DialogResult.OK) {
                quicklaunchPathTextBox.Text = quicklaunchOpenFileDialog.FileName;
            }
        }

        // browse for optional image icon
        private void quickLaunchBrowseImageButton_Click(object sender, EventArgs e) {
            if (quicklaunchOpenFileDialog.ShowDialog(this) == DialogResult.OK) {
                quicklaunchImagePathTextBox.Text = quicklaunchOpenFileDialog.FileName;
            }
        }

    }
}