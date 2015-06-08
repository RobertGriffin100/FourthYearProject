namespace FourthYearProject
{
    partial class ProcessDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components1 = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components1 != null))
            {
                components1.Dispose();
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
            this.processBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // processBox
            // 
            this.processBox.BackColor = System.Drawing.SystemColors.Control;
            this.processBox.Location = new System.Drawing.Point(22, 40);
            this.processBox.Multiline = true;
            this.processBox.Name = "processBox";
            this.processBox.Size = new System.Drawing.Size(263, 513);
            this.processBox.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(303, 40);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 356);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Process that can be ended:";
            // 
            // ProcessDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 580);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.processBox);
            this.Name = "ProcessDisplay";
            this.Text = "ProcessDisplay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox processBox;
        private System.Windows.Forms.TextBox textBox2;
    }
}