namespace XtreamToolbox.Sensors {
    partial class SensorSystemInfos {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorSystemInfos));
            this.cpu_used_counter = new System.Diagnostics.PerformanceCounter();
            this.cpuRamTimer = new System.Windows.Forms.Timer(this.components);
            this.cpuVumeter = new System.Windows.Forms.PictureBox();
            this.vumeterContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.switchToGraphModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ramVumeter = new System.Windows.Forms.PictureBox();
            this.cpuLabel = new System.Windows.Forms.Label();
            this.ramLabel = new System.Windows.Forms.Label();
            this.lanLabel = new System.Windows.Forms.Label();
            this.lanVumeterD = new System.Windows.Forms.PictureBox();
            this.wanVumeterD = new System.Windows.Forms.PictureBox();
            this.wanLabel = new System.Windows.Forms.Label();
            this.lanVumeterU = new System.Windows.Forms.PictureBox();
            this.wanVumeterU = new System.Windows.Forms.PictureBox();
            this.cpuVumeterBg = new System.Windows.Forms.PictureBox();
            this.ramVumeterBg = new System.Windows.Forms.PictureBox();
            this.lanVumeterDBg = new System.Windows.Forms.PictureBox();
            this.lanVumeterUBg = new System.Windows.Forms.PictureBox();
            this.wanVumeterDBg = new System.Windows.Forms.PictureBox();
            this.wanVumeterUBg = new System.Windows.Forms.PictureBox();
            this.c2DPushGraph = new CustomUIControls.Graphing.C2DPushGraph();
            this.graphContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cpuLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ramLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lanReceivedRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lanSendRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wanReceivedRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wanSendRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SwithToVumeterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ram_physical_free = new System.Diagnostics.PerformanceCounter();
            this.initialisationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cpu_used_counter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuVumeter)).BeginInit();
            this.vumeterContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramVumeter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuVumeterBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramVumeterBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterDBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterUBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterDBg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterUBg)).BeginInit();
            this.graphContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ram_physical_free)).BeginInit();
            this.SuspendLayout();
            // 
            // cpu_used_counter
            // 
            this.cpu_used_counter.CategoryName = "Processor";
            this.cpu_used_counter.CounterName = "% Processor Time";
            this.cpu_used_counter.InstanceName = "_Total";
            // 
            // cpuRamTimer
            // 
            this.cpuRamTimer.Interval = 500;
            this.cpuRamTimer.Tick += new System.EventHandler(this.CpuRamTimer_Tick);
            // 
            // cpuVumeter
            // 
            this.cpuVumeter.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.cpuVumeter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpuVumeter.Image = global::XtreamToolbox.Properties.Resources.vumeter;
            resources.ApplyResources(this.cpuVumeter, "cpuVumeter");
            this.cpuVumeter.MaximumSize = new System.Drawing.Size(50, 7);
            this.cpuVumeter.MinimumSize = new System.Drawing.Size(3, 7);
            this.cpuVumeter.Name = "cpuVumeter";
            this.cpuVumeter.TabStop = false;
            this.cpuVumeter.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // vumeterContextMenuStrip
            // 
            this.vumeterContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchToGraphModeToolStripMenuItem});
            this.vumeterContextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.vumeterContextMenuStrip, "vumeterContextMenuStrip");
            // 
            // switchToGraphModeToolStripMenuItem
            // 
            this.switchToGraphModeToolStripMenuItem.Name = "switchToGraphModeToolStripMenuItem";
            resources.ApplyResources(this.switchToGraphModeToolStripMenuItem, "switchToGraphModeToolStripMenuItem");
            this.switchToGraphModeToolStripMenuItem.Click += new System.EventHandler(this.SwitchToGraphModeToolStripMenuItem_Click);
            // 
            // ramVumeter
            // 
            this.ramVumeter.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.ramVumeter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ramVumeter.Image = global::XtreamToolbox.Properties.Resources.vumeter;
            resources.ApplyResources(this.ramVumeter, "ramVumeter");
            this.ramVumeter.MaximumSize = new System.Drawing.Size(50, 7);
            this.ramVumeter.MinimumSize = new System.Drawing.Size(3, 7);
            this.ramVumeter.Name = "ramVumeter";
            this.ramVumeter.TabStop = false;
            this.ramVumeter.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // cpuLabel
            // 
            resources.ApplyResources(this.cpuLabel, "cpuLabel");
            this.cpuLabel.BackColor = System.Drawing.Color.Transparent;
            this.cpuLabel.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.cpuLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpuLabel.Name = "cpuLabel";
            this.cpuLabel.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // ramLabel
            // 
            resources.ApplyResources(this.ramLabel, "ramLabel");
            this.ramLabel.BackColor = System.Drawing.Color.Transparent;
            this.ramLabel.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.ramLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ramLabel.Name = "ramLabel";
            this.ramLabel.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // lanLabel
            // 
            resources.ApplyResources(this.lanLabel, "lanLabel");
            this.lanLabel.BackColor = System.Drawing.Color.Transparent;
            this.lanLabel.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.lanLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lanLabel.Name = "lanLabel";
            this.lanLabel.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // lanVumeterD
            // 
            this.lanVumeterD.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.lanVumeterD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lanVumeterD.Image = global::XtreamToolbox.Properties.Resources.vumeter;
            resources.ApplyResources(this.lanVumeterD, "lanVumeterD");
            this.lanVumeterD.MaximumSize = new System.Drawing.Size(50, 5);
            this.lanVumeterD.MinimumSize = new System.Drawing.Size(3, 5);
            this.lanVumeterD.Name = "lanVumeterD";
            this.lanVumeterD.TabStop = false;
            this.lanVumeterD.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // wanVumeterD
            // 
            this.wanVumeterD.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.wanVumeterD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wanVumeterD.Image = global::XtreamToolbox.Properties.Resources.vumeter;
            resources.ApplyResources(this.wanVumeterD, "wanVumeterD");
            this.wanVumeterD.MaximumSize = new System.Drawing.Size(50, 5);
            this.wanVumeterD.MinimumSize = new System.Drawing.Size(3, 5);
            this.wanVumeterD.Name = "wanVumeterD";
            this.wanVumeterD.TabStop = false;
            this.wanVumeterD.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // wanLabel
            // 
            resources.ApplyResources(this.wanLabel, "wanLabel");
            this.wanLabel.BackColor = System.Drawing.Color.Transparent;
            this.wanLabel.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.wanLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wanLabel.Name = "wanLabel";
            this.wanLabel.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // lanVumeterU
            // 
            this.lanVumeterU.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.lanVumeterU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lanVumeterU.Image = global::XtreamToolbox.Properties.Resources.vumeter;
            resources.ApplyResources(this.lanVumeterU, "lanVumeterU");
            this.lanVumeterU.MaximumSize = new System.Drawing.Size(50, 5);
            this.lanVumeterU.MinimumSize = new System.Drawing.Size(3, 5);
            this.lanVumeterU.Name = "lanVumeterU";
            this.lanVumeterU.TabStop = false;
            this.lanVumeterU.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // wanVumeterU
            // 
            this.wanVumeterU.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.wanVumeterU.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wanVumeterU.Image = global::XtreamToolbox.Properties.Resources.vumeter;
            resources.ApplyResources(this.wanVumeterU, "wanVumeterU");
            this.wanVumeterU.MaximumSize = new System.Drawing.Size(50, 5);
            this.wanVumeterU.MinimumSize = new System.Drawing.Size(3, 5);
            this.wanVumeterU.Name = "wanVumeterU";
            this.wanVumeterU.TabStop = false;
            this.wanVumeterU.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // cpuVumeterBg
            // 
            this.cpuVumeterBg.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.cpuVumeterBg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cpuVumeterBg.Image = global::XtreamToolbox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.cpuVumeterBg, "cpuVumeterBg");
            this.cpuVumeterBg.MaximumSize = new System.Drawing.Size(50, 7);
            this.cpuVumeterBg.MinimumSize = new System.Drawing.Size(3, 7);
            this.cpuVumeterBg.Name = "cpuVumeterBg";
            this.cpuVumeterBg.TabStop = false;
            this.cpuVumeterBg.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // ramVumeterBg
            // 
            this.ramVumeterBg.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.ramVumeterBg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ramVumeterBg.Image = global::XtreamToolbox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.ramVumeterBg, "ramVumeterBg");
            this.ramVumeterBg.MaximumSize = new System.Drawing.Size(50, 7);
            this.ramVumeterBg.MinimumSize = new System.Drawing.Size(3, 7);
            this.ramVumeterBg.Name = "ramVumeterBg";
            this.ramVumeterBg.TabStop = false;
            this.ramVumeterBg.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // lanVumeterDBg
            // 
            this.lanVumeterDBg.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.lanVumeterDBg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lanVumeterDBg.Image = global::XtreamToolbox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.lanVumeterDBg, "lanVumeterDBg");
            this.lanVumeterDBg.MaximumSize = new System.Drawing.Size(50, 5);
            this.lanVumeterDBg.MinimumSize = new System.Drawing.Size(3, 5);
            this.lanVumeterDBg.Name = "lanVumeterDBg";
            this.lanVumeterDBg.TabStop = false;
            this.lanVumeterDBg.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // lanVumeterUBg
            // 
            this.lanVumeterUBg.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.lanVumeterUBg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lanVumeterUBg.Image = global::XtreamToolbox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.lanVumeterUBg, "lanVumeterUBg");
            this.lanVumeterUBg.MaximumSize = new System.Drawing.Size(50, 5);
            this.lanVumeterUBg.MinimumSize = new System.Drawing.Size(3, 5);
            this.lanVumeterUBg.Name = "lanVumeterUBg";
            this.lanVumeterUBg.TabStop = false;
            this.lanVumeterUBg.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // wanVumeterDBg
            // 
            this.wanVumeterDBg.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.wanVumeterDBg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wanVumeterDBg.Image = global::XtreamToolbox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.wanVumeterDBg, "wanVumeterDBg");
            this.wanVumeterDBg.MaximumSize = new System.Drawing.Size(50, 5);
            this.wanVumeterDBg.MinimumSize = new System.Drawing.Size(3, 5);
            this.wanVumeterDBg.Name = "wanVumeterDBg";
            this.wanVumeterDBg.TabStop = false;
            this.wanVumeterDBg.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // wanVumeterUBg
            // 
            this.wanVumeterUBg.ContextMenuStrip = this.vumeterContextMenuStrip;
            this.wanVumeterUBg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wanVumeterUBg.Image = global::XtreamToolbox.Properties.Resources.vumeter_background;
            resources.ApplyResources(this.wanVumeterUBg, "wanVumeterUBg");
            this.wanVumeterUBg.MaximumSize = new System.Drawing.Size(50, 5);
            this.wanVumeterUBg.MinimumSize = new System.Drawing.Size(3, 5);
            this.wanVumeterUBg.Name = "wanVumeterUBg";
            this.wanVumeterUBg.TabStop = false;
            this.wanVumeterUBg.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // c2DPushGraph
            // 
            this.c2DPushGraph.AutoAdjustPeek = false;
            this.c2DPushGraph.BackColor = System.Drawing.Color.Black;
            this.c2DPushGraph.ContextMenuStrip = this.graphContextMenuStrip;
            this.c2DPushGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.c2DPushGraph.GridColor = System.Drawing.Color.Gray;
            this.c2DPushGraph.GridSize = ((ushort)(5));
            this.c2DPushGraph.HighQuality = true;
            this.c2DPushGraph.LineInterval = ((ushort)(1));
            resources.ApplyResources(this.c2DPushGraph, "c2DPushGraph");
            this.c2DPushGraph.MaxLabel = "";
            this.c2DPushGraph.MaxPeekMagnitude = 100;
            this.c2DPushGraph.MinimumSize = new System.Drawing.Size(70, 44);
            this.c2DPushGraph.MinLabel = "";
            this.c2DPushGraph.MinPeekMagnitude = 0;
            this.c2DPushGraph.Name = "c2DPushGraph";
            this.c2DPushGraph.ShowGrid = false;
            this.c2DPushGraph.ShowLabels = false;
            this.c2DPushGraph.TextColor = System.Drawing.Color.Yellow;
            this.c2DPushGraph.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            // 
            // graphContextMenuStrip
            // 
            this.graphContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cpuLineToolStripMenuItem,
            this.ramLineToolStripMenuItem,
            this.lanReceivedRateToolStripMenuItem,
            this.lanSendRateToolStripMenuItem,
            this.wanReceivedRateToolStripMenuItem,
            this.wanSendRateToolStripMenuItem,
            this.toolStripSeparator1,
            this.SwithToVumeterToolStripMenuItem});
            this.graphContextMenuStrip.Name = "contextMenuStrip1";
            this.graphContextMenuStrip.ShowCheckMargin = true;
            this.graphContextMenuStrip.ShowItemToolTips = false;
            resources.ApplyResources(this.graphContextMenuStrip, "graphContextMenuStrip");
            // 
            // cpuLineToolStripMenuItem
            // 
            this.cpuLineToolStripMenuItem.CheckOnClick = true;
            this.cpuLineToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cpuLineToolStripMenuItem.Image = global::XtreamToolbox.Properties.Resources.box_vert;
            this.cpuLineToolStripMenuItem.Name = "cpuLineToolStripMenuItem";
            resources.ApplyResources(this.cpuLineToolStripMenuItem, "cpuLineToolStripMenuItem");
            this.cpuLineToolStripMenuItem.CheckedChanged += new System.EventHandler(this.CpuLineToolStripMenuItem_CheckedChanged);
            // 
            // ramLineToolStripMenuItem
            // 
            this.ramLineToolStripMenuItem.CheckOnClick = true;
            this.ramLineToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ramLineToolStripMenuItem.Image = global::XtreamToolbox.Properties.Resources.box_jaune;
            this.ramLineToolStripMenuItem.Name = "ramLineToolStripMenuItem";
            resources.ApplyResources(this.ramLineToolStripMenuItem, "ramLineToolStripMenuItem");
            this.ramLineToolStripMenuItem.CheckedChanged += new System.EventHandler(this.RamLineToolStripMenuItem_CheckedChanged);
            // 
            // lanReceivedRateToolStripMenuItem
            // 
            this.lanReceivedRateToolStripMenuItem.CheckOnClick = true;
            this.lanReceivedRateToolStripMenuItem.Image = global::XtreamToolbox.Properties.Resources.box_bleu;
            this.lanReceivedRateToolStripMenuItem.Name = "lanReceivedRateToolStripMenuItem";
            resources.ApplyResources(this.lanReceivedRateToolStripMenuItem, "lanReceivedRateToolStripMenuItem");
            this.lanReceivedRateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.LanReceivedRateToolStripMenuItem_CheckedChanged);
            // 
            // lanSendRateToolStripMenuItem
            // 
            this.lanSendRateToolStripMenuItem.CheckOnClick = true;
            this.lanSendRateToolStripMenuItem.Image = global::XtreamToolbox.Properties.Resources.box_turquoise;
            this.lanSendRateToolStripMenuItem.Name = "lanSendRateToolStripMenuItem";
            resources.ApplyResources(this.lanSendRateToolStripMenuItem, "lanSendRateToolStripMenuItem");
            this.lanSendRateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.LanSendRateToolStripMenuItem_CheckedChanged);
            // 
            // wanReceivedRateToolStripMenuItem
            // 
            this.wanReceivedRateToolStripMenuItem.CheckOnClick = true;
            this.wanReceivedRateToolStripMenuItem.Image = global::XtreamToolbox.Properties.Resources.box_rouge;
            this.wanReceivedRateToolStripMenuItem.Name = "wanReceivedRateToolStripMenuItem";
            resources.ApplyResources(this.wanReceivedRateToolStripMenuItem, "wanReceivedRateToolStripMenuItem");
            this.wanReceivedRateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.WanReceivedRateToolStripMenuItem_CheckedChanged);
            // 
            // wanSendRateToolStripMenuItem
            // 
            this.wanSendRateToolStripMenuItem.CheckOnClick = true;
            this.wanSendRateToolStripMenuItem.Image = global::XtreamToolbox.Properties.Resources.box_rose;
            this.wanSendRateToolStripMenuItem.Name = "wanSendRateToolStripMenuItem";
            resources.ApplyResources(this.wanSendRateToolStripMenuItem, "wanSendRateToolStripMenuItem");
            this.wanSendRateToolStripMenuItem.CheckedChanged += new System.EventHandler(this.WanSendRateToolStripMenuItem_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // SwithToVumeterToolStripMenuItem
            // 
            this.SwithToVumeterToolStripMenuItem.Name = "SwithToVumeterToolStripMenuItem";
            resources.ApplyResources(this.SwithToVumeterToolStripMenuItem, "SwithToVumeterToolStripMenuItem");
            this.SwithToVumeterToolStripMenuItem.Click += new System.EventHandler(this.SwithToVumeterToolStripMenuItem_Click);
            // 
            // ram_physical_free
            // 
            this.ram_physical_free.CategoryName = "Memory";
            this.ram_physical_free.CounterName = "Available Bytes";
            // 
            // initialisationBackgroundWorker
            // 
            this.initialisationBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.InitialisationBackgroundWorker_DoWork);
            this.initialisationBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.InitialisationBackgroundWorker_RunWorkerCompleted);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            // 
            // SensorSystemInfos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.c2DPushGraph);
            this.Controls.Add(this.wanVumeterD);
            this.Controls.Add(this.wanVumeterU);
            this.Controls.Add(this.wanVumeterDBg);
            this.Controls.Add(this.wanVumeterUBg);
            this.Controls.Add(this.wanLabel);
            this.Controls.Add(this.lanVumeterD);
            this.Controls.Add(this.lanVumeterU);
            this.Controls.Add(this.lanVumeterDBg);
            this.Controls.Add(this.lanVumeterUBg);
            this.Controls.Add(this.lanLabel);
            this.Controls.Add(this.cpuVumeter);
            this.Controls.Add(this.cpuVumeterBg);
            this.Controls.Add(this.cpuLabel);
            this.Controls.Add(this.ramVumeter);
            this.Controls.Add(this.ramVumeterBg);
            this.Controls.Add(this.ramLabel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            resources.ApplyResources(this, "$this");
            this.Name = "SensorSystemInfos";
            this.Click += new System.EventHandler(this.SensorSystemInfos_Click);
            ((System.ComponentModel.ISupportInitialize)(this.cpu_used_counter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuVumeter)).EndInit();
            this.vumeterContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ramVumeter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpuVumeterBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramVumeterBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterDBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanVumeterUBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterDBg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wanVumeterUBg)).EndInit();
            this.graphContextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ram_physical_free)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.PerformanceCounter cpu_used_counter;
        private System.Windows.Forms.Timer cpuRamTimer;
        private System.Windows.Forms.PictureBox cpuVumeter;
        private System.Windows.Forms.PictureBox ramVumeter;
        private System.Windows.Forms.Label ramLabel;
        private System.Windows.Forms.Label cpuLabel;
        private System.Diagnostics.PerformanceCounter ram_physical_free;
        private System.Windows.Forms.Label lanLabel;
        private System.Windows.Forms.PictureBox lanVumeterD;
        private System.ComponentModel.BackgroundWorker initialisationBackgroundWorker;
        private System.Windows.Forms.PictureBox wanVumeterD;
        private System.Windows.Forms.Label wanLabel;
        private System.Windows.Forms.PictureBox lanVumeterU;
        private System.Windows.Forms.PictureBox wanVumeterU;
        private System.Windows.Forms.PictureBox cpuVumeterBg;
        private System.Windows.Forms.PictureBox ramVumeterBg;
        private System.Windows.Forms.PictureBox lanVumeterDBg;
        private System.Windows.Forms.PictureBox lanVumeterUBg;
        private System.Windows.Forms.PictureBox wanVumeterDBg;
        private System.Windows.Forms.PictureBox wanVumeterUBg;
        private System.Windows.Forms.ContextMenuStrip graphContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cpuLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ramLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lanReceivedRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lanSendRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wanReceivedRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wanSendRateToolStripMenuItem;
        private CustomUIControls.Graphing.C2DPushGraph c2DPushGraph;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem SwithToVumeterToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip vumeterContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem switchToGraphModeToolStripMenuItem;
        private System.Windows.Forms.ToolTip helpToolTip;
    }
}
