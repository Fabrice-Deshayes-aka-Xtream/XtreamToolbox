using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Xtream_ToolBox.Utils;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Globalization;
using System.Resources;

namespace Xtream_ToolBox.Sensors
{
    public partial class SensorWeather : UserControl, ISensor
    {

        // reference on toolbox
        public ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // information system supplémentaires affichées lors du survol de la souris
        private SensorWeatherExtendedPanel extendedPanel = null;

        public Weather currentWeather = null;

        // constructor
        public SensorWeather(ToolBox toolbox)
        {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel()
        {
            return extendedPanel;
        }

        // init sensor data in asynch mode
        private void InitialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            InitSensorData();
        }

        // after init sensor data, refresh ui
        private void InitialisationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshUI();
        }

        // init UI
        public void InitUI()
        {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // couleur du text
            tempLabel.ForeColor = Properties.Settings.Default.textColor;

            helpToolTip.SetToolTip(weatherPictureBox, resources.GetString("Weather_tip"));
            helpToolTip.SetToolTip(tempLabel, resources.GetString("Weather_tip"));
            helpToolTip.SetToolTip(this, resources.GetString("Weather_tip"));

            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            if (!initialisationBackgroundWorker.IsBusy)
            {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            currentWeather = Weather.GetCurrentConditionWeather(Properties.Settings.Default.weatherCode);
            currentWeather = Friendly(currentWeather);
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            if (currentWeather == null || currentWeather.currentObservation == null)
            {
                weatherPictureBox.Image = Properties.Resources._na;
                tempLabel.Text = resources.GetString("not_available");
                return;
            } else
            {
                tempLabel.Text = currentWeather.currentObservation.temp + "°C";
                weatherPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_" + currentWeather.currentObservation.icon);
            }

            if ((extendedPanel != null) && (!extendedPanel.IsDisposed))
            {
                extendedPanel.UpdateWeather();
            }

        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            ToolBoxUtils.ManageExtendedPanelPosition(this, toolbox, extendedPanel);
        }

        // update weather each 30 minutes
        private void UpdateWeatherTimer_Tick(object sender, EventArgs e)
        {
            if (!initialisationBackgroundWorker.IsBusy)
            {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // hide or show extended panel
        private void SensorWeather_MouseClick(object sender, MouseEventArgs e)
        {
            if ((extendedPanel == null) || (extendedPanel.IsDisposed))
            {
                extendedPanel = new SensorWeatherExtendedPanel(this);
                RefreshUI();
            }

            if (extendedPanel.Visible)
            {
                extendedPanel.Hide();
            }
            else
            {
                ToolBoxUtils.ManageExtendedPanelPosition(this, toolbox, extendedPanel);
                extendedPanel.Show();
            }
        }

        // transform dataset for internationnalisation
        private Weather Friendly(Weather weather)
        {
            try
            {
                //// Friendly Wind direction
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("North", resources.GetString("Weather_WinDir_N"));
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("South", resources.GetString("Weather_WinDir_S"));
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("East", resources.GetString("Weather_WinDir_E"));
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("West", resources.GetString("Weather_WinDir_W"));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return weather;
        }
    }
}
