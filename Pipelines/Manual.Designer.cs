namespace Pipelines
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
            this.btopen = new System.Windows.Forms.Button();
            this.btopenPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btopen
            // 
            this.btopen.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopen.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopen.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopen.Location = new System.Drawing.Point(316, 18);
            this.btopen.Name = "btopen";
            this.btopen.Size = new System.Drawing.Size(185, 31);
            this.btopen.TabIndex = 18;
            this.btopen.Text = "Open In Word Document";
            this.btopen.UseVisualStyleBackColor = false;
            this.btopen.Click += new System.EventHandler(this.btopen_Click);
            // 
            // btopenPDF
            // 
            this.btopenPDF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btopenPDF.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btopenPDF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btopenPDF.Location = new System.Drawing.Point(56, 18);
            this.btopenPDF.Name = "btopenPDF";
            this.btopenPDF.Size = new System.Drawing.Size(185, 31);
            this.btopenPDF.TabIndex = 17;
            this.btopenPDF.Text = "Open In PDF Document";
            this.btopenPDF.UseVisualStyleBackColor = false;
            this.btopenPDF.Click += new System.EventHandler(this.btopenPDF_Click_1);
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 78);
            this.Controls.Add(this.btopen);
            this.Controls.Add(this.btopenPDF);
            this.MinimizeBox = false;
            this.Name = "Manual";
            this.Text = "Manual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btopen;
        private System.Windows.Forms.Button btopenPDF;
    }
}