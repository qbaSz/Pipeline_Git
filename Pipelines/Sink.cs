using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Sink : Component
    {

        private int input = 0;

        public int Input { get { return input; } set { input = value; } }

        public Sink(Point p)
        {
            this.Pos = p;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.FillEllipse(new SolidBrush(Color.Gold), Pos.X - this.Size / 2, Pos.Y - this.Size / 2, this.Size, this.Size);
            graphic.DrawString(this.Input.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, Pos.X - this.Size / 2, Pos.Y - 6);
        }
    }
}
