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
        private bool isOverflow = false;
        private const int width = 8;

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
            graphic.DrawLine(new Pen(Color.Black, width), StartComponent.Pos, EndComponent.Pos);
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
                    double a = (double)(StartComponent.Pos.Y - EndComponent.Pos.Y) / (double)(StartComponent.Pos.X - EndComponent.Pos.X);
                    double b = StartComponent.Pos.Y - a * StartComponent.Pos.X;
                    if (pt.Y > (a * pt.X + b - 4) && pt.Y < (a * pt.X + b + 4))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
    }
}
