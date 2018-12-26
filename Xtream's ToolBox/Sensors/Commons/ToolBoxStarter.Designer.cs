namespace Xtream_ToolBox {
    partial class ToolBoxStarter {
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
            this.starterPanel = new System.Windows.Forms.Panel();
            this.moveBox = new System.Windows.Forms.PictureBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.starterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveBox)).BeginInit();
            this.SuspendLayout();
            // 
            // starterPanel
            // 
            this.starterPanel.BackColor = System.Drawing.Color.Transparent;
            this.starterPanel.Controls.Add(this.moveBox);
            this.starterPanel.Location = new System.Drawing.Point(0, 0);
            this.starterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.starterPanel.Name = "starterPanel";
            this.starterPanel.Size = new System.Drawing.Size(16, 48);
            this.starterPanel.TabIndex = 14;
            // 
            // moveBox
            // 
            this.moveBox.BackColor = System.Drawing.Color.Transparent;
            this.moveBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.moveBox.Image = global::Xtream_ToolBox.Properties.Resources.background_left;
            this.moveBox.Location = new System.Drawing.Point(0, 0);
            this.moveBox.Margin = new System.Windows.Forms.Padding(0);
            this.moveBox.Name = "moveBox";
            this.moveBox.Size = new System.Drawing.Size(16, 48);
            this.moveBox.TabIndex = 4;
            this.moveBox.TabStop = false;
            this.moveBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveBox_MouseDown);
            this.moveBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.moveBox_MouseMove);
            this.moveBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.moveBox_MouseUp);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // ToolBoxStarter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.starterPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ToolBoxStarter";
            this.Size = new System.Drawing.Size(16, 48);
            this.starterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moveBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel starterPanel;
        private System.Windows.Forms.PictureBox moveBox;
        private System.Windows.Forms.ToolTip helpToolTip;
    }
}
