namespace XtreamToolbox.Sensors {
    partial class SensorWeather {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorWeather));
            this.weatherPictureBox = new System.Windows.Forms.PictureBox();
            this.tempLabel = new System.Windows.Forms.Label();
            this.updateWeatherTimer = new System.Windows.Forms.Timer(this.components);
            this.initialisationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // weatherPictureBox
            // 
            resources.ApplyResources(this.weatherPictureBox, "weatherPictureBox");
            this.weatherPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.weatherPictureBox.Image = global::XtreamToolbox.Properties.Resources.weather_small_na;
            this.weatherPictureBox.Name = "weatherPictureBox";
            this.weatherPictureBox.TabStop = false;
            this.weatherPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorWeather_MouseClick);
            // 
            // tempLabel
            // 
            resources.ApplyResources(this.tempLabel, "tempLabel");
            this.tempLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorWeather_MouseClick);
            // 
            // updateWeatherTimer
            // 
            this.updateWeatherTimer.Enabled = true;
            this.updateWeatherTimer.Interval = 7200000;
            this.updateWeatherTimer.Tick += new System.EventHandler(this.UpdateWeatherTimer_Tick);
            // 
            // initialisationBackgroundWorker
            // 
            this.initialisationBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitialisationBackgroundWorker_DoWork);
            this.initialisationBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InitialisationBackgroundWorker_RunWorkerCompleted);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            this.helpToolTip.UseAnimation = false;
            this.helpToolTip.UseFading = false;
            // 
            // SensorWeather
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.weatherPictureBox);
            this.Controls.Add(this.tempLabel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "SensorWeather";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorWeather_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.weatherPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox weatherPictureBox;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Timer updateWeatherTimer;
        private System.Windows.Forms.ToolTip helpToolTip;
        public System.ComponentModel.BackgroundWorker initialisationBackgroundWorker;
    }
}
