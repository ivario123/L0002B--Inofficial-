namespace Inlämning3
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LastName = new System.Windows.Forms.TextBox();
            this.Personmr = new System.Windows.Forms.TextBox();
            this.Title1 = new System.Windows.Forms.TextBox();
            this.Title2 = new System.Windows.Forms.TextBox();
            this.Output = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LastName
            // 
            this.LastName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LastName.Location = new System.Drawing.Point(176, 198);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(100, 20);
            this.LastName.TabIndex = 0;
            this.LastName.TextChanged += new System.EventHandler(this.Change);
            // 
            // Personmr
            // 
            this.Personmr.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Personmr.Location = new System.Drawing.Point(176, 243);
            this.Personmr.Name = "Personmr";
            this.Personmr.Size = new System.Drawing.Size(100, 20);
            this.Personmr.TabIndex = 1;
            this.Personmr.TextChanged += new System.EventHandler(this.Change);
            // 
            // Title1
            // 
            this.Title1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Title1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Title1.Enabled = false;
            this.Title1.Location = new System.Drawing.Point(176, 179);
            this.Title1.Name = "Title1";
            this.Title1.ReadOnly = true;
            this.Title1.Size = new System.Drawing.Size(100, 13);
            this.Title1.TabIndex = 2;
            this.Title1.Text = "Efternamn :";
            // 
            // Title2
            // 
            this.Title2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Title2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Title2.Enabled = false;
            this.Title2.Location = new System.Drawing.Point(176, 224);
            this.Title2.Name = "Title2";
            this.Title2.ReadOnly = true;
            this.Title2.Size = new System.Drawing.Size(100, 13);
            this.Title2.TabIndex = 3;
            this.Title2.Text = "Personnummer :";
            // 
            // Output
            // 
            this.Output.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Output.Enabled = false;
            this.Output.Location = new System.Drawing.Point(407, 169);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(245, 311);
            this.Output.TabIndex = 4;
            this.Output.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(176, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "Förnamn :";
            // 
            // FirstName
            // 
            this.FirstName.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.FirstName.Location = new System.Drawing.Point(176, 153);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(100, 20);
            this.FirstName.TabIndex = 6;
            this.FirstName.TextChanged += new System.EventHandler(this.Change);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(721, 429);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.Title2);
            this.Controls.Add(this.Title1);
            this.Controls.Add(this.Personmr);
            this.Controls.Add(this.LastName);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Person info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox Personmr;
        private System.Windows.Forms.TextBox Title1;
        private System.Windows.Forms.TextBox Title2;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox FirstName;
    }
}

