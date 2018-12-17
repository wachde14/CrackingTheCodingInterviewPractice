using System.Collections.Generic;
using Chapter_2___Linked_Lists.DataStructures;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Intersection: Given two (singly) linked lists, determine if the two lists intersect. Return the
    /// intersecting node.Note that the intersection is defined based on reference, not value. That is, if the
    /// kth node of the first linked list is the exact same node (by reference) as the jth node of the second
    /// linked list, then they are intersecting.
    /// </summary>
    class _2_7_Intersection
    {
        public Node FindIntersection(Node list1, Node list2)
        {
            HashSet<Node> nodeSet = new HashSet<Node>();

            Node list1Ptr = list1;
            while (list1Ptr != null)
            {
                nodeSet.Add(list1Ptr);

                list1Ptr = list1Ptr.Next;
            }

            Node list2Ptr = list2;
            while (list2Ptr != null)
            {
                if (nodeSet.Contains(list2Ptr))
                {
                    return list2Ptr;
                }

                list2Ptr = list2Ptr.Next;
            }

            return null;
        }
    }

    public class _2_7_IntersectionTests
    {
        readonly _2_7_Intersection _practice = new _2_7_Intersection();

        [Test]
        public void _2_7_FindIntersection_WithIntersectingList_ShouldReturnIntersection()
        {
            //Arrange
            Node node7 = new Node(7);
            Node node1 = new Node(1);
            Node node6 = new Node(6);
            node7.Next = node1;
            node1.Next = node6;
            Node list1 = node7;

            Node node5 = new Node(5);
            Node node9 = new Node(9);
            Node node2 = new Node(2);
            node5.Next = node9;
            node9.Next = node2;
            //Join with list1
            node2.Next = node1;
            Node list2 = node5;

            //Act
            Node result = _practice.FindIntersection(list1, list2);

            //Assert
            Assert.AreEqual(node1, result);
        }

        [Test]
        public void _2_7_FindIntersection_WithIndependentLists_ShouldReturnNull()
        {
            //Arrange
            Node node7 = new Node(7);
            Node node1 = new Node(1);
            Node node6 = new Node(6);
            node7.Next = node1;
            node1.Next = node6;
            Node list1 = node7;

            Node node5 = new Node(5);
            Node node9 = new Node(9);
            Node node2 = new Node(2);
            node5.Next = node9;
            node9.Next = node2;
            Node list2 = node5;

            //Act
            Node result = _practice.FindIntersection(list1, list2);

            //Assert
            Assert.AreEqual(null, result);
        }
    }
}
