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
        private double capacity;
        private double currentFlow;
        private const int size = 40;

        public double Capacity { get { return capacity; } set { capacity = value; } }
        public double CurrentFlow { get { return currentFlow; } set { currentFlow = value; } }
        public int Size { get { return size; } }

        /// <summary>
        /// Pump class representing fuel source.
        /// </summary>
        /// <param name="capacity_in">Maximum capacity of the pump</param>
        /// <param name="currentFlow_in">Amout of fuel currently flowing through pump</param>
        /// <param name="p">Position on the white board</param>
        public Pump(double capacity_in, double currentFlow_in, Point p)
        {
            this.capacity = capacity_in;
            this.currentFlow = currentFlow_in;
            this.Pos = p;
        }
    }
}
