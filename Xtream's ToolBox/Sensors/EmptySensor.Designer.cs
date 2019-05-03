namespace XtreamToolbox.Sensors {
    partial class EmptySensor {
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
            this.initialisationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
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
            // 
            // EmptySensor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "EmptySensor";
            this.Size = new System.Drawing.Size(48, 48);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker initialisationBackgroundWorker;
        private System.Windows.Forms.ToolTip helpToolTip;
    }
}
