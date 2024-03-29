using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;
using XtreamToolbox.Utils;

namespace XtreamToolbox.Sensors
{
    public partial class SensorCalc : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorCalc(Toolbox toolbox)
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
            helpToolTip.SetToolTip(this, resources.GetString("Calc_tip", culture));
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

        // open calc on click
        private void SensorCalc_Click(object sender, EventArgs e)
        {
            String errMsg = SystemUtils.StartProcess("Calc", null, null);
            if (errMsg != null)
            {
                MessageBox.Show(errMsg);
            }
        }
    }
}
