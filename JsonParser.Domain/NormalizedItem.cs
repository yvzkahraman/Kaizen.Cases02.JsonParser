using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Domain
{
    public class NormalizedItem
    {
        public string Description { get; set; } = null!;

        public double CenterX { get; set; }
        public double CenterY { get; set; }
    }
}
