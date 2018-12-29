using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace Xtream_ToolBox.Sensors.ShutdownManager {
    public partial class ShutdownOptions : Form {

        // ressource manager pour accéder aux chaines localisées
        private ResourceManager resources = Properties.Resources.ResourceManager;

        public const int SHUTDOWN = 0;
        public const int RESTART = 1;
        public const int HIBERNATE = 2;
        public const int LOGOFF = 3;
        public const int LOCK = 4;
        public const int SWITCH_USER = 5;

        private int action=-1;
        private String actionStr = "";
        private DateTime dateTimeAction;

        /** variable necessaire la gestion du déplacement de la fenetre par la souris */
        private bool mouseIsDown = false;
        private int lastMousePositionX = 0;
        private int lastMousePositionY = 0;

        public ShutdownOptions() {
            InitializeComponent();
            this.Text = resources.GetString("FormName_ShutdownManager");
            doItLaterDateTimePicker.CustomFormat = resources.GetString("CalendarEventDateTime");
            doItNowRadioButton.Checked = true;
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            doTimedActionTimer.Enabled = false;
            cancelButton.Enabled = false;
            countDownLabel.Visible = false;
            doItNowRadioButton.Checked = true;
            countDownLabel.Text = "";
            action = -1;
            actionStr = "";
        }

        public void DoAction(int action) {
            DoAction(action, false, null);
        }

        public void DoAction(int action, bool withConfirmation) {
            DoAction(action, withConfirmation, null);
        }

        public void DoAction(int action, Nullable<DateTime> when) {
            DoAction(action, false, when);
        }

        public void DoAction(int action, bool withConfirmation, Nullable<DateTime> when) {
            bool doAction = true;
            if (withConfirmation) {
                switch (action) {
                    case SHUTDOWN:
                        if (MessageBox.Show(resources.GetString("ShutdownManager_ConfirmeShutDown"), resources.GetString("ShutdownManager_ConfirmeShutDownTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.No)) {
                            doAction = false;
                        }
                        break;
                    case RESTART:
                        if (MessageBox.Show(resources.GetString("ShutdownManager_ConfirmeRestart"), resources.GetString("ShutdownManager_ConfirmeRestartTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.No)) {
                            doAction = false;
                        }
                        break;
                    case HIBERNATE:
                        if (MessageBox.Show(resources.GetString("ShutdownManager_ConfirmeHibernate"), resources.GetString("ShutdownManager_ConfirmeHibernateTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.No)) {
                            doAction = false;
                        }
                        break;
                    case LOGOFF:
                        if (MessageBox.Show(resources.GetString("ShutdownManager_ConfirmeLogOff"), resources.GetString("ShutdownManager_ConfirmeLogOffTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.No)) {
                            doAction = false;
                        }
                        break;
                    case LOCK:
                        if (MessageBox.Show(resources.GetString("ShutdownManager_ConfirmeLock"), resources.GetString("ShutdownManager_ConfirmeLockTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.No)) {
                            doAction = false;
                        }
                        break;
                    case SWITCH_USER:
                        if (MessageBox.Show(resources.GetString("ShutdownManager_ConfirmeSwitchUser"), resources.GetString("ShutdownManager_ConfirmeSwitchUserTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.No)) {
                            doAction = false;
                        }
                        break;
                }
            }

            if (doAction && !when.HasValue) {
                switch (action) {
                    case SHUTDOWN:
                        SystemUtils.Shutdown();
                        break;
                    case RESTART:
                        SystemUtils.Restart();
                        break;
                    case HIBERNATE:
                        SystemUtils.Hibernate();
                        break;
                    case LOGOFF:
                        SystemUtils.Logoff();
                        break;
                    case LOCK:
                        SystemUtils.LockWorkStation();
                        break;
                    case SWITCH_USER:
                        SystemUtils.SwitchUser();
                        break;
                }
                Hide();
            }

            if (doAction && when.HasValue) {
                switch (action) {
                    case SHUTDOWN:
                        actionStr = resources.GetString("ShutdownManager_ConfirmeShutDownTitle");
                        break;
                    case RESTART:
                        actionStr = resources.GetString("ShutdownManager_ConfirmeRestartTitle");
                        break;
                    case HIBERNATE:
                        actionStr = resources.GetString("ShutdownManager_ConfirmeHibernateTitle");
                        break;
                    case LOGOFF:
                        actionStr = resources.GetString("ShutdownManager_ConfirmeLogOffTitle");
                        break;
                    case LOCK:
                        actionStr = resources.GetString("ShutdownManager_ConfirmeLockTitle");
                        break;
                    case SWITCH_USER:
                        actionStr = resources.GetString("ShutdownManager_ConfirmeSwitchUserTitle");
                        break;
                }
                this.action = action;
                dateTimeAction = when.Value;
                doTimedActionTimer.Enabled = true;
                cancelButton.Enabled = true;                
            }            
        }

        private void LockPictureBox_Click(object sender, EventArgs e) {
            if (doItNowRadioButton.Checked) {
                DoAction(LOCK);
            } else {
                DoAction(LOCK, doItLaterDateTimePicker.Value);
            }
        }

        private void LogOffPictureBox_Click(object sender, EventArgs e) {
            if (doItNowRadioButton.Checked) {
                DoAction(LOGOFF);
            }
            else {
                DoAction(LOGOFF, doItLaterDateTimePicker.Value);
            }
        }

        private void SwithUserPictureBox_Click(object sender, EventArgs e) {
            if (doItNowRadioButton.Checked) {
                DoAction(SWITCH_USER);
            }
            else {
                DoAction(SWITCH_USER, doItLaterDateTimePicker.Value);
            }
        }

        private void RestartPictureBox_Click(object sender, EventArgs e) {
            if (doItNowRadioButton.Checked) {
                DoAction(RESTART);
            }
            else {
                DoAction(RESTART, doItLaterDateTimePicker.Value);
            }
        }

        private void HibernatePictureBox_Click(object sender, EventArgs e) {
            if (doItNowRadioButton.Checked) {
                DoAction(HIBERNATE);
            }
            else {
                DoAction(HIBERNATE, doItLaterDateTimePicker.Value);
            }
        }

        private void ShutdownPictureBox_Click(object sender, EventArgs e) {
            if (doItNowRadioButton.Checked) {
                DoAction(SHUTDOWN);
            }
            else {
                DoAction(SHUTDOWN, doItLaterDateTimePicker.Value);
            }
        }

        private void DoTimedActionTimer_Tick(object sender, EventArgs e) {
            double nbTickBeforeAction = Math.Round((dateTimeAction - DateTime.Now).TotalSeconds);
            double nbDays = 0, nbHour = 0, nbMin = 0, nbSec = 0;
            if (nbTickBeforeAction > 86400) nbDays = Math.Floor(nbTickBeforeAction / 86400);
            if (nbTickBeforeAction > 3600) nbHour = Math.Floor((nbTickBeforeAction - (nbDays * 86400)) / 3600);
            if (nbTickBeforeAction > 60) nbMin = Math.Floor((nbTickBeforeAction - (nbDays * 86400 + nbHour * 3600)) / 60);
            nbSec = Math.Floor((nbTickBeforeAction - (nbDays * 86400 + nbHour * 3600 + nbMin * 60)));

            countDownLabel.Text = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}", actionStr, resources.GetString("ShutdownManager_Programmed"), nbDays, resources.GetString("Sys_d"), nbHour, resources.GetString("Sys_h"), nbMin, resources.GetString("Sys_mn"), nbSec, resources.GetString("Sys_s"));
            countDownLabel.Visible = true;
            if ((nbTickBeforeAction < 10) && (!this.Visible)) {
                this.Show();
            }

            if (DateTime.Now.CompareTo(dateTimeAction) > 0) {
                CancelButton_Click(sender, e);
                DoAction(action);
            }
        }

        private void CloseExtendedInfosPictureBox_Click(object sender, EventArgs e) {
            Hide();
        }

        private void DoItLaterDateTimePicker_ValueChanged(object sender, EventArgs e) {
            doItLaterRadioButton.Checked = true;
        }

        private void ShutdownOptions_VisibleChanged(object sender, EventArgs e) {
            doItLaterDateTimePicker.MinDate = DateTime.Now;
            doItLaterDateTimePicker.MaxDate = DateTime.Now.AddDays(30);
            doItNowRadioButton.Checked = true;
        }

        // gestion du déplacement de la toolbox : initialisation du déplacement
        private void MoveBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseIsDown = true;
            lastMousePositionX = e.X;
            lastMousePositionY = e.Y;
        }

        // gestion du déplacement de la toolbox : déplacement
        private void MoveBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseIsDown)
            {
                Left = Left - (lastMousePositionX - e.X);
                Top = Top - (lastMousePositionY - e.Y);
            }
        }

        // gestion du déplacement de la toolbox : sauvegarde du déplacement
        private void MoveBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseIsDown = false;
        }
    }
}
