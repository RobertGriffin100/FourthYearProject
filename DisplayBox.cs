using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DisplayBox1
{

    public partial class DisplayBox : Form
    {
        private TextBox displaybox1;
        private Button Save;
        private Button clipboard;
        private Label label1;
        private ImageList Icons;
        private IContainer components;
    
        public DisplayBox()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public DisplayBox(string text, string label):this ()
        {
            this.displaybox1.AppendText(text);
            this.label1.Text = label;
        }

        private void clipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.displaybox1.Text);
        }

        public void display(string text)
        {
            this.displaybox1.AppendText(text);
            this.Visible = true;
        }

        public void AppendText(string text)
        {
            this.displaybox1.AppendText(text);
        }

        public string Label
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        private void infobox_TextChanged(object sender, EventArgs e)
        {

        }

        private void copyToClipboard(object sender, EventArgs e)
        {
            Clipboard.SetText(this.displaybox1.Text);
        }


        private void Save_Click(object sender, EventArgs e)
        {
            string file = this.label1.Text.ToLower().Replace(" ", "_");

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = DateTime.Now.ToString("yyyy-MM-dd") + "_" + file + ".txt";
            saveDialog.Filter = "Text File|*.txt";
            saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveDialog.ShowDialog();

            if (saveDialog.FileName != "")
            {
                System.IO.File.WriteAllText(saveDialog.FileName, this.displaybox1.Text);
            }
            
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayBox));
            this.displaybox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.clipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // displaybox1
            // 
            this.displaybox1.BackColor = System.Drawing.SystemColors.Control;
            this.displaybox1.Location = new System.Drawing.Point(22, 27);
            this.displaybox1.Multiline = true;
            this.displaybox1.Name = "displaybox1";
            this.displaybox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displaybox1.Size = new System.Drawing.Size(513, 425);
            this.displaybox1.TabIndex = 0;
            this.displaybox1.TextChanged += new System.EventHandler(this.displaybox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // Save
            // 
            this.Save.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Save.ImageKey = "shell32_16761.ico";
            this.Save.ImageList = this.Icons;
            this.Save.Location = new System.Drawing.Point(228, 467);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(138, 29);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Icons
            // 
            this.Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Icons.ImageStream")));
            this.Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.Icons.Images.SetKeyName(0, "cleanmgr_113.ico");
            this.Icons.Images.SetKeyName(1, "mycomput_201.ico");
            this.Icons.Images.SetKeyName(2, "servdeps_103.ico");
            this.Icons.Images.SetKeyName(3, "shell32_16.ico");
            this.Icons.Images.SetKeyName(4, "shell32_177.ico");
            this.Icons.Images.SetKeyName(5, "shell32_16747.ico");
            this.Icons.Images.SetKeyName(6, "sysdm_1.ico");
            this.Icons.Images.SetKeyName(7, "taskmgr_107.ico");
            this.Icons.Images.SetKeyName(8, "cmd_IDI_APPICON.ico");
            this.Icons.Images.SetKeyName(9, "notepad_2.ico");
            this.Icons.Images.SetKeyName(10, "shell32_257.ico");
            this.Icons.Images.SetKeyName(11, "shell32_269.ico");
            this.Icons.Images.SetKeyName(12, "shell32_271.ico");
            this.Icons.Images.SetKeyName(13, "shell32_16.ico");
            this.Icons.Images.SetKeyName(14, "shell32_17.ico");
            this.Icons.Images.SetKeyName(15, "shell32_138.ico");
            this.Icons.Images.SetKeyName(16, "sysdm_1.ico");
            this.Icons.Images.SetKeyName(17, "eventvwr_101.ico");
            this.Icons.Images.SetKeyName(18, "mycomput_203.ico");
            this.Icons.Images.SetKeyName(19, "shell32_328.ico");
            this.Icons.Images.SetKeyName(20, "cleanmgr_104.ico");
            this.Icons.Images.SetKeyName(21, "shell32_9.ico");
            this.Icons.Images.SetKeyName(22, "shell32_167.ico");
            this.Icons.Images.SetKeyName(23, "mycomput_204.ico");
            this.Icons.Images.SetKeyName(24, "mycomput_222.ico");
            this.Icons.Images.SetKeyName(25, "shell32_16747.ico");
            this.Icons.Images.SetKeyName(26, "shield-small.ico");
            this.Icons.Images.SetKeyName(27, "REGEDIT_100.ico");
            this.Icons.Images.SetKeyName(28, "shell32_5.ico");
            this.Icons.Images.SetKeyName(29, "shell32_16761.ico");
            this.Icons.Images.SetKeyName(30, "shell32_16763.ico");
            // 
            // clipboard
            // 
            this.clipboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clipboard.ImageKey = "shell32_16763.ico";
            this.clipboard.ImageList = this.Icons;
            this.clipboard.Location = new System.Drawing.Point(383, 467);
            this.clipboard.Name = "clipboard";
            this.clipboard.Size = new System.Drawing.Size(138, 29);
            this.clipboard.TabIndex = 3;
            this.clipboard.Text = "Copy To Clipboard";
            this.clipboard.UseVisualStyleBackColor = true;
            this.clipboard.Click += new System.EventHandler(this.copyToClipboard);
            // 
            // DisplayBox
            // 
            this.ClientSize = new System.Drawing.Size(557, 520);
            this.Controls.Add(this.clipboard);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displaybox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DisplayBox";
            this.Text = "Display Box";
            this.Load += new System.EventHandler(this.DisplayBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void displaybox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DisplayBox_Load(object sender, EventArgs e)
        {

        }


    }
}
