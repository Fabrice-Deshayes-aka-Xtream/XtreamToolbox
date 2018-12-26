namespace Xtream_ToolBox {
    partial class About {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.closerPictureBox = new System.Windows.Forms.PictureBox();
            this.moverRightPictureBox = new System.Windows.Forms.PictureBox();
            this.moverLeftPictureBox = new System.Windows.Forms.PictureBox();
            this.toolBoxLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.developerLabel = new System.Windows.Forms.Label();
            this.changeLogTextBox = new System.Windows.Forms.TextBox();
            this.developerValuelabel = new System.Windows.Forms.Label();
            this.homepageLabel = new System.Windows.Forms.LinkLabel();
            this.designerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelFramework = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverRightPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverLeftPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closerPictureBox
            // 
            this.closerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.closerPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closerPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.closerPictureBox.Location = new System.Drawing.Point(385, 0);
            this.closerPictureBox.Name = "closerPictureBox";
            this.closerPictureBox.Size = new System.Drawing.Size(15, 20);
            this.closerPictureBox.TabIndex = 39;
            this.closerPictureBox.TabStop = false;
            this.closerPictureBox.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // moverRightPictureBox
            // 
            this.moverRightPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.moverRightPictureBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.moverRightPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.moverRightPictureBox.Location = new System.Drawing.Point(385, 20);
            this.moverRightPictureBox.Name = "moverRightPictureBox";
            this.moverRightPictureBox.Size = new System.Drawing.Size(15, 460);
            this.moverRightPictureBox.TabIndex = 38;
            this.moverRightPictureBox.TabStop = false;
            this.moverRightPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseDown);
            this.moverRightPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseMove);
            this.moverRightPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseUp);
            // 
            // moverLeftPictureBox
            // 
            this.moverLeftPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.moverLeftPictureBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.moverLeftPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.moverLeftPictureBox.Location = new System.Drawing.Point(0, 0);
            this.moverLeftPictureBox.Name = "moverLeftPictureBox";
            this.moverLeftPictureBox.Size = new System.Drawing.Size(15, 480);
            this.moverLeftPictureBox.TabIndex = 37;
            this.moverLeftPictureBox.TabStop = false;
            this.moverLeftPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseDown);
            this.moverLeftPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseMove);
            this.moverLeftPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseUp);
            // 
            // toolBoxLogoPictureBox
            // 
            this.toolBoxLogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.toolBoxLogoPictureBox.Image = global::Xtream_ToolBox.Properties.Resources.RefreshCL;
            this.toolBoxLogoPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolBoxLogoPictureBox.Location = new System.Drawing.Point(17, -9);
            this.toolBoxLogoPictureBox.Name = "toolBoxLogoPictureBox";
            this.toolBoxLogoPictureBox.Size = new System.Drawing.Size(171, 180);
            this.toolBoxLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.toolBoxLogoPictureBox.TabIndex = 35;
            this.toolBoxLogoPictureBox.TabStop = false;
            // 
            // productNameLabel
            // 
            this.productNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.productNameLabel.Font = new System.Drawing.Font("Arial Black", 15F);
            this.productNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.productNameLabel.Location = new System.Drawing.Point(187, 3);
            this.productNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(190, 22);
            this.productNameLabel.TabIndex = 32;
            this.productNameLabel.Text = "Xtream ToolBox";
            this.productNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // developerLabel
            // 
            this.developerLabel.BackColor = System.Drawing.Color.Transparent;
            this.developerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.developerLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.developerLabel.Location = new System.Drawing.Point(187, 61);
            this.developerLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.developerLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.developerLabel.Name = "developerLabel";
            this.developerLabel.Size = new System.Drawing.Size(190, 15);
            this.developerLabel.TabIndex = 33;
            this.developerLabel.Text = "Conception & Developpement";
            this.developerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.developerLabel.UseMnemonic = false;
            // 
            // changeLogTextBox
            // 
            this.changeLogTextBox.Location = new System.Drawing.Point(20, 177);
            this.changeLogTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.changeLogTextBox.Multiline = true;
            this.changeLogTextBox.Name = "changeLogTextBox";
            this.changeLogTextBox.ReadOnly = true;
            this.changeLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.changeLogTextBox.Size = new System.Drawing.Size(360, 279);
            this.changeLogTextBox.TabIndex = 34;
            this.changeLogTextBox.TabStop = false;
            this.changeLogTextBox.Text = resources.GetString("changeLogTextBox.Text");
            // 
            // developerValuelabel
            // 
            this.developerValuelabel.BackColor = System.Drawing.Color.Transparent;
            this.developerValuelabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.developerValuelabel.Location = new System.Drawing.Point(187, 76);
            this.developerValuelabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.developerValuelabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.developerValuelabel.Name = "developerValuelabel";
            this.developerValuelabel.Size = new System.Drawing.Size(190, 17);
            this.developerValuelabel.TabIndex = 43;
            this.developerValuelabel.Text = "Fabrice Deshayes aka Xtream";
            this.developerValuelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homepageLabel
            // 
            this.homepageLabel.AutoSize = true;
            this.homepageLabel.BackColor = System.Drawing.Color.Transparent;
            this.homepageLabel.Location = new System.Drawing.Point(145, 459);
            this.homepageLabel.Name = "homepageLabel";
            this.homepageLabel.Size = new System.Drawing.Size(111, 13);
            this.homepageLabel.TabIndex = 46;
            this.homepageLabel.TabStop = true;
            this.homepageLabel.Text = "http://www.xtream.be";
            this.homepageLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomepageLabel_LinkClicked);
            // 
            // designerLabel
            // 
            this.designerLabel.BackColor = System.Drawing.Color.Transparent;
            this.designerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.designerLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.designerLabel.Location = new System.Drawing.Point(187, 101);
            this.designerLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.designerLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.designerLabel.Name = "designerLabel";
            this.designerLabel.Size = new System.Drawing.Size(190, 15);
            this.designerLabel.TabIndex = 47;
            this.designerLabel.Text = "Graphics extract from";
            this.designerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(187, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label2.MaximumSize = new System.Drawing.Size(0, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Refreshcl by tpdk";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(187, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label3.MaximumSize = new System.Drawing.Size(0, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Gant by mattahan";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(187, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label1.MaximumSize = new System.Drawing.Size(0, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "IconBuffet studio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFramework
            // 
            this.labelFramework.BackColor = System.Drawing.Color.Transparent;
            this.labelFramework.Location = new System.Drawing.Point(187, 31);
            this.labelFramework.Margin = new System.Windows.Forms.Padding(0);
            this.labelFramework.Name = "labelFramework";
            this.labelFramework.Size = new System.Drawing.Size(190, 13);
            this.labelFramework.TabIndex = 53;
            this.labelFramework.Text = "labelFramework";
            this.labelFramework.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 8F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(187, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label5.MaximumSize = new System.Drawing.Size(0, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Weather Iconset by Wojciech Grzanka";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // About
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.extendInfosBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelFramework);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.developerLabel);
            this.Controls.Add(this.developerValuelabel);
            this.Controls.Add(this.designerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.homepageLabel);
            this.Controls.Add(this.closerPictureBox);
            this.Controls.Add(this.moverRightPictureBox);
            this.Controls.Add(this.moverLeftPictureBox);
            this.Controls.Add(this.changeLogTextBox);
            this.Controls.Add(this.toolBoxLogoPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverRightPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverLeftPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closerPictureBox;
        private System.Windows.Forms.PictureBox moverRightPictureBox;
        private System.Windows.Forms.PictureBox moverLeftPictureBox;
        private System.Windows.Forms.PictureBox toolBoxLogoPictureBox;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.Label developerLabel;
        private System.Windows.Forms.TextBox changeLogTextBox;
        private System.Windows.Forms.Label developerValuelabel;
        private System.Windows.Forms.LinkLabel homepageLabel;
        private System.Windows.Forms.Label designerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelFramework;
        private System.Windows.Forms.Label label5;

    }
}