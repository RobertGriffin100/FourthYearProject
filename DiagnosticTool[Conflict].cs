using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Net;
using DisplayBox1;

namespace FourthYearProject
{
    public partial class DiagnosticTool : Form
    {

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wp, IntPtr lp);

        public DiagnosticTool()
        {
            InitializeComponent();

            //Checking system for 64 bit and greying out groupboxes/buttons if it is.
            var directory = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)");
            if (Directory.Exists(directory))
            {
                
            }
            else
            {
                progFiles86.Enabled = false;
            }

            ///////////////////////////////////////////////////////////////////////////
            //OS Version Check Code & Ideas taken from:
            //http://stackoverflow.com/questions/13620223/how-to-detect-windows-8-operating-system-using-c-sharp-4-0
            //Check if OS is Windows 8 or 8.1
            var osVersion = new Version(6, 2, 9200, 0);
            if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                Environment.OSVersion.Version >= osVersion)
            {
                Notepad.Enabled = false;
            }

            //Check if OS is earlier than Windows 8
            else if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                     Environment.OSVersion.Version <= osVersion)
            {
                firewall.Enabled = false;
            }
            ////////////////////////////////////////////////////////////////////////////
        }

        //method to run certain processes as admin such as chkdsk & sfc scannow
        private void runAsAdmin(string path, string args)
        {
            var pInfo = new ProcessStartInfo();

            pInfo.FileName = path;
            pInfo.Arguments = args;

            try
            {
                Process.Start(pInfo);
            }
            catch
            {
                MessageBox.Show("Can't do that right now, Please try again soon");
            }
        }

        //Runs Process and displays information out onto form
        private void runAndGet(string command, string args, string label)
        {
            try
            {
                var output = ProcRun.runAndGet(command, args);

                var b = new DisplayBox(output, label);
                b.ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Can't do that right now, Please try again soon");
            }
        }

        private void startService(string service_name, Boolean true_start_false_stop)
        {
            try
            {
                var servC = new ServiceController();
                servC.ServiceName = service_name;

                if (true_start_false_stop)
                    servC.Start();
                else
                    servC.Stop();

                if (true_start_false_stop)
                    servC.WaitForStatus(ServiceControllerStatus.Running);
                else
                    servC.WaitForStatus(ServiceControllerStatus.Stopped);

                string status = servC.Status.ToString();
                MessageBox.Show(service_name + " is now " + status);
            }

            catch (Exception)
            {
                MessageBox.Show(service_name + " can't do that right now, Sorry");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void CompMgmt_Click(object sender, EventArgs e)
        {
            Process.Start("compmgmt.msc");
        }

        private void Home_Click(object sender, EventArgs e)
        {
        }

        private void WindowsSettings_Click(object sender, EventArgs e)
        {
        }

        private void Processes_Click(object sender, EventArgs e)
        {
            //Array of processes to get all current running processes
            var processlist = Process.GetProcesses();

            var processes = "";

            processes += ("Running Processes by Memory Usage \r\n");
            processes += ("================================= \r\n\r\n");
            processes += ("Memory (mb) \tProcess Name \r\n\r\n");

            //An enumerator to list the processes in descending order
            IEnumerable<Process> p = processlist.OrderByDescending(proc => proc.PrivateMemorySize64);

            //A Foreach loop to print the processnames & memory usage in MB to 2 decimal places
            foreach (var theprocess in p)
            {
                //Dividing PMsize64 to give the output in mb instead of bytes
                processes += " " + ((theprocess.PrivateMemorySize64/1024)/1024).ToString("F")
                             + "\t\t" + theprocess.ProcessName + " \r\n";
            }
            //Displaying it through the Displaybox class
            var ProcessesBox = new DisplayBox(processes, "");
            ProcessesBox.ShowDialog(this);
        }

        private void InternetOptions_Click(object sender, EventArgs e)
        {
            Process.Start("inetcpl.cpl");
        }

        private void SystemInfo_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("msinfo32");
            }
            catch
            {
            }
        }

        private void TaskManager_Click(object sender, EventArgs e)
        {
            Process.Start("taskmgr.exe");
        }

        private void ConfigTool_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SystemInfo.Enabled = false;
        }

        private void Show_All_Click(object sender, EventArgs e)
        {
            SystemInfo.Enabled = true;
        }

        private void Exp_tooltip_Popup(object sender, PopupEventArgs e)
        {
        }

        private void AddRemove_Click(object sender, EventArgs e)
        {
            Process.Start("control", "appwiz.cpl");
        }

        private void SysProperties_Click(object sender, EventArgs e)
        {
            Process.Start("control", "sysdm.cpl");
        }

        private void DeviceMngr_Click(object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void Printers_Click(object sender, EventArgs e)
        {
            Process.Start("::{2227A280-3AEA-1069-A2DE-08002B30309D}");
        }

        //Switch statement to cycle through options which will highlight various commands and functions relating to problem
        private void winSetCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (winSetCombo.SelectedItem.ToString().Trim())
            {
                case "My HardDrive is full":
                    tabControl1.SelectedTab = WindowsSettings; //Changes tab depending on the user input
                    groupBox1.Enabled = false;
                    system_Info.Enabled = false;
                    DataCollection.Enabled = false;
                    Misc.Enabled = false;
                    Devices_Printers.Enabled = false;
                    break;

                case "My Printer is not working":
                    tabControl1.SelectedTab = WindowsSettings;
                    groupBox1.Enabled = false;
                    system_Info.Enabled = false;
                    DataCollection.Enabled = false;
                    Misc.Enabled = false;
                    Devices_Printers.Enabled = true;
                    break;

                case "My Internet is not working":
                    tabControl1.SelectedTab = Network;
                    break;

                default:
                    break;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            system_Info.Enabled = true;
            DataCollection.Enabled = true;
            Misc.Enabled = true;
            Devices_Printers.Enabled = true;
        }

        private void resetAdv_Click(object sender, EventArgs e)
        {
        }

        private void netCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (netCombo.SelectedItem.ToString().Trim())
            {
                case "My Internet is not working":
                    tabControl1.SelectedTab = Network;
                    break;

                default:
                    break;
            }
        }

        private void ResetNetwork_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            system_Info.Enabled = true;
            DataCollection.Enabled = true;
            Misc.Enabled = true;
            Devices_Printers.Enabled = true;
            NetworkSettings.Enabled = true;
        }

        private void EventLog_Click(object sender, EventArgs e)
        {
        }

        private void Notepad_Click(object sender, EventArgs e)
        {
            Process.Start("notepad");
        }

        private void Keyboard_Click(object sender, EventArgs e)
        {
            Process.Start("osk");
        }

        private void Spool_Folder_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + "\\system32\\spool\\PRINTERS\\");
        }

        private void UserAcc_Click(object sender, EventArgs e)
        {
            Process.Start("nusrmgr.cpl");
        }

        private void NetConn_Click(object sender, EventArgs e)
        {
            Process.Start("ncpa.cpl");
        }

        private void InetOpt_Click(object sender, EventArgs e)
        {
            Process.Start("inetcpl.cpl");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }

        private void firewall_Click(object sender, EventArgs e)
        {
            Process.Start("control", "firewall.cpl");
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
        }

        private void ipConfig_Click(object sender, EventArgs e)
        {
            runAndGet("cmd", "/c ipconfig /all", "Network Configuration");
        }

        private void folderOptions(object sender, EventArgs e)
        {
            Process.Start("control", "folders");
        }

        private void PowerShell_Click(object sender, EventArgs e)
        {
            //| Format-list > Desktop\\samplelog1.txt

            //PowerShell ps = PowerShell.Create();
            /*    
            ps.AddCommand("Get-EventLog");
            ps.AddArgument("application");
            ps.AddParameter("Newest", 25);
            ps.AddScript("Format-List > ~\\Desktop\\samplelog.txt");
            ps.Invoke();*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void regEdit_Click(object sender, EventArgs e)
        {
             Process.Start("regedit");  
        }

        private void MSCONFIG_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start("msconfig");
            }
            catch
            {
            }
        }

        private void spooler(Boolean start)
        {
            startService("Spooler", start);
        }

        private void startSpooler_Click(object sender, EventArgs e)
        {
            spooler(true);
        }

        private void stopSpooler_Click(object sender, EventArgs e)
        {
            spooler(false);
        }

        private void userProfFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("USERPROFILE"));
        }

        private void tempFol_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("APPDATA"));
        }

        private void recFiles_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("USERPROFILE") + "\\Recent\\");
        }

        private void winSys_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("WINDIR"));
        }

        private void sys32_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("WINDIR") + "\\system32\\");
        }

        private void progFiles_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("PROGRAMFILES"));
        }

        private void progFiles86_Click(object sender, EventArgs e)
        {
            var dir = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)");

            if (Directory.Exists(dir))
                Process.Start(dir);
            else
            {
                progFiles86.Enabled = false;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter_2(object sender, EventArgs e)
        {
        }

        private void renewIP_Click(object sender, EventArgs e)
        {
            runAsAdmin("cmd", "/c ipconfig /renew");
        }

        private void releaseIP_Click(object sender, EventArgs e)
        {
            runAsAdmin("cmd", "/c ipconfig /release");
        }

        private void Ping_Click(object sender, EventArgs e)
        {
            Form ping = new PingBox();
            ping.ShowDialog(this);
        }

        private void showDNS_Click(object sender, EventArgs e)
        {
            runAndGet("cmd", "/c ipconfig /displaydns", "DNS Cache");
        }

        private void flushDNS_Click(object sender, EventArgs e)
        {
            runAsAdmin("cmd", "/c ipconfig /flushdns");
        }

 

        private void remoteDesktop_Click(object sender, EventArgs e)
        {
            Process.Start("mstsc");
        }

        private void winRemAssis_Click(object sender, EventArgs e)
        {
            Process.Start("msra");
        }

        private void winSysFol_Click(object sender, EventArgs e)
        {
            Process.Start(System.Environment.GetEnvironmentVariable("WINDIR"));
        }

        private void event_Log_Click_1(object sender, EventArgs e)
        {
            var evtLog = new EventLog("Application");
            evtLog.MachineName = ".";

            foreach (EventLogEntry evtEntry in evtLog.Entries)
            {
                Console.WriteLine(evtEntry.Message);
            }

            evtLog.Close();
        }

        private void CommandLine_Click(object sender, EventArgs e)
        {
            runAsAdmin("cmd", "");
        }

        private void pShell_Click(object sender, EventArgs e)
        {
            Process.Start("powershell.exe");
        }

        private void Disk_Manager_Click(object sender, EventArgs e)
        {

            Process.Start("diskmgmt.msc");
        }

        private void checkDisk_Click(object sender, EventArgs e)
        {
            runAsAdmin("cmd", "/k chkdsk " + Environment.GetEnvironmentVariable("SYSTEMDRIVE") + " /r");
        }

        private void sfcScannow_Click(object sender, EventArgs e)
        {
            runAsAdmin("cmd", "/k sfc /scannow");
        }

        private void DiscClean_Click(object sender, EventArgs e)
        {
               
            Process.Start("cleanmgr");
        }

        private void defrag_Click(object sender, EventArgs e)
        {
                
            Process.Start("dfrgui");
        }

        private void Services_Click(object sender, EventArgs e)
        {
            Process.Start("services.msc");
        }

        private void EventViewer_Click(object sender, EventArgs e)
        {
            Process.Start("eventvwr.msc");
        }

        private void app_Data_Click2(object sender, EventArgs e)
        {
            Process.Start(Environment.GetEnvironmentVariable("APPDATA"));
        }

        private void appLog_Click(object sender, EventArgs e)
        {
           /* var ps = PowerShell.Create(); //Create empty pipeline
            
            ps.AddCommand("Get-EventLog");
            ps.AddArgument("Application");
            //ps.AddParameter("Newest", 25);
            ps.AddScript("Format-List > ~\\Desktop\\ApplicationLog.txt");
            ps.Invoke();
            MessageBox.Show("Application Data Saved to Desktop");*/

            var ps = PowerShell.Create(); //Create empty pipeline
            ps.AddCommand("Get-WmiObject");
            ps.AddArgument("Win32_BIOS");
            //ps.AddParameter("Newest", 25);
            ps.AddScript("Format-List > C:\\Bios.txt");
            //ps.AddScript(@"C:\\Users\\Rob\\Desktop\\Bios.txt");
            ps.Invoke();
            MessageBox.Show("BIOS Data Saved to Desktop");
            
        }

        private void telnet_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("telnet");
            }
            catch
            {
                MessageBox.Show("Telnet doesn't seem to be enabled");
            }
        }

        private void netStat_Click(object sender, EventArgs e)
        {
            this.runAndGet("cmd", "/c netstat -s", "Network Statistics");
        }

        private void performance_Click(object sender, EventArgs e)
        {
            Process.Start("perfmon.msc");
        }

        private void printMngmt_Click(object sender, EventArgs e)
        {
            Process.Start("printmanagement.msc");
        }

        private void backup_Click(object sender, EventArgs e)
        {
            runAsAdmin("control", "/name Microsoft.BackupAndRestore");
        }

        private void winUpdates_Click(object sender, EventArgs e)
        {
            runAsAdmin("control", "wuauclt");
        }

        private void virusScan_Click(object sender, EventArgs e)
        {
            //Process.Start("MSASCui.exe");
            //runAsAdmin("control", "CWindows Defender MSASCui");
        }

        //The only downloadable link I have, for security purposes. This is a .pdf of every windows error code available.
        private void errorCodes_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("https://www.google.ie/url?sa=t&rct=j&q=&esrc=s&source=web&cd=1&ved=0CCoQFjAA&url=http%3A%2F%2Fdownload.microsoft.com%2Fdownload%2F9%2F5%2FE%2F95EF66AF-9026-4BB0-A41D-A4F81802D92C%2F%5BMS-ERREF%5D.pdf&ei=pGj4VJ_JOs-Q7AaK1oDwBQ&usg=AFQjCNHu2-WVJpA7ViG5e-GAne_gCH9Rzw&cad=rja", @"C:\\ErrorCodes.pdf");
                MessageBox.Show("Your file has been placed in your C: drive, named ErrorCodes.pdf");
            }
            catch
            {
                MessageBox.Show("We cant download that right now, Please try again later");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void Devices_Printers_Enter(object sender, EventArgs e)
        {
        }

        private void system_Info_Enter(object sender, EventArgs e)
        {
        }

        private void InstalledSW_Click(object sender, EventArgs e)
        {
        }
        private void Overview_Click(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter_1(object sender, EventArgs e)
        {
        }

        private void Show_Adv_Click(object sender, EventArgs e)
        {
        }

        private void Show_Inter_Click(object sender, EventArgs e)
        {
        }

        private void Show_Beg_Click(object sender, EventArgs e)
        {
        }

        private void Show_All_Click_1(object sender, EventArgs e)
        {
        }

        private void Network_Click(object sender, EventArgs e)
        {
        }

        private void WindowsServer_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void Misc_Enter(object sender, EventArgs e)
        {
        }

    }
}