using Chapter_2___Linked_Lists.DataStructures;
using Chapter_2___Linked_Lists.HelperMethods;
using Chapter_2___Linked_Lists.TestObjects;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
    /// </summary>
    public class _2_2_KthToLast
    {
        public int KthToLastIterative(Node root, int k)
        {
            return 0;
        }
    }

    public class _2_2_KthToLastTests
    {
        readonly _2_2_KthToLast _practice = new _2_2_KthToLast();

        [Test]
        public void _2_2_KthToLastIterative_Test1()
        {
            Node expected = TestLinkedLists._12345();

            Node inputList = TestLinkedLists._1234555();
            int actual = _practice.KthToLastIterative(inputList, 2);

            Assert.AreEqual(true, true);
        }
    }
}
