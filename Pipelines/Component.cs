using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Component
    {
        private int size = 40;
        private Point pos;
        public enum io { input, output };

        public Point Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public int Size { get { return size; } }
        public virtual void Draw(Graphics graphic) { }
        public virtual bool AddPipe(Pipe ppe, io IO) { return false; }
        public virtual void DeletePipe(Pipe ppe) { }
        public virtual void Delete(List<Pipe> pipeList) { }
        public virtual double GetOutput() { return 0; }
    }
}
