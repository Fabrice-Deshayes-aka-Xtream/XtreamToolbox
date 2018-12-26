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

namespace Xtream_ToolBox.Sensors {
    public partial class SensorWeather : UserControl, ISensor {

        // reference on toolbox
        public ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // information system supplémentaires affichées lors du survol de la souris
        private SensorWeatherExtendedPanel extendedPanel = null;

        public Weather currentWeather = null;

        // constructor
        public SensorWeather(ToolBox toolbox) {
            InitializeComponent();
            this.toolbox = toolbox;
            initUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form getExtendedPanel() {
            return extendedPanel;
        }

        // init sensor data in asynch mode
        private void initialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            initSensorData();
        }

        // after init sensor data, refresh ui
        private void initialisationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            refreshUI();
        }

        // init UI
        public void initUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            // couleur du text
            tempLabel.ForeColor = Properties.Settings.Default.textColor;

            helpToolTip.SetToolTip(weatherPictureBox, resources.GetString("Weather_tip"));
            helpToolTip.SetToolTip(tempLabel, resources.GetString("Weather_tip"));
            helpToolTip.SetToolTip(this, resources.GetString("Weather_tip"));

            ToolBoxUtils.configureTooltips(helpToolTip);

            if (!initialisationBackgroundWorker.IsBusy) {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void initSensorData() {
            currentWeather = Weather.getCurrentConditionWeather(Properties.Settings.Default.weatherCode);
            currentWeather = friendly(currentWeather);
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
            if (currentWeather == null) {
                weatherPictureBox.Image = Properties.Resources._na;
                tempLabel.Text = resources.GetString("not_available");
                return;
            }

            if ((extendedPanel != null) && (!extendedPanel.IsDisposed)) {
                extendedPanel.updateWeather();
            }

            tempLabel.Text = currentWeather.currentObservation.temp + "°C";

            weatherPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("_"+currentWeather.currentObservation.icon);
        }

        // update location of extended panel if needed
        public void updateLocation() {
            ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
        }

        // update weather each 30 minutes
        private void updateWeatherTimer_Tick(object sender, EventArgs e) {
            if (!initialisationBackgroundWorker.IsBusy) {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // hide or show extended panel
        private void SensorWeather_MouseClick(object sender, MouseEventArgs e) {
            if ((extendedPanel == null) || (extendedPanel.IsDisposed)) {
                extendedPanel = new SensorWeatherExtendedPanel(this);
                refreshUI();
            }

            if (extendedPanel.Visible) {
                extendedPanel.Hide();
            } else {
                ToolBoxUtils.manageExtendedPanelPosition(this, toolbox, extendedPanel);
                extendedPanel.Show();
            }
        }

        // transform dataset for internationnalisation
        private Weather friendly(Weather weather) {
            try {
                //// Friendly Wind direction
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("N", resources.GetString("Weather_WinDir_N"));
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("S", resources.GetString("Weather_WinDir_S"));
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("E", resources.GetString("Weather_WinDir_E"));
                weather.currentObservation.windDirection = weather.currentObservation.windDirection.Replace("W", resources.GetString("Weather_WinDir_W"));
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
            return weather;
        }
    }
}
