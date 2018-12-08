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
        public Node KthToLastIterative(Node head, int k)
        {
            Node ptr1 = head;
            Node ptr2 = head;

            for (int i = 0; i < k; i++)
            {
                if (ptr1 == null)
                    return null;

                ptr1 = ptr1.Next;
            }

            while (ptr1.Next != null)
            {
                ptr1 = ptr1.Next;
                ptr2 = ptr2.Next;
            }

            return ptr2;
        }
    }

    public class _2_2_KthToLastTests
    {
        readonly _2_2_KthToLast _practice = new _2_2_KthToLast();

        [Test]
        public void _2_2_KthToLastIterative_Test1()
        {
            int expected = 2;

            Node inputList = TestLinkedLists._123();
            Node actual = _practice.KthToLastIterative(inputList, 1);

            Assert.AreEqual(expected, actual.Data);
        }

        [Test]
        public void _2_2_KthToLastIterative_Test2()
        {
            int expected = 1;

            Node inputList = TestLinkedLists._123();
            Node actual = _practice.KthToLastIterative(inputList, 2);

            Assert.AreEqual(expected, actual.Data);
        }

        [Test]
        public void _2_2_KthToLastIterative_Test3()
        {
            int expected = 3;

            Node inputList = TestLinkedLists._123();
            Node actual = _practice.KthToLastIterative(inputList, 0);

            Assert.AreEqual(expected, actual.Data);
        }

        [Test]
        public void _2_2_KthToLastIterative_Test4()
        {
            int expected = 4;

            Node inputList = TestLinkedLists._12345();
            Node actual = _practice.KthToLastIterative(inputList, 1);

            Assert.AreEqual(expected, actual.Data);
        }

        [Test]
        public void _2_2_KthToLastIterative_Test5()
        {
            int expected = 1;

            Node inputList = TestLinkedLists._12345();
            Node actual = _practice.KthToLastIterative(inputList, 4);

            Assert.AreEqual(expected, actual.Data);
        }
    }
}
