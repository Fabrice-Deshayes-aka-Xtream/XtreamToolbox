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
            this.initialisationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ViewCalendarPictureBox)).BeginInit();
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
            this.ViewCalendarPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewCalendarPictureBox_MouseClick);
            // 
            // dateLabel
            // 
            resources.ApplyResources(this.dateLabel, "dateLabel");
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.ForeColor = System.Drawing.Color.Black;
            this.dateLabel.Name = "dateLabel";
            // 
            // initialisationBackgroundWorker
            // 
            this.initialisationBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitialisationBackgroundWorker_DoWork);
            // 
            // SensorTimeIcalManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.MCalendar;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.dayLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.ViewCalendarPictureBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "SensorTimeIcalManager";
            ((System.ComponentModel.ISupportInitialize)(this.ViewCalendarPictureBox)).EndInit();
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
        public System.ComponentModel.BackgroundWorker initialisationBackgroundWorker;

    }
}
