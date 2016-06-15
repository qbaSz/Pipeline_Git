using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Merger : Component
    {
        private Pipe inputPipe1;
        private Pipe inputPipe2;
        private Pipe outputPipe;

        public Merger(Point pt)
        {
            this.Pos = pt;
            this.inputPipe1 = null;
            this.inputPipe2 = null;
            this.outputPipe = null;
        }

        public override void Draw(Graphics graphic)
        {
            double input = 0;
            if (inputPipe1 != null)
                input += inputPipe1.Flow;
            if (inputPipe2 != null)
                input += inputPipe2.Flow;

            graphic.FillRectangle(new SolidBrush(Color.Green), this.Pos.X, this.Pos.Y, Size, Size);
            if ((inputPipe1 != null || inputPipe2 != null) && outputPipe == null)
            {
                graphic.DrawRectangle(new Pen(Color.Red, 3), this.Pos.X, this.Pos.Y, Size, Size);
            }
            graphic.DrawString(input.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, this.Pos.X, this.Pos.Y + 10);
        }

        public override bool AddPipe(Pipe ppe, io IO)
        {
            if (IO == io.output && this.outputPipe == null)
            {
                this.outputPipe = ppe;
                if (inputPipe1 != null)
                {
                    this.outputPipe.Flow += inputPipe1.Flow;
                }
                if (inputPipe2 != null)
                {
                    this.outputPipe.Flow += inputPipe2.Flow;
                }
                return true;
            }
            else if (IO == io.input)
            {
                if (inputPipe1 == null)
                {
                    this.inputPipe1 = ppe;
                    if(this.outputPipe != null)
                    {
                        this.outputPipe.Flow = this.inputPipe1.Flow;
                        if (inputPipe2 != null)
                        {
                            this.outputPipe.Flow += this.inputPipe2.Flow;
                        }
                    }
                    return true;
                }
                else if (inputPipe2 == null)
                {
                    this.inputPipe2 = ppe;
                    if (this.outputPipe != null)
                    {
                        this.outputPipe.Flow = inputPipe2.Flow;
                        if (this.inputPipe1 != null)
                        {
                            this.outputPipe.Flow += inputPipe1.Flow;
                        } 
                    }
                    return true;
                }
            }
            return false;
        }

        public override void DeletePipe(Pipe ppe)
        {
            if (inputPipe1 == ppe)
            {
                inputPipe1 = null;
            }
            else if (inputPipe2 == ppe)
            {
                inputPipe2 = null;
            }
            else if (outputPipe == ppe)
            {
                outputPipe = null;
            }
        }

        public override void Delete(List<Pipe> pipeList)
        {
            base.Delete(pipeList);
            if (inputPipe1 != null)
            {
                inputPipe1.StartComponent.DeletePipe(inputPipe1);
                pipeList.Remove(inputPipe1);
                inputPipe1 = null;
            }
            if (inputPipe2 != null)
            {
                inputPipe2.StartComponent.DeletePipe(inputPipe2);
                pipeList.Remove(inputPipe2);
                inputPipe2 = null;
            }
            if (outputPipe != null)
            {
                outputPipe.EndComponent.DeletePipe(outputPipe);
                pipeList.Remove(outputPipe);
                outputPipe = null;
            }
        }
    }
}
