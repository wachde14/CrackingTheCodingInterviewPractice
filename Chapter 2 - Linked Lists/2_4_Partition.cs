using Chapter_2___Linked_Lists.DataStructures;
using Chapter_2___Linked_Lists.TestObjects;
using FluentAssertions;
using NUnit.Framework;

namespace Chapter_2___Linked_Lists
{
    /// <summary>
    /// Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
    /// before all nodes greater than or equal to x.If x is contained within the list the values of x only need
    /// to be after the elements less than x(see below). The partition element x can appear anywhere in the
    /// "right partition"; it does not need to appear between the left and right partitions.
    /// EXAMPLE
    /// Input: 3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition= 5]
    /// Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8
    /// </summary>
    class _2_4_Partition
    {
        public Node Partition(Node head, int x)
        {
            Node list1Head = null;
            Node list1Ptr = null;
            Node list2Head = null;
            Node list2Ptr = null;

            while (head != null)
            {
                Node headCopy = new Node(head.Data);

                if (head.Data < x)
                {
                    if (list1Head == null)
                    {
                        list1Head = headCopy;
                        list1Ptr = list1Head;
                    }
                    else
                    {
                        list1Ptr.Next = headCopy;
                        list1Ptr = list1Ptr.Next;
                    }
                }
                else
                {
                    if (list2Head == null)
                    {
                        list2Head = headCopy;
                        list2Ptr = list2Head;
                    }
                    else
                    {
                        list2Ptr.Next = headCopy;
                        list2Ptr = list2Ptr.Next;
                    }
                }

                head = head.Next;
            }

            if (list1Head == null)
                return list2Head;

            list1Ptr.Next = list2Head;

            return list1Head;
        }
    } 

    public class _2_4_PartitionTests
    {
        readonly _2_4_Partition _practice = new _2_4_Partition();

        [Test]
        public void _2_4_Partition_With3_5_8_5_10_2LinkedList_ShouldCreatePartitioned()
        {
            Node testList = TestLinkedLists._3_5_8_5_10_2();
            Node expected = TestLinkedLists._3_2_1_5_8_5_10();

            Node partitionedList = _practice.Partition(testList, 5);

            partitionedList.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void _2_4_Partition_With1LinkedList_ShouldCreatePartitioned()
        {
            Node testList = new Node(1);

            Node partitionedList = _practice.Partition(testList, 5);

            testList.Should().BeEquivalentTo(partitionedList);
        }

        [Test]
        public void _2_4_Partition_With9LinkedList_ShouldCreatePartitioned()
        {
            Node testList = new Node(9);

            Node partitionedList = _practice.Partition(testList, 5);

            testList.Should().BeEquivalentTo(partitionedList);
        }
    }
}
