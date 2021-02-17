namespace InlämningsUppgift1
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Pris = new System.Windows.Forms.TextBox();
            this.Betalat = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.Change = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdToolStripMenuItem,
            this.asdToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(93, 48);
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.asdToolStripMenuItem.Text = "asd";
            // 
            // asdToolStripMenuItem1
            // 
            this.asdToolStripMenuItem1.Name = "asdToolStripMenuItem1";
            this.asdToolStripMenuItem1.Size = new System.Drawing.Size(92, 22);
            this.asdToolStripMenuItem1.Text = "asd";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(194, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Vad kostar varan";
            // 
            // Pris
            // 
            this.Pris.AccessibleName = "Pris";
            this.Pris.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.Pris.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Pris.Location = new System.Drawing.Point(194, 191);
            this.Pris.Name = "Pris";
            this.Pris.Size = new System.Drawing.Size(100, 13);
            this.Pris.TabIndex = 4;
            this.Pris.Text = "Vad kostade det?";
            this.Pris.Click += new System.EventHandler(this.Pris_Click);
            this.Pris.TextChanged += new System.EventHandler(this.ChangeOut);
            // 
            // Betalat
            // 
            this.Betalat.AccessibleName = "Betalat";
            this.Betalat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Betalat.Location = new System.Drawing.Point(495, 191);
            this.Betalat.Name = "Betalat";
            this.Betalat.Size = new System.Drawing.Size(100, 13);
            this.Betalat.TabIndex = 6;
            this.Betalat.Text = "Vad betalde du?";
            this.Betalat.Click += new System.EventHandler(this.Betalat_Click);
            this.Betalat.TextChanged += new System.EventHandler(this.ChangeOut);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(495, 137);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 13);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "Vad betalade du";
            // 
            // Change
            // 
            this.Change.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Change.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Change.Location = new System.Drawing.Point(-8, 281);
            this.Change.Multiline = true;
            this.Change.Name = "Change";
            this.Change.ReadOnly = true;
            this.Change.Size = new System.Drawing.Size(821, 206);
            this.Change.TabIndex = 8;
            this.Change.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(806, 479);
            this.Controls.Add(this.Change);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.Betalat);
            this.Controls.Add(this.Pris);
            this.Controls.Add(this.textBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Växel";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox Pris;
        private System.Windows.Forms.TextBox Betalat;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox Change;
    }
}

