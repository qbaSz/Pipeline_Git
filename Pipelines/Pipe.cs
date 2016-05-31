using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipelines
{
    class Pipe
    {
        private Component startComponent;
        private Component endComponent;
        private bool isOverflow = false;

        public Component EndComponent
        {
            get { return endComponent; }
            set { endComponent = value; }
        }


        public Component StartComponent
        {
            get { return startComponent; }
            set { startComponent = value; }
        }

        public void Draw(Graphics graphic)
        {
            graphic.DrawLine(new Pen(Color.Black, 8), StartComponent.Pos, EndComponent.Pos);
        }
        
    }
}
