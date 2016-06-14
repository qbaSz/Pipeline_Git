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
            if (currentFlow > capacity)
            {
                MessageBox.Show("Current flow cannot exceed capacity of the pump.");
            }
            else if (CheckCollision(pt) == null)
            {
                Pump tempPump = new Pump(currentFlow, capacity, pt);
                componentList.Add(tempPump);
            }
            
        }

        public void AddSink(Point pt, double capacity)
        {
            if (CheckCollision(pt) == null)
            {
                Sink tempSink = new Sink(pt, capacity);
                componentList.Add(tempSink);
            }
        }

        public void AddStartPipePt(Point pt, double capacity)
        {
            Component cmp = CheckCollision(pt);
            if (cmp != null)
            {
                tempPipe = new Pipe(capacity);
                if (cmp.AddPipe(tempPipe, Component.io.output))
                {
                    tempPipe.StartComponent = cmp;
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
                        tempPipe.StartComponent.DeletePipe(tempPipe);
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

        public void AddSplitter(Point pt)
        {
            if (CheckCollision(pt) == null)
            {
                Splitter tempSplitter = new Splitter(pt);
                componentList.Add(tempSplitter);
            }
        }

        public void AddAdjustableSplitter(Point pt, double percentage)
        {
            if (CheckCollision(pt) == null)
            {
                AdjustableSplitter tempSplitter = new AdjustableSplitter(pt, percentage);
                componentList.Add(tempSplitter);
            }
        }

        public Component CheckCollision(Point pt)
        {
            foreach (Component cmp in componentList)
            {
                if (Math.Abs(cmp.Pos.X - pt.X) < Component.Size && Math.Abs(cmp.Pos.Y - pt.Y) < Component.Size)
                {
                    return cmp;
                }
            }
            return null;
        }

        public Component FindComponent(Point pt)
        {
            foreach (Component cmp in componentList)
            {
                if (cmp.Contains(pt))
                {
                    return cmp;
                }
            }
            return null;
        }

        public Pipe CheckCollisionPipe(Point pt)
        {
            foreach (Pipe p in pipeList)
            {
                if (p.Contains(pt))
                {
                    return p;
                }
            }
            return null;
        }

        public void Delete(Point pt)
        {
            Component cmp = FindComponent(pt);
            Pipe ppe = CheckCollisionPipe(pt);
            if (cmp != null)
            {
                cmp.Delete(pipeList);
                componentList.Remove(cmp);
            }
            else if (ppe != null)
            {
                ppe.Delete();
                pipeList.Remove(ppe);
            }
        }
    }
}
