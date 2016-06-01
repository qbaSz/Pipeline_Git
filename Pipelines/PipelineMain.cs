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
        }

        private void pbPipeline_Paint(object sender, PaintEventArgs e)
        {
            pg.Paint(e.Graphics);
        }

        private void pbPipeline_MouseClick(object sender, MouseEventArgs e)
        {
            if (buttonPump.Checked)
            {
                pg.AddPump(Convert.ToDouble(numCurrentFlow.Value), Convert.ToDouble(numCapacity.Value), new Point(e.X, e.Y));
            }
            else if (buttonSink.Checked)
            {
                pg.AddSink(new Point(e.X, e.Y));
            }
            else if (buttonMerger.Checked)
            {
                pg.AddMerger(new Point(e.X, e.Y));
            }

            pbPipeline.Invalidate();
        }

        private void pbPipeline_MouseDown(object sender, MouseEventArgs e)
        {
            if (buttonPipe.Checked)
            {
                pg.AddStartPipePt(new Point(e.X, e.Y));
            }
        }

        private void pbPipeline_MouseUp(object sender, MouseEventArgs e)
        {
            if (buttonPipe.Checked)
            {
                pg.AddEndPipePt(new Point(e.X, e.Y));
            }
            pbPipeline.Invalidate();
        }
    }
}
