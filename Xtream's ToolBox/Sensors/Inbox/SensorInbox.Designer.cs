namespace Xtream_ToolBox.Sensors {
    partial class SensorInbox {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorInbox));
            this.initialisationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.emailLabel = new System.Windows.Forms.Label();
            this.checkMailTimer = new System.Windows.Forms.Timer(this.components);
            this.spamLabel = new System.Windows.Forms.Label();
            this.progressPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.progressPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // initialisationBackgroundWorker
            // 
            this.initialisationBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.initialisationBackgroundWorker_DoWork);
            this.initialisationBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.initialisationBackgroundWorker_RunWorkerCompleted);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // emailLabel
            // 
            this.emailLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.emailLabel, "emailLabel");
            this.emailLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorInbox_MouseClick);
            // 
            // checkMailTimer
            // 
            this.checkMailTimer.Enabled = true;
            this.checkMailTimer.Interval = 300000;
            this.checkMailTimer.Tick += new System.EventHandler(this.checkMailTimer_Tick);
            // 
            // spamLabel
            // 
            this.spamLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.spamLabel, "spamLabel");
            this.spamLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.spamLabel.Name = "spamLabel";
            this.spamLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorInbox_MouseClick);
            // 
            // progressPictureBox
            // 
            this.progressPictureBox.Image = global::Xtream_ToolBox.Properties.Resources.progress;
            resources.ApplyResources(this.progressPictureBox, "progressPictureBox");
            this.progressPictureBox.Name = "progressPictureBox";
            this.progressPictureBox.TabStop = false;
            this.progressPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorInbox_MouseClick);
            // 
            // SensorInbox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.InboxEmpty;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.progressPictureBox);
            this.Controls.Add(this.spamLabel);
            this.Controls.Add(this.emailLabel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "SensorInbox";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorInbox_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.progressPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker initialisationBackgroundWorker;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Timer checkMailTimer;
        private System.Windows.Forms.Label spamLabel;
        private System.Windows.Forms.PictureBox progressPictureBox;
    }
}
