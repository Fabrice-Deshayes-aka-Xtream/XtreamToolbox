using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using XtreamToolbox.Utils;
using System.Threading;
using System.Globalization;
using System.Resources;
using System.Collections;

namespace XtreamToolbox.Sensors
{
    public partial class SensorTimeIcalManager : UserControl, ISensor
    {

        // reference on parent and child objects
        private Toolbox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorTimeIcalManager(Toolbox toolbox)
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

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            // nothing to do on this sensor
        }

        private void InitialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            InitSensorData();
        }

        public void InitUI()
        {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            ToolBoxUtils.SetTooltips(helpToolTip, ViewCalendarPictureBox, String.Format(resources.GetString("TimeICalManager_Tip"), Environment.NewLine));
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            timeLabel.ForeColor = Properties.Settings.Default.textColor;
            dayLabel.ForeColor = Properties.Settings.Default.textColor;
            dateLabel.ForeColor = Properties.Settings.Default.textColor;

            RefreshUI();

            if (SystemUtils.IsInternetConnected() && !initialisationBackgroundWorker.IsBusy)
            {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            dayLabel.Text = DateTime.Now.ToString("dddd");
            dateLabel.Text = DateTime.Now.ToString("d MMM");
            timeLabel.Text = DateTime.Now.ToLongTimeString();

            int maxLength = 55;
            if (dateLabel.Width > maxLength) maxLength = dateLabel.Width;
            if (dayLabel.Width > maxLength) maxLength = dayLabel.Width;
            this.Width = 40 + maxLength;
            dayLabel.Left = this.Width - dayLabel.Width;
            dateLabel.Left = this.Width - dateLabel.Width;
            timeLabel.Left = this.Width - timeLabel.Width;
        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            // nothing to do on this sensor
        }

        // refresh datetime every timer tick
        private void CalendarTimer_Tick(object sender, EventArgs e)
        {
            RefreshUI();
        }

        private void RefreshCalendarDataTimer_Tick(object sender, EventArgs e)
        {
            if (SystemUtils.IsInternetConnected() && !initialisationBackgroundWorker.IsBusy)
            {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        private void ViewCalendarPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                SystemUtils.OpenInDefaultBrowser(Properties.Settings.Default.contactsUrl);
            }
            else if (e.Button.Equals(MouseButtons.Left))
            {
                SystemUtils.OpenInDefaultBrowser(Properties.Settings.Default.calendarUrl);
            }

        }
    }
}
