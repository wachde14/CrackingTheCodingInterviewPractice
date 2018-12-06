using System.Collections.Generic;
using Chapter_2___Linked_Lists.DataStructures;
using Chapter_2___Linked_Lists.HelperMethods;
using Chapter_2___Linked_Lists.TestObjects;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Remove Dups: Write code to remove duplicates from an unsorted linked list.
    /// </summary>
    public class _2_1_RemoveDups
    {
        public Node Problem_2_1_Iterative(Node root)
        {
            return RemoveDupsIterative(ref root);
        }
        Node RemoveDupsIterative(ref Node root)
        {
            Dictionary<int, int> valueCountDictionary = new Dictionary<int, int>();

            Node node = root;
            Node prev = null;
            while (node != null)
            {
                if (!valueCountDictionary.ContainsKey(node.Data))
                {
                    valueCountDictionary.Add(node.Data, 1);
                    prev = node;
                }
                else
                {
                    prev.Next = node.Next;
                }

                node = node.Next;
            }

            return root;
        }

        public Node Problem_2_1_Recursive(Node root)
        {
            Dictionary<int, int> valueCountDictionary = new Dictionary<int, int>();
            Node prev = null;
            return RemoveDupsRecursive(root, prev, valueCountDictionary, root);
        }

        Node RemoveDupsRecursive(Node root, Node prev, Dictionary<int, int> valueCountDictionary, Node head)
        {
            if (root == null)
                return head;

            if (!valueCountDictionary.ContainsKey(root.Data))
            {
                valueCountDictionary.Add(root.Data, 1);
                prev = root;
            }
            else
            {
                prev.Next = root.Next;
            }

            return RemoveDupsRecursive(root.Next, prev, valueCountDictionary, head);
        }
    }

    public class _2_1_RemoveDupsTests
    {
        readonly _2_1_RemoveDups _practice = new _2_1_RemoveDups();

        [Test]
        public void _2_1_RemoveDupsIterative_Test1()
        {
            Node expected = TestLinkedLists._12345();

            Node input = TestLinkedLists._1234555();
            Node actual = _practice.Problem_2_1_Iterative(input);

            Assert.AreEqual(true, LinkedListUtilityMethods.AreLinkedListsEqual(actual, expected));
        }

        [Test]
        public void _2_1_RemoveDupsRecursive_Test1()
        {
            Node expected = TestLinkedLists._12345();

            Node input = TestLinkedLists._1234555();
            Node actual = _practice.Problem_2_1_Recursive(input);

            Assert.AreEqual(true, LinkedListUtilityMethods.AreLinkedListsEqual(actual, expected));
        }

        [Test]
        public void _2_1_RemoveDupsIterative_Test2()
        {
            Node expected = TestLinkedLists._123();

            Node input = TestLinkedLists._11122233();
            Node actual = _practice.Problem_2_1_Iterative(input);

            Assert.AreEqual(true, LinkedListUtilityMethods.AreLinkedListsEqual(actual, expected));
        }

        [Test]
        public void _2_1_RemoveDupsRecursive_Test2()
        {
            Node expected = TestLinkedLists._123();

            Node input = TestLinkedLists._11122233();
            Node actual = _practice.Problem_2_1_Recursive(input);

            Assert.AreEqual(true, LinkedListUtilityMethods.AreLinkedListsEqual(actual, expected));
        }
    }
}
