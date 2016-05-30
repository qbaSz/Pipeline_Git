using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Pump : Component
    {
        private int capacity;
        private int currentFlow;
        private const int size = 30;

        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int CurrentFlow { get { return currentFlow; } set { currentFlow = value; } }
        public int Size { get { return size; } }


        public Pump(int capacity_in, int currentFlow_in, Point p)
        {
            this.capacity = capacity_in;
            this.currentFlow = currentFlow_in;
            this.Pos = p;
        }
    }
}
