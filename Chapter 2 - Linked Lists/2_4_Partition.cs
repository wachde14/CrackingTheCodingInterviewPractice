using Chapter_2___Linked_Lists.DataStructures;
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
        public void Partition(Node node, int x)
        {

        }

    }

    public class _2_4_PartitionTests
    {
        readonly _2_4_Partition _practice = new _2_4_Partition();

        [Test]
        public void _2_4_DeleteMiddleNode_With123LinkedList_ShouldDeleteMiddleNode()
        {
            //Node node1 = new Node(1);
            //Node node2 = new Node(2);
            //Node node3 = new Node(3);
            //node1.Next = node2;
            //node2.Next = node3;

            //_practice.DeleteMiddleNode(ref node2);

            //node3.Should().BeEquivalentTo(node1.Next);
        }
    }

}
