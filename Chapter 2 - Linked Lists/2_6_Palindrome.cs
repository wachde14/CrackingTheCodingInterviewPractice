using Chapter_2___Linked_Lists.DataStructures;
using Chapter_2___Linked_Lists.HelperMethods;
using Chapter_2___Linked_Lists.TestObjects;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Palindrome: Implement a function to check if a linked list is a palindrome.
    /// </summary>
    class _2_6_Palindrome
    {
        public bool IsPalindrome(Node head)
        {
            Node reversedList = ReverseLinkedList(head);

            return LinkedListUtilityMethods.AreLinkedListsEqual(head, reversedList);
        }

        private Node ReverseLinkedList(Node first)
        {
            Node head = LinkedListUtilityMethods.CloneList(first);

            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }
    }

    public class _2_6_PalindromeTests
    {
        readonly _2_6_Palindrome _practice = new _2_6_Palindrome();

        [Test]
        public void _2_6_IsPalindrome_WithLinkedList123_ShouldReturnFalse()
        {
            Node input = TestLinkedLists._123();

            bool result = _practice.IsPalindrome(input);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void _2_6_IsPalindrome_WithLinkedList121_ShouldReturnTrue()
        {
            Node input = TestLinkedLists._121();

            bool result = _practice.IsPalindrome(input);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void _2_6_IsPalindrome_WithNull_ShouldReturnTrue()
        {
            Node input = null;

            bool result = _practice.IsPalindrome(input);

            Assert.AreEqual(true, result);
        }
    }
}
