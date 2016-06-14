namespace Pipelines
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDelete = new System.Windows.Forms.RadioButton();
            this.numCurrentFlow = new System.Windows.Forms.NumericUpDown();
            this.labelCurrentFlow = new System.Windows.Forms.Label();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.numPercentage = new System.Windows.Forms.NumericUpDown();
            this.labelPercentage = new System.Windows.Forms.Label();
            this.buttonPump = new System.Windows.Forms.RadioButton();
            this.buttonSink = new System.Windows.Forms.RadioButton();
            this.buttonPipe = new System.Windows.Forms.RadioButton();
            this.buttonMerger = new System.Windows.Forms.RadioButton();
            this.buttonSplitter = new System.Windows.Forms.RadioButton();
            this.buttonAdjSplitter = new System.Windows.Forms.RadioButton();
            this.pbPipeline = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeline)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonPump);
            this.flowLayoutPanel1.Controls.Add(this.buttonSink);
            this.flowLayoutPanel1.Controls.Add(this.buttonPipe);
            this.flowLayoutPanel1.Controls.Add(this.buttonMerger);
            this.flowLayoutPanel1.Controls.Add(this.buttonSplitter);
            this.flowLayoutPanel1.Controls.Add(this.buttonAdjSplitter);
            this.flowLayoutPanel1.Controls.Add(this.buttonDelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(72, 447);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Location = new System.Drawing.Point(3, 352);
            this.buttonDelete.MinimumSize = new System.Drawing.Size(67, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(67, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.TabStop = true;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDelete_MouseClick);
            // 
            // numCurrentFlow
            // 
            this.numCurrentFlow.Location = new System.Drawing.Point(12, 518);
            this.numCurrentFlow.Name = "numCurrentFlow";
            this.numCurrentFlow.Size = new System.Drawing.Size(62, 20);
            this.numCurrentFlow.TabIndex = 2;
            // 
            // labelCurrentFlow
            // 
            this.labelCurrentFlow.AutoSize = true;
            this.labelCurrentFlow.Location = new System.Drawing.Point(10, 502);
            this.labelCurrentFlow.Name = "labelCurrentFlow";
            this.labelCurrentFlow.Size = new System.Drawing.Size(66, 13);
            this.labelCurrentFlow.TabIndex = 3;
            this.labelCurrentFlow.Text = "Current Flow";
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(10, 541);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(48, 13);
            this.labelCapacity.TabIndex = 4;
            this.labelCapacity.Text = "Capacity";
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(12, 557);
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(62, 20);
            this.numCapacity.TabIndex = 5;
            // 
            // numPercentage
            // 
            this.numPercentage.Location = new System.Drawing.Point(12, 479);
            this.numPercentage.Name = "numPercentage";
            this.numPercentage.Size = new System.Drawing.Size(62, 20);
            this.numPercentage.TabIndex = 6;
            // 
            // labelPercentage
            // 
            this.labelPercentage.AutoSize = true;
            this.labelPercentage.Location = new System.Drawing.Point(9, 463);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(65, 13);
            this.labelPercentage.TabIndex = 7;
            this.labelPercentage.Text = "Perc. pipe A";
            // 
            // buttonPump
            // 
            this.buttonPump.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonPump.AutoSize = true;
            this.buttonPump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPump.Image = global::Pipelines.Properties.Resources.pump;
            this.buttonPump.Location = new System.Drawing.Point(3, 3);
            this.buttonPump.MinimumSize = new System.Drawing.Size(67, 40);
            this.buttonPump.Name = "buttonPump";
            this.buttonPump.Size = new System.Drawing.Size(67, 53);
            this.buttonPump.TabIndex = 0;
            this.buttonPump.TabStop = true;
            this.buttonPump.Text = "Pump";
            this.buttonPump.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPump.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPump.UseVisualStyleBackColor = true;
            this.buttonPump.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPump_MouseClick);
            // 
            // buttonSink
            // 
            this.buttonSink.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonSink.AutoSize = true;
            this.buttonSink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSink.Image = global::Pipelines.Properties.Resources.sink;
            this.buttonSink.Location = new System.Drawing.Point(3, 62);
            this.buttonSink.MinimumSize = new System.Drawing.Size(67, 40);
            this.buttonSink.Name = "buttonSink";
            this.buttonSink.Size = new System.Drawing.Size(67, 53);
            this.buttonSink.TabIndex = 1;
            this.buttonSink.TabStop = true;
            this.buttonSink.Text = "Sink";
            this.buttonSink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonSink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSink.UseVisualStyleBackColor = true;
            this.buttonSink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSink_MouseClick);
            // 
            // buttonPipe
            // 
            this.buttonPipe.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonPipe.AutoSize = true;
            this.buttonPipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPipe.Image = global::Pipelines.Properties.Resources.pipe;
            this.buttonPipe.Location = new System.Drawing.Point(3, 121);
            this.buttonPipe.MinimumSize = new System.Drawing.Size(67, 0);
            this.buttonPipe.Name = "buttonPipe";
            this.buttonPipe.Size = new System.Drawing.Size(67, 31);
            this.buttonPipe.TabIndex = 2;
            this.buttonPipe.TabStop = true;
            this.buttonPipe.Text = "Pipe";
            this.buttonPipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonPipe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonPipe.UseVisualStyleBackColor = true;
            this.buttonPipe.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonPipe_MouseClick);
            // 
            // buttonMerger
            // 
            this.buttonMerger.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonMerger.AutoSize = true;
            this.buttonMerger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonMerger.Image = global::Pipelines.Properties.Resources.merger;
            this.buttonMerger.Location = new System.Drawing.Point(3, 158);
            this.buttonMerger.MinimumSize = new System.Drawing.Size(67, 0);
            this.buttonMerger.Name = "buttonMerger";
            this.buttonMerger.Size = new System.Drawing.Size(67, 53);
            this.buttonMerger.TabIndex = 3;
            this.buttonMerger.TabStop = true;
            this.buttonMerger.Text = "Merger";
            this.buttonMerger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonMerger.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonMerger.UseVisualStyleBackColor = true;
            this.buttonMerger.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMerger_MouseClick);
            // 
            // buttonSplitter
            // 
            this.buttonSplitter.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonSplitter.AutoSize = true;
            this.buttonSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSplitter.Image = global::Pipelines.Properties.Resources.splitter;
            this.buttonSplitter.Location = new System.Drawing.Point(3, 217);
            this.buttonSplitter.MinimumSize = new System.Drawing.Size(67, 0);
            this.buttonSplitter.Name = "buttonSplitter";
            this.buttonSplitter.Size = new System.Drawing.Size(67, 53);
            this.buttonSplitter.TabIndex = 5;
            this.buttonSplitter.TabStop = true;
            this.buttonSplitter.Text = "Splitter";
            this.buttonSplitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonSplitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonSplitter.UseVisualStyleBackColor = true;
            this.buttonSplitter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSplitter_MouseClick);
            // 
            // buttonAdjSplitter
            // 
            this.buttonAdjSplitter.Appearance = System.Windows.Forms.Appearance.Button;
            this.buttonAdjSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdjSplitter.Image = global::Pipelines.Properties.Resources.adj_splitter;
            this.buttonAdjSplitter.Location = new System.Drawing.Point(3, 276);
            this.buttonAdjSplitter.MinimumSize = new System.Drawing.Size(67, 70);
            this.buttonAdjSplitter.Name = "buttonAdjSplitter";
            this.buttonAdjSplitter.Size = new System.Drawing.Size(67, 70);
            this.buttonAdjSplitter.TabIndex = 6;
            this.buttonAdjSplitter.TabStop = true;
            this.buttonAdjSplitter.Text = "Adjustable Splitter";
            this.buttonAdjSplitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonAdjSplitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonAdjSplitter.UseVisualStyleBackColor = true;
            this.buttonAdjSplitter.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonAdjSplitter_MouseClick);
            // 
            // pbPipeline
            // 
            this.pbPipeline.BackColor = System.Drawing.Color.White;
            this.pbPipeline.Location = new System.Drawing.Point(81, 12);
            this.pbPipeline.Name = "pbPipeline";
            this.pbPipeline.Size = new System.Drawing.Size(1041, 565);
            this.pbPipeline.TabIndex = 0;
            this.pbPipeline.TabStop = false;
            this.pbPipeline.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPipeline_Paint);
            this.pbPipeline.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbPipeline_MouseClick);
            this.pbPipeline.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPipeline_MouseDown);
            this.pbPipeline.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPipeline_MouseUp);
            // 
            // PipelineMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 589);
            this.Controls.Add(this.labelPercentage);
            this.Controls.Add(this.numPercentage);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.labelCapacity);
            this.Controls.Add(this.labelCurrentFlow);
            this.Controls.Add(this.numCurrentFlow);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pbPipeline);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PipelineMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pipelines";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPipeline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPipeline;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton buttonPump;
        private System.Windows.Forms.RadioButton buttonSink;
        private System.Windows.Forms.RadioButton buttonPipe;
        private System.Windows.Forms.NumericUpDown numCurrentFlow;
        private System.Windows.Forms.Label labelCurrentFlow;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.RadioButton buttonMerger;
        private System.Windows.Forms.RadioButton buttonSplitter;
        private System.Windows.Forms.RadioButton buttonAdjSplitter;
        private System.Windows.Forms.RadioButton buttonDelete;
        private System.Windows.Forms.NumericUpDown numPercentage;
        private System.Windows.Forms.Label labelPercentage;
    }
}

