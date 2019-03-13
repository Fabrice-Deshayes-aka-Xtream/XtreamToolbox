using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Xtream_ToolBox;
using System.Resources;
using System.Threading;
using System.Globalization;
using Xtream_ToolBox.Utils;
using System.Drawing.Drawing2D;

namespace Xtream_ToolBox.Sensors {
    /// <summary>
    /// Control name: Analog Clock Control
    /// Description: A customizable and resizable clock control
    /// Developed by: Syed Mehroz Alam
    /// Email: smehrozalam@yahoo.com
    /// URL: Programming Home "http://www.geocities.com/smehrozalam/"
    /// </summary>
    public class SensorAnalogClock : UserControl, ISensor {
        // reference on toolbox
        private readonly ToolBox toolbox = null;

        // ressource manager pour accéder aux chaines localisées
        private readonly ResourceManager resources = Xtream_ToolBox.Properties.Resources.ResourceManager;

        private const float PI = 3.141592654F;

        private DateTime dateTime;

        private float fRadius;
        private float fCenterX;
        private float fCenterY;
        private float fCenterCircleRadius;

        private float fHourLength;
        private float fMinLength;
        private float fSecLength;

        private float fHourThickness;
        private float fMinThickness;
        private float fSecThickness;

        private bool bDraw5MinuteTicks = true;
        private bool bDraw1MinuteTicks = false;
        private readonly float fTicksThickness = 1;

        private Color hrColor = Color.Black;
        private Color minColor = Color.Black;
        private Color secColor = Color.Red;
        private Color circleColor = Color.Red;
        private Color ticksColor = Color.Black;

        private System.Windows.Forms.Timer AnalogClockTimer;
        private ToolTip helpToolTip;
        private System.ComponentModel.IContainer components;

        // constructor
        public SensorAnalogClock(ToolBox toolbox) {
            InitializeComponent();

            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel() {
            return null;
        }

        // init UI
        public void InitUI() {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Xtream_ToolBox.Properties.Settings.Default.spaceBetweenSensor, 0, Xtream_ToolBox.Properties.Settings.Default.spaceBetweenSensor, 0);

            // tips
            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            dateTime = DateTime.Now;

            fRadius = Height / 2;
            fCenterX = fRadius;
            fCenterY = fRadius;
            fCenterCircleRadius = Height / 50;

            fHourLength = (float)fRadius * 0.55F;
            fMinLength = (float)fRadius * 0.85F;
            fSecLength = (float)fRadius * 0.70F;

            fHourThickness = 1.02F;
            fMinThickness = 1.01F;
            fSecThickness = 1.0F;
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData() {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI() {
            this.dateTime = DateTime.Now;
            this.Refresh();
        }

        // update location of extended panel if needed
        public void UpdateLocation() {
            // nothing to do on this sensor
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.AnalogClockTimer = new System.Windows.Forms.Timer(this.components);
            this.helpToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // AnalogClockTimer
            // 
            this.AnalogClockTimer.Enabled = true;
            this.AnalogClockTimer.Interval = 1000;
            this.AnalogClockTimer.Tick += new System.EventHandler(this.AnalogClockTimer_Tick);
            // 
            // helpToolTip
            // 
            this.helpToolTip.AutomaticDelay = 1;
            this.helpToolTip.AutoPopDelay = 60000;
            this.helpToolTip.InitialDelay = 1;
            this.helpToolTip.ReshowDelay = 0;
            this.helpToolTip.ShowAlways = true;
            // 
            // SensorAnalogClock
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Xtream_ToolBox.Properties.Resources.Clock;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SensorAnalogClock";
            this.Size = new System.Drawing.Size(48, 48);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AnalogClock_Paint);
            this.ResumeLayout(false);

        }
        #endregion

        private void Timer1_Tick(object sender, System.EventArgs e) {
            RefreshUI();
        }

        private void DrawLine(float fThickness, float fLength, Color color, System.Windows.Forms.PaintEventArgs e) {
            e.Graphics.DrawLine(new Pen(color, fThickness), 0, fLength / 9, 0, -fLength);
        }

        private void DrawPolygon(float fThickness, float fLength, Color color, System.Windows.Forms.PaintEventArgs e) {
            PointF A = new PointF(fThickness * 2F, 0);
            PointF B = new PointF(-fThickness * 2F, 0);
            PointF C = new PointF(0, -fLength);
            PointF D = new PointF(0, fThickness * 4F);
            PointF[] points ={ A, D, B, C };
            e.Graphics.FillPolygon(new SolidBrush(color), points);
        }

        private void AnalogClock_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
            e.Graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TranslateTransform(fCenterX, fCenterY);
            Matrix m = e.Graphics.Transform;

            e.Graphics.RotateTransform((dateTime.Hour % 12 + dateTime.Minute / 60F) * 30);
            DrawPolygon(this.fHourThickness, this.fHourLength, hrColor, e);

            e.Graphics.Transform = m;
            e.Graphics.RotateTransform(dateTime.Minute * 6 + dateTime.Second / 10F);
            DrawPolygon(this.fMinThickness, this.fMinLength, minColor, e);

            e.Graphics.Transform = m;
            e.Graphics.RotateTransform(dateTime.Second * 6);
            DrawLine(this.fSecThickness, this.fSecLength, secColor, e);


            for (int i = 0; i < 60; i++) {
                e.Graphics.Transform = m;
                e.Graphics.RotateTransform(i * 6);
                if (this.bDraw5MinuteTicks == true && i % 5 == 0){
                    // Draw 5 minute ticks
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness), 0, -this.fRadius / 1.50F, 0, -this.fRadius / 1.65F);
                } else if (this.bDraw1MinuteTicks == true){
                    // draw 1 minute ticks
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness), 0, -this.fRadius / 1.50F, 0, -this.fRadius / 1.55F);
                }
            }

            //draw circle at center
            e.Graphics.FillEllipse(new SolidBrush(circleColor), -fCenterCircleRadius / 2, -fCenterCircleRadius / 2, fCenterCircleRadius, fCenterCircleRadius);
        }

        public Color HourHandColor {
            get { return this.hrColor; }
            set { this.hrColor = value; }
        }

        public Color MinuteHandColor {
            get { return this.minColor; }
            set { this.minColor = value; }
        }

        public Color SecondHandColor {
            get { return this.secColor; }
            set {
                this.secColor = value;
                this.circleColor = value;
            }
        }

        public Color TicksColor {
            get { return this.ticksColor; }
            set { this.ticksColor = value; }
        }

        public bool Draw1MinuteTicks {
            get { return this.bDraw1MinuteTicks; }
            set { this.bDraw1MinuteTicks = value; }
        }

        public bool Draw5MinuteTicks {
            get { return this.bDraw5MinuteTicks; }
            set { this.bDraw5MinuteTicks = value; }
        }

        private void AnalogClockTimer_Tick(object sender, EventArgs e)
        {
            RefreshUI();
        }
    }
}
