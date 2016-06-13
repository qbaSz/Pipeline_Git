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

        public Splitter(Point pt)
        {
            this.Pos = pt;
        }

        public override void Draw(Graphics graphic)
        {
            graphic.FillEllipse(new SolidBrush(Color.Cyan), this.Pos.X - this.Size / 2, this.Pos.Y - this.Size / 2, this.Size, this.Size);
        }

        public override bool AddPipe(Pipe ppe, io IO)
        {
            if (IO == io.input && inputPipe == null)
            {
                inputPipe = ppe;
                if (outputPipe1 != null)
                {
                    outputPipe1.Flow = inputPipe.Flow / 2;
                }
                if (outputPipe2 != null)
                {
                    outputPipe2.Flow = inputPipe.Flow / 2;
                }
                return true;
            }
            else if (IO == io.output)
            {
                if (outputPipe1 == null)
                {
                    outputPipe1 = ppe;
                    return true;
                }
                else if (outputPipe2 == null)
                {
                    outputPipe2 = ppe;
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

        public override double GetOutput()
        {
            if (inputPipe != null)
            {
                return inputPipe.Flow / 2;
            }
            return 0;
        }

    }
}
