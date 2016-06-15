using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipelines
{
    class ComponentEventArgs : EventArgs
    {
        public Pipe Pipe { get; set; }
    }
}
