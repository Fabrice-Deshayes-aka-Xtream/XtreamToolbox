using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace XtreamToolbox
{
    public partial class PhotosRenamerForm : Form
    {

        // delegate méthode for adding line to listbox in threadsafe mode from background worker
        public delegate void addLogsDelegate(String logs);

        // ressource manager pour accéder aux chaines localisées
        ResourceManager resources = Properties.Resources.ResourceManager;

        // default search pattern for photos to rename
        private String searchPattern = "*.jpg";

        // constructor
        public PhotosRenamerForm()
        {
            InitializeComponent();

            SimulateButton.Enabled = false;
            renameButton.Enabled = false;

            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            this.Text = resources.GetString("FormName_ExifRenamer", culture);
        }

        // launch simulation
        private void SimulateButton_Click(object sender, EventArgs e)
        {
            ManageGUI(false);
            searchPattern = searchPatternComboBox.Text;
            if (!renamerBackgroundWorker.IsBusy)
            {
                renamerBackgroundWorker.RunWorkerAsync(true);
            }
        }

        // launch rename process
        private void RenameButton_Click(object sender, EventArgs e)
        {
            ManageGUI(false);
            searchPattern = searchPatternComboBox.Text;
            if (!renamerBackgroundWorker.IsBusy)
            {
                renamerBackgroundWorker.RunWorkerAsync(false);
            }
        }

        // browse folder to rename
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (imagesFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                imagesPathTextBox.Text = imagesFolderBrowserDialog.SelectedPath;
            }
        }

        // update rename's directory
        private void ImagesPathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Directory.Exists(imagesPathTextBox.Text))
            {
                SimulateButton.Enabled = true;
                renameButton.Enabled = true;
            }
            else
            {
                SimulateButton.Enabled = false;
                renameButton.Enabled = false;
            }
        }

        // clear result logs
        private void ClearButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            resultListBox.Items.Clear();
        }

        // add a line in result logs in thread safe mode
        private void AddLogs(String logs)
        {
            if (InvokeRequired)
            {
                Invoke(new addLogsDelegate(AddLogs), new object[] { logs });
            }
            else
            {
                // Update the UI
                resultListBox.Items.Add(logs);
                if (!scrollLockCheckBox.Checked)
                {
                    resultListBox.SetSelected(resultListBox.Items.Count - 1, true);
                    resultListBox.SetSelected(resultListBox.Items.Count - 1, false);
                }
                resultListBox.Refresh();
            }
        }

        // cancel simulation or rename process
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (renamerBackgroundWorker.IsBusy)
            {
                renamerBackgroundWorker.CancelAsync();
                ManageGUI(true);
            }
        }

        // manage enable/disable of GUI Button
        private void ManageGUI(bool enable)
        {
            cancelButton.Enabled = !enable;
            browseButton.Enabled = enable;
            SimulateButton.Enabled = enable;
            renameButton.Enabled = enable;
        }

        // it's forbidden to close Jpeg renamer when it's busy, must cancel operation before
        private void PhotosRenamerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (!renamerBackgroundWorker.IsBusy)
            {
                Hide();
            }
        }

        // rename jpg in background
        private void RenamerBackgroundWorker_DoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            String currentExifDate = null;
            String currentImageName = null;
            String newImageName = null;
            String originalImageName = null;
            String currentImagePath = null;
            int nbImgRenamed = 0;
            int nbImgIgnored = 0;
            int nbImgError = 0;
            int nbImgNoChange = 0;
            int nbImgCorrectDate = 0;
            int progressCurrentValue = 0;
            int progressMaximumValue = 0;
            Stopwatch timeWatcher = new Stopwatch();
            bool simulation = (bool)doWorkEventArgs.Argument;
            bool recursiveMode = recursiveModeRadioButton.Checked;
            String currentPhotoStr;

            timeWatcher.Start();

            CultureInfo culture = new CultureInfo(Properties.Settings.Default.language);

            if (simulation)
            {
                AddLogs(String.Format(resources.GetString("JpgRenamer_SimulationStart", culture), imagesPathTextBox.Text));
            }
            else
            {
                AddLogs(String.Format(resources.GetString("JpgRenamer_RenameStart", culture), imagesPathTextBox.Text));
            }
            List<FileSystemInfo> fileSystemInfos = FindFiles(imagesPathTextBox.Text, searchPattern, recursiveMode);
            progressMaximumValue = fileSystemInfos.Count;
            AddLogs(String.Format(resources.GetString("JpgRenamer_NPhotosToRename", culture), progressMaximumValue));
            AddLogs("");

            if (progressMaximumValue != 0)
            {
                renamerBackgroundWorker.ReportProgress((progressCurrentValue * 100) / progressMaximumValue);
            }

            foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
            {
                if (renamerBackgroundWorker.CancellationPending)
                {
                    doWorkEventArgs.Cancel = true;
                    break;
                }
                progressCurrentValue += 1;
                renamerBackgroundWorker.ReportProgress((progressCurrentValue * 100) / progressMaximumValue);

                currentPhotoStr = String.Format("[{0}/{1}]  ", progressCurrentValue.ToString().PadLeft(progressMaximumValue.ToString().Length, '0'), progressMaximumValue.ToString().PadLeft(progressMaximumValue.ToString().Length, '0'));

                try
                {
                    currentImageName = fileSystemInfo.Name;
                    currentImagePath = new FileInfo(fileSystemInfo.FullName).Directory.FullName;
                    currentExifDate = GetExifDate(fileSystemInfo.FullName);
                    if (currentExifDate != null)
                    {
                        currentExifDate = String.Format("[{0}] ", currentExifDate.Replace(':', '-'));
                        if (currentImageName.StartsWith("["))
                        {
                            originalImageName = currentImageName.Substring(currentImageName.IndexOf(']') + 2);
                            newImageName = currentExifDate + originalImageName;
                            if (fileSystemInfo.FullName.Equals(currentImagePath + "\\" + newImageName))
                            {
                                // no changes to do. Filename is already good
                                nbImgNoChange++;
                                AddLogs(currentPhotoStr + String.Format(resources.GetString("JpgRenamer_Action1", culture), currentImageName));
                            }
                            else
                            {
                                // correct EXIF date in filename
                                nbImgCorrectDate++;
                                AddLogs(currentPhotoStr + String.Format(resources.GetString("JpgRenamer_Action2", culture), currentImageName, newImageName));
                            }
                        }
                        else
                        {
                            // rename image
                            newImageName = currentExifDate + currentImageName;
                            AddLogs(currentPhotoStr + String.Format(resources.GetString("JpgRenamer_Action3", culture), currentImageName, newImageName));
                            nbImgRenamed++;
                            if (!simulation)
                            {
                                File.Move(fileSystemInfo.FullName, currentImagePath + "\\" + newImageName);
                            }
                        }
                    }
                    else
                    {
                        // no EXIF datas. Can't rename this photo
                        AddLogs(currentPhotoStr + String.Format(resources.GetString("JpgRenamer_Action4", culture), currentImageName));
                        nbImgIgnored++;
                    }
                }
                catch (Exception exception)
                {
                    // ERROR
                    AddLogs(currentPhotoStr + String.Format(resources.GetString("JpgRenamer_Error", culture), exception.Message));
                    nbImgError++;
                }
            }
            timeWatcher.Stop();

            AddLogs("_____________________________________________________________________________________________");
            AddLogs("");
            String recursiveModeStr = resources.GetString("JpgRenamer_RecursiveMode", culture);
            if (!recursiveMode)
            {
                recursiveModeStr = resources.GetString("JpgRenamer_NormalMode", culture);
            }

            String completeStr = resources.GetString("JpgRenamer_Complete", culture);
            if (renamerBackgroundWorker.CancellationPending)
            {
                completeStr = resources.GetString("JpgRenamer_Canceled", culture);
            }

            if (simulation)
            {
                AddLogs(String.Format(resources.GetString("JpgRenamer_ReportSimulation1", culture), completeStr, progressMaximumValue, recursiveModeStr, (timeWatcher.ElapsedMilliseconds / 1000)));
                AddLogs(String.Format(resources.GetString("JpgRenamer_ReportSimulation2", culture), nbImgRenamed));
                if (nbImgIgnored > 0)
                {
                    AddLogs(String.Format(resources.GetString("JpgRenamer_ReportSimulation3", culture), nbImgIgnored));
                }
                if (nbImgNoChange > 0)
                {
                    AddLogs(String.Format(resources.GetString("JpgRenamer_ReportSimulation4", culture), nbImgNoChange));
                }
                if (nbImgCorrectDate > 0)
                {
                    AddLogs(String.Format(resources.GetString("JpgRenamer_ReportSimulation5", culture), nbImgCorrectDate));
                }
            }
            else
            {
                AddLogs(String.Format(resources.GetString("JpgRenamer_ReportRename1", culture), completeStr, progressMaximumValue, recursiveModeStr, (timeWatcher.ElapsedMilliseconds / 1000)));
                AddLogs(String.Format(resources.GetString("JpgRenamer_ReportRename2", culture), nbImgRenamed));
                if (nbImgIgnored > 0)
                {
                    AddLogs(String.Format(resources.GetString("JpgRenamer_ReportRename3", culture), nbImgIgnored));
                }
                if (nbImgNoChange > 0)
                {
                    AddLogs(String.Format(resources.GetString("JpgRenamer_ReportRename4", culture), nbImgNoChange));
                }
                if (nbImgCorrectDate > 0)
                {
                    AddLogs(String.Format(resources.GetString("JpgRenamer_ReportRename5", culture), nbImgCorrectDate));
                }
                if (nbImgError > 0)
                {
                    AddLogs(String.Format(resources.GetString("JpgRenamer_ReportRename6", culture), nbImgError));
                }
            }
            AddLogs("_____________________________________________________________________________________________");
            AddLogs("");
        }

        // update progressBar
        private void RenamerBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs progressChangedEventArgs)
        {
            progressBar.Value = progressChangedEventArgs.ProgressPercentage;
            progressBar.Refresh();
        }

        // occurs when simulation or rename job is completed
        private void RenamerBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
        {
            ManageGUI(true);
        }

        // récupére la liste des fichiers respectant la searchPattern (ex : *.jpg) contenu dans le chemin "path"
        public static List<FileSystemInfo> FindFiles(String path, String searchPattern, bool recursiveMode)
        {
            List<FileSystemInfo> retour = new List<FileSystemInfo>();

            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                try
                {
                    FileSystemInfo[] fileSystemInfos = directoryInfo.GetFileSystemInfos(searchPattern);
                    foreach (FileSystemInfo fileSystemInfo in fileSystemInfos)
                    {
                        retour.Add(fileSystemInfo);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message, exception);
                }
                if (recursiveMode)
                {
                    try
                    {
                        DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                        foreach (DirectoryInfo currentDirectoryInfo in directoryInfos)
                        {
                            retour.AddRange(FindFiles(currentDirectoryInfo.FullName, searchPattern, recursiveMode));
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message, exception);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message, exception);
            }

            return retour;
        }

        // get Exif date for JPEG/TIFF image in format : yyyy:MM:dd hh:mm:ss
        public static String GetExifDate(String imageFilename)
        {
            ASCIIEncoding asciiEncoder = new ASCIIEncoding();
            String exifDate = null;
            try
            {
                Image img = new Bitmap(@imageFilename);
                exifDate = asciiEncoder.GetString(img.GetPropertyItem(0x9003).Value);
                img.Dispose();
                if (exifDate.EndsWith("\0"))
                {
                    exifDate = exifDate.Substring(0, exifDate.LastIndexOf("\0"));
                }
            }
            catch (Exception exception)
            {
                // no exif date... nothing to do
                Console.WriteLine(exception.Message, exception);
            }
            return exifDate;
        }
    }
}