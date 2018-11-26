using Chapter_4.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4.TestObjects
{
    public static class TestNodeWithParentTrees
    {
        public static NodeWithParent Book4dot8Example()
        {
            NodeWithParent node3 = new NodeWithParent(3);
            NodeWithParent node5 = new NodeWithParent(5);
            NodeWithParent node7 = new NodeWithParent(7);
            NodeWithParent node10 = new NodeWithParent(10);
            NodeWithParent node15 = new NodeWithParent(15);
            NodeWithParent node17 = new NodeWithParent(17);
            NodeWithParent node20 = new NodeWithParent(20);
            NodeWithParent node30 = new NodeWithParent(30);

            node20.right = node30;
            node20.left = node10;

            node30.parent = node20;

            node10.parent = node20;
            node10.left = node5;
            node10.right = node15;

            node15.parent = node10;
            node15.right = node17;

            node5.parent = node10;
            node5.left = node3;
            node5.right = node7;

            node3.parent = node5;

            node7.parent = node5;

            node17.parent = node15;

            return node20;
        }


    }
}
