using Chapter_4.DataStructures;
using NUnit.Framework;

namespace Chapter_4
{
    /// <summary>
    /// Successor: Write an algorithm to find the "next" node (i.e., in-order successor) of a given node in a
    /// binary search tree.You may assume that each node has a link to its parent.
    /// </summary>
    public class _4_6_Successor
    {
        public NodeWithParent Problem_4_6(NodeWithParent treeNode)
        {
            return InorderSuccessor(treeNode);
        }

        NodeWithParent InorderSuccessor(NodeWithParent treeNode)
        {
            if (treeNode.right != null)
            {
                NodeWithParent n;
                n = treeNode.right;

                while (n.left != null)
                {
                    n = n.left;
                }

                return n;
            }

            NodeWithParent m = treeNode.parent;
            while (m != null && treeNode.data > m.data)
            {
                m = m.parent;
            }

            return m;
        }
    }

    public class _4_6_SuccessorTests
    {
        readonly _4_6_Successor _practice = new _4_6_Successor();

        [Test]
        public void _4_6_Successor()
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
            NodeWithParent node11 = new NodeWithParent(11);
            node1.parent = node2;

            node2.left = node1;
            node2.right = node3;
            node2.parent = node4;

            node3.parent = node2;

            node4.left = node2;
            node4.right = node5;
            node4.parent = node6;

            node5.parent = node4;

            node6.left = node4;
            node6.right = node8;

            node7.parent = node8;

            node8.left = node7;
            node8.right = node10;
            node8.parent = node6;

            node9.parent = node10;

            node10.left = node9;
            node10.right = node11;
            node10.parent = node8;

            node11.parent = node10;

            //Act
            var result1 = _practice.Problem_4_6(node1);
            var result2 = _practice.Problem_4_6(node2);
            var result3 = _practice.Problem_4_6(node3);
            var result4 = _practice.Problem_4_6(node4);
            var result5 = _practice.Problem_4_6(node5);
            var result6 = _practice.Problem_4_6(node6);
            var result7 = _practice.Problem_4_6(node7);
            var result8 = _practice.Problem_4_6(node8);
            var result9 = _practice.Problem_4_6(node9);
            var result10 = _practice.Problem_4_6(node10);
            var result11 = _practice.Problem_4_6(node11);

            //Assert
            Assert.AreEqual(node2, result1);
            Assert.AreEqual(node3, result2);
            Assert.AreEqual(node4, result3);
            Assert.AreEqual(node5, result4);
            Assert.AreEqual(node6, result5);
            Assert.AreEqual(node7, result6);
            Assert.AreEqual(node8, result7);
            Assert.AreEqual(node9, result8);
            Assert.AreEqual(node10, result9);
            Assert.AreEqual(node11, result10);
            Assert.AreEqual(null, result11);

        }

    }

}
