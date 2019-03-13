namespace Xtream_ToolBox
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.closerPictureBox = new System.Windows.Forms.PictureBox();
            this.moverRightPictureBox = new System.Windows.Forms.PictureBox();
            this.moverLeftPictureBox = new System.Windows.Forms.PictureBox();
            this.productNameLabel = new System.Windows.Forms.Label();
            this.homepageLabel = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverRightPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverLeftPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // productNameLabel
            // 
            this.productNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.productNameLabel.Font = new System.Drawing.Font("Arial Black", 15F);
            this.productNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.productNameLabel.Location = new System.Drawing.Point(22, 115);
            this.productNameLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.productNameLabel.Name = "productNameLabel";
            this.productNameLabel.Size = new System.Drawing.Size(357, 22);
            this.productNameLabel.TabIndex = 32;
            this.productNameLabel.Text = "Xtream\'s ToolBox";
            this.productNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // homepageLabel
            // 
            this.homepageLabel.AutoSize = true;
            this.homepageLabel.BackColor = System.Drawing.Color.Transparent;
            this.homepageLabel.Location = new System.Drawing.Point(145, 458);
            this.homepageLabel.Name = "homepageLabel";
            this.homepageLabel.Size = new System.Drawing.Size(111, 13);
            this.homepageLabel.TabIndex = 46;
            this.homepageLabel.TabStop = true;
            this.homepageLabel.Text = "http://www.xtream.be";
            this.homepageLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomepageLabel_LinkClicked);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 8F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(15, 266);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label4.MaximumSize = new System.Drawing.Size(0, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "G.A.N.T. by Mattahan";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 8F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(15, 300);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label6.MaximumSize = new System.Drawing.Size(0, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 13);
            this.label6.TabIndex = 49;
            this.label6.Text = "Refreshcl by tpdk";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 8F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(15, 317);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label7.MaximumSize = new System.Drawing.Size(0, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "IconBuffet studio";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(15, 246);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label8.MaximumSize = new System.Drawing.Size(0, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 15);
            this.label8.TabIndex = 47;
            this.label8.Text = "Graphics extract from";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(104, 198);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label9.MaximumSize = new System.Drawing.Size(0, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "Fabrice Deshayes aka Xtream";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(104, 181);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label10.MaximumSize = new System.Drawing.Size(0, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(190, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = "Design & Development";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.UseMnemonic = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 8F);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(15, 282);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label11.MaximumSize = new System.Drawing.Size(0, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 17);
            this.label11.TabIndex = 54;
            this.label11.Text = "Weather icons by Wojciech Grzanka";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 8F);
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(198, 297);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label12.MaximumSize = new System.Drawing.Size(0, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(190, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Mattias Sjögren (ShellShortcut.cs)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(198, 246);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label13.MaximumSize = new System.Drawing.Size(0, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(190, 15);
            this.label13.TabIndex = 55;
            this.label13.Text = "Use some code from";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 8F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(198, 265);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label14.MaximumSize = new System.Drawing.Size(0, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(190, 13);
            this.label14.TabIndex = 58;
            this.label14.Text = "Stuart Konen (C2DPushGraph)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Arial", 8F);
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(198, 281);
            this.label16.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label16.MaximumSize = new System.Drawing.Size(0, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(190, 13);
            this.label16.TabIndex = 57;
            this.label16.Text = "James Newton-King (Newtonsoft)";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(198, 313);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label1.MaximumSize = new System.Drawing.Size(0, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 60;
            this.label1.Text = "Valer BOCAN (NTPClient.cs)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.versionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.versionLabel.Location = new System.Drawing.Point(104, 139);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.versionLabel.MaximumSize = new System.Drawing.Size(0, 17);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(190, 15);
            this.versionLabel.TabIndex = 62;
            this.versionLabel.Text = "version yyyy.mm.dd";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(198, 329);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.label2.MaximumSize = new System.Drawing.Size(0, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Syed Mehroz Alam (Analog Clock)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::Xtream_ToolBox.Properties.Resources.GitHubChangeLog;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(44, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(319, 77);
            this.button1.TabIndex = 64;
            this.button1.Text = "Display CHANGELOG on GitHub";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OpenChangeLogOnGithub_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Xtream_ToolBox.Properties.Resources.Logo_Xtream;
            this.pictureBox1.Location = new System.Drawing.Point(51, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.extendInfosBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 480);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.productNameLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.homepageLabel);
            this.Controls.Add(this.closerPictureBox);
            this.Controls.Add(this.moverRightPictureBox);
            this.Controls.Add(this.moverLeftPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverRightPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverLeftPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox closerPictureBox;
        private System.Windows.Forms.PictureBox moverRightPictureBox;
        private System.Windows.Forms.PictureBox moverLeftPictureBox;
        private System.Windows.Forms.Label productNameLabel;
        private System.Windows.Forms.LinkLabel homepageLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}