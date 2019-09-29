using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using XtreamToolbox.Utils;
using XtreamToolbox.Sensors.ShutdownManager;
using System.Globalization;

namespace XtreamToolbox
{
    public partial class SensorShutdownManager : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private ShutdownOptions shutdownOptions = new ShutdownOptions();

        // constructor
        public SensorShutdownManager(Toolbox toolbox)
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

            // Tooltips
            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            helpToolTip.SetToolTip(upperButton, resources.GetString("ShutdownManager_Tip", culture));
            helpToolTip.SetToolTip(lowerButton, resources.GetString("ShutdownManager_Tip", culture));
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            switch (Properties.Settings.Default.shutdownManagerDefaultActionUpperButton)
            {
                case ShutdownOptions.SHUTDOWN:
                    upperButton.Image = Properties.Resources.shutdownManager_shutdown_small;
                    break;
                case ShutdownOptions.RESTART:
                    upperButton.Image = Properties.Resources.shutdownManager_restart_small;
                    break;
                case ShutdownOptions.HIBERNATE:
                    upperButton.Image = Properties.Resources.shutdownManager_hibernate_small;
                    break;
                case ShutdownOptions.LOGOFF:
                    upperButton.Image = Properties.Resources.shutdownManager_logoff_small;
                    break;
                case ShutdownOptions.LOCK:
                    upperButton.Image = Properties.Resources.shutdownManager_lock_small;
                    break;
                case ShutdownOptions.SWITCH_USER:
                    upperButton.Image = Properties.Resources.shutdownManager_switch_user_small;
                    break;
            }

            switch (Properties.Settings.Default.shutdownManagerDefaultActionLowerButton)
            {
                case ShutdownOptions.SHUTDOWN:
                    lowerButton.Image = Properties.Resources.shutdownManager_shutdown_small;
                    break;
                case ShutdownOptions.RESTART:
                    lowerButton.Image = Properties.Resources.shutdownManager_restart_small;
                    break;
                case ShutdownOptions.HIBERNATE:
                    lowerButton.Image = Properties.Resources.shutdownManager_hibernate_small;
                    break;
                case ShutdownOptions.LOGOFF:
                    lowerButton.Image = Properties.Resources.shutdownManager_logoff_small;
                    break;
                case ShutdownOptions.LOCK:
                    lowerButton.Image = Properties.Resources.shutdownManager_lock_small;
                    break;
                case ShutdownOptions.SWITCH_USER:
                    lowerButton.Image = Properties.Resources.shutdownManager_switch_user_small;
                    break;
            }
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

        private void UpperButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                if (!Properties.Settings.Default.shutdownManagerLowerActionConfirmation)
                {
                    shutdownOptions.DoAction(Properties.Settings.Default.shutdownManagerDefaultActionUpperButton, true);
                }
                else
                {
                    shutdownOptions.DoAction(Properties.Settings.Default.shutdownManagerDefaultActionUpperButton, false);
                }
            }
            else if (e.Button.Equals(MouseButtons.Right))
            {
                // display menu for other or timed actions
                shutdownOptions.ShowDialog();
            }
        }

        private void LowerButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                if (!Properties.Settings.Default.shutdownManagerUpperActionConfirmation)
                {
                    shutdownOptions.DoAction(Properties.Settings.Default.shutdownManagerDefaultActionLowerButton, true);
                }
                else
                {
                    shutdownOptions.DoAction(Properties.Settings.Default.shutdownManagerDefaultActionLowerButton, false);
                }
            }
            else if (e.Button.Equals(MouseButtons.Right))
            {
                shutdownOptions.Show();
            }
        }
    }
}
