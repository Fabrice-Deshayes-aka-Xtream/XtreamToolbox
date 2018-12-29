namespace Xtream_ToolBox.Sensors
{
    partial class SensorNotepadExtendedPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorNotepadExtendedPanel));
            this.closeExtendedInfosPictureBox = new System.Windows.Forms.PictureBox();
            this.notepadTextBox = new System.Windows.Forms.TextBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
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
            // notepadTextBox
            // 
            this.notepadTextBox.AcceptsReturn = true;
            this.notepadTextBox.AcceptsTab = true;
            resources.ApplyResources(this.notepadTextBox, "notepadTextBox");
            this.notepadTextBox.Name = "notepadTextBox";
            this.notepadTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NotepadTextBox_KeyUp);
            // 
            // helpToolTip
            // 
            this.helpToolTip.ShowAlways = true;
            // 
            // loadButton
            // 
            resources.ApplyResources(this.loadButton, "loadButton");
            this.loadButton.Image = global::Xtream_ToolBox.Properties.Resources.folder_open_16;
            this.loadButton.MinimumSize = new System.Drawing.Size(0, 24);
            this.loadButton.Name = "loadButton";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Image = global::Xtream_ToolBox.Properties.Resources.save_16;
            this.saveButton.MinimumSize = new System.Drawing.Size(0, 24);
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.clearButton.Image = global::Xtream_ToolBox.Properties.Resources.trash_16;
            this.clearButton.MinimumSize = new System.Drawing.Size(0, 24);
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.saveButton);
            this.flowLayoutPanel1.Controls.Add(this.loadButton);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "txt";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            // 
            // SensorNotepadExtendedPanel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.extendInfosBackground;
            resources.ApplyResources(this, "$this");
            this.ControlBox = false;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.notepadTextBox);
            this.Controls.Add(this.closeExtendedInfosPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SensorNotepadExtendedPanel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closeExtendedInfosPictureBox;
        private System.Windows.Forms.TextBox notepadTextBox;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}