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

        public CurrentCondition currentCondition = null;

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
            currentCondition = CurrentCondition.GetCurrentCondition(Properties.Settings.Default.weatherCityId, Properties.Settings.Default.weatherTempUnit);
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            if (currentCondition == null || currentCondition.Weather == null || currentCondition.Weather.Length == 0)
            {
                weatherPictureBox.Image = Properties.Resources.weather_small_na;
                tempLabel.Text = resources.GetString("not_available");
            } else if (!CurrentCondition.availableIcons.Contains(currentCondition.Weather[0].Icon))
            {
                weatherPictureBox.Image = Properties.Resources.weather_small_na;
            } else
            {
                tempLabel.Text = Math.Round(currentCondition.Main.Temp,1) + " " + currentCondition.TempUnits;
                weatherPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject("weather_small_" + currentCondition.Weather[0].Icon);
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
    }
}
