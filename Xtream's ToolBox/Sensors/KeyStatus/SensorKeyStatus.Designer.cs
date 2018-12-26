namespace Xtream_ToolBox.Sensors {
    partial class SensorKeyStatus {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorKeyStatus));
            this.updateKeyStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.capsLockStatusPictureBoxON = new System.Windows.Forms.PictureBox();
            this.capsLockStatusPictureBoxOFF = new System.Windows.Forms.PictureBox();
            this.numLockStatusPictureBoxON = new System.Windows.Forms.PictureBox();
            this.numLockStatusPictureBoxOFF = new System.Windows.Forms.PictureBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.capsLockStatusPictureBoxON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsLockStatusPictureBoxOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLockStatusPictureBoxON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLockStatusPictureBoxOFF)).BeginInit();
            this.SuspendLayout();
            // 
            // updateKeyStatusTimer
            // 
            this.updateKeyStatusTimer.Enabled = true;
            this.updateKeyStatusTimer.Interval = 400;
            this.updateKeyStatusTimer.Tick += new System.EventHandler(this.updateKeyStatusTimer_Tick);
            // 
            // capsLockStatusPictureBoxON
            // 
            this.capsLockStatusPictureBoxON.BackColor = System.Drawing.Color.Transparent;
            this.capsLockStatusPictureBoxON.Image = global::Xtream_ToolBox.Properties.Resources.key_capslock_on;
            resources.ApplyResources(this.capsLockStatusPictureBoxON, "capsLockStatusPictureBoxON");
            this.capsLockStatusPictureBoxON.Name = "capsLockStatusPictureBoxON";
            this.capsLockStatusPictureBoxON.TabStop = false;
            // 
            // capsLockStatusPictureBoxOFF
            // 
            this.capsLockStatusPictureBoxOFF.BackColor = System.Drawing.Color.Transparent;
            this.capsLockStatusPictureBoxOFF.Image = global::Xtream_ToolBox.Properties.Resources.key_capslock_off;
            resources.ApplyResources(this.capsLockStatusPictureBoxOFF, "capsLockStatusPictureBoxOFF");
            this.capsLockStatusPictureBoxOFF.Name = "capsLockStatusPictureBoxOFF";
            this.capsLockStatusPictureBoxOFF.TabStop = false;
            // 
            // numLockStatusPictureBoxON
            // 
            this.numLockStatusPictureBoxON.BackColor = System.Drawing.Color.Transparent;
            this.numLockStatusPictureBoxON.Image = global::Xtream_ToolBox.Properties.Resources.key_numlock_on;
            resources.ApplyResources(this.numLockStatusPictureBoxON, "numLockStatusPictureBoxON");
            this.numLockStatusPictureBoxON.Name = "numLockStatusPictureBoxON";
            this.numLockStatusPictureBoxON.TabStop = false;
            // 
            // numLockStatusPictureBoxOFF
            // 
            this.numLockStatusPictureBoxOFF.BackColor = System.Drawing.Color.Transparent;
            this.numLockStatusPictureBoxOFF.Image = global::Xtream_ToolBox.Properties.Resources.key_numlock_off;
            resources.ApplyResources(this.numLockStatusPictureBoxOFF, "numLockStatusPictureBoxOFF");
            this.numLockStatusPictureBoxOFF.Name = "numLockStatusPictureBoxOFF";
            this.numLockStatusPictureBoxOFF.TabStop = false;
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // SensorKeyStatus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.capsLockStatusPictureBoxON);
            this.Controls.Add(this.capsLockStatusPictureBoxOFF);
            this.Controls.Add(this.numLockStatusPictureBoxON);
            this.Controls.Add(this.numLockStatusPictureBoxOFF);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "SensorKeyStatus";
            ((System.ComponentModel.ISupportInitialize)(this.capsLockStatusPictureBoxON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capsLockStatusPictureBoxOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLockStatusPictureBoxON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLockStatusPictureBoxOFF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateKeyStatusTimer;
        private System.Windows.Forms.PictureBox capsLockStatusPictureBoxON;
        private System.Windows.Forms.PictureBox numLockStatusPictureBoxON;
        private System.Windows.Forms.PictureBox capsLockStatusPictureBoxOFF;
        private System.Windows.Forms.PictureBox numLockStatusPictureBoxOFF;
        private System.Windows.Forms.ToolTip helpToolTip;
    }
}
