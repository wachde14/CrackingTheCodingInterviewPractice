using Chapter_2___Linked_Lists.DataStructures;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Sum Lists: You have two numbers represented by a linked list, where each node contains a single
    /// digit.The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
    /// function that adds the two numbers and returns the sum as a linked list.
    /// EXAMPLE
    /// Input: (7-> 1 -> 6) + (5 -> 9 -> 2).That is,617 + 295.
    /// Output: 2 -> 1 -> 9. That is, 912.
    /// </summary>
    class _2_5_SumLists
    {
        public Node SumLists(Node l1, Node l2)
        {
            bool carry = false;

            Node answer = null;
            Node tail = null;

            while (l1 != null || l2 != null || carry)
            {
                int currDigit = 0;
                int addOne = 0;
                int addTwo = 0;
                if (l1 != null)
                {
                    addOne = l1.Data;
                }

                if (l2 != null)
                {
                    addTwo = l2.Data;
                }

                if (carry && l1 == null && l2 == null)
                {
                    tail.Next = new Node(1);
                    return answer;
                }

                if (carry)
                {
                    currDigit = addOne + addTwo + 1;
                }
                else
                {
                    currDigit = addOne + addTwo;
                }

                if (currDigit >= 10)
                {
                    carry = true;
                    currDigit = currDigit % 10;
                }
                else
                {
                    carry = false;
                }


                if (answer == null)
                {
                    answer = new Node(currDigit);
                    tail = answer;
                }
                else
                {
                    tail.Next = new Node(currDigit);
                    tail = tail.Next;
                }

                if (l1 != null && l1.Next != null)
                {
                    l1 = l1.Next;
                }
                else
                {
                    l1 = null;
                }

                if (l2 != null && l2.Next != null)
                {
                    l2 = l2.Next;
                }
                else
                {
                    l2 = null;
                }

            }

            return answer;
        }
    }

    public class _2_5_SumListsTests
    {
        readonly _2_5_SumLists _practice = new _2_5_SumLists();

        [Test]
        public void _2_5_SumLists_WithBookExampleLinkedLists_ShouldSumLists()
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

            Node node2a = new Node(2);
            Node node1a = new Node(1);
            Node node9a = new Node(9);
            node2a.Next = node1a;
            node1a.Next = node9a;
            Node expected = node2a;

            //Act
            Node result = _practice.SumLists(list1, list2);

            //Assert
            result.Should().BeEquivalentTo(expected);
        }
    }
}
