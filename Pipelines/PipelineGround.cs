using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class PipelineGround
    {
        List<Pump> pumpList = new List<Pump>();
        List<Sink> sinkList = new List<Sink>();

        public void Paint(Graphics graphic)
        {
            foreach (Pump p in pumpList)
            {
                graphic.DrawEllipse(new Pen(Color.Aqua), p.Pos.X - p.Size / 2, p.Pos.Y - p.Size / 2, p.Size, p.Size);
                graphic.DrawString(p.CurrentFlow.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, p.Pos.X - 6, p.Pos.Y - 6);
            }

            foreach (Sink s in sinkList)
            {
                graphic.DrawEllipse(new Pen(Color.Green), s.Pos.X - s.Size / 2, s.Pos.Y - s.Size / 2, s.Size, s.Size);
                graphic.DrawString(s.Input.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, s.Pos.X - 6, s.Pos.Y - 6);
            }
        }

        public void AddPump(Point pt)
        {
            bool canPaint = true;
            foreach (Pump pmp in pumpList)
            {
                if (Math.Abs(pmp.Pos.X - pt.X) < pmp.Size && Math.Abs(pmp.Pos.Y - pt.Y) < pmp.Size) 
                {
                    canPaint = false;
                }
            }
 
            if(canPaint) 
            {
                Pump tempPump = new Pump(10, 5, pt);
                pumpList.Add(tempPump);   
            }
        }

        public void AddSink(Point p)
        {
            Sink tempSink = new Sink(p);
            tempSink.Size = 30;
            tempSink.Input = 10;
            sinkList.Add(tempSink);
        }
    }
}
