using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FourthYearProject
{
    public partial class ProcessBox : Form
    {
        private Label procLabel;
        
        public ProcessBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public ProcessBox(string text, string label):this ()
        {
            this.procTextBox.AppendText(text);
            this.procLabel.Text = label;
        }

        public void display(string text)
        {
            this.procTextBox.AppendText(text);
            this.Visible = true;
        }

        public void AppendText(string text)
        {
            this.procTextBox.AppendText(text);
        }

        public string Label
        {
            get { return this.procLabel.Text; }
            set { this.procLabel.Text = value; }
        }

        public void startProc_Click(object sender, EventArgs e)
        {
            string text = startText.Text; //Gets text from textbox
            Process proc = new Process();
            proc.StartInfo.FileName = text;
            proc.Start();
        }

        private void stopProc_Click(object sender, EventArgs e)
        {
            //proc.Kill();
        }

        private void ProcessBox_Load(object sender, EventArgs e)
        {

        }

        private void clipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.procTextBox.Text);
        }

        private void save1_Click(object sender, EventArgs e)
        {
            string file = this.procLabel.Text.ToLower().Replace(" ", "_");

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text File|*.txt";
            saveDialog.FileName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + file + ".txt";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                System.IO.File.WriteAllText(saveDialog.FileName, this.procTextBox.Text);
            }
        }
    }
}
