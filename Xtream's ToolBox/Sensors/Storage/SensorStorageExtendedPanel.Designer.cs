namespace XtreamToolbox.Sensors
{
    partial class SensorStorageExtendedPanel
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorStorageExtendedPanel));
            this.closeExtendedInfosPictureBox = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.detailStoragePanel = new System.Windows.Forms.Panel();
            this.drivesComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeExtendedInfosPictureBox
            // 
            this.closeExtendedInfosPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.closeExtendedInfosPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.closeExtendedInfosPictureBox, "closeExtendedInfosPictureBox");
            this.closeExtendedInfosPictureBox.Name = "closeExtendedInfosPictureBox";
            this.closeExtendedInfosPictureBox.TabStop = false;
            this.helpToolTip.SetToolTip(this.closeExtendedInfosPictureBox, resources.GetString("closeExtendedInfosPictureBox.ToolTip"));
            this.closeExtendedInfosPictureBox.Click += new System.EventHandler(this.CloseExtendedInfosPictureBox_Click);
            // 
            // flowLayoutPanel
            // 
            resources.ApplyResources(this.flowLayoutPanel, "flowLayoutPanel");
            this.flowLayoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // detailStoragePanel
            // 
            this.detailStoragePanel.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.detailStoragePanel, "detailStoragePanel");
            this.detailStoragePanel.Name = "detailStoragePanel";
            // 
            // drivesComboBox
            // 
            this.drivesComboBox.DisplayMember = "VolumeLabel";
            this.drivesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drivesComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.drivesComboBox, "drivesComboBox");
            this.drivesComboBox.Name = "drivesComboBox";
            this.drivesComboBox.ValueMember = "VolumeLabel";
            this.drivesComboBox.SelectedIndexChanged += new System.EventHandler(this.DrivesComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Name = "label4";
            // 
            // helpToolTip
            // 
            this.helpToolTip.ShowAlways = true;
            // 
            // SensorStorageExtendedPanel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::XtreamToolbox.Properties.Resources.extendInfosBackground;
            this.Controls.Add(this.flowLayoutPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.drivesComboBox);
            this.Controls.Add(this.detailStoragePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeExtendedInfosPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SensorStorageExtendedPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeExtendedInfosPictureBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel detailStoragePanel;
        private System.Windows.Forms.ComboBox drivesComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip helpToolTip;
    }
}