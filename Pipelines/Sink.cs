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

        private int input;
        private const int size = 40;

        public int Input { get { return input; } set { input = value; } }
        public int Size { get { return size; } }

        public Sink(Point p)
        {
            this.Pos = p;
        }
    }
}
