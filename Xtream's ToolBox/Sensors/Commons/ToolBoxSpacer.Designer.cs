namespace Xtream_ToolBox {
    partial class SensorSpacer {
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
            System.Windows.Forms.Panel separatorPanel1;
            separatorPanel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // separatorPanel1
            // 
            separatorPanel1.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.background_separator;
            separatorPanel1.Location = new System.Drawing.Point(0, 0);
            separatorPanel1.Margin = new System.Windows.Forms.Padding(0);
            separatorPanel1.Name = "separatorPanel1";
            separatorPanel1.Size = new System.Drawing.Size(10, 48);
            separatorPanel1.TabIndex = 16;
            // 
            // SensorSpacer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(separatorPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SensorSpacer";
            this.Size = new System.Drawing.Size(10, 48);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
