namespace Xtream_ToolBox.Sensors {
    partial class SensorTimeIcalManager {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorTimeIcalManager));
            this.calendarTimer = new System.Windows.Forms.Timer(this.components);
            this.dayLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ViewCalendarPictureBox = new System.Windows.Forms.PictureBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.reminderTimer = new System.Windows.Forms.Timer(this.components);
            this.reminderBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.hasBirthdayTodayPictureBox = new System.Windows.Forms.PictureBox();
            this.initialisationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.refreshCalendarDataTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ViewCalendarPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hasBirthdayTodayPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // calendarTimer
            // 
            this.calendarTimer.Enabled = true;
            this.calendarTimer.Interval = 990;
            this.calendarTimer.Tick += new System.EventHandler(this.CalendarTimer_Tick);
            // 
            // dayLabel
            // 
            resources.ApplyResources(this.dayLabel, "dayLabel");
            this.dayLabel.BackColor = System.Drawing.Color.Transparent;
            this.dayLabel.ForeColor = System.Drawing.Color.Black;
            this.dayLabel.Name = "dayLabel";
            // 
            // timeLabel
            // 
            resources.ApplyResources(this.timeLabel, "timeLabel");
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.timeLabel.Name = "timeLabel";
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 10;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // ViewCalendarPictureBox
            // 
            this.ViewCalendarPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.ViewCalendarPictureBox, "ViewCalendarPictureBox");
            this.ViewCalendarPictureBox.Name = "ViewCalendarPictureBox";
            this.ViewCalendarPictureBox.TabStop = false;
            this.ViewCalendarPictureBox.Click += new System.EventHandler(this.ViewCalendarPictureBox_Click);
            // 
            // dateLabel
            // 
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.ForeColor = System.Drawing.Color.Black;
            this.dateLabel.Name = "dateLabel";
            // 
            // reminderTimer
            // 
            this.reminderTimer.Interval = 60000;
            this.reminderTimer.Tick += new System.EventHandler(this.ReminderTimer_Tick);
            // 
            // reminderBackgroundWorker
            // 
            this.reminderBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReminderBackgroundWorker_DoWork);
            this.reminderBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ReminderBackgroundWorker_RunWorkerCompleted);
            // 
            // hasBirthdayTodayPictureBox
            // 
            this.hasBirthdayTodayPictureBox.Image = global::Xtream_ToolBox.Properties.Resources.EventBirthday;
            resources.ApplyResources(this.hasBirthdayTodayPictureBox, "hasBirthdayTodayPictureBox");
            this.hasBirthdayTodayPictureBox.Name = "hasBirthdayTodayPictureBox";
            this.hasBirthdayTodayPictureBox.TabStop = false;
            // 
            // initialisationBackgroundWorker
            // 
            this.initialisationBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitialisationBackgroundWorker_DoWork);
            this.initialisationBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InitialisationBackgroundWorker_RunWorkerCompleted);
            // 
            // refreshCalendarDataTimer
            // 
            this.refreshCalendarDataTimer.Enabled = true;
            this.refreshCalendarDataTimer.Interval = 300000;
            this.refreshCalendarDataTimer.Tick += new System.EventHandler(this.RefreshCalendarDataTimer_Tick);
            // 
            // SensorTimeIcalManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.MCalendar;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.hasBirthdayTodayPictureBox);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.ViewCalendarPictureBox);
            this.DoubleBuffered = true;
            this.Name = "SensorTimeIcalManager";
            ((System.ComponentModel.ISupportInitialize)(this.ViewCalendarPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hasBirthdayTodayPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer calendarTimer;
        private System.Windows.Forms.Label dayLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.PictureBox ViewCalendarPictureBox;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Timer reminderTimer;
        private System.ComponentModel.BackgroundWorker reminderBackgroundWorker;
        private System.Windows.Forms.PictureBox hasBirthdayTodayPictureBox;
        public System.ComponentModel.BackgroundWorker initialisationBackgroundWorker;
        private System.Windows.Forms.Timer refreshCalendarDataTimer;

    }
}
