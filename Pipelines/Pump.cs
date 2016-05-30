﻿using System;
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

        public double Capacity { get { return capacity; } set { capacity = value; } }
        public double CurrentFlow { get { return currentFlow; } set { currentFlow = value; } }

        /// <summary>
        /// Pump class representing fuel source.
        /// </summary>
        /// <param name="capacity_in">Maximum capacity of the pump</param>
        /// <param name="currentFlow_in">Amout of fuel currently flowing through pump</param>
        /// <param name="p">Position on the white board</param>
        public Pump(double currentFlow_in, double capacity_in, Point p)
        {
            this.capacity = capacity_in;
            this.currentFlow = currentFlow_in;
            this.Pos = p;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.FillEllipse(new SolidBrush(Color.Gray), this.Pos.X - this.Size / 2, this.Pos.Y - this.Size / 2, this.Size, this.Size);
            graphic.DrawString(this.CurrentFlow.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, this.Pos.X - this.Size / 2, this.Pos.Y - 6);
        }
    }
}
