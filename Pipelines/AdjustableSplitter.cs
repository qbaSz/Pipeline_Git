using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pipelines
{
    class AdjustableSplitter : Splitter
    {
        public AdjustableSplitter(Point pt, double percentage) : base(pt)
        {
            PercentOut1 = percentage;
            this.color = Color.Khaki;
        }
    }
}
