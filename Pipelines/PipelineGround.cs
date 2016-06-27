using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pipelines
{
    [Serializable]
    class PipelineGround
    {
        List<Component> componentList = new List<Component>();
        List<Pipe> pipeList = new List<Pipe>();
        Pipe tempPipe = null;
        public List<Component> ComponentList { get { return componentList; } }
        public List<Pipe> pipelist { get { return pipeList; } }

        public PipelineGround() { }

        public void Paint(Graphics graphic)
        {
            foreach (Pipe pi in pipeList)
            {
                pi.Draw(graphic);
            }
            if(tempPipe != null)
                tempPipe.Draw(graphic);
            foreach (Component cmp in componentList)
            {
                cmp.Draw(graphic);
            }
        }

        public bool AddPump(double currentFlow, double capacity, Point pt)
        {
            if (currentFlow > capacity)
            {
                MessageBox.Show("Current flow cannot exceed capacity of the pump.");
            }
            else if (CheckCollision(pt) == null)
            {
                Pump tempPump = new Pump(currentFlow, capacity, pt);
                componentList.Add(tempPump);
                return true;
            }
            return false;
            
        }

        public bool AddSink(Point pt, double capacity)
        {
            if (CheckCollision(pt) == null)
            {
                Sink tempSink = new Sink(pt, capacity);
                componentList.Add(tempSink);
                return true;
            }
            return false;
        }

        public void AddStartPipePt(Point pt, double capacity)
        {
            Component cmp = FindComponent(pt);
            if (cmp != null)
            {
                tempPipe = new Pipe(capacity);
                tempPipe.AddAnchorPoint(pt);
                if (cmp.AddPipe(tempPipe, Component.io.output))
                    tempPipe.StartComponent = cmp;
                else
                    tempPipe = null;
            }
        }

        public void AddEndPipePt(Point pt)
        {
            Component cmp = FindComponent(pt);
            if (cmp == tempPipe.StartComponent)
            {
                tempPipe.StartComponent.DeletePipe(tempPipe);
                tempPipe = null;
            }else
            {
                if (cmp.AddPipe(tempPipe, Component.io.input))
                {
                    tempPipe.EndComponent = cmp;
                    tempPipe.AddAnchorPoint(pt);
                    pipeList.Add(tempPipe);
                    tempPipe.StartComponent.OutputChanged += tempPipe.EndComponent.OnOutputChanged;
                    tempPipe = null;
                }
                else
                {
                    tempPipe.StartComponent.DeletePipe(tempPipe);
                    tempPipe = null;
                }
            }
        }

        public void AddPipesAnchorPoint(Point pt)
        {
            if(tempPipe != null)
                tempPipe.AddAnchorPoint(pt);
        }

        public void AddPipe(Point pt, double capacity)
        {
            if (tempPipe == null)
            {
                AddStartPipePt(pt, capacity);
            }
            else if (tempPipe != null && FindComponent(pt) == null)
            {
                AddPipesAnchorPoint(pt);
            }
            else if (tempPipe != null && FindComponent(pt) != null)
            {
                AddEndPipePt(pt);
            }
        }

        public bool AddMerger(Point pt)
        {
            if (CheckCollision(pt) == null)
            {
                Merger tempMerger = new Merger(pt);
                componentList.Add(tempMerger);
                return true;
            }
            return false;
        }

        public bool AddSplitter(Point pt)
        {
            if (CheckCollision(pt) == null)
            {
                Splitter tempSplitter = new Splitter(pt);
                componentList.Add(tempSplitter);
                return true;
            }
            return false;
        }

        public bool AddAdjustableSplitter(Point pt, double percentage)
        {
            if (CheckCollision(pt) == null)
            {
                AdjustableSplitter tempSplitter = new AdjustableSplitter(pt, percentage);
                componentList.Add(tempSplitter);
                return true;
            }
            return false;
        }

        public Component CheckCollision(Point pt)
        {
            foreach (Component cmp in componentList)
            {
                if (Math.Abs(cmp.Pos.X - pt.X) < Component.Size && Math.Abs(cmp.Pos.Y - pt.Y) < Component.Size)
                    return cmp;
            }
            return null;
        }

        public Component FindComponent(Point pt)
        {
            foreach (Component cmp in componentList)
            {
                if (cmp.Contains(pt))
                    return cmp;
            }
            return null;
        }

        public Pipe CheckCollisionPipe(Point pt)
        {
            foreach (Pipe p in pipeList)
            {
                if (p.Contains(pt))
                    return p;
            }
            return null;
        }

        public bool DeleteElementFromGround(Point pt)
        {
            Component cmp = FindComponent(pt);
            Pipe ppe = CheckCollisionPipe(pt);
            if (cmp != null)
            {
                cmp.Delete(pipeList);
                componentList.Remove(cmp);
               return false;
            }
            else if (ppe != null)
            {
                ppe.Delete();
                pipeList.Remove(ppe);
                return false;
            }
            return true;
        }
      
       

        public void ClearTempPipe()
        {
            if (tempPipe != null)
            {
                tempPipe.StartComponent.DeletePipe(tempPipe);
                tempPipe = null;
            }
        }
    }
}
