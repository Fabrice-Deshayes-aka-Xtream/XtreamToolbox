using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Xtream_ToolBox.Utils {
    class ToolBoxUtils {

        private const int EXTENDED_PANEL_POSITION_TOP = 0;
        private const int EXTENDED_PANEL_POSITION_BOTTOM = 1;
        private const int EXTENDED_PANEL_POSITION_AUTOMATIC = 2;

        public static int UP = 1;
        public static int DOWN = 2;

        // manage enable status of up/down button
        public static bool ManageUpDownButton(ListBox listBox, int button) {
            bool retour;

            if (listBox.SelectedItem == null) {
                retour = false;
            } else {
                if (button == UP) {
                    if (listBox.SelectedIndex > 0) {
                        retour = true;
                    } else {
                        retour = false;
                    }
                } else {
                    if (listBox.SelectedIndex < (listBox.Items.Count - 1)) {
                        retour = true;
                    } else {
                        retour = false;
                    }
                }
            }

            return retour;
        }

        // move up or down item in a listBox
        public static void MoveSelectedItem(ListBox listBox, int direction) {
            Object itemToMove = listBox.SelectedItem;
            if (itemToMove != null) {
                int itemToMoveIndex = listBox.SelectedIndex;
                listBox.Items.RemoveAt(itemToMoveIndex);
                if (direction == UP) {
                    listBox.Items.Insert(itemToMoveIndex - 1, itemToMove);
                    listBox.SelectedIndex = itemToMoveIndex - 1;
                } else {
                    listBox.Items.Insert(itemToMoveIndex + 1, itemToMove);
                    listBox.SelectedIndex = itemToMoveIndex + 1;
                }
            }
        }

        public static void ManageExtendedPanelPosition(UserControl sensor, ToolBox toolbox, Form extendedPanel) {
            if ((extendedPanel != null) && (!extendedPanel.IsDisposed)) {
                extendedPanel.TopMost = toolbox.TopMost;

                switch (Properties.Settings.Default.extendedInfosPanel) {
                    case EXTENDED_PANEL_POSITION_TOP:
                        extendedPanel.Left = toolbox.Left + sensor.Left;
                        extendedPanel.Top = toolbox.Top - extendedPanel.Height;
                        break;
                    case EXTENDED_PANEL_POSITION_BOTTOM:
                        extendedPanel.Left = toolbox.Left + sensor.Left;
                        extendedPanel.Top = toolbox.Bottom;
                        break;
                    case EXTENDED_PANEL_POSITION_AUTOMATIC:
                    default:
                        if ((toolbox.Top + (toolbox.Height / 2)) > (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2)) {
                            // top
                            extendedPanel.Left = toolbox.Left + sensor.Left;
                            extendedPanel.Top = toolbox.Top - extendedPanel.Height;
                        } else {
                            // bottom
                            extendedPanel.Left = toolbox.Left + sensor.Left;
                            extendedPanel.Top = toolbox.Bottom;
                        }
                        break;
                }

                if (extendedPanel.Right > toolbox.Right) extendedPanel.Left = toolbox.Right - extendedPanel.Width;
            }
        }

        public static Rectangle ManageMagneticPosition(Rectangle toolboxArea, List<int> magneticXPositions, List<int> magneticYPositions, int precision, bool magneticActive) {
            Rectangle retour = toolboxArea;

            if (magneticActive) {
                foreach (int currentMagneticPosition in magneticXPositions) {
                    // magnetisme de centrage horizontal
                    if (Math.Abs((retour.Left + (retour.Width / 2)) - currentMagneticPosition) < precision) {
                        retour.X = currentMagneticPosition - (retour.Width / 2);
                    }
                    // magnetisme à gauche
                    if (Math.Abs(retour.Left - currentMagneticPosition) < precision) {
                        retour.X = currentMagneticPosition;
                    }

                    // magnetisme à droite
                    if (Math.Abs(retour.Right - currentMagneticPosition) < precision) {
                        retour.X = currentMagneticPosition - retour.Width;
                    }
                }

                foreach (int currentMagneticPosition in magneticYPositions) {
                    // magnetisme en haut
                    if (Math.Abs(retour.Top - currentMagneticPosition) < precision) {
                        retour.Y = currentMagneticPosition;
                    }

                    // magnetisme en bas
                    if (Math.Abs(retour.Bottom - currentMagneticPosition) < precision) {
                        retour.Y = currentMagneticPosition - retour.Height;
                    }
                }
            }
            return retour;
        }

        public static String WordWrap(String chaine, int width) {
            String[] splittedString = chaine.Split(' ');
            String finalString = "";
            int nbChar = 0;

            foreach (String currentStr in splittedString) {
                finalString += currentStr;
                nbChar += currentStr.Length;
                if (nbChar > width) {
                    finalString += Environment.NewLine;
                    nbChar = 0;
                } else {
                    finalString += " ";
                }
            }
            return finalString;
        }

        public static void ConfigureTooltips(ToolTip tooltip) {
            tooltip.AutomaticDelay = Properties.Settings.Default.hintsAfter;
            tooltip.AutoPopDelay = Properties.Settings.Default.hintsLength;
            tooltip.ReshowDelay = Properties.Settings.Default.hintsReshow;
            tooltip.InitialDelay = Properties.Settings.Default.hintsAfter;
            tooltip.Active = Properties.Settings.Default.hintsActive;
        }

        public static void SetTooltips(ToolTip tooltip, Control control, String message) {
            if (Properties.Settings.Default.hintsActive) {
                tooltip.SetToolTip(control, message);
            }
        }
    }
}
