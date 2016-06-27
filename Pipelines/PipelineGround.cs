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
        //for returng list of components and list of pipe
        public List<Component> ComponentList { get { return componentList; } }
        public List<Pipe> pipelist { get { return pipeList; } }
        //  private ComponentPropertiesForm propertiesForm;

        public PipelineGround()
        {
           // propertiesForm = new ComponentPropertiesForm();
        }

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
            Component cmp = FindComponent(pt);
            if (cmp != null)
            {
                tempPipe = new Pipe(capacity);
                tempPipe.AddAnchorPoint(pt);
                if (cmp.AddPipe(tempPipe, Component.io.output))
                {
                    tempPipe.StartComponent = cmp;
                    Console.WriteLine("Start component added");
                }
                else
                {
                    tempPipe = null;
                }
            }
        }

        public void AddEndPipePt(Point pt)
        {
            Component cmp = FindComponent(pt);
            //if(tempPipe != null)
            //{
            //    if (tempPipe.StartComponent != null && cmp != null && cmp != tempPipe.StartComponent)
            //    {
            //        if (cmp.AddPipe(tempPipe, Component.io.input))
            //        {
            //            tempPipe.EndComponent = cmp;
            //            pipeList.Add(tempPipe);
            //            tempPipe.AddAnchorPoint(pt);
            //            tempPipe.StartComponent.OutputChanged += tempPipe.EndComponent.OnOutputChanged;
            //            tempPipe = null;
            //        }
            //        else
            //        {
            //            tempPipe.StartComponent.DeletePipe(tempPipe);
            //            tempPipe = null;
            //        }

            //    }
            //    else if ((tempPipe.StartComponent != null && cmp == null) || (tempPipe.StartComponent != null && cmp == tempPipe.StartComponent))
            //    {
            //        tempPipe.StartComponent.DeletePipe(tempPipe);
            //        tempPipe = null;
            //    }
            //}
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
            {
                tempPipe.AddAnchorPoint(pt);
            }
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
