using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using Xtream_ToolBox.Utils;
using System.Runtime.InteropServices;
using System.IO;

namespace Xtream_ToolBox.Sensors
{
    public partial class SensorWeatherExtendedPanel : Form
    {

        private bool initDone = false;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private SensorWeather sensorWeather = null;

        // constructor
        public SensorWeatherExtendedPanel(SensorWeather sensorWeather)
        {
            InitializeComponent();
            this.sensorWeather = sensorWeather;
            Initialisation();
            SystemUtils.HideFromAltTab(this);
        }

        // initialize weather data
        public void Initialisation()
        {
            this.Text = resources.GetString("FormName_Weather");

            EmptyWeatherInformations();

            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            // Weather options
            locationTextBox.Text = Properties.Settings.Default.weatherCode;

            weatherLabel.Text = resources.GetString("Weather_DataProvider");
            weatherLinkLabel.Left = weatherLabel.Left + weatherLabel.Width;
            initDone = true;
        }

        public void SaveConfiguration()
        {
            if (initDone)
            {
                Properties.Settings.Default.weatherCode = locationTextBox.Text;

                if (!sensorWeather.initialisationBackgroundWorker.IsBusy)
                {
                    sensorWeather.initialisationBackgroundWorker.RunWorkerAsync();
                }
            }
        }

        // update weather display infos
        public void UpdateWeather()
        {
            if (sensorWeather.currentWeather != null)
            {
                temperatureGroupbox.Enabled = true;
                pressureAndVisibilityGroupBox.Enabled = true;
                windGroupBox.Enabled = true;
                localisationLabel.Text = sensorWeather.currentWeather.currentObservation.displayLocation.name;
                localisationPositionLabel.Text = String.Format(resources.GetString("Weather_02"), sensorWeather.currentWeather.currentObservation.displayLocation.latitude, sensorWeather.currentWeather.currentObservation.displayLocation.longitude);
                lastMesureLabel.Text = String.Format(resources.GetString("Weather_03"), sensorWeather.currentWeather.currentObservation.lastupdateTimeDT.ToShortTimeString());
                lastUpdateLabel.Text = String.Format(resources.GetString("Weather_04"), sensorWeather.currentWeather.currentObservation.timeDT.ToShortTimeString());
                tempLabel.Text = String.Format(resources.GetString("Weather_05"), sensorWeather.currentWeather.currentObservation.temp, "C", sensorWeather.currentWeather.currentObservation.feelike, "C");
                humidityDrewLabel.Text = String.Format(resources.GetString("Weather_06"), sensorWeather.currentWeather.currentObservation.relativeHumidity, sensorWeather.currentWeather.currentObservation.dewpoint, "C");
                barometricPressureLabel.Text = String.Format(resources.GetString("Weather_07"), sensorWeather.currentWeather.currentObservation.pressureMb);
                uvVisLabel.Text = String.Format(resources.GetString("Weather_08"), sensorWeather.currentWeather.currentObservation.uv, sensorWeather.currentWeather.currentObservation.visibility, "KM");
                windLabel.Text = String.Format(resources.GetString("Weather_09"), sensorWeather.currentWeather.currentObservation.windPower, "KM/H", sensorWeather.currentWeather.currentObservation.windDirection, sensorWeather.currentWeather.currentObservation.windDegrees);

                weatherPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(sensorWeather.currentWeather.currentObservation.icon);
            }
            else
            {
                EmptyWeatherInformations();
                MessageBox.Show(resources.GetString("Weather_err"));
            }
        }

        private void EmptyWeatherInformations()
        {
            temperatureGroupbox.Enabled = false;
            pressureAndVisibilityGroupBox.Enabled = false;
            windGroupBox.Enabled = false;
            String naStr = resources.GetString("not_available");

            localisationLabel.Text = resources.GetString("Weather_01");
            localisationPositionLabel.Text = String.Format(resources.GetString("Weather_02"), naStr, naStr, naStr);
            lastMesureLabel.Text = String.Format(resources.GetString("Weather_03"), naStr);
            lastUpdateLabel.Text = String.Format(resources.GetString("Weather_04"), naStr);
            tempLabel.Text = String.Format(resources.GetString("Weather_05"), naStr, naStr, naStr, naStr);
            humidityDrewLabel.Text = String.Format(resources.GetString("Weather_06"), naStr, naStr, naStr);
            barometricPressureLabel.Text = String.Format(resources.GetString("Weather_07"), naStr, naStr, naStr);
            uvVisLabel.Text = String.Format(resources.GetString("Weather_08"), naStr, naStr, naStr);
            windLabel.Text = String.Format(resources.GetString("Weather_09"), naStr, naStr, naStr, naStr);
        }

        // close extended panel
        private void CloseExtendedInfosPictureBox_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void ChangeLocationButton_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void SystemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void WeatherLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.weather.com");
        }
    }
}