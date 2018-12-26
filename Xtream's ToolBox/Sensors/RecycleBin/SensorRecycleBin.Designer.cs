namespace Xtream_ToolBox {
    partial class SensorRecycleBin {
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
            this.recycleBinTimer = new System.Windows.Forms.Timer(this.components);
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // recycleBinTimer
            // 
            this.recycleBinTimer.Enabled = true;
            this.recycleBinTimer.Interval = 1000;
            this.recycleBinTimer.Tick += new System.EventHandler(this.recycleBinTimer_Tick);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // SensorRecycleBin
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.TrashEmpty;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SensorRecycleBin";
            this.Size = new System.Drawing.Size(42, 48);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.SensorRecycleBin_DragDrop);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trashFull_MouseClick);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.SensorRecycleBin_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer recycleBinTimer;
        private System.Windows.Forms.ToolTip helpToolTip;
    }
}
