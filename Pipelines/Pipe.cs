using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Pipe
    {
        private Point startPos;
        private Point endPos;

        public Point EndPos
        {
            get { return endPos; }
            set { endPos = value; }
        }


        public Point StartPos
        {
            get { return startPos; }
            set { startPos = value; }
        }

        public void Draw(Graphics graphic)
        {
            graphic.DrawLine(new Pen(Color.Black), StartPos, EndPos);
        }
        
    }
}
