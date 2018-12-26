using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Specialized;
using System.Collections;
using Google.GData.Calendar;
using Google.GData.Client;
using Google.GData.Extensions;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorTimeManagerICalendar : Form {

        private SensorTimeIcalManager timeIcalManager;

        /** variable necessaire la gestion du déplacement de la fenetre par la souris */
        private bool mouseIsDown = false;
        private int lastMousePositionX = 0;
        private int lastMousePositionY = 0;

        // constructor
        public SensorTimeManagerICalendar(SensorTimeIcalManager timeIcalManager) {
            InitializeComponent();
            this.timeIcalManager = timeIcalManager;
        }

        // gestion du déplacement de la toolbox : initialisation du déplacement
        private void moveBox_MouseDown(object sender, MouseEventArgs e) {
            mouseIsDown = true;
            lastMousePositionX = e.X;
            lastMousePositionY = e.Y;
        }

        // gestion du déplacement de la toolbox : déplacement
        private void moveBox_MouseMove(object sender, MouseEventArgs e) {
            if (mouseIsDown) {
                Left = Left - (lastMousePositionX - e.X);
                Top = Top - (lastMousePositionY - e.Y);
            }
        }

        // gestion du déplacement de la toolbox : sauvegarde du déplacement
        private void moveBox_MouseUp(object sender, MouseEventArgs e) {
            mouseIsDown = false;
        }

        private void closerPictureBox_Click(object sender, EventArgs e) {
            Hide();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e) {
            eventsListView.Items.Clear();

            foreach (EventEntry entry in timeIcalManager.entryList) {
                foreach (When when in entry.Times) {
                    if (when.StartTime.Ticks >= e.Start.Ticks && when.StartTime.Ticks <= e.End.Ticks) {
                        ListViewItem item = new ListViewItem(entry.Title.Text);
                        item.Tag = entry;
                        if (when.AllDay) {
                            item.SubItems.Add(when.StartTime.ToShortDateString());
                        }
                        else if (when.StartTime.Equals(when.EndTime)) {
                            item.SubItems.Add(when.StartTime.ToShortDateString() + " " + when.StartTime.ToShortTimeString());
                        }
                        else {
                            item.SubItems.Add(when.StartTime.ToShortDateString() + " " + when.StartTime.ToShortTimeString() + " - " + when.EndTime.ToShortDateString() + " " + when.EndTime.ToShortTimeString());
                        }
                        item.SubItems.Add(entry.Content.Content);
                        eventsListView.Items.Add(item);
                    }
                }
            }
        }

        private void SensorTimeManagerICalendar_VisibleChanged(object sender, EventArgs e) {
            if (this.Visible) {
                DateTime[] aDates = new DateTime[timeIcalManager.dates.Count];

                int i = 0;
                foreach (DateTime d in timeIcalManager.dates) {
                    aDates[i++] = d;
                }

                monthCalendar1.BoldedDates = aDates;
                monthCalendar1.SelectionStart = DateTime.Today;
                monthCalendar1.SelectionEnd = DateTime.Today;

                monthCalendar1_DateSelected(this, new DateRangeEventArgs(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd));
            }
        }
   }
}