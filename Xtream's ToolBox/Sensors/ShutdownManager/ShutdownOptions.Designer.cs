﻿namespace XtreamToolbox.Sensors.ShutdownManager
{
    partial class ShutdownOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShutdownOptions));
            this.lockPictureBox = new System.Windows.Forms.PictureBox();
            this.logOffPictureBox = new System.Windows.Forms.PictureBox();
            this.swithUserPictureBox = new System.Windows.Forms.PictureBox();
            this.restartPictureBox = new System.Windows.Forms.PictureBox();
            this.hibernatePictureBox = new System.Windows.Forms.PictureBox();
            this.shutdownPictureBox = new System.Windows.Forms.PictureBox();
            this.lockLabel = new System.Windows.Forms.Label();
            this.logOffLabel = new System.Windows.Forms.Label();
            this.switchUserLabel = new System.Windows.Forms.Label();
            this.restartLabel = new System.Windows.Forms.Label();
            this.hibernateLabel = new System.Windows.Forms.Label();
            this.shutdownLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.doItNowRadioButton = new System.Windows.Forms.RadioButton();
            this.doItLaterRadioButton = new System.Windows.Forms.RadioButton();
            this.doItLaterDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.doTimedActionTimer = new System.Windows.Forms.Timer(this.components);
            this.countDownLabel = new System.Windows.Forms.Label();
            this.closeExtendedInfosPictureBox = new System.Windows.Forms.PictureBox();
            this.moveBoxLeft = new System.Windows.Forms.PictureBox();
            this.moveBoxRight = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.lockPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logOffPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swithUserPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hibernatePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shutdownPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // lockPictureBox
            // 
            this.lockPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.lockPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lockPictureBox.Image = global::XtreamToolbox.Properties.Resources.shutdownManager_lock;
            resources.ApplyResources(this.lockPictureBox, "lockPictureBox");
            this.lockPictureBox.Name = "lockPictureBox";
            this.lockPictureBox.TabStop = false;
            this.lockPictureBox.Click += new System.EventHandler(this.LockPictureBox_Click);
            // 
            // logOffPictureBox
            // 
            this.logOffPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.logOffPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logOffPictureBox.Image = global::XtreamToolbox.Properties.Resources.shutdownManager_logoff;
            resources.ApplyResources(this.logOffPictureBox, "logOffPictureBox");
            this.logOffPictureBox.Name = "logOffPictureBox";
            this.logOffPictureBox.TabStop = false;
            this.logOffPictureBox.Click += new System.EventHandler(this.LogOffPictureBox_Click);
            // 
            // swithUserPictureBox
            // 
            this.swithUserPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.swithUserPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swithUserPictureBox.Image = global::XtreamToolbox.Properties.Resources.shutdownManager_switch_user;
            resources.ApplyResources(this.swithUserPictureBox, "swithUserPictureBox");
            this.swithUserPictureBox.Name = "swithUserPictureBox";
            this.swithUserPictureBox.TabStop = false;
            this.swithUserPictureBox.Click += new System.EventHandler(this.SwithUserPictureBox_Click);
            // 
            // restartPictureBox
            // 
            this.restartPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.restartPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restartPictureBox.Image = global::XtreamToolbox.Properties.Resources.shutdownManager_restart;
            resources.ApplyResources(this.restartPictureBox, "restartPictureBox");
            this.restartPictureBox.Name = "restartPictureBox";
            this.restartPictureBox.TabStop = false;
            this.restartPictureBox.Click += new System.EventHandler(this.RestartPictureBox_Click);
            // 
            // hibernatePictureBox
            // 
            this.hibernatePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.hibernatePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hibernatePictureBox.Image = global::XtreamToolbox.Properties.Resources.shutdownManager_hibernate;
            resources.ApplyResources(this.hibernatePictureBox, "hibernatePictureBox");
            this.hibernatePictureBox.Name = "hibernatePictureBox";
            this.hibernatePictureBox.TabStop = false;
            this.hibernatePictureBox.Click += new System.EventHandler(this.HibernatePictureBox_Click);
            // 
            // shutdownPictureBox
            // 
            this.shutdownPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.shutdownPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shutdownPictureBox.Image = global::XtreamToolbox.Properties.Resources.shutdownManager_shutdown;
            resources.ApplyResources(this.shutdownPictureBox, "shutdownPictureBox");
            this.shutdownPictureBox.Name = "shutdownPictureBox";
            this.shutdownPictureBox.TabStop = false;
            this.shutdownPictureBox.Click += new System.EventHandler(this.ShutdownPictureBox_Click);
            // 
            // lockLabel
            // 
            resources.ApplyResources(this.lockLabel, "lockLabel");
            this.lockLabel.BackColor = System.Drawing.Color.Transparent;
            this.lockLabel.Name = "lockLabel";
            // 
            // logOffLabel
            // 
            resources.ApplyResources(this.logOffLabel, "logOffLabel");
            this.logOffLabel.BackColor = System.Drawing.Color.Transparent;
            this.logOffLabel.Name = "logOffLabel";
            // 
            // switchUserLabel
            // 
            resources.ApplyResources(this.switchUserLabel, "switchUserLabel");
            this.switchUserLabel.BackColor = System.Drawing.Color.Transparent;
            this.switchUserLabel.Name = "switchUserLabel";
            // 
            // restartLabel
            // 
            resources.ApplyResources(this.restartLabel, "restartLabel");
            this.restartLabel.BackColor = System.Drawing.Color.Transparent;
            this.restartLabel.Name = "restartLabel";
            // 
            // hibernateLabel
            // 
            resources.ApplyResources(this.hibernateLabel, "hibernateLabel");
            this.hibernateLabel.BackColor = System.Drawing.Color.Transparent;
            this.hibernateLabel.Name = "hibernateLabel";
            // 
            // shutdownLabel
            // 
            resources.ApplyResources(this.shutdownLabel, "shutdownLabel");
            this.shutdownLabel.BackColor = System.Drawing.Color.Transparent;
            this.shutdownLabel.Name = "shutdownLabel";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // doItNowRadioButton
            // 
            resources.ApplyResources(this.doItNowRadioButton, "doItNowRadioButton");
            this.doItNowRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.doItNowRadioButton.Checked = true;
            this.doItNowRadioButton.Name = "doItNowRadioButton";
            this.doItNowRadioButton.TabStop = true;
            this.doItNowRadioButton.UseVisualStyleBackColor = false;
            // 
            // doItLaterRadioButton
            // 
            resources.ApplyResources(this.doItLaterRadioButton, "doItLaterRadioButton");
            this.doItLaterRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.doItLaterRadioButton.Name = "doItLaterRadioButton";
            this.doItLaterRadioButton.UseVisualStyleBackColor = false;
            // 
            // doItLaterDateTimePicker
            // 
            this.doItLaterDateTimePicker.Cursor = System.Windows.Forms.Cursors.Arrow;
            resources.ApplyResources(this.doItLaterDateTimePicker, "doItLaterDateTimePicker");
            this.doItLaterDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.doItLaterDateTimePicker.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.doItLaterDateTimePicker.Name = "doItLaterDateTimePicker";
            this.doItLaterDateTimePicker.ShowUpDown = true;
            this.doItLaterDateTimePicker.ValueChanged += new System.EventHandler(this.DoItLaterDateTimePicker_ValueChanged);
            // 
            // doTimedActionTimer
            // 
            this.doTimedActionTimer.Interval = 1000;
            this.doTimedActionTimer.Tick += new System.EventHandler(this.DoTimedActionTimer_Tick);
            // 
            // countDownLabel
            // 
            this.countDownLabel.BackColor = System.Drawing.Color.Transparent;
            this.countDownLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.countDownLabel, "countDownLabel");
            this.countDownLabel.Name = "countDownLabel";
            // 
            // closeExtendedInfosPictureBox
            // 
            this.closeExtendedInfosPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.closeExtendedInfosPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.closeExtendedInfosPictureBox, "closeExtendedInfosPictureBox");
            this.closeExtendedInfosPictureBox.Name = "closeExtendedInfosPictureBox";
            this.closeExtendedInfosPictureBox.TabStop = false;
            this.closeExtendedInfosPictureBox.Click += new System.EventHandler(this.CloseExtendedInfosPictureBox_Click);
            // 
            // moveBoxLeft
            // 
            this.moveBoxLeft.BackColor = System.Drawing.Color.Transparent;
            this.moveBoxLeft.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            resources.ApplyResources(this.moveBoxLeft, "moveBoxLeft");
            this.moveBoxLeft.Name = "moveBoxLeft";
            this.moveBoxLeft.TabStop = false;
            this.moveBoxLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseDown);
            this.moveBoxLeft.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseMove);
            this.moveBoxLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseUp);
            // 
            // moveBoxRight
            // 
            this.moveBoxRight.BackColor = System.Drawing.Color.Transparent;
            this.moveBoxRight.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            resources.ApplyResources(this.moveBoxRight, "moveBoxRight");
            this.moveBoxRight.Name = "moveBoxRight";
            this.moveBoxRight.TabStop = false;
            this.moveBoxRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseDown);
            this.moveBoxRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseMove);
            this.moveBoxRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MoveBox_MouseUp);
            // 
            // ShutdownOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::XtreamToolbox.Properties.Resources.shutdownOptionsBackground;
            this.ControlBox = false;
            this.Controls.Add(this.moveBoxRight);
            this.Controls.Add(this.moveBoxLeft);
            this.Controls.Add(this.closeExtendedInfosPictureBox);
            this.Controls.Add(this.countDownLabel);
            this.Controls.Add(this.doItLaterDateTimePicker);
            this.Controls.Add(this.doItLaterRadioButton);
            this.Controls.Add(this.doItNowRadioButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.shutdownLabel);
            this.Controls.Add(this.hibernateLabel);
            this.Controls.Add(this.restartLabel);
            this.Controls.Add(this.switchUserLabel);
            this.Controls.Add(this.logOffLabel);
            this.Controls.Add(this.lockLabel);
            this.Controls.Add(this.shutdownPictureBox);
            this.Controls.Add(this.hibernatePictureBox);
            this.Controls.Add(this.restartPictureBox);
            this.Controls.Add(this.swithUserPictureBox);
            this.Controls.Add(this.logOffPictureBox);
            this.Controls.Add(this.lockPictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShutdownOptions";
            this.ShowIcon = false;
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.ShutdownOptions_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.lockPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logOffPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swithUserPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restartPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hibernatePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shutdownPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeExtendedInfosPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moveBoxRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox lockPictureBox;
        private System.Windows.Forms.PictureBox logOffPictureBox;
        private System.Windows.Forms.PictureBox swithUserPictureBox;
        private System.Windows.Forms.PictureBox restartPictureBox;
        private System.Windows.Forms.PictureBox hibernatePictureBox;
        private System.Windows.Forms.PictureBox shutdownPictureBox;
        private System.Windows.Forms.Label lockLabel;
        private System.Windows.Forms.Label logOffLabel;
        private System.Windows.Forms.Label switchUserLabel;
        private System.Windows.Forms.Label restartLabel;
        private System.Windows.Forms.Label hibernateLabel;
        private System.Windows.Forms.Label shutdownLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton doItNowRadioButton;
        private System.Windows.Forms.RadioButton doItLaterRadioButton;
        private System.Windows.Forms.DateTimePicker doItLaterDateTimePicker;
        private System.Windows.Forms.Timer doTimedActionTimer;
        private System.Windows.Forms.Label countDownLabel;
        private System.Windows.Forms.PictureBox closeExtendedInfosPictureBox;
        private System.Windows.Forms.PictureBox moveBoxLeft;
        private System.Windows.Forms.PictureBox moveBoxRight;
    }
}