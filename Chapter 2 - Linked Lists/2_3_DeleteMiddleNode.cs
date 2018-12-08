using Chapter_2___Linked_Lists.DataStructures;
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
        public bool DeleteMiddleNode(Node node)
        {
            return false;
        }
    }

    public class _2_3_DeleteMiddleNodeTests
    {
        readonly _2_3_DeleteMiddleNode _practice = new _2_3_DeleteMiddleNode();

        [Test]
        public void _2_3_DeleteMiddleNode_Test1()
        {
            int expected = 2;

            bool actual = _practice.DeleteMiddleNode(new Node(3));

            //Assert.AreEqual(expected, actual.Data);
        }

    }

}
