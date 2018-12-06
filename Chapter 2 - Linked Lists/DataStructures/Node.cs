namespace Chapter_2___Linked_Lists.DataStructures
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data, Node next = null)
        {
            this.Data = data;
            this.Next = next;
        }
    }
}
