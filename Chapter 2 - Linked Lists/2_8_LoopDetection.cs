using System.Collections.Generic;
using Chapter_2___Linked_Lists.DataStructures;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Loop Detection: Given a circular linked list, implement an algorithm that returns the node at the
    /// beginning of the loop.
    /// DEFINITION
    /// Circular linked list: A (corrupt) linked list in which a node's next pointer points to an earlier node, so
    /// as to make a loop in the linked list.
    /// EXAMPLE
    /// Input:
    /// Output:
    /// SOLUTION
    /// A - > B - > C - > D - > E - > C[the same C as earlier]
    /// C
    /// </summary>
    class _2_8_LoopDetection
    {
        public Node FindLoopBeginning(Node head)
        {
            HashSet<Node> nodeSet = new HashSet<Node>();

            Node listPtr = head;
            while (listPtr != null)
            {
                if (!nodeSet.Contains(listPtr))
                {
                    nodeSet.Add(listPtr);
                }
                else
                {
                    return listPtr;
                }

                listPtr = listPtr.Next;
            }

            return null;
        }
    }

    public class __2_8_LoopDetectionTests
    {
        readonly _2_8_LoopDetection _practice = new _2_8_LoopDetection();

        [Test]
        public void _2_8_FindLoopBeginning_WithIntersectingList_ShouldReturnIntersection()
        {
            //Arrange
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            //Add intersection
            node5.Next = node3;

            //Act
            Node result = _practice.FindLoopBeginning(node1);

            //Assert
            Assert.AreEqual(node3, result);
        }

        [Test]
        public void _2_8_FindLoopBeginning_WithNonIntersectingList_ShouldReturnNull()
        {
            //Arrange
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;

            //Act
            Node result = _practice.FindLoopBeginning(node1);

            //Assert
            Assert.AreEqual(null, result);
        }
    }
}
