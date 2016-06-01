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
            graphic.FillEllipse(new SolidBrush(Color.Green), this.Pos.X - this.Size / 2, this.Pos.Y - this.Size / 2, this.Size, this.Size);
        }

        public override bool AddPipe(Pipe ppe, io IO)
        {
            if (IO == io.output && this.outputPipe == null)
            {
                this.outputPipe = ppe;
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
                    }
                    return true;
                }
                else if (inputPipe2 == null)
                {
                    this.inputPipe2 = ppe;
                    if (this.outputPipe != null)
                    {
                        this.outputPipe.Flow = this.getOutput();
                    }
                    return true;
                }
            }
            return false;
        }

        public override double getOutput()
        {
            if (this.inputPipe1 != null)
            {
                if (this.inputPipe2 != null)
                {
                    return this.inputPipe1.Flow + this.inputPipe2.Flow;;
                }
                return this.inputPipe1.Flow;
            } 
            return 0;
        }

        public override void DeletePipe(Component.io IO)
        {
            if (IO == io.output)
            {
                base.DeletePipe(IO);
                this.outputPipe = null;
            }
        }
    }
}
