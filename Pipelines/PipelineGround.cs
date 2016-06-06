using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pipelines
{
    class PipelineGround
    {
        List<Component> componentList = new List<Component>();
        List<Pipe> pipeList = new List<Pipe>();
        Pipe tempPipe = null;

        public void Paint(Graphics graphic)
        {
            foreach (Pipe pi in pipeList)
            {
                pi.Draw(graphic);
            }
            foreach (Component cmp in componentList)
            {
                cmp.Draw(graphic);
            }
        }

        public void AddPump(double currentFlow, double capacity, Point pt)
        {

            if(CheckCollision(pt) == null) 
            {
                Pump tempPump = new Pump(currentFlow, capacity, pt);
                componentList.Add(tempPump);   
            }
        }

        public void AddSink(Point pt)
        {
            if (CheckCollision(pt) == null)
            {
                Sink tempSink = new Sink(pt);
                componentList.Add(tempSink);
            }
        }

        public void AddStartPipePt(Point pt)
        {
            Component cmp = CheckCollision(pt);
            if (cmp != null)
            {
                tempPipe = new Pipe();
                if (cmp.AddPipe(tempPipe, Component.io.output))
                {
                    tempPipe.StartComponent = cmp;
                    tempPipe.Flow = tempPipe.StartComponent.GetOutput();
                }
            }
        }

        public void AddEndPipePt(Point pt)
        {
            Component cmp = CheckCollision(pt);
            try
            {
                if (tempPipe.StartComponent != null && cmp != null)
                {
                    if (cmp.AddPipe(tempPipe, Component.io.input))
                    {
                        tempPipe.EndComponent = cmp;
                        pipeList.Add(tempPipe);
                    }
                    else
                    {
                        tempPipe.StartComponent.DeletePipe(Component.io.output);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please draw pump or sink first");
            }
        }

        public void AddMerger(Point pt)
        {
            if (CheckCollision(pt) == null)
            {
                Merger tempMerger = new Merger(pt);
                componentList.Add(tempMerger);
            }
        }

        public Component CheckCollision(Point pt)
        {
            foreach (Component cmp in componentList)
            {
                if (Math.Abs(cmp.Pos.X - pt.X) < cmp.Size && Math.Abs(cmp.Pos.Y - pt.Y) < cmp.Size)
                {
                    return cmp;
                }
            }
            return null;
        }
    }
}
