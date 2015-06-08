using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Net;
using DisplayBox1;
using System.Management;
using System.Drawing;
using Microsoft.Win32;

namespace FourthYearProject
{
    public partial class DiagnosticTool : Form
    {
        public DiagnosticTool()
        {
            InitializeComponent();

            ///////////////////////////////////////////////////////////////////////////
            //OS Version Check Code & Ideas taken from:
            //http://stackoverflow.com/questions/13620223/how-to-detect-windows-8-operating-system-using-c-sharp-4-0
            //Check if OS is Windows 8 or 8.1
            //Some processes don't work on Windows 8, that do work on Windows 7 and earlier
            var osVersion = new Version(6, 2, 9200, 0);
            if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                Environment.OSVersion.Version >= osVersion)
            {
                printMngmt.Enabled = false;
                backup.Enabled = false;
            }

            //Check if OS is earlier than Windows 8
            else if (Environment.OSVersion.Platform == PlatformID.Win32NT &&
                     Environment.OSVersion.Version <= osVersion)
            {

            }
            ////////////////////////////////////////////////////////////////////////////


            //Checking system for 64 bit and greying out groupboxes/buttons if it is.
            var directory = Environment.GetEnvironmentVariable("PROGRAMFILES(X86)");
            if (Directory.Exists(directory)) // if 64 bit
            {
                
            }
            else //else if 32 bit
            {
                progFiles.Enabled = false;
            }
        }

        //Runs Process and displays information out onto a form
        private void runAndGet(string command, string args, string label)
        {
            try
            {
                var output = ProcRun.ProcRunAndGet(command, args);
                var db = new DisplayBox(output, label);
                db.ShowDialog(this);
            }
            catch
            {
                MessageBox.Show("Can't do that right now, Please try again soon");
            }
        }

        //method that takes in a process path and arguments to run them 
        private void runAsAdmin(string path, string args)
        {
            ProcessStartInfo proc = new ProcessStartInfo();

            proc.FileName = path;
            proc.Arguments = args;

            try
            {
                Process.Start(proc);
            }
            catch
            {
                MessageBox.Show("Can't do that right now, Please try again soon");
            }
        }

        //start or stop Windows services
        private void startService(string serv_name, Boolean trueStart_falseStop)
        {
            //ServiceController class manipulates service state
            ServiceController scontroller = new ServiceController();
            scontroller.ServiceName = serv_name;

            if (trueStart_falseStop)
            {
                scontroller.Start();
                scontroller.WaitForStatus(ServiceControllerStatus.Running);
            }
            else
            {
                scontroller.Stop();
                scontroller.WaitForStatus(ServiceControllerStatus.Stopped);
            }

            var serv_status = scontroller.Status.ToString();
            MessageBox.Show(serv_name + " is now " + serv_status);
        }

        //Running a Process on Remote Machine
        private void remoteProc_Click(object sender, EventArgs e)
        {
            object[] process = { "diskmgmt.msc" };

            //ConnectionOptions specifies all settings for WMI connection
            System.Management.ConnectionOptions connection = new System.Management.ConnectionOptions();
            connection.Username = "usertest";//Need to fill in when run
            connection.Password = "password123";//Need to fill in when run

            //ManagementScope used to identify the IP of remote machine
            ManagementScope scope = new ManagementScope("\\\\255.255.1.1\\root\\cimv2", connection);
            scope.Options.EnablePrivileges = true;
            scope.Options.Impersonation = System.Management.ImpersonationLevel.Impersonate;
            scope.Connect();

            ManagementClass mc = new ManagementClass(scope, new ManagementPath("diskmgmt"),
                new ObjectGetOptions());
            mc.InvokeMethod("Create", process);
        }

        private void ListProcesses()
        {
            //Array of processes to get all current running processes
            Process[] processlist = Process.GetProcesses();

            string processes = "";

            processes = ("Memory (mb) \tProcess Name \r\n\r\n");

            //An enumerator to list the processes in descending order
            IEnumerable<Process> p = processlist.OrderByDescending(proc => proc.PrivateMemorySize64);

            //A Foreach loop to print the processnames & memory usage in MB to 2 decimal places
            foreach (var theprocess in p)
            {
                //Dividing PMsize64 to give the output in mb instead of bytes
                processes += " " + ((theprocess.PrivateMemorySize64 / 1024) / 1024).ToString("F")
                             + "\t\t" + theprocess.ProcessName + " \r\n";
            }
            //Displaying it through the ProcessBox class
            ProcessBox processBox = new ProcessBox(processes, "Running Processes by Memory Usage");
            processBox.ShowDialog(this);
        }

        private void Processes_Click(object sender, EventArgs e)
        {
            ListProcesses();
        }

        private void Queued_Jobs()
        {
            MessageBox.Show("The Error is: The operation cannot continue as there are jobs queued in the printer");
            tabControl1.SelectedTab = WindowsSettings;
            groupBox1.Enabled = false;
            system_Info.Enabled = false;
            DataCollection.Enabled = false;
            Misc.Enabled = false;
            Folders.Enabled = false;
            Devices_Printers.Enabled = true;
        }

        private void No_Printers_Found()
        {
            MessageBox.Show("The Error is: No Printers were found");
            tabControl1.SelectedTab = WindowsSettings;
            groupBox1.Enabled = false;
            system_Info.Enabled = false;
            DataCollection.Enabled = false;
            Misc.Enabled = false;
            Folders.Enabled = false;
            Devices_Printers.Enabled = true;
        }

        /*
          Enter error code if one is found, User is told what the error was
          for and then brought to where they can fix it
         */
        private void errorCodes_Combo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (errorCodes_Combo.SelectedItem.ToString().Trim())
            {
                case "0x00000BC1":
                    Queued_Jobs();
                    break;

                case "0x00000BC4":
                    No_Printers_Found();
                    break;

                case "0xC00D1128":
                    MessageBox.Show("The Error is: The attempt to connect to the internet failed");
                    tabControl1.SelectedTab = Network;
                    break;
            }
        }

        private void biosInfo_Click(object sender, EventArgs e)
        {
            runAsAdmin("powershell", "Get-WmiObject Win32_BIOS | Format-List * > ~\\Desktop\\BIOS.txt");
            MessageBox.Show("BIOS Information Saved to Desktop");
        }

        private void secLog_Click(object sender, EventArgs e)
        {
            runAsAdmin("powershell", "Get-EventLog -Newest 25 -logname Security | Format-List > ~\\Desktop\\SecurityLog.txt");
            MessageBox.Show("Security Log Information Saved to Desktop");

        }

        private void sysLog_Click(object sender, EventArgs e)
        {
            runAsAdmin("powershell", "Get-EventLog -Newest 25 -logname System | Format-List > ~\\Desktop\\Systemlog.csv");
            MessageBox.Show("System Log Information Saved to Desktop");
        }

        //Expert System
        private void diagnose_Click(object sender, EventArgs e)
        {
            RadioButton[] radioCollection = new RadioButton[] { slowComp, netProblem,
                genProb, printProb, winFreezes };
            if (!radioCollection.Any(radio => radio.Checked))
            {
                MessageBox.Show("Please pick 1 of the symptoms at the top");
            }

            if (slowComp.Checked && strangeNoises.Checked || filesNotOpen.Checked)
            {
                MessageBox.Show("Your Harddrives condition may need to be evaluated and cleaned up." +
                " I recommend you use 'Check disk for errors' and 'Disk Cleanup'.");
                Degraded_Hardrive();
            }

            else if (printProb.Checked && notDetected.Checked)
            {
                MessageBox.Show("Click the Add Printer button at the top of the next screen");
                Process.Start("::{2227A280-3AEA-1069-A2DE-08002B30309D}");
                printProb.Checked = false;
                notDetected.Checked = false;
            }

            else if (netProblem.Checked && netDisconnect.Checked)
            {
                MessageBox.Show("At the next screen, Choose Release IP, Then Renew IP");
                Internet_Issues();
                netProblem.Checked = false;
                netDisconnect.Checked = false;
            }

            else if (genProb.Checked && makeBackup.Checked)
            {
                MessageBox.Show("At the next screen, Follow the dialog to create your backup");
                runAsAdmin("control", "/name Microsoft.BackupAndRestore");
                genProb.Checked = false;
                makeBackup.Checked = false;
            }

            else if (slowComp.Checked && slowBoot.Checked)
            {
                MessageBox.Show("At the next screen, Go to the startup tab and uncheck programs such as adobe");
                Process.Start("msconfig.exe");
            }
            else if (slowComp.Checked && oldPC.Checked || cantInstall.Checked)
            {
                MessageBox.Show("At the next screen you may need to uninstall some uneeded program and delete your temp folder");
                Remove_Files();
            }
            else if (netProblem.Checked && slowNet.Checked)
            {
                MessageBox.Show("You may have too many processes running, At the next screen follow the instructions to stop some of them");
                ListProcesses();
            }

        }

        private void Degraded_Hardrive()
        {
            tabControl1.SelectedTab = AdvSettings;
            foreach (Control advs in AdvSettings.Controls)
            {
                if (advs != diskAndFile)
                {
                    advs.Enabled = false;
                    resetAdv.Enabled = true;
                    diskAndFile.BackColor = Color.MistyRose;
                    backup.Enabled = false;
                    backup.BackColor = Color.White;
                    slowComp.Checked = false;
                    strangeNoises.Checked = false;
                    filesNotOpen.Checked = false;
                }
            }
        }

        private void Internet_Issues()
        {
            tabControl1.SelectedTab = Network;
            foreach (Control net in Network.Controls)
            {
                if (net != IP_Utils)
                {
                    net.Enabled = false;
                    ResetNetwork.Enabled = true;
                    resetAdv.Enabled = true;
                    netProblem.Checked = false;
                    netDisconnect.Checked = false;
                    IP_Utils.BackColor = Color.MistyRose;
                }
            }
        }

        private void Remove_Files()
        {
            tabControl1.SelectedTab = WindowsSettings;
            foreach (Control winS in Network.Controls)
            {
                if (winS != Folders)
                {
                    winS.Enabled = false;
                    tempFol.Enabled = true;
                    AddRemove.Enabled = true;
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            foreach (Control wins in WindowsSettings.Controls)
            {
                wins.Enabled = true;
                wins.BackColor = Color.White;
            }
        }

        private void resetAdv_Click(object sender, System.EventArgs e)
        {

            foreach (Control advs in AdvSettings.Controls)
            {
                advs.Enabled = true;
                advs.BackColor = Color.White;
            }

        }

        private void Printer_Not_Working()
        {
            Reset_Click1();
            tabControl1.SelectedTab = WindowsSettings;
            groupBox1.Enabled = false;
            system_Info.Enabled = false;
            DataCollection.Enabled = false;
            Misc.Enabled = false;
            Devices_Printers.Enabled = true;
            Devices_Printers.BackColor = Color.Bisque;
        }

        private void ResetNetwork_Click(object sender, EventArgs e)
        {
            foreach (Control c in Network.Controls)
            {
                c.Enabled = true;
                c.BackColor = Color.White;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void ipConf_Click(object sender, EventArgs e)
        {
            runAndGet("powershell", "Get-WmiObject -Class Win32_NetworkAdapterConfiguration -Filter IPEnabled=TRUE  | Select-Object -Property [a-z]* -ExcludeProperty IPX*,WINS*", "");
        }

        private void CompMgmt_Click(object sender, EventArgs e)
        {
            Process.Start("compmgmt.msc");
        }


        private void MSCONFIG_Click(object sender, EventArgs e)
        {
        }

        private void InternetOptions_Click(object sender, EventArgs e)
        {
            Process.Start("inetcpl.cpl");
        }

        private void button3_Click(object sender, EventArgs e)
        {
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {
        }
        
        //Re-enables all functions
        private void Reset_Click1()
        {
            foreach (Control c in WindowsSettings.Controls)
            {
                c.Enabled = true;
                c.BackColor = Color.White;
            }
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
            Process.Start("msconfig");
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

        private void button4_Click(object sender, EventArgs e)
        {
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
            try
            {
                Process.Start("diskmgmt.msc");
            }
            catch
            {
            }
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
            try
            {
                Process.Start("cleanmgr");
            }
            catch
            {
            }
        }

        private void defrag_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("dfrgui");
            }
            catch
            {
            }
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
            ps.AddParameter("Newest", 25);
            ps.AddScript("Format-List > ~\\Desktop\\ApplicationLog.txt");
            ps.Invoke();
            MessageBox.Show("Application Data Saved to Desktop");

            var ps = PowerShell.Create(); //Create empty pipeline
            ps.AddCommand("Get-WmiObject");
            ps.AddArgument("Win32_BIOS");
            //ps.AddParameter("Newest", 25);
            ps.AddScript("Format-List > ~Bios.txt");
            ps.Invoke();
            MessageBox.Show("BIOS Data Saved to Desktop");*/

            runAsAdmin("powershell", "Get-EventLog -Newest 25 -logname Application | Format-List > ~\\Desktop\\EventLog.txt");

            MessageBox.Show("EventLog Information Saved to Desktop");
            
        }

        private void compSpecs_Click_1(object sender, EventArgs e)
        {
            runAndGet("powershell", "Get-WmiObject -Class Win32_ComputerSystem", "Make and Model of Computer");
        }

        private void ipAssign_Click(object sender, EventArgs e)
        {
            runAndGet("powershell", "Get-WmiObject -Class Win32_NetworkAdapterConfiguration -Filter IPEnabled=TRUE | Format-Table -Property IPAddress", "Basic IP Info");
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

        private void InstalledSW_Click(object sender, EventArgs e)
        {


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

        private void recyclingBin_Click(object sender, EventArgs e)
        {
            Process.Start("explorer ::{645FF040-5081-101B-9F08-00AA002F954E}");
        }

        private void UserAcc_Click(object sender, EventArgs e)
        {
            Process.Start("control", "userpasswords");
        }
        
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Home_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void WindowsSettings_Click(object sender, EventArgs e)
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

        private void DataCollection_Enter(object sender, EventArgs e)
        {
        }

        private void Devices_Printers_Enter(object sender, EventArgs e)
        {
        }

        private void system_Info_Enter(object sender, EventArgs e)
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

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void winFreezes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void compSlow_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void diskAndFile_Enter(object sender, EventArgs e)
        {

        }

    }
}