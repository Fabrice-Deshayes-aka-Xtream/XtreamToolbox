using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Xtream_ToolBox.Utils;
using System.Threading;
using System.Globalization;
using System.Resources;
using Google.GData.Calendar;
using Google.GData.Client;
using System.Collections;
using Google.GData.Extensions;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorTimeIcalManager : UserControl, ISensor {

        // reference on parent and child objects
        private ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        private SensorTimeManagerICalendar extendedPanel = null;

        private bool hasEventToday = false;
        private bool hasBirthdayToday = false;
        public ArrayList dates = new ArrayList(50);
        public ArrayList entryList = new ArrayList(50);

        // constructor
        public SensorTimeIcalManager(ToolBox toolbox) {
            InitializeComponent();
            this.toolbox = toolbox;
            initUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form getExtendedPanel() {
            return null;
        }

        public void initSensorData() {
            try {
                ArrayList updatedDates = new ArrayList(50);
                ArrayList updatedEntryList = new ArrayList(50);

                if (Properties.Settings.Default.googleAccountEmail.Length > 0 && Properties.Settings.Default.googleAccountPassword.Length > 0) {
                    // connect to google calendar service
                    CalendarService myService = new CalendarService("XtreamToolbox");
                    myService.setUserCredentials(Properties.Settings.Default.googleAccountEmail, Properties.Settings.Default.googleAccountPassword);

                    // query to see if there is event today to display event icon
                    EventQuery myEventQuery = new EventQuery("http://www.google.com/calendar/feeds/default/private/full");
                    myEventQuery.SingleEvents = true;
                    myEventQuery.StartTime = DateTime.Now.AddYears(-1);
                    myEventQuery.EndTime = DateTime.Now.AddYears(1);
                    myEventQuery.ExtraParameters = "orderby=starttime";
                    myEventQuery.SortOrder = CalendarSortOrder.ascending;

                    EventFeed myResultsFeed = myService.Query(myEventQuery);

                    // now populate the calendar
                    while (myResultsFeed != null && myResultsFeed.Entries.Count > 0) {
                        foreach (EventEntry entry in myResultsFeed.Entries) {
                            updatedEntryList.Add(entry);
                            if (entry.Times.Count > 0) {
                                foreach (When w in entry.Times) {
                                    updatedDates.Add(w.StartTime);
                                }
                            }
                        }
                        // just query the same query again.
                        if (myResultsFeed.NextChunk != null) {
                            myEventQuery.Uri = new Uri(myResultsFeed.NextChunk);
                            myResultsFeed = myService.Query(myEventQuery) as EventFeed;
                        }
                        else {
                            myResultsFeed = null;
                        }
                    }
                }
                dates = updatedDates;
                entryList = updatedEntryList;
            }
            catch (Exception) {
                // nothing to do
            } 
        }

        private void initialisationBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.language);
            initSensorData();
        }

        private void initialisationBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {            
            // le calendrier est chargé, on force le lancement du reminder
            reminderTimer.Enabled = true;
            reminderTimer_Tick(this, null);
        }

        public void initUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);

            ToolBoxUtils.configureTooltips(helpToolTip);

            timeLabel.ForeColor = Properties.Settings.Default.textColor;
            dayLabel.ForeColor = Properties.Settings.Default.textColor;
            dateLabel.ForeColor = Properties.Settings.Default.textColor;
            
            hasEventToday = false;
            hasBirthdayToday = false;

            refreshUI();

            if (SystemUtils.IsInternetConnected() && !initialisationBackgroundWorker.IsBusy) {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }

        // refresh UI based on sensor Data
        public void refreshUI() {
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
        public void updateLocation() {
            // nothing to do on this sensor
        }

        // refresh datetime every timer tick
        private void calendarTimer_Tick(object sender, EventArgs e) {
            refreshUI();
        }

        // view reminding event or view calendar
        private void ViewCalendarPictureBox_Click(object sender, EventArgs e) {
            if ((extendedPanel == null) || (extendedPanel.IsDisposed)) {
                extendedPanel = new SensorTimeManagerICalendar(this);
            }

            if (extendedPanel.Visible) {
                extendedPanel.Hide();
            } else {
                extendedPanel.Show();
            }
        }

        public void reminderTimer_Tick(object sender, EventArgs e) {
            if ((!reminderBackgroundWorker.IsBusy) && (!initialisationBackgroundWorker.IsBusy)) {
                // on rafraichi le reminder si il est pas déjà en cours et que l'on est pas en train de recharger le calendrier
                reminderBackgroundWorker.RunWorkerAsync();
            }
        }

        private void reminderBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            DateTime remindMeAfter = DateTime.Now;
            DateTime eventStartTime = DateTime.Now;
            bool newHasEventToday = false;
            bool newHasBirthdayToday = false;
            Reminder currentReminder;

            
            foreach (EventEntry currentEntry in entryList) {
                foreach(When when in currentEntry.Times){
                    eventStartTime = when.StartTime;
                    break;
                }
                
                currentReminder = currentEntry.Reminder;
                if (currentReminder != null) {
                    remindMeAfter = eventStartTime.AddDays(-currentReminder.Days).AddHours(-currentReminder.Hours).AddMinutes(-currentReminder.Minutes);
                    
                    if (!newHasEventToday && (DateTime.Now.CompareTo(remindMeAfter) >= 0) && (DateTime.Now.CompareTo(eventStartTime) <= 0)) {
                        newHasEventToday = true;
                    }
                }

                if (!newHasBirthdayToday && (!Properties.Settings.Default.googleBirthdayEventKeyword.Equals("")) && (eventStartTime.DayOfYear == DateTime.Now.DayOfYear) && (currentEntry.Title.Text.Contains(Properties.Settings.Default.googleBirthdayEventKeyword))) {
                    newHasBirthdayToday = true;
                }
            }
             
            hasEventToday = newHasEventToday;
            hasBirthdayToday = newHasBirthdayToday;
        }

        private void reminderBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (hasEventToday) {
                this.BackgroundImage = Properties.Resources.MCalendarEvent;
            }
            else {
                this.BackgroundImage = Properties.Resources.MCalendar;
            }

            hasBirthdayTodayPictureBox.Visible = hasBirthdayToday;
        }

        private void refreshCalendarDataTimer_Tick(object sender, EventArgs e) {
            if (SystemUtils.IsInternetConnected() && !initialisationBackgroundWorker.IsBusy) {
                initialisationBackgroundWorker.RunWorkerAsync();
            }
        }
    }
}
