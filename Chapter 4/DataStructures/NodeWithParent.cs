using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4.DataStructures
{
    public class NodeWithParent
    {
        public int data;
        public NodeWithParent left;
        public NodeWithParent right;
        public NodeWithParent parent;

        public NodeWithParent(int data)
        {
            this.data = data;
        }
    }
}
