using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Sink : Component
    {

        //private double input = 0;
        private Pipe inputPipe;

        public double Input
        { 
            get
            { 
                if(inputPipe != null) 
                { 
                    return this.inputPipe.Flow; 
                } 
                return 0; 
            }
            //set { input = value; } 
        }

        public Sink(Point p)
        {
            this.Pos = p;
            this.inputPipe = null;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.FillEllipse(new SolidBrush(Color.Gold), Pos.X - this.Size / 2, Pos.Y - this.Size / 2, this.Size, this.Size);
            graphic.DrawString(this.Input.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, Pos.X - this.Size / 2, Pos.Y - 6);
        }

        public override bool AddPipe(Pipe ppe, Component.io IO)
        {
            if (IO == io.input && this.inputPipe == null)
            {
                base.AddPipe(ppe, IO);
                this.inputPipe = ppe;
                //this.input = ppe.Flow;
                return true;
            }
            return false;
        }

        public override void Delete(List<Pipe> pipeList)
        {
            base.Delete(pipeList);
            if (inputPipe != null)
            {
                inputPipe.StartComponent.DeletePipe(inputPipe);
                pipeList.Remove(inputPipe);
                inputPipe = null;
            }
        }

        public override void DeletePipe(Pipe ppe)
        {
            base.DeletePipe(ppe);
            inputPipe = null;
        }
    }
}
