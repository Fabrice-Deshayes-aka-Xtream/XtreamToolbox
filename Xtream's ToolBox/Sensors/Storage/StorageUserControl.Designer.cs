namespace Xtream_ToolBox.Sensors {
    partial class StorageUserControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StorageUserControl));
            this.devicePictureBox = new System.Windows.Forms.PictureBox();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.deviceSpacePictureBox = new System.Windows.Forms.PictureBox();
            this.sizeInfoLabel = new System.Windows.Forms.Label();
            this.deviceSpaceBackgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.deviceFormatLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.devicePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpacePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpaceBackgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // devicePictureBox
            // 
            this.devicePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.devicePictureBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.devicePictureBox.Image = global::Xtream_ToolBox.Properties.Resources.Drive_harddisc;
            resources.ApplyResources(this.devicePictureBox, "devicePictureBox");
            this.devicePictureBox.Name = "devicePictureBox";
            this.devicePictureBox.TabStop = false;
            // 
            // deviceNameLabel
            // 
            resources.ApplyResources(this.deviceNameLabel, "deviceNameLabel");
            this.deviceNameLabel.Name = "deviceNameLabel";
            // 
            // deviceSpacePictureBox
            // 
            this.deviceSpacePictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter;
            resources.ApplyResources(this.deviceSpacePictureBox, "deviceSpacePictureBox");
            this.deviceSpacePictureBox.Name = "deviceSpacePictureBox";
            this.deviceSpacePictureBox.TabStop = false;
            // 
            // sizeInfoLabel
            // 
            resources.ApplyResources(this.sizeInfoLabel, "sizeInfoLabel");
            this.sizeInfoLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.sizeInfoLabel.Name = "sizeInfoLabel";
            // 
            // deviceSpaceBackgroundPictureBox
            // 
            this.deviceSpaceBackgroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.deviceSpaceBackgroundPictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.deviceSpaceBackgroundPictureBox, "deviceSpaceBackgroundPictureBox");
            this.deviceSpaceBackgroundPictureBox.Name = "deviceSpaceBackgroundPictureBox";
            this.deviceSpaceBackgroundPictureBox.TabStop = false;
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 10;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // deviceFormatLabel
            // 
            resources.ApplyResources(this.deviceFormatLabel, "deviceFormatLabel");
            this.deviceFormatLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.deviceFormatLabel.Name = "deviceFormatLabel";
            // 
            // StorageUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.deviceFormatLabel);
            this.Controls.Add(this.sizeInfoLabel);
            this.Controls.Add(this.deviceSpacePictureBox);
            this.Controls.Add(this.deviceSpaceBackgroundPictureBox);
            this.Controls.Add(this.deviceNameLabel);
            this.Controls.Add(this.devicePictureBox);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "StorageUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.devicePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpacePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpaceBackgroundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox devicePictureBox;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.PictureBox deviceSpacePictureBox;
        private System.Windows.Forms.Label sizeInfoLabel;
        private System.Windows.Forms.PictureBox deviceSpaceBackgroundPictureBox;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label deviceFormatLabel;
    }
}
