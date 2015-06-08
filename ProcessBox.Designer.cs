namespace FourthYearProject
{
    partial class ProcessBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessBox));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.procLabel = new System.Windows.Forms.Label();
            this.procTextBox = new System.Windows.Forms.TextBox();
            this.startProc = new System.Windows.Forms.Button();
            this.Icons = new System.Windows.Forms.ImageList(this.components);
            this.stopProc = new System.Windows.Forms.Button();
            this.startText = new System.Windows.Forms.TextBox();
            this.save1 = new System.Windows.Forms.Button();
            this.copy1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(330, 44);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(181, 201);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Processes that can be Ended:\r\n\r\nSkype.exe\r\nAdobeARM.exe\r\niTunesHelper.exe\r\nReader" +
    "_sl.exe\r\nDivXUpdate.exe\r\nNeroCheck.exe\r\nHKCMD.exe";
            // 
            // procLabel
            // 
            this.procLabel.AutoSize = true;
            this.procLabel.Location = new System.Drawing.Point(13, 13);
            this.procLabel.Name = "procLabel";
            this.procLabel.Size = new System.Drawing.Size(35, 13);
            this.procLabel.TabIndex = 2;
            this.procLabel.Text = "label2";
            // 
            // procTextBox
            // 
            this.procTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.procTextBox.Location = new System.Drawing.Point(13, 44);
            this.procTextBox.Multiline = true;
            this.procTextBox.Name = "procTextBox";
            this.procTextBox.Size = new System.Drawing.Size(311, 502);
            this.procTextBox.TabIndex = 0;
            // 
            // startProc
            // 
            this.startProc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startProc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startProc.ImageIndex = 31;
            this.startProc.ImageList = this.Icons;
            this.startProc.Location = new System.Drawing.Point(349, 306);
            this.startProc.Name = "startProc";
            this.startProc.Size = new System.Drawing.Size(138, 29);
            this.startProc.TabIndex = 3;
            this.startProc.Text = "Start Process";
            this.startProc.UseVisualStyleBackColor = true;
            this.startProc.Click += new System.EventHandler(this.startProc_Click);
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
            this.Icons.Images.SetKeyName(31, "startProc.png");
            this.Icons.Images.SetKeyName(32, "stopProc.png");
            this.Icons.Images.SetKeyName(33, "stopProc.jpg");
            // 
            // stopProc
            // 
            this.stopProc.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopProc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopProc.ImageIndex = 32;
            this.stopProc.ImageList = this.Icons;
            this.stopProc.Location = new System.Drawing.Point(349, 352);
            this.stopProc.Name = "stopProc";
            this.stopProc.Size = new System.Drawing.Size(138, 29);
            this.stopProc.TabIndex = 4;
            this.stopProc.Text = "Stop Process";
            this.stopProc.UseVisualStyleBackColor = true;
            this.stopProc.Click += new System.EventHandler(this.stopProc_Click);
            // 
            // startText
            // 
            this.startText.Location = new System.Drawing.Point(349, 261);
            this.startText.Multiline = true;
            this.startText.Name = "startText";
            this.startText.Size = new System.Drawing.Size(138, 20);
            this.startText.TabIndex = 5;
            // 
            // save1
            // 
            this.save1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.save1.ImageKey = "shell32_16761.ico";
            this.save1.ImageList = this.Icons;
            this.save1.Location = new System.Drawing.Point(349, 443);
            this.save1.Name = "save1";
            this.save1.Size = new System.Drawing.Size(138, 29);
            this.save1.TabIndex = 6;
            this.save1.Text = "Save";
            this.save1.UseVisualStyleBackColor = true;
            this.save1.Click += new System.EventHandler(this.save1_Click);
            // 
            // copy1
            // 
            this.copy1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.copy1.ImageIndex = 30;
            this.copy1.ImageList = this.Icons;
            this.copy1.Location = new System.Drawing.Point(349, 488);
            this.copy1.Name = "copy1";
            this.copy1.Size = new System.Drawing.Size(138, 29);
            this.copy1.TabIndex = 7;
            this.copy1.Text = "Copy To Clipboard";
            this.copy1.UseVisualStyleBackColor = true;
            // 
            // v
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 575);
            this.Controls.Add(this.copy1);
            this.Controls.Add(this.save1);
            this.Controls.Add(this.startText);
            this.Controls.Add(this.stopProc);
            this.Controls.Add(this.startProc);
            this.Controls.Add(this.procLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.procTextBox);
            this.Name = "v";
            this.Text = "ProcessBox";
            this.Load += new System.EventHandler(this.ProcessBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox procTextBox;
        private System.Windows.Forms.Button startProc;
        private System.Windows.Forms.Button stopProc;
        private System.Windows.Forms.TextBox startText;
        private System.Windows.Forms.ImageList Icons;
        private System.Windows.Forms.Button save1;
        private System.Windows.Forms.Button copy1;
    }
}