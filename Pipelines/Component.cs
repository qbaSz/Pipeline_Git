using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    [Serializable]
    class Component
    {
        private static int size = 40;
        //top-left corner
        private Point pos;
        public enum io { input, output };

        public Point Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public EventHandler<ComponentEventArgs> OutputChanged;
        public static int Size { get { return size; } }
        public virtual void Draw(Graphics graphic) { }
        public virtual bool AddPipe(Pipe ppe, io IO) { return false; }
        public virtual void DeletePipe(Pipe ppe) { }
        public virtual void Delete(List<Pipe> pipeList) { }
        public virtual double GetCapacity() { return 0; }
        public virtual void UpdateOutput() { }

        public bool Contains(Point pt)
        {
            if (pt == pos || ((pt.X > this.pos.X && pt.X < this.pos.X + size) && (pt.Y > this.pos.Y && pt.Y < this.pos.Y + size)))
            {
                return true;
            }
            return false;
        }

        protected virtual void OnOutputChanged(Pipe ppe)
        {
            if (OutputChanged != null)
                OutputChanged(this, new ComponentEventArgs(){Pipe = ppe});
        }

        public virtual void OnOutputChanged(object sender, ComponentEventArgs args) { }
    }
}
