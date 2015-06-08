using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;

namespace FourthYearProject
{
    public partial class PingBox : Form
    {
        public PingBox()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pingBut_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 5; ++i)
                {
                    using (Ping p = new Ping())
                    {
                        //pingRes.Items.Add(p.Send("www.google.com").RoundtripTime.ToString() + " ms\n");
                    }
                }
            }
            catch (PingException)
            {
                System.Windows.Forms.MessageBox.Show("Error");
            }
            /*
            Ping ping = new Ping();
            PingReply pingReply = ping.Send("192.168.2.18");

            this.pingRes.Text = "";

            this.pingRes.AppendText("Address: {0}", pingReply.Address);
            this.pingRes.AppendText("Time in miliseconds: {0}", pingReply.RoundtripTime);
            this.pingRes.AppendText("Status: {0}", pingReply.Status);
            */

        }
    }
}
