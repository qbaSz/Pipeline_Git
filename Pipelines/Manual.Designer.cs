﻿namespace Pipelines
{
    partial class Manual
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btopenTXT = new System.Windows.Forms.Button();
            this.btopen = new System.Windows.Forms.Button();
            this.btopenPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(38, 69);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(704, 381);
            this.listBox1.TabIndex = 21;
            // 
            // btopenTXT
            // 
            this.btopenTXT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopenTXT.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopenTXT.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopenTXT.Location = new System.Drawing.Point(264, 31);
            this.btopenTXT.Name = "btopenTXT";
            this.btopenTXT.Size = new System.Drawing.Size(185, 31);
            this.btopenTXT.TabIndex = 20;
            this.btopenTXT.Text = "Open In Text File";
            this.btopenTXT.UseVisualStyleBackColor = false;
            this.btopenTXT.Click += new System.EventHandler(this.btopenTXT_Click);
            // 
            // btopen
            // 
            this.btopen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopen.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopen.Location = new System.Drawing.Point(502, 32);
            this.btopen.Name = "btopen";
            this.btopen.Size = new System.Drawing.Size(185, 31);
            this.btopen.TabIndex = 19;
            this.btopen.Text = "Open In Word Document";
            this.btopen.UseVisualStyleBackColor = false;
            this.btopen.Click += new System.EventHandler(this.btopen_Click);
            // 
            // btopenPDF
            // 
            this.btopenPDF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopenPDF.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopenPDF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopenPDF.Location = new System.Drawing.Point(38, 30);
            this.btopenPDF.Name = "btopenPDF";
            this.btopenPDF.Size = new System.Drawing.Size(185, 31);
            this.btopenPDF.TabIndex = 18;
            this.btopenPDF.Text = "Open In PDF Document";
            this.btopenPDF.UseVisualStyleBackColor = false;
            this.btopenPDF.Click += new System.EventHandler(this.btopenPDF_Click);
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 481);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btopenTXT);
            this.Controls.Add(this.btopen);
            this.Controls.Add(this.btopenPDF);
            this.Name = "Manual";
            this.Text = "Manual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btopenTXT;
        private System.Windows.Forms.Button btopen;
        private System.Windows.Forms.Button btopenPDF;
    }
}