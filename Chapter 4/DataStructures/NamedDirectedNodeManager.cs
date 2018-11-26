using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4.DataStructures
{
    public class NamedDirectedNodeManager
    {
        public List<NamedDirectedNode> nodes;

        public bool DoesNodeHaveIncoming(NamedDirectedNode node)
        {
            foreach (NamedDirectedNode currNode in nodes)
            {
                if (currNode.children.Contains(node))
                {
                    return true;
                }
            }

            return false;
        }

        public NamedDirectedNode GetNodeByName(string name)
        {
            foreach (NamedDirectedNode node in nodes)
            {
                if (node.name == name)
                {
                    return node;
                }
            }

            return null;
        }
    }
}
