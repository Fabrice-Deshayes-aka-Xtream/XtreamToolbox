namespace XtreamToolbox
{
    partial class SensorFavoriteLocations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorFavoriteLocations));
            this.DocumentsPictureBox = new System.Windows.Forms.PictureBox();
            this.MusicsPictureBox = new System.Windows.Forms.PictureBox();
            this.ImagesPictureBox = new System.Windows.Forms.PictureBox();
            this.DownloadsPictureBox = new System.Windows.Forms.PictureBox();
            this.VideosPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagesPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideosPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DocumentsPictureBox
            // 
            this.DocumentsPictureBox.BackgroundImage = global::XtreamToolbox.Properties.Resources.fav_documents;
            resources.ApplyResources(this.DocumentsPictureBox, "DocumentsPictureBox");
            this.DocumentsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DocumentsPictureBox.Name = "DocumentsPictureBox";
            this.DocumentsPictureBox.TabStop = false;
            this.DocumentsPictureBox.Click += new System.EventHandler(this.DocumentsPictureBox_Click);
            // 
            // MusicsPictureBox
            // 
            this.MusicsPictureBox.BackgroundImage = global::XtreamToolbox.Properties.Resources.fav_Music;
            resources.ApplyResources(this.MusicsPictureBox, "MusicsPictureBox");
            this.MusicsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MusicsPictureBox.Name = "MusicsPictureBox";
            this.MusicsPictureBox.TabStop = false;
            this.MusicsPictureBox.Click += new System.EventHandler(this.MusicsPictureBox_Click);
            // 
            // ImagesPictureBox
            // 
            this.ImagesPictureBox.BackgroundImage = global::XtreamToolbox.Properties.Resources.fav_images;
            resources.ApplyResources(this.ImagesPictureBox, "ImagesPictureBox");
            this.ImagesPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImagesPictureBox.Name = "ImagesPictureBox";
            this.ImagesPictureBox.TabStop = false;
            this.ImagesPictureBox.Click += new System.EventHandler(this.ImagesPictureBox_Click);
            // 
            // DownloadsPictureBox
            // 
            this.DownloadsPictureBox.BackgroundImage = global::XtreamToolbox.Properties.Resources.fav_downloads;
            resources.ApplyResources(this.DownloadsPictureBox, "DownloadsPictureBox");
            this.DownloadsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownloadsPictureBox.Name = "DownloadsPictureBox";
            this.DownloadsPictureBox.TabStop = false;
            this.DownloadsPictureBox.Click += new System.EventHandler(this.DownloadsPictureBox_Click);
            // 
            // VideosPictureBox
            // 
            this.VideosPictureBox.BackgroundImage = global::XtreamToolbox.Properties.Resources.fav_videos;
            resources.ApplyResources(this.VideosPictureBox, "VideosPictureBox");
            this.VideosPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.VideosPictureBox.Name = "VideosPictureBox";
            this.VideosPictureBox.TabStop = false;
            this.VideosPictureBox.Click += new System.EventHandler(this.VideosPictureBox_Click);
            // 
            // SensorFavoriteLocations
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.VideosPictureBox);
            this.Controls.Add(this.DownloadsPictureBox);
            this.Controls.Add(this.ImagesPictureBox);
            this.Controls.Add(this.MusicsPictureBox);
            this.Controls.Add(this.DocumentsPictureBox);
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "SensorFavoriteLocations";
            ((System.ComponentModel.ISupportInitialize)(this.DocumentsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagesPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownloadsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VideosPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox DocumentsPictureBox;
        private System.Windows.Forms.PictureBox MusicsPictureBox;
        private System.Windows.Forms.PictureBox ImagesPictureBox;
        private System.Windows.Forms.PictureBox DownloadsPictureBox;
        private System.Windows.Forms.PictureBox VideosPictureBox;
    }
}
