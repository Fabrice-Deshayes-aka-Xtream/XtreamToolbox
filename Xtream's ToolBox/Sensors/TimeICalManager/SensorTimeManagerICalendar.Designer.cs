namespace Xtream_ToolBox.Sensors {
    partial class SensorTimeManagerICalendar {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SensorTimeManagerICalendar));
            this.closerPictureBox = new System.Windows.Forms.PictureBox();
            this.moverRightPictureBox = new System.Windows.Forms.PictureBox();
            this.moverLeftPictureBox = new System.Windows.Forms.PictureBox();
            this.eventsListView = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sortColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.loadCalendarBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverRightPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverLeftPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closerPictureBox
            // 
            this.closerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.closerPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.closerPictureBox, "closerPictureBox");
            this.closerPictureBox.Name = "closerPictureBox";
            this.closerPictureBox.TabStop = false;
            this.closerPictureBox.Click += new System.EventHandler(this.CloserPictureBox_Click);
            // 
            // moverRightPictureBox
            // 
            this.moverRightPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.moverRightPictureBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            resources.ApplyResources(this.moverRightPictureBox, "moverRightPictureBox");
            this.moverRightPictureBox.Name = "moverRightPictureBox";
            this.moverRightPictureBox.TabStop = false;
            this.moverRightPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseDown);
            this.moverRightPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseMove);
            this.moverRightPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseUp);
            // 
            // moverLeftPictureBox
            // 
            this.moverLeftPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.moverLeftPictureBox.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            resources.ApplyResources(this.moverLeftPictureBox, "moverLeftPictureBox");
            this.moverLeftPictureBox.Name = "moverLeftPictureBox";
            this.moverLeftPictureBox.TabStop = false;
            this.moverLeftPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseDown);
            this.moverLeftPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseMove);
            this.moverLeftPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseUp);
            // 
            // eventsListView
            // 
            this.eventsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Date,
            this.Description,
            this.sortColumnHeader});
            this.eventsListView.FullRowSelect = true;
            this.eventsListView.GridLines = true;
            this.eventsListView.HideSelection = false;
            resources.ApplyResources(this.eventsListView, "eventsListView");
            this.eventsListView.MultiSelect = false;
            this.eventsListView.Name = "eventsListView";
            this.eventsListView.UseCompatibleStateImageBehavior = false;
            this.eventsListView.View = System.Windows.Forms.View.Details;
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            // 
            // Date
            // 
            resources.ApplyResources(this.Date, "Date");
            // 
            // Description
            // 
            resources.ApplyResources(this.Description, "Description");
            // 
            // monthCalendar1
            // 
            resources.ApplyResources(this.monthCalendar1, "monthCalendar1");
            this.monthCalendar1.MaxSelectionCount = 40;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateSelected);
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MonthCalendar1_DateSelected);
            // 
            // SensorTimeManagerICalendar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.calendarBackground;
            this.Controls.Add(this.eventsListView);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.closerPictureBox);
            this.Controls.Add(this.moverRightPictureBox);
            this.Controls.Add(this.moverLeftPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SensorTimeManagerICalendar";
            this.VisibleChanged += new System.EventHandler(this.SensorTimeManagerICalendar_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.closerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverRightPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moverLeftPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox closerPictureBox;
        private System.Windows.Forms.PictureBox moverRightPictureBox;
        private System.Windows.Forms.PictureBox moverLeftPictureBox;
        private System.Windows.Forms.ListView eventsListView;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.ComponentModel.BackgroundWorker loadCalendarBackgroundWorker;
        private System.Windows.Forms.ColumnHeader sortColumnHeader;
    }
}