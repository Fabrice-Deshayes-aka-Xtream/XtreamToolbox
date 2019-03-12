using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using Xtream_ToolBox.Utils;
using System.Runtime.InteropServices;

namespace Xtream_ToolBox.Sensors {
    public partial class SensorNotepadExtendedPanel : Form {

        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        // constructor
        public SensorNotepadExtendedPanel() {
            InitializeComponent();
            Initialisation();
            SystemUtils.HideFromAltTab(this);
        }

        // Init GUI
        private void Initialisation() {
            this.Text = resources.GetString("FormName_Notepad");

            ToolBoxUtils.ConfigureTooltips(helpToolTip);

            notepadTextBox.Clear();
            notepadTextBox.AppendText(Properties.Settings.Default.notepadTxt);
        }

        // Close Notepad sensor
        private void CloseExtendedInfosPictureBox_Click(object sender, EventArgs e) {
            Hide();
        }

        // Save notepad text in system properties
        private void SaveNotepadInSettings() {
            Properties.Settings.Default.notepadTxt = notepadTextBox.Text;
            Properties.Settings.Default.Save();
        }

        // Save notepad text in system properties on each key typed
        private void NotepadTextBox_KeyUp(object sender, KeyEventArgs e) {
            SaveNotepadInSettings();
        }

        // Clear notepad
        private void ClearButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show(resources.GetString("Notepad_ConfirmeClear"), resources.GetString("Notepad_ConfirmeClearTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                notepadTextBox.Clear();
            }
            SaveNotepadInSettings();            
        }

        // Load text file in notepad
        private void LoadButton_Click(object sender, EventArgs e) {
            try {
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    if (MessageBox.Show(resources.GetString("Notepad_ConfirmeClear"), resources.GetString("Notepad_ConfirmeClearTitle"), MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    {
                        saveFileDialog.FileName = openFileDialog.FileName;
                        notepadTextBox.Clear();
                        notepadTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                        SaveNotepadInSettings();
                    }
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        // save notepad to text file
        private void SaveButton_Click(object sender, EventArgs e) {
            try {
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                    File.AppendAllText(saveFileDialog.FileName, notepadTextBox.Text);
                }
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }
    }
}