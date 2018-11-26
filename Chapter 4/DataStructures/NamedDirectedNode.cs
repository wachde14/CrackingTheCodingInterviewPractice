using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4.DataStructures
{
    public class NamedDirectedNode
    {
        public string name;
        public List<NamedDirectedNode> children = new List<NamedDirectedNode>();

        public NamedDirectedNode(string name)
        {
            this.name = name;
        }
    }
}
