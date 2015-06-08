namespace FourthYearProject
{
    partial class PingBox
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
            this.hostLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pingBut = new System.Windows.Forms.Button();
            this.pingRes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hostLabel.Location = new System.Drawing.Point(13, 23);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(36, 15);
            this.hostLabel.TabIndex = 1;
            this.hostLabel.Text = "Host:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(61, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(258, 23);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "www.google.com";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // pingBut
            // 
            this.pingBut.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pingBut.Location = new System.Drawing.Point(330, 20);
            this.pingBut.Name = "pingBut";
            this.pingBut.Size = new System.Drawing.Size(80, 23);
            this.pingBut.TabIndex = 3;
            this.pingBut.Text = "Ping";
            this.pingBut.UseVisualStyleBackColor = true;
            this.pingBut.Click += new System.EventHandler(this.pingBut_Click);
            // 
            // pingRes
            // 
            this.pingRes.BackColor = System.Drawing.SystemColors.Control;
            this.pingRes.Location = new System.Drawing.Point(16, 66);
            this.pingRes.Multiline = true;
            this.pingRes.Name = "pingRes";
            this.pingRes.Size = new System.Drawing.Size(394, 202);
            this.pingRes.TabIndex = 4;
            // 
            // PingBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 306);
            this.Controls.Add(this.pingRes);
            this.Controls.Add(this.pingBut);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.hostLabel);
            this.Name = "PingBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetworkBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button pingBut;
        private System.Windows.Forms.TextBox pingRes;
    }
}