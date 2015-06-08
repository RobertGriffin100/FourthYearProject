using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthYearProject
{
    class ProcRun
    {
        public static string ProcRunAndGet(string cmd, string args)
        {
            ProcessStartInfo pInfo = new ProcessStartInfo();
            //Gets the Application and Arguments to start
            pInfo.FileName = cmd;
            pInfo.Arguments = args;
            pInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pInfo.RedirectStandardOutput = true;
            pInfo.UseShellExecute = false;

            //Redirects output stream 
            Process proc = Process.Start(pInfo);
            System.IO.StreamReader reader = proc.StandardOutput;
            string s = reader.ReadToEnd();
            reader.Close();
            return s;
        }
    }
}
