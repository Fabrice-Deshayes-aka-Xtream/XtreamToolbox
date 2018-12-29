using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading;
using System.Resources;
using System.Windows.Forms;
using System.Diagnostics;

namespace Xtream_ToolBox {

    class SystemUtils {

        #region Native Win32 API functions
        private class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern void LockWorkStation();

            [DllImport("user32.dll")]
            internal static extern bool ExitWindowsEx(uint flags, uint reason);

            [DllImport("kernel32.dll", ExactSpelling = true)]
            internal static extern IntPtr GetCurrentProcess();

            [DllImport("wtsapi32.dll", SetLastError = true)]
            internal static extern bool WTSDisconnectSession(IntPtr hServer, int sessionId, bool bWait);

            [DllImport("advapi32.dll")]
            internal static extern System.Boolean OpenProcessToken(
                IntPtr ProcessHandle,
                uint DesiredAccess,
                ref IntPtr Tokenhandle
            );

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
            internal static extern System.Boolean LookupPrivilegeValue(
                string lpSsytemName,
                string lpName,
                ref LUID pluid
            );

             [DllImport("advapi32.dll", CharSet = CharSet.Unicode)]
            internal static extern int AdjustTokenPrivileges(
                IntPtr TokenHandle,
                [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,
                [MarshalAs(UnmanagedType.Struct)] ref TOKEN_PRIVILEGES NewState,
                int BufferLength,
                long PreviousState,
                long ReturnLength
            );

            [DllImport("user32.dll")]
            internal static extern int GetForegroundWindow();

            [DllImport("user32.dll")]
            internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

            [DllImport("user32.dll")]
            internal static extern int GetWindowRect(IntPtr hWnd, ref RECT rect);

            // find a process windows by classname or windows name
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Unicode)]
            internal static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

            // get windows title
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Unicode)]
            internal static extern int GetWindowText(IntPtr hwnd, string lpString, int cch);

            // send windows message to other windows
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
            internal static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

            [DllImport("user32", CharSet = CharSet.Auto)]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32", CharSet = CharSet.Auto)]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

            [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
            internal static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);

            [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
            internal static extern int SHQueryRecycleBin(string pszRootPath, ref SHQUERYRBINFO pSHQueryRBInfo);

            [DllImport("wininet.dll", SetLastError = true)]
            internal static extern int InternetAttemptConnect(uint res);

            [DllImport("wininet.dll", SetLastError = true)]
            internal static extern bool InternetGetConnectedState(long flags, int reserved);

            // Start Get Key Status
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
            internal static extern short GetKeyState(Keys keyCode);
        }
        #endregion

        // Shutdown / Reboot / LogOff / LockWokStation - Start

        public enum EWX_ENUM {
            EWX_LOGOFF = 0x00000000,
            EWX_SHUTDOWN = 0x00000001,
            EWX_REBOOT = 0x00000002,
            EWX_FORCE = 0x00000004,
            EWX_POWEROFF = 0x00000008,
            EWX_FORCEIFHUNG = 0x00000010,
            EWX_FORCEREBOOT = EWX_REBOOT | EWX_FORCE,
            EWX_FORCEIFHUNGREBOOT = EWX_REBOOT | EWX_FORCEIFHUNG,
            EWX_FORCESHUTDOWN = EWX_SHUTDOWN | EWX_FORCE,
            EWX_FORCEIFHUNGSHUTDOWN = EWX_SHUTDOWN | EWX_FORCEIFHUNG,
            EWX_FORCEPOWEROFF = EWX_POWEROFF | EWX_FORCE,
            EWX_FORCEIFHUNGPOWEROFF = EWX_POWEROFF | EWX_FORCEIFHUNG,
            EWX_FORCELOGOFF = EWX_LOGOFF | EWX_FORCE,
            EWX_FORCEIFHUNGLOGOFF = EWX_LOGOFF | EWX_FORCEIFHUNG
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LUID {
            public uint LowPart;
            public uint HighPart;
        };

        [StructLayout(LayoutKind.Sequential)]
        public struct TOKEN_PRIVILEGES {
            public uint PriviledgeCount;
            public LUID Luid;
            public uint Attributes;
        }
        // Shutdown / Reboot / LogOff - End

        // find position & size of foreground windows for screenshot - start
        public enum WindowState {
            SW_SHOWNORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        // find position & size of foreground windows for screenshot - end

        internal static void LockWorkStation()
        {
            NativeMethods.LockWorkStation();
        }

        // Begin hide this form from alt tab (overhide activated event)
        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int WS_EX_APPWINDOW = 0x40000;

        public static void HideFromAltTab(Form form) {
            NativeMethods.SetWindowLong(form.Handle, GWL_EXSTYLE, (NativeMethods.GetWindowLong(form.Handle, GWL_EXSTYLE) | WS_EX_TOOLWINDOW) & ~WS_EX_APPWINDOW);
        }
        // Endhide this form from alt tab (overhide activated event)

        enum RecycleFlags : uint {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000002,
            SHERB_NOSOUND = 0x00000004
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHQUERYRBINFO{
            public int cbSize;
            public long i64Size;
            public long i64NumItems;
        }

        private static readonly int ERROR_SUCCESS = 0;
        public static bool IsInternetConnected() {
            long dwConnectionFlags = 0;
            if (!NativeMethods.InternetGetConnectedState(dwConnectionFlags, 0))
                return false;

            if (NativeMethods.InternetAttemptConnect(0) != ERROR_SUCCESS)
                return false;

            return true;
        }

        // ressource manager pour accéder aux chaines localisées
        private static ResourceManager resources = Properties.Resources.ResourceManager;

        // deconnexion de l'utilisateur
        public static void Logoff() {
            ExitSystem(Convert.ToUInt32(EWX_ENUM.EWX_FORCELOGOFF));
        }

        // redémarre le PC
        public static void Restart() {
            ExitSystem(Convert.ToUInt32(EWX_ENUM.EWX_FORCEREBOOT));
        }

        // éteind le PC
        public static void Shutdown() {
            ExitSystem(Convert.ToUInt32(EWX_ENUM.EWX_FORCEPOWEROFF));
        }

        // lock le PC
        public static void LockMyWorkStation() {
            NativeMethods.LockWorkStation();
        }

        // passe en veille prolongée
        public static void Hibernate() {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        // passe en veille
        public static void Suspend() {
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }

        // change d'utilisateur
        public static void SwitchUser() {
            NativeMethods.WTSDisconnectSession(IntPtr.Zero, -1, false);
        }

        // mount network drive
        public static void MountNetworkDrive(String driveLetter, String path) {
            ProcessStartInfo info = new ProcessStartInfo
            {
                FileName = "net.exe",
                Arguments = "use " + driveLetter + ": " + path,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            System.Diagnostics.Process.Start(info);
        }

        // open webpage in default browser
        public static void OpenInDefaultBrowser(String link) {
            try {
                System.Diagnostics.Process.Start(link);
            } catch (Exception exception) {
                MessageBox.Show("Error occured : " + exception.Message + ". You may not have defined a windows default web browser");
            }
        }

        // Grant privilege to this application Shutdown Windows and launch ExitWindowsEx function
        public static void ExitSystem(uint EWX_VALUE) {
            TOKEN_PRIVILEGES tp = new TOKEN_PRIVILEGES();
            LUID luid = new LUID();

            NativeMethods.LookupPrivilegeValue(null, "SeShutdownPrivilege", ref luid);
            IntPtr processHandle = NativeMethods.GetCurrentProcess();
            IntPtr TokenHandle = IntPtr.Zero;
            NativeMethods.OpenProcessToken(processHandle, 0x00000020 | 0x00000008, ref TokenHandle);

            tp.PriviledgeCount = 1;
            tp.Attributes = 0x00000002;
            tp.Luid = luid;

            int tpsz = Marshal.SizeOf(tp);
            tpsz = NativeMethods.AdjustTokenPrivileges(TokenHandle, false, ref tp, tpsz, 0, 0);
            NativeMethods.ExitWindowsEx(EWX_VALUE, 0);
        }
        
        public static bool IsKeyPressedOrToggleOn(Keys testKey) {
            bool keyPressed = false;
            short result = NativeMethods.GetKeyState(testKey);

            switch (result) {
                case 0:
                    // Not pressed and not toggled on.
                    keyPressed = false;
                    break;

                case 1:
                    // Not pressed, but toggled on
                    keyPressed = true;
                    break;

                default:
                    // Pressed (and may be toggled on)
                    keyPressed = true;
                    break;
            }

            return keyPressed;
        }

        // vide la poubelle (avec ou sans confirmation)
        public static uint EmptyRecycleBin(bool disableConfirmation) {
            uint retour;

            if (disableConfirmation) {
                retour = NativeMethods.SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION);
            } else {
                retour = NativeMethods.SHEmptyRecycleBin(IntPtr.Zero, null, 0);
            }

            return retour;
        }

        // récupère des infos sur le contenu de la poubelle
        public static SHQUERYRBINFO GetInfosFromRecycleBin() {
            SHQUERYRBINFO sqrbi = new SHQUERYRBINFO
            {
                cbSize = Marshal.SizeOf(typeof(SHQUERYRBINFO))
            };
            int hresult = NativeMethods.SHQueryRecycleBin(string.Empty, ref sqrbi);
            return sqrbi;
        }

        // récupère la taille d'un fichier
        public static String GetFriendlyBytesSize(long sizeInByte, String displayMode) {
            String friendlyBytesSize = "";
            String byteStr = resources.GetString("Sys_byte");
            String kbyteStr = resources.GetString("Sys_kbyte");
            String mbyteStr = resources.GetString("Sys_mbyte");
            String gbyteStr = resources.GetString("Sys_gbyte");

            if ((displayMode==null) || ("".Equals(displayMode))){
                displayMode = "auto";
            }

            if (("byte".Equals(displayMode)) || (("auto".Equals(displayMode))&&(sizeInByte < 1024))) {
                // display in byte
                friendlyBytesSize = String.Format("{0} {1}", sizeInByte, byteStr);
            } else if (("kbyte".Equals(displayMode)) || (("auto".Equals(displayMode)) && (sizeInByte >= 1024) && (sizeInByte<1024*1024))) {
                // display in kilobyte
                friendlyBytesSize = String.Format("{0} {1}", sizeInByte / 1024, kbyteStr);
            } else if (("mbyte".Equals(displayMode)) || (("auto".Equals(displayMode)) && (sizeInByte >= 1024 * 1024) && (sizeInByte < 1024 * 1024 * 1024))) {
                // display in mb
                friendlyBytesSize = String.Format("{0} {1}", sizeInByte / 1024 / 1024, mbyteStr);
            } else {
                // display in gb
                friendlyBytesSize = String.Format("{0} {1}", Math.Round((decimal)sizeInByte / 1024 / 1024 / 1024, 1), gbyteStr);
            }

            return friendlyBytesSize;
        }

        // récupère une taille formaté à partir d'un nombre de bit
        public static String GetFriendlyBitsSize(long sizeInBits, String displayMode) {
            String friendlyBitsSize = "";
            String bitStr = resources.GetString("Sys_bit");
            String kbitStr = resources.GetString("Sys_kbit");
            String mbitStr = resources.GetString("Sys_mbit");
            String gbitStr = resources.GetString("Sys_gbit");

            if ((displayMode == null) || ("".Equals(displayMode))) {
                displayMode = "auto";
            }

            if (("byte".Equals(displayMode)) || (("auto".Equals(displayMode)) && (sizeInBits < 1000))) {
                // display in byte
                friendlyBitsSize = String.Format("{0} {1}", sizeInBits, bitStr);
            } else if (("kbyte".Equals(displayMode)) || (("auto".Equals(displayMode)) && (sizeInBits >= 1000) && (sizeInBits < 1000 * 1000))) {
                // display in kilobyte
                friendlyBitsSize = String.Format("{0} {1}", sizeInBits / 1000, kbitStr);
            } else if (("mbyte".Equals(displayMode)) || (("auto".Equals(displayMode)) && (sizeInBits >= 1000 * 1000) && (sizeInBits < 1000 * 1000 * 1000))) {
                // display in mb
                friendlyBitsSize = String.Format("{0} {1}", sizeInBits / 1000 / 1000, mbitStr);
            } else {
                // display in gb
                friendlyBitsSize = String.Format("{0} {1}", Math.Round((decimal)sizeInBits / 1000 / 1000 / 1000, 1), gbitStr);
            }

            return friendlyBitsSize;
        }

        // récupère une durée à partir d'un nombre de secondes
        public static String GetFriendlyTimespan(int spanInSeconde, String displayMode) {
            String friendlyTimespan = "";
            String hourStr = resources.GetString("Sys_h");
            String minStr = resources.GetString("Sys_mn");
            String secStr = resources.GetString("Sys_s");

            if ((displayMode == null) || ("".Equals(displayMode))) {
                displayMode = "auto";
            }

            if (("s".Equals(displayMode)) || (("auto".Equals(displayMode)) && (spanInSeconde < 60))) {
                // display in seconds
                friendlyTimespan = String.Format("{0} {1}", spanInSeconde, secStr);
            } else if (("mn".Equals(displayMode)) || (("auto".Equals(displayMode)) && (spanInSeconde >= 60) && (spanInSeconde < 3600))) {
                // display in minutes
                friendlyTimespan = String.Format("{0} {1}", spanInSeconde / 60, minStr);
            } else {
                // display in hours
                friendlyTimespan = String.Format("{0} {1}", Math.Round((decimal)spanInSeconde / 3600, 1), hourStr);
            }

            return friendlyTimespan;
        }

        // lance un processus
        public static String StartProcess(String fileName, String arguments, String workingDirectory) {
            String retour = null;

            try {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.WorkingDirectory = workingDirectory;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.FileName = fileName;
                proc.Start();
                proc.Close(); // Attention Close ne met pas fin au processus.
            } catch (Exception e) {
                retour = e.Message + " (filename : " + fileName + " / argument : " + arguments + ")";
            }

            return retour;
        }

        // return hostname of local machine
        public static String GetHostName() {
            String retour = "";
            
            try {
                retour = Dns.GetHostName();
            } catch (SocketException socketException) {
                Console.WriteLine(socketException.ToString());
            }
            
            return retour;
        }

        // return ip adress of local machine
        public static String GetHostAdress() {
            String retour = "";

            try {
                IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());
                if (adresses.Length > 0) {
                    retour = adresses[0].ToString();
                }
            }catch(Exception exception){
                Console.WriteLine(exception.ToString());
            }

            return retour;
        }

        // lance l'application au démarrage
        public static bool RunOnStart(string Libele, string Fichier, string action) {
            bool retour = true;

            Microsoft.Win32.RegistryKey Key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            switch (action) {
                case "add":
                    Key.SetValue(Libele, Fichier);
                    Key.Close();
                    break;
                case "remove":
                    Key.DeleteValue(Libele, false);
                    Key.Close();
                    break;
                default:
                    // is launch with windows
                    if ((Key == null) || (Key.GetValue(Libele) == null)) {
                        retour = false;
                    } else {
                        retour = true;
                        Key.Close();
                    }
                    break;
            }            
            Key = null;

            return retour;
        }

        /// <summary>
        /// Launches the default mail client.
        /// </summary>
        public static void LaunchDefaultMailClient(string defaultEmailClient) {
            
            if ((defaultEmailClient==null) || (defaultEmailClient.Equals("")) || (defaultEmailClient.Equals("default"))){
                // Open the "HKLM\SOFTWARE\Clients\Mail" key.
                Microsoft.Win32.RegistryKey mailKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\Mail");

                // The default mail application is stored in the default value of that key.
                string defaultMailApp = (string)mailKey.GetValue(null);

                if (defaultMailApp != null && defaultMailApp.Length > 0) {
                    // Open the subkey of the default mail application and the "shell\open\command" key below that.
                    Microsoft.Win32.RegistryKey cmdKey = mailKey.OpenSubKey(defaultMailApp + @"\shell\open\command");

                    // We're now in "HKLM\SOFTWARE\Clients\Mail\<default-mail-app>\shell\open\command".
                    // The default value of this key is the command line to start.
                    string command = (string)cmdKey.GetValue(null);

                    // If there are command arguments, extract them out of the main command string.
                    string args = string.Empty;
                    if (command.IndexOf(" ") > 0) {
                        args = command.Substring(command.IndexOf(" ") + 1);
                        command = command.Substring(0, command.IndexOf(" "));
                    }

                    // Start a new process for the mail application.
                    System.Diagnostics.Process.Start(command, args);
                }
            }else{
                System.Diagnostics.Process.Start(defaultEmailClient);
            }
        }

        public static string FormatSpeedInHertz(Int64 lSpeed) {
            //Format number to Hz
            float floatSpeed = 0;
            string stringSpeed = "";

            if (lSpeed < 1000) {
                //less than 1G Hz
                stringSpeed = lSpeed.ToString() + " MHz";
            } else {
                //convert to Giga Hz
                floatSpeed = (float)lSpeed / 1000;
                stringSpeed = floatSpeed.ToString() + " GHz";
            }

            return stringSpeed;
        }

        public static SystemInformations GetSystemInfo() {
            SystemInformations retour = new SystemInformations();
            ManagementObjectSearcher query = null;
            ManagementObjectCollection queryCollection = null;
            System.Management.ObjectQuery oq = null;
            ConnectionOptions co = new ConnectionOptions();
            ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = null;
            ManagementObject managementObject = null;

            //Point to machine
            System.Management.ManagementScope ms = new System.Management.ManagementScope("\\\\localhost\\root\\cimv2", co);


            try {
                // Operating System infos
                oq = new System.Management.ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                query = new ManagementObjectSearcher(ms, oq);
                queryCollection = query.Get();
                if (queryCollection.Count > 0) {
                    managementObjectEnumerator = queryCollection.GetEnumerator();
                    managementObjectEnumerator.MoveNext();
                    managementObject = (ManagementObject)managementObjectEnumerator.Current;

                    retour.osCaption = managementObject["Caption"].ToString();
                    retour.osVersion = managementObject["Version"].ToString();
                    retour.osManufacturer = managementObject["Manufacturer"].ToString();
                    retour.osWinDir = managementObject["WindowsDirectory"].ToString();
                    retour.osSerialNumber = managementObject["SerialNumber"].ToString();
                    retour.memoryTotalPhysicalMemory = Convert.ToInt64(managementObject["TotalVisibleMemorySize"]) * 1024;
                    retour.osInstallDate = ToDateTime(managementObject["InstallDate"].ToString());
                }

                // page file memory info
                retour.memoryTotalPageFileSpace = 0;
                oq = new System.Management.ObjectQuery("SELECT * FROM Win32_PageFile");
                query = new ManagementObjectSearcher(ms, oq);
                queryCollection = query.Get();
                if (queryCollection.Count > 0) {
                    managementObjectEnumerator = queryCollection.GetEnumerator();
                    while (managementObjectEnumerator.MoveNext()) {
                        managementObject = (ManagementObject)managementObjectEnumerator.Current;
                        retour.memoryTotalPageFileSpace += Convert.ToInt64(managementObject["FileSize"]);
                    }
                }

                // machine info
                oq = new System.Management.ObjectQuery("SELECT * FROM Win32_ComputerSystem");
                query = new ManagementObjectSearcher(ms, oq);
                queryCollection = query.Get();
                if (queryCollection.Count > 0) {
                    managementObjectEnumerator = queryCollection.GetEnumerator();
                    managementObjectEnumerator.MoveNext();
                    managementObject = (ManagementObject)managementObjectEnumerator.Current;

                    retour.computerManufacturerName = managementObject["Manufacturer"].ToString();
                    retour.computerModel = managementObject["model"].ToString();
                    retour.computerSystemType = managementObject["SystemType"].ToString();
                    retour.computerDomain = managementObject["Domain"].ToString();
                    retour.computerUserName = Environment.UserName;
                    retour.computerMachineName = Environment.MachineName.ToLower();
                }

                // processor info
                oq = new System.Management.ObjectQuery("SELECT * FROM Win32_processor");
                query = new ManagementObjectSearcher(ms, oq);
                queryCollection = query.Get();
                if (queryCollection.Count > 0) {
                    managementObjectEnumerator = queryCollection.GetEnumerator();
                    managementObjectEnumerator.MoveNext();
                    managementObject = (ManagementObject)managementObjectEnumerator.Current;

                    retour.processorManufacturer = managementObject["Manufacturer"].ToString();
                    retour.processorCaption = managementObject["Caption"].ToString();
                    retour.processorMaxClockSpeed = Convert.ToInt64(managementObject["MaxClockSpeed"]);
                    retour.processorL2CacheSize = Convert.ToInt64(managementObject["L2CacheSize"]) * 1024;
                }

                // Bios info
                oq = new System.Management.ObjectQuery("SELECT * FROM Win32_bios");
                query = new ManagementObjectSearcher(ms, oq);
                queryCollection = query.Get();
                if (queryCollection.Count > 0) {
                    managementObjectEnumerator = queryCollection.GetEnumerator();
                    managementObjectEnumerator.MoveNext();
                    managementObject = (ManagementObject)managementObjectEnumerator.Current;

                    retour.biosCaption = managementObject["Caption"].ToString();
                    retour.biosVersion = managementObject["version"].ToString();
                }

                // Display info
                retour.displayNbScreen = System.Windows.Forms.Screen.AllScreens.Length;
                System.Windows.Forms.Screen currentScreen;
                if (retour.displayNbScreen > 0) {
                    currentScreen = System.Windows.Forms.Screen.AllScreens[0];
                    retour.displayPrimaryScreenInfos = currentScreen.Bounds.Width + "x" + currentScreen.Bounds.Height + "x" + currentScreen.BitsPerPixel;
                    if (retour.displayNbScreen > 1) {
                        currentScreen = System.Windows.Forms.Screen.AllScreens[1];
                        retour.displaySecondaryScreenInfos = currentScreen.Bounds.Width + "x" + currentScreen.Bounds.Height + "x" + currentScreen.BitsPerPixel;
                    }
                    else {
                        retour.displaySecondaryScreenInfos = "";
                    }
                }

                // Network connection
                if ((NetworkInterface.GetIsNetworkAvailable()) && (NetworkInterface.GetAllNetworkInterfaces().Length > 0)) {
                    NetworkInterface networkInterface = (NetworkInterface)NetworkInterface.GetAllNetworkInterfaces().GetValue(0);
                    retour.networkConnectionSpeed = networkInterface.Speed;
                    retour.networkConnectionName = networkInterface.Name;
                    retour.networkConnectionDescription = networkInterface.Description;
                    retour.networkConnectionType = networkInterface.NetworkInterfaceType.ToString();
                    try {
                        IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());
                        for (int i = 0; i < adresses.Length; i++)
                        {
                            if ((adresses[i].AddressFamily == AddressFamily.InterNetwork) && (retour.networkLocalIpAdresse==null))
                            {
                                retour.networkLocalIpAdresse = adresses[i].ToString();
                            }
                            if ((adresses[i].AddressFamily == AddressFamily.InterNetworkV6) && (retour.networkLocalIpAdresseV6==null)) {
                                retour.networkLocalIpAdresseV6 = adresses[i].ToString();
                            }
                        }
                    } catch (Exception exception) {
                        Console.WriteLine(exception.ToString());
                    }
                }

                // Video 
                oq = new System.Management.ObjectQuery("SELECT * FROM Win32_VideoController");
                query = new ManagementObjectSearcher(ms, oq);
                queryCollection = query.Get();
                if (queryCollection.Count > 0) {
                    managementObjectEnumerator = queryCollection.GetEnumerator();
                    managementObjectEnumerator.MoveNext();
                    managementObject = (ManagementObject)managementObjectEnumerator.Current;

                    retour.videoControllerName = managementObject["Name"].ToString();
                    retour.videoControllerProcessor = managementObject["VideoProcessor"].ToString();
                    retour.videoControllerMode = managementObject["VideoModeDescription"].ToString();
                    retour.videoControllerRam = Convert.ToInt64(managementObject["AdapterRAM"]);
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                if (query!=null) query.Dispose();
                if (queryCollection!=null) queryCollection.Dispose();
                if (managementObjectEnumerator!=null) managementObjectEnumerator.Dispose();
                if (managementObject!=null) managementObject.Dispose();
            }
            return retour;
        }

        //There is a utility called mgmtclassgen that ships with the .NET SDK that
        //will generate managed code for existing WMI classes. It also generates
        // datetime conversion routines like this one.
        //Thanks to Chetan Parmar and dotnet247.com for the help.
        static System.DateTime ToDateTime(string dmtfDate) {
            int year = System.DateTime.Now.Year;
            int month = 1;
            int day = 1;
            int hour = 0;
            int minute = 0;
            int second = 0;
            int millisec = 0;
            string dmtf = dmtfDate;
            string tempString = System.String.Empty;

            if (((System.String.Empty == dmtf) || (dmtf == null))) {
                return System.DateTime.MinValue;
            }

            if ((dmtf.Length != 25)) {
                return System.DateTime.MinValue;
            }

            tempString = dmtf.Substring(0, 4);
            if (("****" != tempString)) {
                year = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(4, 2);

            if (("**" != tempString)) {
                month = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(6, 2);

            if (("**" != tempString)) {
                day = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(8, 2);

            if (("**" != tempString)) {
                hour = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(10, 2);

            if (("**" != tempString)) {
                minute = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(12, 2);

            if (("**" != tempString)) {
                second = System.Int32.Parse(tempString);
            }

            tempString = dmtf.Substring(15, 3);

            if (("***" != tempString)) {
                millisec = System.Int32.Parse(tempString);
            }

            System.DateTime dateRet = new System.DateTime(year, month, day, hour, minute, second, millisec);

            return dateRet;
        }
    }

    public class SystemInformations {
        // operating system informations
        public String osCaption;
        public String osVersion;
        public String osManufacturer;
        public String osWinDir;
        public String osSerialNumber;
        public DateTime osInstallDate;

        // computer information
        public String computerManufacturerName;
        public String computerModel;
        public String computerSystemType;
        public String computerDomain;
        public String computerUserName;
        public String computerMachineName;

        // processor info
        public String processorManufacturer;
        public String processorCaption;
        public Int64 processorMaxClockSpeed;
        public Int64 processorL2CacheSize;

        // Display infos
        public int displayNbScreen;
        public String displayPrimaryScreenInfos;
        public String displaySecondaryScreenInfos;

        // Bios info
        public String biosCaption;
        public String biosVersion;

        // memory configuration
        public Int64 memoryTotalPageFileSpace;
        public Int64 memoryTotalPhysicalMemory;

        // Network connection
        public String networkConnectionName;
        public Int64 networkConnectionSpeed;
        public String networkConnectionType;
        public String networkConnectionDescription;
        public String networkLocalIpAdresse;
        public String networkLocalIpAdresseV6;

        // video controller
        public String videoControllerName;
        public String videoControllerProcessor;
        public String videoControllerMode;
        public Int64 videoControllerRam;
    }

    class SingleInstanceApp : IDisposable {
        // Mutex
        Mutex _siMutex;
        bool _siMutexOwned;

        // Constructeur
        public SingleInstanceApp(string name) {
            _siMutex = new Mutex(false, name);
            _siMutexOwned = false;
        }

        // Application déjà lancée ?
        public bool IsRunning() {
            // Acquisition du mutex.
            // Si _siMutexOwned vaut true, l'application acquiert le mutex car il est "libre"
            // Sinon le mutex a déjà été acquis lors du lancement d'une instance précédente
            _siMutexOwned = _siMutex.WaitOne(0, true);
            return !(_siMutexOwned);
        }

        // Membre de IDisposable
        public void Dispose() {
            // Libération du mutex si il a été acquis
            if (_siMutexOwned)
            {
                _siMutex.ReleaseMutex();
                _siMutex.Dispose();
            }            
        }
    }
}
