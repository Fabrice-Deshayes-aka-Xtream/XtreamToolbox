using System;
using System.Resources;
using System.Windows.Forms;

namespace XtreamToolbox.Sensors
{
    public partial class SensorQuickLaunchPropertyForm : Form
    {

        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;
        public Location CurrentLocation { get; set; } = null;

        // constructor
        public SensorQuickLaunchPropertyForm(Location currentLocation)
        {
            InitializeComponent();

            this.Text = resources.GetString("FormName_QuickLaunchProperty");
            this.CurrentLocation = currentLocation;
            PopulateForm();
        }

        // populate form data with location informations
        private void PopulateForm()
        {
            quicklaunchDisplayNameTextBox.Text = CurrentLocation.Name;
            quicklaunchPathTextBox.Text = CurrentLocation.Loc;

            CurrentLocation.Parameters.TryGetValue("imagePath", out string imagePath);
            CurrentLocation.Parameters.TryGetValue("arguments", out string arguments);
            CurrentLocation.Parameters.TryGetValue("workingDirectory", out string workingDirectory);
            CurrentLocation.Parameters.TryGetValue("description", out string description);
            quicklaunchImagePathTextBox.Text = imagePath;
            quickLaunchArgumentsTextBox.Text = arguments;
            quickLaunchWorkingDirTextBox.Text = workingDirectory;
            quickLaunchDescriptionTextBox.Text = description;
        }

        // cancel : close and do nothing
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        // save location modifications
        private void SaveButton_Click(object sender, EventArgs e)
        {
            CurrentLocation.Name = quicklaunchDisplayNameTextBox.Text;
            CurrentLocation.Loc = quicklaunchPathTextBox.Text;
            CurrentLocation.Parameters.Remove("imagePath");
            CurrentLocation.Parameters.Add("imagePath", quicklaunchImagePathTextBox.Text);
            CurrentLocation.Parameters.Remove("arguments");
            CurrentLocation.Parameters.Add("arguments", quickLaunchArgumentsTextBox.Text);
            CurrentLocation.Parameters.Remove("workingDirectory");
            CurrentLocation.Parameters.Add("workingDirectory", quickLaunchWorkingDirTextBox.Text);
            CurrentLocation.Parameters.Remove("description");
            CurrentLocation.Parameters.Add("description", quickLaunchDescriptionTextBox.Text);

            this.DialogResult = DialogResult.OK;
            Close();
        }

        // browse for executable filename
        private void QuickLaunchBrowseButton_Click(object sender, EventArgs e)
        {
            if (quicklaunchOpenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                quicklaunchPathTextBox.Text = quicklaunchOpenFileDialog.FileName;
            }
        }

        // browse for optional image icon
        private void QuickLaunchBrowseImageButton_Click(object sender, EventArgs e)
        {
            if (quicklaunchOpenFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                quicklaunchImagePathTextBox.Text = quicklaunchOpenFileDialog.FileName;
            }
        }

    }
}