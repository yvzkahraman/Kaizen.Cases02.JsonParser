using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser.Domain
{
    public class Item
    {
        public string Description { get; set; } = null!;
        public BoundingPoly? BoundingPoly { get; set; }
    }

    public class BoundingPoly
    {
        public List<Vertice>? Vertices { get; set; }
    }
    public class Vertice
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
