namespace FourthYearProject
{
    partial class ConfigTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigTool));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Home = new System.Windows.Forms.TabPage();
            this.WindowsSettings = new System.Windows.Forms.TabPage();
            this.Security = new System.Windows.Forms.TabPage();
            this.Network = new System.Windows.Forms.TabPage();
            this.UNIX = new System.Windows.Forms.TabPage();
            this.Misc = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.Home.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Home);
            this.tabControl1.Controls.Add(this.WindowsSettings);
            this.tabControl1.Controls.Add(this.Security);
            this.tabControl1.Controls.Add(this.Network);
            this.tabControl1.Controls.Add(this.UNIX);
            this.tabControl1.Controls.Add(this.Misc);
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(12, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // Home
            // 
            this.Home.Controls.Add(this.label1);
            this.Home.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ImageIndex = 0;
            this.Home.Location = new System.Drawing.Point(4, 25);
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(3);
            this.Home.Size = new System.Drawing.Size(652, 471);
            this.Home.TabIndex = 0;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            // 
            // WindowsSettings
            // 
            this.WindowsSettings.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WindowsSettings.ImageIndex = 1;
            this.WindowsSettings.Location = new System.Drawing.Point(4, 25);
            this.WindowsSettings.Name = "WindowsSettings";
            this.WindowsSettings.Padding = new System.Windows.Forms.Padding(3);
            this.WindowsSettings.Size = new System.Drawing.Size(652, 471);
            this.WindowsSettings.TabIndex = 1;
            this.WindowsSettings.Text = "WindowsSettings";
            this.WindowsSettings.UseVisualStyleBackColor = true;
            // 
            // Security
            // 
            this.Security.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Security.ImageIndex = 3;
            this.Security.Location = new System.Drawing.Point(4, 25);
            this.Security.Name = "Security";
            this.Security.Size = new System.Drawing.Size(652, 471);
            this.Security.TabIndex = 2;
            this.Security.Text = "Security Utilities";
            this.Security.UseVisualStyleBackColor = true;
            // 
            // Network
            // 
            this.Network.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Network.ImageIndex = 4;
            this.Network.Location = new System.Drawing.Point(4, 25);
            this.Network.Name = "Network";
            this.Network.Size = new System.Drawing.Size(652, 471);
            this.Network.TabIndex = 3;
            this.Network.Text = "Network Utilities";
            this.Network.UseVisualStyleBackColor = true;
            // 
            // UNIX
            // 
            this.UNIX.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UNIX.ImageIndex = 2;
            this.UNIX.Location = new System.Drawing.Point(4, 25);
            this.UNIX.Name = "UNIX";
            this.UNIX.Size = new System.Drawing.Size(652, 471);
            this.UNIX.TabIndex = 4;
            this.UNIX.Text = "UNIX Systems";
            this.UNIX.UseVisualStyleBackColor = true;
            // 
            // Misc
            // 
            this.Misc.ImageIndex = 5;
            this.Misc.Location = new System.Drawing.Point(4, 25);
            this.Misc.Name = "Misc";
            this.Misc.Size = new System.Drawing.Size(652, 471);
            this.Misc.TabIndex = 5;
            this.Misc.Text = "Misc Tools";
            this.Misc.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Californian FB", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(478, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Rob\'s Configuration and Diagnostic tool.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "home.png");
            this.imageList1.Images.SetKeyName(1, "mycomp.bmp");
            this.imageList1.Images.SetKeyName(2, "linux.png");
            this.imageList1.Images.SetKeyName(3, "security.png");
            this.imageList1.Images.SetKeyName(4, "network.png");
            this.imageList1.Images.SetKeyName(5, "misc.bmp");
            // 
            // ConfigTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.tabControl1);
            this.Name = "ConfigTool";
            this.Text = "Rob\'s Config & Support Tool";
            this.tabControl1.ResumeLayout(false);
            this.Home.ResumeLayout(false);
            this.Home.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Home;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage WindowsSettings;
        private System.Windows.Forms.TabPage Security;
        private System.Windows.Forms.TabPage Network;
        private System.Windows.Forms.TabPage UNIX;
        private System.Windows.Forms.TabPage Misc;
        private System.Windows.Forms.ImageList imageList1;
    }
}

