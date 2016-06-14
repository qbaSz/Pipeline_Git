using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pipelines
{
    public partial class PipelineMain : Form
    {
        PipelineGround pg = new PipelineGround();
        
        public PipelineMain()
        {
            InitializeComponent();
            NumInputsToggle(false, true, true);
            pbPipeline.Invalidate();
        }

        private void pbPipeline_Paint(object sender, PaintEventArgs e)
        {
            pg.Paint(e.Graphics);
        }

        private void pbPipeline_MouseClick(object sender, MouseEventArgs e)
        {
            Point pt = new Point(e.X - Component.Size / 2, e.Y - Component.Size / 2);
            if (buttonPump.Checked)
            {
                pg.AddPump(Convert.ToDouble(numCurrentFlow.Value), Convert.ToDouble(numCapacity.Value), pt);
            }
            else if (buttonSink.Checked)
            {
                pg.AddSink(pt, Convert.ToDouble(numCapacity.Value));
            }
            else if (buttonMerger.Checked)
            {
                pg.AddMerger(pt);
            }
            else if (buttonDelete.Checked)
            {
                pg.Delete(new Point(e.X, e.Y));
            }
            else if (buttonSplitter.Checked)
            {
                pg.AddSplitter(pt);
            }
            else if (buttonAdjSplitter.Checked)
            {
                pg.AddAdjustableSplitter(pt, Convert.ToDouble(numPercentage.Value / 100));
            }

            pbPipeline.Invalidate();
        }

        private void pbPipeline_MouseDown(object sender, MouseEventArgs e)
        {
            if (buttonPipe.Checked)
            {
                pg.AddStartPipePt(new Point(e.X, e.Y), Convert.ToDouble(numCapacity.Value));
            }
        }

        private void pbPipeline_MouseUp(object sender, MouseEventArgs e)
        {
            if (buttonPipe.Checked)
            {
                pg.AddEndPipePt(new Point(e.X, e.Y));
            }
            pbPipeline.Refresh();
        }

        private void NumPercentageToggle(bool visible)
        {
            labelPercentage.Visible = visible;
            numPercentage.Visible = visible;
        }

        private void NumCurrentFlowToggle(bool visible)
        {
            labelCurrentFlow.Visible = visible;
            numCurrentFlow.Visible = visible;
        }

        private void NumCapacityFlowToggle(bool visible)
        {
            labelCapacity.Visible = visible;
            numCapacity.Visible = visible;
        }

        private void NumInputsToggle(bool percentage_visible, bool flow_visible, bool capacity_visible)
        {
            NumPercentageToggle(percentage_visible);
            NumCurrentFlowToggle(flow_visible);
            NumCapacityFlowToggle(capacity_visible);
        }

        private void buttonPump_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, true, true);
        }

        private void buttonSink_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, true);
        }

        private void buttonPipe_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, true);
        }

        private void buttonMerger_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, false);
        }

        private void buttonSplitter_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, false);
        }

        private void buttonAdjSplitter_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(true, false, false);
        }

        private void buttonDelete_MouseClick(object sender, MouseEventArgs e)
        {
            NumInputsToggle(false, false, false);
        }


    }
}
