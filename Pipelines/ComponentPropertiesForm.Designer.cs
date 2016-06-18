namespace Pipelines
{
    partial class ComponentPropertiesForm
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.labelCapacity = new System.Windows.Forms.Label();
            this.labelCurrentFlow = new System.Windows.Forms.Label();
            this.numCurrentFlow = new System.Windows.Forms.NumericUpDown();
            this.numPercentage = new System.Windows.Forms.NumericUpDown();
            this.labelPercentage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(32, 179);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(92, 40);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(87, 92);
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(62, 20);
            this.numCapacity.TabIndex = 9;
            this.numCapacity.ValueChanged += new System.EventHandler(this.numCapacity_ValueChanged);
            // 
            // labelCapacity
            // 
            this.labelCapacity.AutoSize = true;
            this.labelCapacity.Location = new System.Drawing.Point(9, 94);
            this.labelCapacity.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.labelCapacity.Name = "labelCapacity";
            this.labelCapacity.Size = new System.Drawing.Size(48, 13);
            this.labelCapacity.TabIndex = 8;
            this.labelCapacity.Text = "Capacity";
            // 
            // labelCurrentFlow
            // 
            this.labelCurrentFlow.AutoSize = true;
            this.labelCurrentFlow.Location = new System.Drawing.Point(9, 61);
            this.labelCurrentFlow.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.labelCurrentFlow.Name = "labelCurrentFlow";
            this.labelCurrentFlow.Size = new System.Drawing.Size(66, 13);
            this.labelCurrentFlow.TabIndex = 7;
            this.labelCurrentFlow.Text = "Current Flow";
            // 
            // numCurrentFlow
            // 
            this.numCurrentFlow.Location = new System.Drawing.Point(87, 59);
            this.numCurrentFlow.Name = "numCurrentFlow";
            this.numCurrentFlow.Size = new System.Drawing.Size(62, 20);
            this.numCurrentFlow.TabIndex = 6;
            // 
            // numPercentage
            // 
            this.numPercentage.Location = new System.Drawing.Point(87, 26);
            this.numPercentage.Name = "numPercentage";
            this.numPercentage.Size = new System.Drawing.Size(62, 20);
            this.numPercentage.TabIndex = 10;
            // 
            // labelPercentage
            // 
            this.labelPercentage.AutoSize = true;
            this.labelPercentage.Location = new System.Drawing.Point(9, 28);
            this.labelPercentage.Name = "labelPercentage";
            this.labelPercentage.Size = new System.Drawing.Size(72, 13);
            this.labelPercentage.TabIndex = 11;
            this.labelPercentage.Text = "Percent out A";
            // 
            // ComponentPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 231);
            this.Controls.Add(this.labelPercentage);
            this.Controls.Add(this.numPercentage);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.labelCapacity);
            this.Controls.Add(this.labelCurrentFlow);
            this.Controls.Add(this.numCurrentFlow);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ComponentPropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Properties";
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCurrentFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPercentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Label labelCapacity;
        private System.Windows.Forms.Label labelCurrentFlow;
        private System.Windows.Forms.NumericUpDown numCurrentFlow;
        private System.Windows.Forms.NumericUpDown numPercentage;
        private System.Windows.Forms.Label labelPercentage;
    }
}