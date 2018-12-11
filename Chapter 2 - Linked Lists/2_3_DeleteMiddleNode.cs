using Chapter_2___Linked_Lists.DataStructures;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
    /// the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
    /// that node.
    /// EXAMPLE
    /// lnput:the node c from the linked list a->b->c->d->e->f
    /// Result: nothing is returned, but the new linked list looks like a ->b->d- >e- >f
    /// </summary>
    public class _2_3_DeleteMiddleNode
    {
        public void DeleteMiddleNode(ref Node middleNode)
        {
            if (middleNode == null || middleNode.Next == null)
            {
                return;
            }

            Node next = middleNode.Next;

            middleNode.Data = next.Data;
            middleNode.Next = next.Next;
        }
    }

    public class _2_3_DeleteMiddleNodeTests
    {
        readonly _2_3_DeleteMiddleNode _practice = new _2_3_DeleteMiddleNode();

        [Test]
        public void _2_3_DeleteMiddleNode_With123LinkedList_ShouldDeleteMiddleNode()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            node1.Next = node2;
            node2.Next = node3;

            _practice.DeleteMiddleNode(ref node2);

            node3.Should().BeEquivalentTo(node1.Next);
        }
    }
}
