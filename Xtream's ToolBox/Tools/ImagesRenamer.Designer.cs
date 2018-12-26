namespace Xtream_ToolBox {
    partial class PhotosRenamerForm {
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotosRenamerForm));
            this.imagesFolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.renamerBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchPatternComboBox = new System.Windows.Forms.ComboBox();
            this.searchPattenrLabel = new System.Windows.Forms.Label();
            this.cameraPictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.renameButton = new System.Windows.Forms.Button();
            this.SimulateButton = new System.Windows.Forms.Button();
            this.normalModeRadioButton = new System.Windows.Forms.RadioButton();
            this.recursiveModeRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.imagesPathTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            this.resultListBox = new System.Windows.Forms.ListBox();
            this.scrollLockCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.clearButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imagesFolderBrowserDialog
            // 
            resources.ApplyResources(this.imagesFolderBrowserDialog, "imagesFolderBrowserDialog");
            this.imagesFolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.imagesFolderBrowserDialog.ShowNewFolderButton = false;
            // 
            // renamerBackgroundWorker
            // 
            this.renamerBackgroundWorker.WorkerReportsProgress = true;
            this.renamerBackgroundWorker.WorkerSupportsCancellation = true;
            this.renamerBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.renamerBackgroundWorker_DoWork);
            this.renamerBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.renamerBackgroundWorker_ProgressChanged);
            this.renamerBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.renamerBackgroundWorker_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchPatternComboBox);
            this.panel1.Controls.Add(this.searchPattenrLabel);
            this.panel1.Controls.Add(this.cameraPictureBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.renameButton);
            this.panel1.Controls.Add(this.SimulateButton);
            this.panel1.Controls.Add(this.normalModeRadioButton);
            this.panel1.Controls.Add(this.recursiveModeRadioButton);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.browseButton);
            this.panel1.Controls.Add(this.imagesPathTextBox);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // searchPatternComboBox
            // 
            this.searchPatternComboBox.FormattingEnabled = true;
            this.searchPatternComboBox.Items.AddRange(new object[] {
            resources.GetString("searchPatternComboBox.Items"),
            resources.GetString("searchPatternComboBox.Items1"),
            resources.GetString("searchPatternComboBox.Items2"),
            resources.GetString("searchPatternComboBox.Items3"),
            resources.GetString("searchPatternComboBox.Items4")});
            resources.ApplyResources(this.searchPatternComboBox, "searchPatternComboBox");
            this.searchPatternComboBox.Name = "searchPatternComboBox";
            // 
            // searchPattenrLabel
            // 
            resources.ApplyResources(this.searchPattenrLabel, "searchPattenrLabel");
            this.searchPattenrLabel.Name = "searchPattenrLabel";
            // 
            // cameraPictureBox
            // 
            this.cameraPictureBox.Image = global::Xtream_ToolBox.Properties.Resources.camera;
            resources.ApplyResources(this.cameraPictureBox, "cameraPictureBox");
            this.cameraPictureBox.Name = "cameraPictureBox";
            this.cameraPictureBox.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // renameButton
            // 
            resources.ApplyResources(this.renameButton, "renameButton");
            this.renameButton.Image = global::Xtream_ToolBox.Properties.Resources.rename;
            this.renameButton.Name = "renameButton";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // SimulateButton
            // 
            resources.ApplyResources(this.SimulateButton, "SimulateButton");
            this.SimulateButton.Image = global::Xtream_ToolBox.Properties.Resources.simulate;
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // normalModeRadioButton
            // 
            resources.ApplyResources(this.normalModeRadioButton, "normalModeRadioButton");
            this.normalModeRadioButton.Checked = true;
            this.normalModeRadioButton.Name = "normalModeRadioButton";
            this.normalModeRadioButton.TabStop = true;
            this.normalModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // recursiveModeRadioButton
            // 
            resources.ApplyResources(this.recursiveModeRadioButton, "recursiveModeRadioButton");
            this.recursiveModeRadioButton.Name = "recursiveModeRadioButton";
            this.recursiveModeRadioButton.TabStop = true;
            this.recursiveModeRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // browseButton
            // 
            this.browseButton.Image = global::Xtream_ToolBox.Properties.Resources.folder_open_16;
            resources.ApplyResources(this.browseButton, "browseButton");
            this.browseButton.Name = "browseButton";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // imagesPathTextBox
            // 
            resources.ApplyResources(this.imagesPathTextBox, "imagesPathTextBox");
            this.imagesPathTextBox.Name = "imagesPathTextBox";
            this.imagesPathTextBox.TextChanged += new System.EventHandler(this.imagesPathTextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.cancelButton);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.Name = "progressBar";
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // resultListBox
            // 
            resources.ApplyResources(this.resultListBox, "resultListBox");
            this.resultListBox.Name = "resultListBox";
            // 
            // scrollLockCheckBox
            // 
            resources.ApplyResources(this.scrollLockCheckBox, "scrollLockCheckBox");
            this.scrollLockCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.scrollLockCheckBox.Name = "scrollLockCheckBox";
            this.scrollLockCheckBox.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Name = "label4";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.scrollLockCheckBox);
            this.panel4.Controls.Add(this.clearButton);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // clearButton
            // 
            resources.ApplyResources(this.clearButton, "clearButton");
            this.clearButton.Image = global::Xtream_ToolBox.Properties.Resources.trash_16;
            this.clearButton.Name = "clearButton";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.resultListBox);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // PhotosRenamerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "PhotosRenamerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhotosRenamerForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog imagesFolderBrowserDialog;
        private System.ComponentModel.BackgroundWorker renamerBackgroundWorker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton normalModeRadioButton;
        private System.Windows.Forms.RadioButton recursiveModeRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox imagesPathTextBox;
        private System.Windows.Forms.PictureBox cameraPictureBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button SimulateButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.CheckBox scrollLockCheckBox;
        private System.Windows.Forms.ListBox resultListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox searchPatternComboBox;
        private System.Windows.Forms.Label searchPattenrLabel;
    }
}