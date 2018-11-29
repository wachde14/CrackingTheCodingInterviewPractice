using Chapter_4.DataStructures;
using NUnit.Framework;
using System;

namespace Chapter_4
{
    /// <summary>
    /// First Common Ancestor: Design an algorithm and write code to find the first common ancestor
    /// of two nodes in a binary tree.Avoid storing additional nodes in a data structure.NOTE: This is not
    /// necessarily a binary search tree.
    /// </summary>
    public class _4_8_FirstCommonAncestor
    {
        public NodeWithParent Problem_4_8(NodeWithParent node1, NodeWithParent node2)
        {
            return FirstCommonAncestorWithParents(node1, node2);
        }

        NodeWithParent FirstCommonAncestorWithParents(NodeWithParent node1, NodeWithParent node2)
        {
            int depth1 = GetDepth(node1);
            int depth2 = GetDepth(node2);

            int difference = Math.Abs(depth1 - depth2);

            if (depth1 < depth2)
            {
                for (int i = 0; i < difference; i++)
                {
                    node2 = node2.parent;
                }
            }

            if (depth2 < depth1)
            {
                for (int i = 0; i < difference; i++)
                {
                    node1 = node1.parent;
                }
            }

            while (node1.parent != null && node2.parent != null && node1 != node2)
            {
                node1 = node1.parent;
                node2 = node2.parent;
            }

            if (node1 == node2)
            {
                return node1;
            }

            return null;
        }

        int GetDepth(NodeWithParent node)
        {
            NodeWithParent runnerNode = new NodeWithParent(0);
            runnerNode = node;

            int count = 0;
            while (runnerNode != null)
            {
                count++;
                runnerNode = runnerNode.parent;
            }

            return count;
        }

    }


    public class _4_8_FirstCommonAncestorTests
    {
        readonly _4_8_FirstCommonAncestor _practice = new _4_8_FirstCommonAncestor();

        [Test]
        public void _4_8_FirstCommonAncestor()
        {
            //Arrange
            NodeWithParent node1 = new NodeWithParent(1);
            NodeWithParent node2 = new NodeWithParent(2);
            NodeWithParent node3 = new NodeWithParent(3);
            NodeWithParent node4 = new NodeWithParent(4);
            NodeWithParent node5 = new NodeWithParent(5);
            NodeWithParent node6 = new NodeWithParent(6);
            NodeWithParent node7 = new NodeWithParent(7);
            NodeWithParent node8 = new NodeWithParent(8);
            NodeWithParent node9 = new NodeWithParent(9);
            NodeWithParent node10 = new NodeWithParent(10);

            node1.left = node2;
            node1.right = node3;

            node2.parent = node1;
            node2.left = node4;

            node3.parent = node1;
            node3.left = node5; node3.right = node6;

            node4.parent = node2;
            node4.right = node7;

            node5.parent = node3;

            node6.parent = node3;
            node6.left = node8; node6.right = node9;

            node7.parent = node4;

            node8.parent = node6;
            node8.right = node10;

            node9.parent = node6;

            node10.parent = node8;

            //Act
            NodeWithParent result = _practice.Problem_4_8(node8, node9);

            //Assert
            Assert.AreSame(node6, result);
        }

    }

}
