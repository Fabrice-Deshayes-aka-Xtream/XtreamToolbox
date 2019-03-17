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
            locationTextBox.Text = Properties.Settings.Default.weatherCityId;

            weatherLabel.Text = resources.GetString("Weather_DataProvider");
            weatherLinkLabel.Left = weatherLabel.Left + weatherLabel.Width;
            initDone = true;
        }

        public void SaveConfiguration()
        {
            if (initDone)
            {
                Properties.Settings.Default.weatherCityId = locationTextBox.Text;

                if (!sensorWeather.initialisationBackgroundWorker.IsBusy)
                {
                    sensorWeather.initialisationBackgroundWorker.RunWorkerAsync();
                }
            }
        }

        // update weather display infos
        public void UpdateWeather()
        {
            if (sensorWeather.currentCondition != null)
            {
                temperatureGroupbox.Enabled = true;
                pressureAndVisibilityGroupBox.Enabled = true;
                windGroupBox.Enabled = true;
                localisationLabel.Text = sensorWeather.currentCondition.Name + "/" + sensorWeather.currentCondition.Sys.Country;
                localisationPositionLabel.Text = String.Format(resources.GetString("Weather_02"), sensorWeather.currentCondition.Coord.Lat, sensorWeather.currentCondition.Coord.Lon);
                lastMesureLabel.Text = String.Format(resources.GetString("Weather_03"), CurrentCondition.ConvertUnixUTCToLocalDateTime(sensorWeather.currentCondition.Dt).ToShortTimeString());
                sunLabel.Text = String.Format(resources.GetString("Weather_04"), CurrentCondition.ConvertUnixUTCToLocalDateTime(sensorWeather.currentCondition.Sys.Sunrise).ToShortTimeString(), CurrentCondition.ConvertUnixUTCToLocalDateTime(sensorWeather.currentCondition.Sys.Sunset).ToShortTimeString());
                tempLabel.Text = String.Format(resources.GetString("Weather_05"), Math.Round(sensorWeather.currentCondition.Main.Temp, 1), Math.Round(sensorWeather.currentCondition.Main.Temp_min, 1), Math.Round(sensorWeather.currentCondition.Main.Temp_max, 1), sensorWeather.currentCondition.TempUnits, "C");
                humidityLabel.Text = String.Format(resources.GetString("Weather_06"), sensorWeather.currentCondition.Main.Humidity);
                pressureLabel.Text = String.Format(resources.GetString("Weather_07"), sensorWeather.currentCondition.Main.Pressure, sensorWeather.currentCondition.PressureUnit);
                visibilityLabel.Text = String.Format(resources.GetString("Weather_08"), sensorWeather.currentCondition.Visibility, "M");
                windLabel.Text = String.Format(resources.GetString("Weather_09"), sensorWeather.currentCondition.Wind.Speed, sensorWeather.currentCondition.WindSpeedUnit, sensorWeather.currentCondition.Wind.Deg);

                weatherPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("weather_" + sensorWeather.currentCondition.Weather[0].Icon);
            }
            else
            {
                EmptyWeatherInformations();
            }
        }

        private void EmptyWeatherInformations()
        {
            temperatureGroupbox.Enabled = false;
            pressureAndVisibilityGroupBox.Enabled = false;
            windGroupBox.Enabled = false;
            String naStr = resources.GetString("not_available");
            weatherPictureBox.Image = weatherPictureBox.Image = Properties.Resources.weather_na;

            localisationLabel.Text = resources.GetString("Weather_01");
            localisationPositionLabel.Text = String.Format(resources.GetString("Weather_02"), naStr, naStr);
            lastMesureLabel.Text = String.Format(resources.GetString("Weather_03"), naStr);
            sunLabel.Text = String.Format(resources.GetString("Weather_04"), naStr, naStr);
            tempLabel.Text = String.Format(resources.GetString("Weather_05"), naStr, naStr, naStr, naStr);
            humidityLabel.Text = String.Format(resources.GetString("Weather_06"), naStr);
            pressureLabel.Text = String.Format(resources.GetString("Weather_07"), naStr, naStr);
            visibilityLabel.Text = String.Format(resources.GetString("Weather_08"), naStr, naStr);
            windLabel.Text = String.Format(resources.GetString("Weather_09"), naStr, naStr, naStr);
        }

        // close extended panel
        private void CloseExtendedInfosPictureBox_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void WeatherLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://openweathermap.org/");
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }
    }
}