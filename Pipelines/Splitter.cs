using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pipelines
{
    [Serializable]
    class Splitter : Component
    {
        protected Color color = Color.Cyan;
        private double percentOut1 = 0;
        private Pipe outputPipe1;
        private Pipe outputPipe2;
        private Pipe inputPipe;

        public Pipe OutputPipe1 { get { return outputPipe1; } set { outputPipe1 = value; } }
        public Pipe InputPipe { get { return inputPipe; } set { inputPipe = value; } }
        public Pipe OutputPipe2 { get { return outputPipe2; } set { outputPipe2 = value; } }
        public double PercentOut1 { get { return percentOut1; } set { percentOut1 = value; } }

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
            graphic.DrawString("A:" + (this.percentOut1 * 100).ToString() + "%", new Font("Arial", 10, FontStyle.Regular), Brushes.Blue, Pos.X, Pos.Y + Size);
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
                UpdateOutput();
            }
        }

        public override void Delete(List<Pipe> pipeList)
        {
            if (inputPipe != null)
            {
                inputPipe.StartComponent.DeletePipe(inputPipe);
                pipeList.Remove(inputPipe);
                inputPipe = null;
                UpdateOutput();
            }
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
        }

        public override void UpdateOutput()
        {
            base.UpdateOutput();
            if (outputPipe1 != null)
            {
                if (inputPipe != null)
                    outputPipe1.Flow = inputPipe.Flow * percentOut1;
                else
                    outputPipe1.Flow = 0;
                OnOutputChanged(outputPipe1);
            }
            if (outputPipe2 != null)
            {
                if (inputPipe != null)
                    outputPipe2.Flow = inputPipe.Flow * (1 - percentOut1);
                else
                    outputPipe2.Flow = 0;
                OnOutputChanged(outputPipe2);
            }
        }

        public override void OnOutputChanged(object sender, ComponentEventArgs args)
        {
            if (args.Pipe.EndComponent != null)
               args.Pipe.EndComponent.UpdateOutput();
        }
    }
}
