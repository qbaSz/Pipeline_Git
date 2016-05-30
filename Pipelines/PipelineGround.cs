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
        List<Component> componentList = new List<Component>();
        List<Pipe> pipeList = new List<Pipe>();
        Pipe tempPipe = null;

        public void Paint(Graphics graphic)
        {
            foreach (Component cmp in componentList)
            {
                cmp.Draw(graphic);
            }
            foreach (Pipe pi in pipeList)
            {
                pi.Draw(graphic);
            }
        }

        public void AddPump(double currentFlow, double capacity, Point pt)
        {

            if(CheckCollosion(pt)) 
            {
                Pump tempPump = new Pump(currentFlow, capacity, pt);
                componentList.Add(tempPump);   
            }
        }

        public void AddSink(Point pt)
        {
            if (CheckCollosion(pt))
            {
                Sink tempSink = new Sink(pt);
                componentList.Add(tempSink);
            }
        }

        public void AddStartPipePt(Point pt)
        {
            if (!CheckCollosion(pt))
            {
                tempPipe = new Pipe();
                tempPipe.StartPos = pt;
            }
        }

        public void AddEndPipePt(Point pt)
        {
            if (tempPipe != null && !CheckCollosion(pt))
            {
                tempPipe.EndPos = pt;
                pipeList.Add(tempPipe);
            }
        }

        public bool CheckCollosion(Point pt)
        {
            bool canPaint = true;
            foreach (Component cmp in componentList)
            {
                if (Math.Abs(cmp.Pos.X - pt.X) < cmp.Size && Math.Abs(cmp.Pos.Y - pt.Y) < cmp.Size)
                {
                    canPaint = false;
                }
            }
            return canPaint;
 
        }
    }
}
