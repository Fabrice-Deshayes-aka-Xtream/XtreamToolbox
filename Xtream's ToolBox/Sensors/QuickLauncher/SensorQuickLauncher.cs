using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using MSjogren.Samples.ShellLink;
using XtreamToolbox.Utils;

namespace XtreamToolbox.Sensors
{
    public partial class SensorQuickLauncher : UserControl, ISensor
    {

        // reference on toolbox
        private Toolbox toolbox = null;

        private static int iconSize;
        private static int separatorSize;
        private static int startTotalWidth;

        private static int iconSize1Line = 36;
        private static int iconSize2Line = 22;

        private Padding paddingOneLineAlone = new Padding(1, 6, 1, 0);
        private Padding paddingFirstLine = new Padding(1, 2, 1, 0);
        private Padding paddingSecondLine = new Padding(1, 1, 1, 1);

        private PictureBox currentMovingShortcut = null;
        private bool moveShortcut = false;
        private Point originalLocation;

        // constructor
        public SensorQuickLauncher(Toolbox toolbox)
        {
            InitializeComponent();
            this.toolbox = toolbox;
            InitUI();
        }

        // return extended panel if exist, null otherwise (for activate and hide/show)
        public Form GetExtendedPanel()
        {
            return null;
        }

        // init UI
        public void InitUI()
        {
            // set component margins (left, top, right, bottom)
            Margin = new Padding(Properties.Settings.Default.spaceBetweenSensor, 0, Properties.Settings.Default.spaceBetweenSensor, 0);
            this.SuspendLayout();

            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            if (Properties.Settings.Default.quickLauncherOnlyOneLine)
            {
                iconSize = iconSize1Line;
                separatorSize = Properties.Settings.Default.QuicklaunchSeparatorWidth;
            }
            else
            {
                iconSize = iconSize2Line;
                separatorSize = Properties.Settings.Default.QuicklaunchSeparatorWidth;
            }
            startTotalWidth = iconSize / 2;

            quickLaunchFlowLayoutPanelDown.Controls.Clear();
            quickLaunchFlowLayoutPanelUp.Controls.Clear();

            if (Properties.Settings.Default.quickLauncherOnlyOneLine)
            {
                quickLaunchFlowLayoutPanelUp.MinimumSize = new Size(48, 48);
                quickLaunchFlowLayoutPanelUp.MaximumSize = new Size(0, 48);
                quickLaunchFlowLayoutPanelDown.Visible = false;
            }
            else
            {
                quickLaunchFlowLayoutPanelUp.MinimumSize = new Size(48, 24);
                quickLaunchFlowLayoutPanelUp.MaximumSize = new Size(0, 24);
                quickLaunchFlowLayoutPanelDown.Visible = true;
            }

            if (Properties.Settings.Default.location != null)
            {
                foreach (String locationStr in Properties.Settings.Default.location)
                {
                    Location location = XtreamToolbox.Location.FromString(locationStr);
                    if ((location != null) && (location.Type == XtreamToolbox.Location.APPLICATION))
                    {
                        InsertShortcut(location, -1);
                    }
                }
            }
            this.ResumeLayout();
        }

        // init sensor data (will be called in asynch mode : no UI changed allowed!!)
        public void InitSensorData()
        {
            // nothing to do on this sensor
        }

        // refresh UI based on sensor Data
        public void RefreshUI()
        {
            // nothing to do on this sensor
        }

        // update location of extended panel if needed
        public void UpdateLocation()
        {
            // nothing to do on this sensor
        }

        // launch shortcut
        private void LaunchShortcut(object sender, EventArgs e)
        {
            if (!moveShortcut)
            {
                currentMovingShortcut = null;
                PictureBox currentShortcut = (PictureBox)sender;
                XtreamToolbox.Location currentLocation = (Location)currentShortcut.Tag;
                currentShortcut.Enabled = false;
                Cursor = Cursors.AppStarting;
                if (File.Exists(currentLocation.Loc))
                {
                    currentLocation.Parameters.TryGetValue("arguments", out string arguments);
                    currentLocation.Parameters.TryGetValue("workingDirectory", out string workingDirectory);
                    String retour = SystemUtils.StartProcess(currentLocation.Loc, arguments, workingDirectory);
                    if (retour != null)
                    {
                        MessageBox.Show(retour);
                    }
                }
                else
                {
                    MessageBox.Show("file not found : " + currentLocation.Loc);
                }
                System.Threading.Thread.Sleep(700);
                Cursor = Cursors.Default;
                currentShortcut.Enabled = true;
            }
        }

        // Remove shortcut or separator
        private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ContextMenuStrip contextMenuStrip = (ContextMenuStrip)((ToolStripDropDownItem)sender).Owner;
                PictureBox currentPictureBox = (PictureBox)contextMenuStrip.SourceControl;
                XtreamToolbox.Location currentLocation = (Location)currentPictureBox.Tag;
                Properties.Settings.Default.location.Remove(currentLocation.ToDelimitedString());
                this.SuspendLayout();
                if (quickLaunchFlowLayoutPanelDown.Controls.Contains(currentPictureBox))
                {
                    quickLaunchFlowLayoutPanelDown.Controls.Remove(currentPictureBox);
                }
                else
                {
                    quickLaunchFlowLayoutPanelUp.Controls.Remove(currentPictureBox);
                }
                currentPictureBox.Dispose();
                Properties.Settings.Default.Save();
                this.ResumeLayout();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        // view or modify shortcut's properties
        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)((ToolStripDropDownItem)sender).Owner;
            PictureBox currentShortcut = (PictureBox)contextMenuStrip.SourceControl;
            XtreamToolbox.Location currentLocation = (Location)currentShortcut.Tag;
            int oldLocationIndex = Properties.Settings.Default.location.IndexOf(currentLocation.ToDelimitedString());

            SensorQuickLaunchPropertyForm tmpPropertyForm = new SensorQuickLaunchPropertyForm(currentLocation);

            if (tmpPropertyForm.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.location.RemoveAt(oldLocationIndex);
                Properties.Settings.Default.location.Insert(oldLocationIndex, tmpPropertyForm.CurrentLocation.ToDelimitedString());
                Properties.Settings.Default.Save();

                // repercute le changement
                currentLocation.Parameters.TryGetValue("imagePath", out string imagePath);
                currentLocation.Parameters.TryGetValue("description", out string description);
                currentShortcut.Tag = currentLocation;
                if ((description != null) && (!"".Equals(description)))
                {
                    helpToolTip.SetToolTip(currentShortcut, String.Format("{0}{1}{2}", currentLocation.Name, Environment.NewLine, ToolBoxUtils.WordWrap(description, 30)));
                }
                else
                {
                    helpToolTip.SetToolTip(currentShortcut, currentLocation.Name);
                }
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    currentShortcut.ImageLocation = imagePath;
                }
                else
                {
                    if ((currentLocation.Loc != null) && (System.IO.File.Exists(currentLocation.Loc)))
                    {
                        currentShortcut.Image = Icon.ExtractAssociatedIcon(currentLocation.Loc).ToBitmap();
                    }
                }
            }
        }

        // manage drag : change icon if file are drag over sensor
        private void QuickLaunchFlowLayoutPanelUp_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // manage drop
        private void QuickLaunchFlowLayoutPanelDown_DragDrop(object sender, DragEventArgs e)
        {
            Location newLocation;
            ShellShortcut shellShortcut;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // find in which flowLayoutPanel to insert, in which position, and where to insert in location list
                FindInsertPosition(e.X, e.Y, out FlowLayoutPanel flowLayoutPanel, out int flowLayoutPanelInsertIndex, out int locationInsertIndex);

                foreach (String filename in (String[])e.Data.GetData(DataFormats.FileDrop))
                {
                    if (filename.ToLower().EndsWith(".lnk"))
                    {
                        shellShortcut = new ShellShortcut(filename);
                        newLocation = XtreamToolbox.Location.InsertApplicationLocation(shellShortcut.Path, flowLayoutPanel.Equals(quickLaunchFlowLayoutPanelUp), locationInsertIndex, shellShortcut.Arguments, shellShortcut.Description, shellShortcut.WorkingDirectory);
                    }
                    else
                    {
                        newLocation = XtreamToolbox.Location.InsertApplicationLocation(filename, flowLayoutPanel.Equals(quickLaunchFlowLayoutPanelUp), locationInsertIndex, "", "", "");
                    }

                    // create shortcut picturebox, add and move it to it's correct position
                    InsertShortcut(newLocation, flowLayoutPanelInsertIndex);
                }
            }
        }

        // create shortcut picturebox, add and move it to it's correct position
        private void InsertShortcut(Location newLocation, int flowLayoutPanelInsertIndex)
        {
            PictureBox currentShortcut;

            if (newLocation != null)
            {
                currentShortcut = new PictureBox();
                newLocation.Parameters.TryGetValue("type", out string typeValue);
                newLocation.Parameters.TryGetValue("imagePath", out string imagePath);
                newLocation.Parameters.TryGetValue("description", out string description);
                currentShortcut.Tag = newLocation;
                currentShortcut.Height = iconSize;
                currentShortcut.MouseDown += new MouseEventHandler(this.Shortcut_MouseDown);
                currentShortcut.MouseUp += new MouseEventHandler(this.Shortcut_MouseUp);
                currentShortcut.MouseMove += new MouseEventHandler(this.Shortcut_MouseMove);
                currentShortcut.SizeMode = PictureBoxSizeMode.StretchImage;

                if (Convert.ToInt16(typeValue) == XtreamToolbox.Location.PARAMETERS_TYPE_SHORTCUT)
                {
                    currentShortcut.ContextMenuStrip = shortcutContextMenu;
                    currentShortcut.Width = iconSize;
                    currentShortcut.Click += new EventHandler(this.LaunchShortcut);
                    if ((description != null) && (!"".Equals(description)))
                    {
                        helpToolTip.SetToolTip(currentShortcut, String.Format("{0}{1}{2}", newLocation.Name, Environment.NewLine, ToolBoxUtils.WordWrap(description, 30)));
                    }
                    else
                    {
                        helpToolTip.SetToolTip(currentShortcut, newLocation.Name);
                    }
                    currentShortcut.Cursor = Cursors.Hand;

                    if (!string.IsNullOrEmpty(imagePath) && (System.IO.File.Exists(imagePath)))
                    {
                        currentShortcut.ImageLocation = imagePath;
                    }
                    else
                    {
                        if ((newLocation.Loc != null) && (System.IO.File.Exists(newLocation.Loc)))
                        {
                            currentShortcut.Image = Icon.ExtractAssociatedIcon(newLocation.Loc).ToBitmap();
                        }
                        else
                        {
                            currentShortcut.Image = Properties.Resources.not_found;
                            helpToolTip.SetToolTip(currentShortcut, "file not found!");
                        }
                    }
                }
                else
                {
                    // separator
                    currentShortcut.ContextMenuStrip = separatorContextMenu;
                    currentShortcut.Width = separatorSize;
                    currentShortcut.Cursor = Cursors.Default;
                    currentShortcut.Image = Properties.Resources.separator;
                    helpToolTip.SetToolTip(currentShortcut, "separator");
                }

                if (Properties.Settings.Default.quickLauncherOnlyOneLine)
                {
                    // tout sur la meme ligne
                    currentShortcut.Margin = paddingOneLineAlone;
                    quickLaunchFlowLayoutPanelUp.Controls.Add(currentShortcut);
                    if (flowLayoutPanelInsertIndex != -1)
                    {
                        quickLaunchFlowLayoutPanelUp.Controls.SetChildIndex(currentShortcut, flowLayoutPanelInsertIndex);
                    }
                }
                else
                {
                    // 2 lignes d'icones
                    newLocation.Parameters.TryGetValue("position", out string positionValue);
                    if (Convert.ToInt16(positionValue) == XtreamToolbox.Location.PARAMETERS_POSITION_2ND_LINE)
                    {
                        currentShortcut.Margin = paddingSecondLine;
                        quickLaunchFlowLayoutPanelDown.Controls.Add(currentShortcut);
                        if (flowLayoutPanelInsertIndex != -1)
                        {
                            quickLaunchFlowLayoutPanelDown.Controls.SetChildIndex(currentShortcut, flowLayoutPanelInsertIndex);
                        }
                    }
                    else
                    {
                        currentShortcut.Margin = paddingFirstLine;
                        quickLaunchFlowLayoutPanelUp.Controls.Add(currentShortcut);
                        if (flowLayoutPanelInsertIndex != -1)
                        {
                            quickLaunchFlowLayoutPanelUp.Controls.SetChildIndex(currentShortcut, flowLayoutPanelInsertIndex);
                        }
                    }
                }
            }
        }

        private void FindInsertPosition(int mouseX, int mouseY, out FlowLayoutPanel flowLayoutPanel, out int flowLayoutPanelInsertIndex, out int locationInsertIndex)
        {
            Point clientPoint;
            int totalWidth = startTotalWidth;
            flowLayoutPanel = quickLaunchFlowLayoutPanelUp;
            flowLayoutPanelInsertIndex = 0;
            locationInsertIndex = 0;

            // where have you drop this file?
            clientPoint = quickLaunchFlowLayoutPanelUp.PointToClient(new Point(mouseX, mouseY));
            if ((clientPoint != null) && ((clientPoint.Y < 0) || (clientPoint.Y > quickLaunchFlowLayoutPanelUp.Height)))
            {
                flowLayoutPanel = quickLaunchFlowLayoutPanelDown;
                clientPoint = quickLaunchFlowLayoutPanelDown.PointToClient(new Point(mouseX, mouseY));
                foreach (Control control in quickLaunchFlowLayoutPanelDown.Controls)
                {
                    if (totalWidth > clientPoint.X)
                    {
                        break;
                    }
                    totalWidth += control.Width + control.Margin.Left + control.Margin.Right;
                    flowLayoutPanelInsertIndex++;
                }
                if (flowLayoutPanelInsertIndex > quickLaunchFlowLayoutPanelDown.Controls.Count)
                {
                    flowLayoutPanelInsertIndex = quickLaunchFlowLayoutPanelDown.Controls.Count;
                }
            }
            else
            {
                foreach (Control control in quickLaunchFlowLayoutPanelUp.Controls)
                {
                    if (totalWidth > clientPoint.X)
                    {
                        break;
                    }
                    totalWidth += control.Width + control.Margin.Left + control.Margin.Right;
                    flowLayoutPanelInsertIndex++;
                }
                if (flowLayoutPanelInsertIndex > quickLaunchFlowLayoutPanelUp.Controls.Count)
                {
                    flowLayoutPanelInsertIndex = quickLaunchFlowLayoutPanelUp.Controls.Count;
                }
            }

            // find insert position in location list            
            Location currentLocation;
            int positionLeft = flowLayoutPanelInsertIndex;
            foreach (String locationStr in Properties.Settings.Default.location)
            {
                currentLocation = XtreamToolbox.Location.FromString(locationStr);
                locationInsertIndex++;
                if (currentLocation.Type == XtreamToolbox.Location.APPLICATION)
                {
                    currentLocation.Parameters.TryGetValue("position", out string positionValue);
                    if (((flowLayoutPanel == quickLaunchFlowLayoutPanelUp) && (Convert.ToInt16(positionValue) == XtreamToolbox.Location.PARAMETERS_POSITION_1ST_LINE))
                    || ((flowLayoutPanel == quickLaunchFlowLayoutPanelDown) && (Convert.ToInt16(positionValue) == XtreamToolbox.Location.PARAMETERS_POSITION_2ND_LINE)))
                    {
                        positionLeft--;
                    }
                    if (positionLeft <= 0)
                    {
                        break;
                    }
                }
            }
        }

        private void AddSeparatorBeforeThisItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Location newLocation;

            ContextMenuStrip contextMenuStrip = (ContextMenuStrip)((ToolStripDropDownItem)sender).Owner;
            PictureBox currentShortcut = (PictureBox)contextMenuStrip.SourceControl;
            XtreamToolbox.Location currentLocation = (Location)currentShortcut.Tag;
            currentLocation.Parameters.TryGetValue("position", out string positionValue);
            bool firstLine = (Convert.ToInt16(positionValue) == XtreamToolbox.Location.PARAMETERS_POSITION_1ST_LINE);

            // create new separator location
            newLocation = XtreamToolbox.Location.InsertSeparator(Properties.Settings.Default.location.IndexOf(currentLocation.ToDelimitedString()), firstLine);

            // add this separator to the flowLayout concerned
            InsertShortcut(newLocation, currentShortcut.Parent.Controls.IndexOf(currentShortcut));
        }

        private void Shortcut_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                originalLocation = new Point(e.X, e.Y);
                currentMovingShortcut = (PictureBox)sender;
            }
        }

        private void Shortcut_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentMovingShortcut != null)
            {
                if ((moveShortcut) || ((Math.Abs(e.X - originalLocation.X) > (currentMovingShortcut.Width / 2)) || (Math.Abs(e.Y - originalLocation.Y) > (currentMovingShortcut.Height / 2))))
                {
                    moveShortcut = true;
                    this.Cursor = Cursors.Default;
                    Point screenRelativePoint = ((PictureBox)sender).PointToScreen(new Point(e.X, e.Y));
                    Point sensorRelativePoint = this.PointToClient(screenRelativePoint);
                    int X = sensorRelativePoint.X - (currentMovingShortcut.Width / 2);
                    int Y = sensorRelativePoint.Y - (currentMovingShortcut.Height / 2);
                    if (X < 0)
                    {
                        X = 0;
                    }
                    else if (X > (this.Width - currentMovingShortcut.Width))
                    {
                        X = this.Width - currentMovingShortcut.Width;
                    }
                    if (Y < 0)
                    {
                        Y = 0;
                    }
                    else if (Y > (this.Height - currentMovingShortcut.Height))
                    {
                        Y = this.Height - currentMovingShortcut.Height;
                    }
                    moveShortcutPictureBox.Left = X;
                    moveShortcutPictureBox.Top = Y;
                    if (!moveShortcutPictureBox.Visible)
                    {
                        this.MaximumSize = new Size(this.Width, this.Height);
                        moveShortcutPictureBox.Image = currentMovingShortcut.Image;
                        moveShortcutPictureBox.Width = currentMovingShortcut.Width;
                        moveShortcutPictureBox.Height = currentMovingShortcut.Height;
                        moveShortcutPictureBox.Visible = true;
                    }
                }
            }
        }

        private void Shortcut_MouseUp(object sender, MouseEventArgs e)
        {
            if (moveShortcut)
            {
                this.MaximumSize = new Size(0, 0);
                int locationIndex = Properties.Settings.Default.location.IndexOf(((Location)currentMovingShortcut.Tag).ToDelimitedString());
                Location location = (Location)currentMovingShortcut.Tag;
                Point pt = currentMovingShortcut.PointToScreen(new Point(e.X, e.Y));

                Location newLocation = XtreamToolbox.Location.FromString(location.ToDelimitedString());

                // find in which flowLayoutPanel to insert, in which position, and where to insert in location list
                FindInsertPosition(pt.X, pt.Y, out FlowLayoutPanel flowLayoutPanel, out int flowLayoutPanelInsertIndex, out int locationInsertIndex);

                // change location line
                newLocation.Parameters.Remove("position");
                if (flowLayoutPanel.Equals(quickLaunchFlowLayoutPanelUp))
                {
                    newLocation.Parameters.Add("position", Convert.ToString(XtreamToolbox.Location.PARAMETERS_POSITION_1ST_LINE));
                }
                else
                {
                    newLocation.Parameters.Add("position", Convert.ToString(XtreamToolbox.Location.PARAMETERS_POSITION_2ND_LINE));
                }

                if (!(((locationIndex == locationInsertIndex - 1) || (locationIndex == locationInsertIndex)) && (location.ToDelimitedString().Equals(newLocation.ToDelimitedString()))))
                {
                    // insert new location, remove old
                    Properties.Settings.Default.location.RemoveAt(locationIndex);
                    if (locationInsertIndex > Properties.Settings.Default.location.Count)
                    {
                        locationInsertIndex = Properties.Settings.Default.location.Count;
                    }
                    Properties.Settings.Default.location.Insert(locationInsertIndex, newLocation.ToDelimitedString());

                    // create shortcut picturebox, add and move it to it's correct position
                    InsertShortcut(newLocation, flowLayoutPanelInsertIndex);
                    // delete old shortcut
                    if (quickLaunchFlowLayoutPanelUp.Controls.Contains(currentMovingShortcut))
                    {
                        quickLaunchFlowLayoutPanelUp.Controls.Remove(currentMovingShortcut);
                    }
                    else
                    {
                        quickLaunchFlowLayoutPanelDown.Controls.Remove(currentMovingShortcut);
                    }
                }
                moveShortcut = false;
                this.Cursor = Cursors.Default;
                moveShortcutPictureBox.Visible = false;
            }
            currentMovingShortcut = null;
        }
    }
}
