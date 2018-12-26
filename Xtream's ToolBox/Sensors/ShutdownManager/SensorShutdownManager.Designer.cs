namespace Xtream_ToolBox {
    partial class SensorShutdownManager {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorShutdownManager));
            this.lowerButton = new System.Windows.Forms.PictureBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.upperButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lowerButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperButton)).BeginInit();
            this.SuspendLayout();
            // 
            // lowerButton
            // 
            resources.ApplyResources(this.lowerButton, "lowerButton");
            this.lowerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lowerButton.Image = global::Xtream_ToolBox.Properties.Resources.shutdownManager_shutdown;
            this.lowerButton.Name = "lowerButton";
            this.lowerButton.TabStop = false;
            this.helpToolTip.SetToolTip(this.lowerButton, resources.GetString("lowerButton.ToolTip"));
            this.lowerButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LowerButton_MouseClick);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // upperButton
            // 
            resources.ApplyResources(this.upperButton, "upperButton");
            this.upperButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.upperButton.Image = global::Xtream_ToolBox.Properties.Resources.shutdownManager_logoff;
            this.upperButton.Name = "upperButton";
            this.upperButton.TabStop = false;
            this.helpToolTip.SetToolTip(this.upperButton, resources.GetString("upperButton.ToolTip"));
            this.upperButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UpperButton_MouseClick);
            // 
            // SensorShutdownManager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lowerButton);
            this.Controls.Add(this.upperButton);
            this.DoubleBuffered = true;
            this.Name = "SensorShutdownManager";
            this.helpToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            ((System.ComponentModel.ISupportInitialize)(this.lowerButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox lowerButton;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.PictureBox upperButton;
    }
}
