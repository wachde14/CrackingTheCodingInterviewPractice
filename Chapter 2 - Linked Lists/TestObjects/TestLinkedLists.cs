using Chapter_2___Linked_Lists.DataStructures;

namespace Chapter_2___Linked_Lists.TestObjects
{
    public static class TestLinkedLists
    {
        public static Node _12345()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;

            return node1;
        }

        public static Node _1234555()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node5a = new Node(5);
            Node node5b = new Node(5);

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = node5;
            node5.Next = node5a;
            node5a.Next = node5b;

            return node1;
        }

        public static Node _123()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);

            node1.Next = node2;
            node2.Next = node3;

            return node1;
        }
        public static Node _11122233()
        {
            Node node1 = new Node(1);
            Node node1a = new Node(1);
            Node node1b = new Node(1);

            Node node2 = new Node(2);
            Node node2a = new Node(2);
            Node node2b = new Node(2);

            Node node3 = new Node(3);
            Node node3a = new Node(3);

            node1.Next = node1a;
            node1a.Next = node1b;
            node1b.Next = node2;

            node2.Next = node2a;
            node2a.Next = node2b;
                
            node2b.Next = node3;
            node3.Next = node3a;

            return node1;
        }



    }
}
