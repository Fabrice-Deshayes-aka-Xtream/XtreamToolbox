using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using XtreamToolbox.Utils;
using System.Runtime.InteropServices;
using System.IO;

namespace XtreamToolbox.Sensors
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
            if (sensorWeather.CurrentCondition != null)
            {
                temperatureGroupbox.Enabled = true;
                pressureAndVisibilityGroupBox.Enabled = true;
                windGroupBox.Enabled = true;
                localisationLabel.Text = sensorWeather.CurrentCondition.Name + "/" + sensorWeather.CurrentCondition.Sys.Country;
                localisationPositionLabel.Text = String.Format(resources.GetString("Weather_02"), sensorWeather.CurrentCondition.Coord.Lat, sensorWeather.CurrentCondition.Coord.Lon);
                lastMesureLabel.Text = String.Format(resources.GetString("Weather_03"), CurrentCondition.ConvertUnixUTCToLocalDateTime(sensorWeather.CurrentCondition.Dt).ToShortTimeString());
                sunLabel.Text = String.Format(resources.GetString("Weather_04"), CurrentCondition.ConvertUnixUTCToLocalDateTime(sensorWeather.CurrentCondition.Sys.Sunrise).ToShortTimeString(), CurrentCondition.ConvertUnixUTCToLocalDateTime(sensorWeather.CurrentCondition.Sys.Sunset).ToShortTimeString());
                tempLabel.Text = String.Format(resources.GetString("Weather_05"), Math.Round(sensorWeather.CurrentCondition.Main.Temp, 1), Math.Round(sensorWeather.CurrentCondition.Main.Temp_min, 1), Math.Round(sensorWeather.CurrentCondition.Main.Temp_max, 1), sensorWeather.CurrentCondition.TempUnits, "C");
                humidityLabel.Text = String.Format(resources.GetString("Weather_06"), sensorWeather.CurrentCondition.Main.Humidity);
                pressureLabel.Text = String.Format(resources.GetString("Weather_07"), sensorWeather.CurrentCondition.Main.Pressure, sensorWeather.CurrentCondition.PressureUnit);
                visibilityLabel.Text = String.Format(resources.GetString("Weather_08"), sensorWeather.CurrentCondition.Visibility, "M");
                windLabel.Text = String.Format(resources.GetString("Weather_09"), sensorWeather.CurrentCondition.Wind.Speed, sensorWeather.CurrentCondition.WindSpeedUnit, sensorWeather.CurrentCondition.Wind.Deg);

                weatherPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("weather_" + sensorWeather.CurrentCondition.Weather[0].Icon);
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