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
        private Component startComponent;
        private Component endComponent;
        private const int width = 8;
        private const int labelDistance = 50;
        private char label = ' ';
        private double a, b;

        public char Label
        {
            set { label = value; }
        }

        private double flow;

        public double Flow
        {
            get { return flow; }
            set { flow = value; }
        }
        

        public Component EndComponent
        {
            get { return endComponent; }
            set { endComponent = value; }
        }


        public Component StartComponent
        {
            get { return startComponent; }
            set { startComponent = value; }
        }

        public void Draw(Graphics graphic)
        {
            graphic.DrawLine(new Pen(Overflow(), width), StartComponent.Pos, EndComponent.Pos);
            if (StartComponent.GetType() == typeof(Splitter) || StartComponent.GetType() == typeof(AdjustableSplitter))
	        {
                CalculateLineEquation();
                graphic.DrawString(this.label.ToString(), new Font("Arial", 12, FontStyle.Bold), Brushes.Black, (int)CalculateLabelX(), (int)(a * CalculateLabelX() + b));
	        }
            
        }

        private Color Overflow()
        {
            if (EndComponent.GetType() != typeof(Merger))
            {
                if (StartComponent.GetOutput() > EndComponent.GetCapacity())
                {
                    return Color.Red;
                }
            }
            return Color.Green;
        }

        public void Delete()
        {
            StartComponent.DeletePipe(this);
            EndComponent.DeletePipe(this);
        }

        public bool Contains(Point pt)
        {
            int top = Math.Min(StartComponent.Pos.Y, EndComponent.Pos.Y);
            int bottom = Math.Max(StartComponent.Pos.Y, EndComponent.Pos.Y);
            int left = Math.Min(StartComponent.Pos.X, EndComponent.Pos.X);
            int right = Math.Max(StartComponent.Pos.X, EndComponent.Pos.X);
            Rectangle rect = Rectangle.FromLTRB(left, top, right, bottom);
            if (rect.Contains(pt))
            {
                if (StartComponent.Pos.X == EndComponent.Pos.X)
                {
                    return true;
                }
                else if (StartComponent.Pos.Y == EndComponent.Pos.Y)
                {
                    return true;
                }
                else
                {
                    //y = ax + b
                    CalculateLineEquation();
                    if (pt.Y > (a * pt.X + b - 4) && pt.Y < (a * pt.X + b + 4))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CalculateLineEquation()
        {
            this.a = (double)(StartComponent.Pos.Y - EndComponent.Pos.Y) / (double)(StartComponent.Pos.X - EndComponent.Pos.X);
            this.b = StartComponent.Pos.Y - a * StartComponent.Pos.X;
        }

        private double CalculateLabelX()
        {
            double pipeLength = Math.Sqrt(Math.Pow(EndComponent.Pos.X - StartComponent.Pos.X, 2) + Math.Pow(EndComponent.Pos.Y - StartComponent.Pos.Y, 2));
            return (labelDistance * (EndComponent.Pos.X - StartComponent.Pos.X))/(pipeLength) + StartComponent.Pos.X;
        }

    }
}
