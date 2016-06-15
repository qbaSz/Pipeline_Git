using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pipelines
{
    class Splitter : Component
    {
        private Pipe outputPipe1;

        public Pipe OutputPipe1
        {
            get { return outputPipe1; }
            set { outputPipe1 = value; }
        }

        private Pipe inputPipe;

        public Pipe InputPipe
        {
            get { return inputPipe; }
            set { inputPipe = value; }
        }

        private Pipe outputPipe2;

        public Pipe OutputPipe2
        {
            get { return outputPipe2; }
            set { outputPipe2 = value; }
        }

        private double percentOut1 = 0;

        public double PercentOut1
        {
            get { return percentOut1; }
            set { percentOut1 = value; }
        }

        protected Color color = Color.Cyan;

        public Splitter(Point pt)
        {
            this.Pos = pt;
            this.percentOut1 = 0.5;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.FillRectangle(new SolidBrush(this.color), this.Pos.X, this.Pos.Y, Size, Size);
            if (inputPipe != null && (outputPipe1 == null || outputPipe2 == null))
            {
                graphic.DrawRectangle(new Pen(Color.Red, 3), this.Pos.X, this.Pos.Y, Size, Size);

            }
            if (inputPipe != null)
            {
                graphic.DrawString(this.inputPipe.Flow.ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Blue, this.Pos.X, this.Pos.Y + 10);
            }
            
        }

        public override bool AddPipe(Pipe ppe, io IO)
        {
            if (IO == io.input && inputPipe == null)
            {
                inputPipe = ppe;
                if (outputPipe1 != null)
                {
                    outputPipe1.Flow = inputPipe.Flow * this.percentOut1;
                }
                if (outputPipe2 != null)
                {
                    outputPipe2.Flow = inputPipe.Flow * (1 - this.percentOut1);
                }
                return true;
            }
            else if (IO == io.output)
            {
                if (outputPipe1 == null)
                {
                    outputPipe1 = ppe;
                    if (inputPipe != null)
                    {
                        outputPipe1.Flow = inputPipe.Flow * PercentOut1;
                    }
                    outputPipe1.Label = 'A';
                    return true;
                }
                else if (outputPipe2 == null)
                {
                    outputPipe2 = ppe;
                    if (inputPipe != null)
                    {
                        outputPipe2.Flow = inputPipe.Flow * (1 - PercentOut1);
                    }
                    outputPipe2.Label = 'B';
                    return true;
                }
            }
            return false;
        }

        public override void DeletePipe(Pipe ppe)
        {
            if (outputPipe1 == ppe)
            {
                outputPipe1 = null;
            }
            else if (outputPipe2 == ppe)
            {
                outputPipe2 = null;
            }
            else if (inputPipe == ppe)
            {
                inputPipe = null;
            }
        }

        public override void Delete(List<Pipe> pipeList)
        {
            if (outputPipe1 != null)
            {
                outputPipe1.EndComponent.DeletePipe(outputPipe1);
                pipeList.Remove(outputPipe1);
                outputPipe1 = null;
            }
            if (outputPipe2 != null)
            {
                outputPipe2.EndComponent.DeletePipe(outputPipe2);
                pipeList.Remove(outputPipe2);
                outputPipe2 = null;
            }
            if (inputPipe != null)
            {
                inputPipe.StartComponent.DeletePipe(inputPipe);
                pipeList.Remove(inputPipe);
                inputPipe = null;
            }
        }
    }
}
