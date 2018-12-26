namespace Xtream_ToolBox {
    partial class SensorFavoriteLocations {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorFavoriteLocations));
            this.webLocationComboBox = new System.Windows.Forms.ComboBox();
            this.fileLocationComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // webLocationComboBox
            // 
            this.webLocationComboBox.DisplayMember = "name";
            this.webLocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.webLocationComboBox, "webLocationComboBox");
            this.webLocationComboBox.Items.AddRange(new object[] {
            resources.GetString("webLocationComboBox.Items")});
            this.webLocationComboBox.Name = "webLocationComboBox";
            this.webLocationComboBox.TabStop = false;
            this.webLocationComboBox.SelectedIndexChanged += new System.EventHandler(this.webLocationComboBox_SelectedIndexChanged);
            // 
            // fileLocationComboBox
            // 
            this.fileLocationComboBox.DisplayMember = "name";
            this.fileLocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.fileLocationComboBox, "fileLocationComboBox");
            this.fileLocationComboBox.Items.AddRange(new object[] {
            resources.GetString("fileLocationComboBox.Items")});
            this.fileLocationComboBox.Name = "fileLocationComboBox";
            this.fileLocationComboBox.TabStop = false;
            this.fileLocationComboBox.SelectedIndexChanged += new System.EventHandler(this.fileLocationComboBox_SelectedIndexChanged);
            // 
            // SensorFavoriteLocations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.webLocationComboBox);
            this.Controls.Add(this.fileLocationComboBox);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "SensorFavoriteLocations";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox webLocationComboBox;
        private System.Windows.Forms.ComboBox fileLocationComboBox;
    }
}
