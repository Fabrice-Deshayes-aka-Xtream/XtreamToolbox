namespace XtreamToolbox.Sensors
{
    partial class SensorPowerStatus
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RefreshUiTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // RefreshUiTimer
            // 
            this.RefreshUiTimer.Enabled = true;
            this.RefreshUiTimer.Interval = 300000;
            this.RefreshUiTimer.Tick += new System.EventHandler(this.RefreshUiTimer_Tick);
            // 
            // SensorPowerStatus
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::XtreamToolbox.Properties.Resources.battery_na;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "SensorPowerStatus";
            this.Size = new System.Drawing.Size(44, 48);
            this.Click += new System.EventHandler(this.SensorPowerStatus_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.Timer RefreshUiTimer;
    }
}
