﻿namespace Pipelines
{
    partial class PipelineMain
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
            this.pbPipeline = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPump = new System.Windows.Forms.RadioButton();
            this.buttonSink = new System.Windows.Forms.RadioButton();
            this.buttonPipe = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeline)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPipeline
            // 
            this.pbPipeline.BackColor = System.Drawing.Color.White;
            this.pbPipeline.Location = new System.Drawing.Point(81, 12);
            this.pbPipeline.Name = "pbPipeline";
            this.pbPipeline.Size = new System.Drawing.Size(671, 501);
            this.pbPipeline.TabIndex = 0;
            this.pbPipeline.TabStop = false;
            this.pbPipeline.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPipeline_Paint);
            this.pbPipeline.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbPipeline_MouseClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonPump);
            this.flowLayoutPanel1.Controls.Add(this.buttonSink);
            this.flowLayoutPanel1.Controls.Add(this.buttonPipe);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(62, 181);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonPump
            // 
            this.buttonPump.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonPump.AutoSize = true;
            this.buttonPump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPump.Location = new System.Drawing.Point(3, 3);
            this.buttonPump.MinimumSize = new System.Drawing.Size(50, 0);
            this.buttonPump.Name = "buttonPump";
            this.buttonPump.Size = new System.Drawing.Size(50, 23);
            this.buttonPump.TabIndex = 0;
            this.buttonPump.TabStop = true;
            this.buttonPump.Text = "Pump";
            this.buttonPump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPump.UseVisualStyleBackColor = true;
            // 
            // buttonSink
            // 
            this.buttonSink.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonSink.AutoSize = true;
            this.buttonSink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSink.Location = new System.Drawing.Point(3, 32);
            this.buttonSink.MinimumSize = new System.Drawing.Size(50, 0);
            this.buttonSink.Name = "buttonSink";
            this.buttonSink.Size = new System.Drawing.Size(50, 23);
            this.buttonSink.TabIndex = 1;
            this.buttonSink.TabStop = true;
            this.buttonSink.Text = "Sink";
            this.buttonSink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonSink.UseVisualStyleBackColor = true;
            // 
            // buttonPipe
            // 
            this.buttonPipe.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonPipe.AutoSize = true;
            this.buttonPipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPipe.Location = new System.Drawing.Point(3, 61);
            this.buttonPipe.MinimumSize = new System.Drawing.Size(50, 0);
            this.buttonPipe.Name = "buttonPipe";
            this.buttonPipe.Size = new System.Drawing.Size(50, 23);
            this.buttonPipe.TabIndex = 2;
            this.buttonPipe.TabStop = true;
            this.buttonPipe.Text = "Pipe";
            this.buttonPipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPipe.UseVisualStyleBackColor = true;
            // 
            // PipelineMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 525);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pbPipeline);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PipelineMain";
            this.Text = "PipelineMain";
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeline)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPipeline;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton buttonPump;
        private System.Windows.Forms.RadioButton buttonSink;
        private System.Windows.Forms.RadioButton buttonPipe;
    }
}
