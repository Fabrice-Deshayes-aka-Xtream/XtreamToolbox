using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using XtreamToolbox.Utils;

namespace XtreamToolbox
{
    public partial class SensorFavoriteLocations : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        // ressource manager pour acc�der aux chaines localis�es
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorFavoriteLocations(Toolbox toolbox)
        {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel()
        {
            return null;
        }

        // init UI
        public void InitUI()
        {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // tips
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            helpToolTip.SetToolTip(DocumentsPictureBox, resources.GetString("FavoriteLocationDocuments", culture));
            helpToolTip.SetToolTip(MusicsPictureBox, resources.GetString("FavoriteLocationMusics", culture));
            helpToolTip.SetToolTip(ImagesPictureBox, resources.GetString("FavoriteLocationImages", culture));
            helpToolTip.SetToolTip(VideosPictureBox, resources.GetString("FavoriteLocationVideos", culture));
            helpToolTip.SetToolTip(DownloadsPictureBox, resources.GetString("FavoriteLocationDownloads", culture));
            ToolBoxUtils.ConfigureTooltips(helpToolTip);
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            // nothing to do on this sensor
        }

        private void DocumentsPictureBox_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:Personal", null);
        }

        private void MusicsPictureBox_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:My Music", null);
        }

        private void ImagesPictureBox_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:My Pictures", null);
        }

        private void VideosPictureBox_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:My Video", null);
        }

        private void DownloadsPictureBox_Click(object sender, EventArgs e)
        {
            SystemUtils.StartProcess("shell:Downloads", null);
        }
    }
}
