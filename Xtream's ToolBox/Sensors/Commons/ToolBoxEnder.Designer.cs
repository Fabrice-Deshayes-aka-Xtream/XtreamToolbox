namespace Xtream_ToolBox
{
    partial class ToolBoxEnder
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.enderPanel = new System.Windows.Forms.Panel();
            this.moveBoxEnder = new System.Windows.Forms.PictureBox();
            this.closerPictureBox = new System.Windows.Forms.PictureBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.enderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moveBoxEnder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // enderPanel
            // 
            this.enderPanel.BackColor = System.Drawing.Color.Transparent;
            this.enderPanel.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.background_right;
            this.enderPanel.Controls.Add(this.moveBoxEnder);
            this.enderPanel.Controls.Add(this.closerPictureBox);
            this.enderPanel.Location = new System.Drawing.Point(0, 0);
            this.enderPanel.Margin = new System.Windows.Forms.Padding(0);
            this.enderPanel.Name = "enderPanel";
            this.enderPanel.Size = new System.Drawing.Size(16, 48);
            this.enderPanel.TabIndex = 15;
            // 
            // moveBoxEnder
            // 
            this.moveBoxEnder.BackColor = System.Drawing.Color.Transparent;
            this.moveBoxEnder.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.moveBoxEnder.Location = new System.Drawing.Point(0, 15);
            this.moveBoxEnder.Margin = new System.Windows.Forms.Padding(0);
            this.moveBoxEnder.Name = "moveBoxEnder";
            this.moveBoxEnder.Size = new System.Drawing.Size(16, 33);
            this.moveBoxEnder.TabIndex = 4;
            this.moveBoxEnder.TabStop = false;
            this.moveBoxEnder.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseDown);
            this.moveBoxEnder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseMove);
            this.moveBoxEnder.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseUp);
            // 
            // closerPictureBox
            // 
            this.closerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.closerPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closerPictureBox.Location = new System.Drawing.Point(0, 0);
            this.closerPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.closerPictureBox.Name = "closerPictureBox";
            this.closerPictureBox.Size = new System.Drawing.Size(16, 15);
            this.closerPictureBox.TabIndex = 5;
            this.closerPictureBox.TabStop = false;
            this.closerPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CloserPictureBox_MouseClick);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // ToolBoxEnder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.enderPanel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ToolBoxEnder";
            this.Size = new System.Drawing.Size(16, 48);
            this.enderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.moveBoxEnder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel enderPanel;
        private System.Windows.Forms.PictureBox closerPictureBox;
        private System.Windows.Forms.PictureBox moveBoxEnder;
        private System.Windows.Forms.ToolTip helpToolTip;
    }
}
