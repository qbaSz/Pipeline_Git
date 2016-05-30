using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Component
    {
        private int size = 40;
        private Point pos;

        public Point Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public int Size { get { return size; } }
        public virtual void Draw(Graphics graphic) { }
    }
}
