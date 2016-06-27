using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    [Serializable]
    class Pipe
    {
        private Component startComponent;
        private Component endComponent;
        private const int width = 8;
        private const int labelDistance = 50;
        private char label = ' ';
        private double a, b, pipeLength;
        private List<Point> anchorPoints = new List<Point>();

        private double capacity;

        public double Capacity { get { return capacity; } set { capacity = value; } }

        public Pipe(double capacity)
        {
            this.capacity = capacity;
        }

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
            if (anchorPoints.Count > 1)
            {
                Pen pen = new Pen(Overflow(), width);
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                //CalculateLineEquation(new Point(StartComponent.Pos.X + Component.Size / 2, StartComponent.Pos.Y + Component.Size / 2), new Point(EndComponent.Pos.X + Component.Size / 2, EndComponent.Pos.Y + Component.Size / 2));
                CalculateLineEquation(anchorPoints[(int)(anchorPoints.Count / 2) - 1], anchorPoints[(int)(anchorPoints.Count / 2)]);
                for (int i = 0; i < anchorPoints.Count - 1; i++)
                {
                    graphic.DrawLine(pen, anchorPoints[i].X, anchorPoints[i].Y, anchorPoints[i + 1].X, anchorPoints[i + 1].Y);
                }

                if (StartComponent.GetType() == typeof(Splitter) || StartComponent.GetType() == typeof(AdjustableSplitter))
                {
                    graphic.DrawString("\n" + this.label.ToString() + " = " + this.flow.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, (int)CalculateLabelX(anchorPoints[(int)(anchorPoints.Count / 2) - 1], anchorPoints[(int)(anchorPoints.Count / 2)], (int)(pipeLength * 0.75)), (int)(a * CalculateLabelX(anchorPoints[(int)(anchorPoints.Count / 2) - 1], anchorPoints[(int)(anchorPoints.Count / 2)], (int)(pipeLength * 0.75)) + b));
                }
                graphic.DrawString("Cap: " + this.capacity.ToString(), new Font("Arial", 9, FontStyle.Bold), Brushes.Brown, (int)CalculateLabelX(anchorPoints[(int)(anchorPoints.Count / 2) - 1], anchorPoints[(int)(anchorPoints.Count / 2)], (int)(pipeLength * 0.75)), (int)(a * CalculateLabelX(anchorPoints[(int)(anchorPoints.Count / 2) - 1], anchorPoints[(int)(anchorPoints.Count / 2)], (int)(pipeLength * 0.75)) + b));
            }
            
        }

        private Color Overflow()
        {
            if (this.capacity < this.flow)
            {
                return Color.Red;
            }
            return Color.LightGreen;
        }

        public void Delete()
        {
            StartComponent.DeletePipe(this);
            EndComponent.DeletePipe(this);
        }

        public bool Contains(Point pt)
        {
            bool result = false;
            for (int i = 0; i < anchorPoints.Count - 1; i++)
            {
                result = SegmentContainsPoint(anchorPoints[i], anchorPoints[i + 1], pt);
                if (result)
                {
                    break;
                }
            }
            return result;
        }

        private bool SegmentContainsPoint(Point startPt, Point endPt, Point pt)
        {
            int top = Math.Min(startPt.Y, endPt.Y);
            int bottom = Math.Max(startPt.Y, endPt.Y);
            int left = Math.Min(startPt.X, endPt.X);
            int right = Math.Max(startPt.X, endPt.X);
            Rectangle rect = Rectangle.FromLTRB(left, top, right, bottom);
            if (rect.Contains(pt))
            {
                if (startPt.X == endPt.X)
                {
                    return true;
                }
                else if (startPt.Y == endPt.Y)
                {
                    return true;
                }
                else
                {
                    //y = ax + b
                    CalculateLineEquation(startPt, endPt);
                    if (pt.Y > (a * pt.X + b - 4) && pt.Y < (a * pt.X + b + 4))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CalculateLineEquation(Point startPt, Point endPt)
        {
            this.a = (double)(startPt.Y - endPt.Y) / (double)(startPt.X - endPt.X);
            this.b = startPt.Y - a * startPt.X;
            this.pipeLength = Math.Sqrt(Math.Pow(endPt.X - startPt.X, 2) + Math.Pow(endPt.Y - startPt.Y, 2));
        }

        private double CalculateLabelX(Point startPt, Point endPt, int distance)
        {
            //Point startPt = new Point(StartComponent.Pos.X + Component.Size / 2, StartComponent.Pos.Y + Component.Size / 2);
            //Point endPt = new Point(EndComponent.Pos.X + Component.Size / 2, EndComponent.Pos.Y + Component.Size / 2);
            return ((distance) * (endPt.X - startPt.X))/(this.pipeLength) + startPt.X;
        }

        public void AddAnchorPoint(Point pt)
        {
            anchorPoints.Add(pt);
        }

    }
}
