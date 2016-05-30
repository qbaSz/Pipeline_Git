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
                pg.AddPump(new Point(e.X, e.Y));
            }
            else if (buttonSink.Checked)
            {
                pg.AddSink(new Point(e.X, e.Y));
            }
            else if (buttonPipe.Checked)
            {
                
            }

            pbPipeline.Invalidate();
        }
    }
}
