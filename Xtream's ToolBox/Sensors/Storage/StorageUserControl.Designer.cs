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
            ((System.ComponentModel.ISupportInitialize)(this.devicePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpacePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpaceBackgroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // devicePictureBox
            // 
            this.devicePictureBox.AccessibleDescription = null;
            this.devicePictureBox.AccessibleName = null;
            resources.ApplyResources(this.devicePictureBox, "devicePictureBox");
            this.devicePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.devicePictureBox.BackgroundImage = null;
            this.devicePictureBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.devicePictureBox.Font = null;
            this.devicePictureBox.Image = global::Xtream_ToolBox.Properties.Resources.Drive_harddisc;
            this.devicePictureBox.ImageLocation = null;
            this.devicePictureBox.Name = "devicePictureBox";
            this.devicePictureBox.TabStop = false;
            this.helpToolTip.SetToolTip(this.devicePictureBox, resources.GetString("devicePictureBox.ToolTip"));
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.AccessibleDescription = null;
            this.deviceNameLabel.AccessibleName = null;
            resources.ApplyResources(this.deviceNameLabel, "deviceNameLabel");
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.helpToolTip.SetToolTip(this.deviceNameLabel, resources.GetString("deviceNameLabel.ToolTip"));
            // 
            // deviceSpacePictureBox
            // 
            this.deviceSpacePictureBox.AccessibleDescription = null;
            this.deviceSpacePictureBox.AccessibleName = null;
            resources.ApplyResources(this.deviceSpacePictureBox, "deviceSpacePictureBox");
            this.deviceSpacePictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter;
            this.deviceSpacePictureBox.Font = null;
            this.deviceSpacePictureBox.ImageLocation = null;
            this.deviceSpacePictureBox.Name = "deviceSpacePictureBox";
            this.deviceSpacePictureBox.TabStop = false;
            this.helpToolTip.SetToolTip(this.deviceSpacePictureBox, resources.GetString("deviceSpacePictureBox.ToolTip"));
            // 
            // sizeInfoLabel
            // 
            this.sizeInfoLabel.AccessibleDescription = null;
            this.sizeInfoLabel.AccessibleName = null;
            resources.ApplyResources(this.sizeInfoLabel, "sizeInfoLabel");
            this.sizeInfoLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.sizeInfoLabel.Name = "sizeInfoLabel";
            this.helpToolTip.SetToolTip(this.sizeInfoLabel, resources.GetString("sizeInfoLabel.ToolTip"));
            // 
            // deviceSpaceBackgroundPictureBox
            // 
            this.deviceSpaceBackgroundPictureBox.AccessibleDescription = null;
            this.deviceSpaceBackgroundPictureBox.AccessibleName = null;
            resources.ApplyResources(this.deviceSpaceBackgroundPictureBox, "deviceSpaceBackgroundPictureBox");
            this.deviceSpaceBackgroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.deviceSpaceBackgroundPictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter_background;
            this.deviceSpaceBackgroundPictureBox.Font = null;
            this.deviceSpaceBackgroundPictureBox.ImageLocation = null;
            this.deviceSpaceBackgroundPictureBox.Name = "deviceSpaceBackgroundPictureBox";
            this.deviceSpaceBackgroundPictureBox.TabStop = false;
            this.helpToolTip.SetToolTip(this.deviceSpaceBackgroundPictureBox, resources.GetString("deviceSpaceBackgroundPictureBox.ToolTip"));
            // 
            // helpToolTip
            // 
            resources.ApplyResources(this.helpToolTip, "helpToolTip");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StorageUserControl
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = null;
            this.Controls.Add(this.sizeInfoLabel);
            this.Controls.Add(this.deviceSpacePictureBox);
            this.Controls.Add(this.deviceSpaceBackgroundPictureBox);
            this.Controls.Add(this.deviceNameLabel);
            this.Controls.Add(this.devicePictureBox);
            this.DoubleBuffered = true;
            this.Font = null;
            this.Name = "StorageUserControl";
            this.helpToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
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
    }
}
