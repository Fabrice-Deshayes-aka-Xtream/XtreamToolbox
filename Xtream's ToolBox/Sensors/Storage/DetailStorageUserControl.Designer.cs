namespace Xtream_ToolBox.Sensors {
    partial class DetailStorageUserControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailStorageUserControl));
            this.devicePictureBox = new System.Windows.Forms.PictureBox();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.deviceSpacePictureBox = new System.Windows.Forms.PictureBox();
            this.sizeInfoLabel = new System.Windows.Forms.Label();
            this.deviceFormatLabel = new System.Windows.Forms.Label();
            this.deviceSpaceBackgroundPictureBox = new System.Windows.Forms.PictureBox();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.typeLabel = new System.Windows.Forms.Label();
            this.readWriteGraph = new CustomUIControls.Graphing.C2DPushGraph();
            this.readLegendPictureBox = new System.Windows.Forms.PictureBox();
            this.writeLegendPictureBox = new System.Windows.Forms.PictureBox();
            this.readLegendLabel = new System.Windows.Forms.Label();
            this.writeLegendLabel = new System.Windows.Forms.Label();
            this.readMaxLabel = new System.Windows.Forms.Label();
            this.writeMaxLabel = new System.Windows.Forms.Label();
            this.bytesReadBySecPerformanceCounter = new System.Diagnostics.PerformanceCounter();
            this.bytesWriteBySecPerformanceCounter = new System.Diagnostics.PerformanceCounter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.devicePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpacePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpaceBackgroundPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.readLegendPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeLegendPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bytesReadBySecPerformanceCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bytesWriteBySecPerformanceCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // devicePictureBox
            // 
            this.devicePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.devicePictureBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.devicePictureBox, "devicePictureBox");
            this.devicePictureBox.Name = "devicePictureBox";
            this.devicePictureBox.TabStop = false;
            this.helpToolTip.SetToolTip(this.devicePictureBox, resources.GetString("devicePictureBox.ToolTip"));
            // 
            // deviceNameLabel
            // 
            resources.ApplyResources(this.deviceNameLabel, "deviceNameLabel");
            this.deviceNameLabel.Name = "deviceNameLabel";
            // 
            // deviceSpacePictureBox
            // 
            this.deviceSpacePictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter;
            resources.ApplyResources(this.deviceSpacePictureBox, "deviceSpacePictureBox");
            this.deviceSpacePictureBox.Name = "deviceSpacePictureBox";
            this.deviceSpacePictureBox.TabStop = false;
            // 
            // sizeInfoLabel
            // 
            resources.ApplyResources(this.sizeInfoLabel, "sizeInfoLabel");
            this.sizeInfoLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.sizeInfoLabel.Name = "sizeInfoLabel";
            // 
            // deviceFormatLabel
            // 
            resources.ApplyResources(this.deviceFormatLabel, "deviceFormatLabel");
            this.deviceFormatLabel.ForeColor = System.Drawing.Color.DarkGreen;
            this.deviceFormatLabel.Name = "deviceFormatLabel";
            // 
            // deviceSpaceBackgroundPictureBox
            // 
            this.deviceSpaceBackgroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.deviceSpaceBackgroundPictureBox.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.deviceSpaceBackgroundPictureBox, "deviceSpaceBackgroundPictureBox");
            this.deviceSpaceBackgroundPictureBox.Name = "deviceSpaceBackgroundPictureBox";
            this.deviceSpaceBackgroundPictureBox.TabStop = false;
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 10;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // typeLabel
            // 
            resources.ApplyResources(this.typeLabel, "typeLabel");
            this.typeLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.typeLabel.Name = "typeLabel";
            // 
            // readWriteGraph
            // 
            this.readWriteGraph.AutoAdjustPeek = false;
            this.readWriteGraph.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.readWriteGraph, "readWriteGraph");
            this.readWriteGraph.GridColor = System.Drawing.Color.DarkGreen;
            this.readWriteGraph.GridSize = ((ushort)(5));
            this.readWriteGraph.HighQuality = true;
            this.readWriteGraph.LineInterval = ((ushort)(1));
            this.readWriteGraph.MaxLabel = "";
            this.readWriteGraph.MaxPeekMagnitude = 1;
            this.readWriteGraph.MinLabel = "";
            this.readWriteGraph.MinPeekMagnitude = 0;
            this.readWriteGraph.Name = "readWriteGraph";
            this.readWriteGraph.ShowGrid = false;
            this.readWriteGraph.ShowLabels = false;
            this.readWriteGraph.TextColor = System.Drawing.Color.Yellow;
            // 
            // readLegendPictureBox
            // 
            this.readLegendPictureBox.Image = global::Xtream_ToolBox.Properties.Resources.box_rouge;
            resources.ApplyResources(this.readLegendPictureBox, "readLegendPictureBox");
            this.readLegendPictureBox.Name = "readLegendPictureBox";
            this.readLegendPictureBox.TabStop = false;
            // 
            // writeLegendPictureBox
            // 
            this.writeLegendPictureBox.Image = global::Xtream_ToolBox.Properties.Resources.box_bleu;
            resources.ApplyResources(this.writeLegendPictureBox, "writeLegendPictureBox");
            this.writeLegendPictureBox.Name = "writeLegendPictureBox";
            this.writeLegendPictureBox.TabStop = false;
            // 
            // readLegendLabel
            // 
            resources.ApplyResources(this.readLegendLabel, "readLegendLabel");
            this.readLegendLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.readLegendLabel.Name = "readLegendLabel";
            // 
            // writeLegendLabel
            // 
            resources.ApplyResources(this.writeLegendLabel, "writeLegendLabel");
            this.writeLegendLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.writeLegendLabel.Name = "writeLegendLabel";
            // 
            // readMaxLabel
            // 
            resources.ApplyResources(this.readMaxLabel, "readMaxLabel");
            this.readMaxLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.readMaxLabel.Name = "readMaxLabel";
            // 
            // writeMaxLabel
            // 
            resources.ApplyResources(this.writeMaxLabel, "writeMaxLabel");
            this.writeMaxLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.writeMaxLabel.Name = "writeMaxLabel";
            // 
            // bytesReadBySecPerformanceCounter
            // 
            this.bytesReadBySecPerformanceCounter.CategoryName = "LogicalDisk";
            this.bytesReadBySecPerformanceCounter.CounterName = "Disk Read Bytes/sec";
            // 
            // bytesWriteBySecPerformanceCounter
            // 
            this.bytesWriteBySecPerformanceCounter.CategoryName = "LogicalDisk";
            this.bytesWriteBySecPerformanceCounter.CounterName = "Disk Write Bytes/sec";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // DetailStorageUserControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.writeMaxLabel);
            this.Controls.Add(this.readMaxLabel);
            this.Controls.Add(this.writeLegendLabel);
            this.Controls.Add(this.readLegendLabel);
            this.Controls.Add(this.writeLegendPictureBox);
            this.Controls.Add(this.readLegendPictureBox);
            this.Controls.Add(this.readWriteGraph);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.deviceFormatLabel);
            this.Controls.Add(this.sizeInfoLabel);
            this.Controls.Add(this.deviceSpacePictureBox);
            this.Controls.Add(this.deviceSpaceBackgroundPictureBox);
            this.Controls.Add(this.deviceNameLabel);
            this.Controls.Add(this.devicePictureBox);
            this.DoubleBuffered = true;
            this.Name = "DetailStorageUserControl";
            ((System.ComponentModel.ISupportInitialize)(this.devicePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpacePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceSpaceBackgroundPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.readLegendPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writeLegendPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bytesReadBySecPerformanceCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bytesWriteBySecPerformanceCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox devicePictureBox;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.PictureBox deviceSpacePictureBox;
        private System.Windows.Forms.Label sizeInfoLabel;
        private System.Windows.Forms.Label deviceFormatLabel;
        private System.Windows.Forms.PictureBox deviceSpaceBackgroundPictureBox;
        private System.Windows.Forms.ToolTip helpToolTip;
        private System.Windows.Forms.Label typeLabel;
        private System.Diagnostics.PerformanceCounter bytesReadBySecPerformanceCounter;
        private System.Diagnostics.PerformanceCounter bytesWriteBySecPerformanceCounter;
        private CustomUIControls.Graphing.C2DPushGraph readWriteGraph;
        private System.Windows.Forms.PictureBox readLegendPictureBox;
        private System.Windows.Forms.PictureBox writeLegendPictureBox;
        private System.Windows.Forms.Label readLegendLabel;
        private System.Windows.Forms.Label writeLegendLabel;
        private System.Windows.Forms.Label readMaxLabel;
        private System.Windows.Forms.Label writeMaxLabel;
        private System.Windows.Forms.Timer timer1;
    }
}
