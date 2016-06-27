using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    [Serializable]
    class Pump : Component
    {
        private double capacity;
        private double currentFlow;
        private Pipe outputPipe;

        public double Capacity { get { return capacity; } set { capacity = value; } }
        public double CurrentFlow { get { return currentFlow; } set { currentFlow = value; } }
        public Pipe OutputPipe { get { return outputPipe; } set { outputPipe = value; } }

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
            this.outputPipe = null;
        }

        public override void Draw(Graphics graphic)
        {
            //base.Draw(graphic);
            graphic.FillEllipse(new SolidBrush(Color.Gray), this.Pos.X, this.Pos.Y, Size, Size);
            if (currentFlow != 0 && outputPipe == null )
            {
                graphic.DrawEllipse(new Pen(Color.Red, 3), this.Pos.X, this.Pos.Y, Size, Size);
            }
            graphic.DrawString(this.CurrentFlow.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, this.Pos.X, this.Pos.Y + 10);
            graphic.DrawString("Cap:" + this.capacity.ToString(), new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, Pos.X, Pos.Y + Size);
        }

        public override bool AddPipe(Pipe ppe, io IO)
        {
            if (outputPipe == null && IO == io.output)
            {
                base.AddPipe(ppe, IO);
                this.outputPipe = ppe;
                this.outputPipe.Flow = this.currentFlow;
                return true;
            }
            return false;
        }

        public override void DeletePipe(Pipe ppe)
        {
            if (this.outputPipe == ppe)
            {
                outputPipe.Flow = 0;
                UpdateOutput();
                this.outputPipe = null;
            }
        }

        public override void Delete(List<Pipe> pipeList)
        {
            if (outputPipe != null)
            {
                outputPipe.Flow = 0;
                UpdateOutput();
                outputPipe.EndComponent.DeletePipe(outputPipe);
                pipeList.Remove(outputPipe);
                outputPipe = null;
            }
        }

        public override void OnOutputChanged(object sender, ComponentEventArgs args)
        {
            args.Pipe.EndComponent.UpdateOutput();
        }

        public override void UpdateOutput()
        {
            base.UpdateOutput();
            if (outputPipe != null)
            {
                outputPipe.Flow = currentFlow;
                OnOutputChanged(outputPipe);
            }
        }
    }
}
