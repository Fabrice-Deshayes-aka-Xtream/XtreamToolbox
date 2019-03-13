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
            this.devicePictureBox.Location = new System.Drawing.Point(0, 0);
            this.devicePictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.devicePictureBox.Name = "devicePictureBox";
            this.devicePictureBox.Size = new System.Drawing.Size(36, 36);
            this.devicePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.devicePictureBox.TabIndex = 0;
            this.devicePictureBox.TabStop = false;
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.AutoSize = true;
            this.deviceNameLabel.Font = new System.Drawing.Font("Arial", 8F);
            this.deviceNameLabel.Location = new System.Drawing.Point(51, 2);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(65, 14);
            this.deviceNameLabel.TabIndex = 1;
            this.deviceNameLabel.Text = "C:\\ Système";
            // 
            // deviceSpacePictureBox
            // 
            this.deviceSpacePictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter;
            this.deviceSpacePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.deviceSpacePictureBox.Location = new System.Drawing.Point(54, 21);
            this.deviceSpacePictureBox.Name = "deviceSpacePictureBox";
            this.deviceSpacePictureBox.Size = new System.Drawing.Size(40, 9);
            this.deviceSpacePictureBox.TabIndex = 2;
            this.deviceSpacePictureBox.TabStop = false;
            // 
            // sizeInfoLabel
            // 
            this.sizeInfoLabel.AutoSize = true;
            this.sizeInfoLabel.Font = new System.Drawing.Font("Arial", 8F);
            this.sizeInfoLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.sizeInfoLabel.Location = new System.Drawing.Point(110, 18);
            this.sizeInfoLabel.Name = "sizeInfoLabel";
            this.sizeInfoLabel.Size = new System.Drawing.Size(148, 14);
            this.sizeInfoLabel.TabIndex = 3;
            this.sizeInfoLabel.Text = "40 GB : 3% used, 12 GB free";
            // 
            // deviceSpaceBackgroundPictureBox
            // 
            this.deviceSpaceBackgroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.deviceSpaceBackgroundPictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter_background;
            this.deviceSpaceBackgroundPictureBox.Location = new System.Drawing.Point(54, 21);
            this.deviceSpaceBackgroundPictureBox.Name = "deviceSpaceBackgroundPictureBox";
            this.deviceSpaceBackgroundPictureBox.Size = new System.Drawing.Size(50, 9);
            this.deviceSpaceBackgroundPictureBox.TabIndex = 5;
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
            this.deviceFormatLabel.AutoSize = true;
            this.deviceFormatLabel.Font = new System.Drawing.Font("Arial", 8F);
            this.deviceFormatLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.deviceFormatLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deviceFormatLabel.Location = new System.Drawing.Point(300, 2);
            this.deviceFormatLabel.Name = "deviceFormatLabel";
            this.deviceFormatLabel.Size = new System.Drawing.Size(37, 14);
            this.deviceFormatLabel.TabIndex = 6;
            this.deviceFormatLabel.Text = "FAT32";
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
            this.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.Name = "StorageUserControl";
            this.Size = new System.Drawing.Size(340, 36);
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
