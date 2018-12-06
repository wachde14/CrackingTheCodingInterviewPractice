using System;

namespace Chapter_2___Linked_Lists.DataStructures
{
    public static class LinkedList
    {
        public static int Length(Node first)
        {
            if (first == null)
                return 0;

            int count = 0;
            Node node = first;
            while (node != null)
            {
                count++;
                node = node.Next;
            }

            return count;
        }

        public static Node PadZerosOnHead(Node first, int numberOfZeros)
        {
            Node node = first;
            for (int i = 1; i <= numberOfZeros; i++)
            {
                node = AddToHead(node, 0);
            }
            return node;
        }
        public static Node CreateLinkedList(int[] numbers)
        {
            Node first = new Node(numbers[0], null);
            for (int i = 1; i < numbers.Length; i++)
            {
                Node node = first;
                for (int j = i - 1; j > 0; j--)
                {
                    node = node.Next;
                }
                Node newNode = new Node(numbers[i], null);
                node.Next = newNode;
            }

            return first;
        }
        public static Node RemoveNode(Node first, int data)
        {
            Node node = first;

            if (node.Data == data)
            {
                return node.Next;
            }
            while (node.Next != null)
            {
                if (node.Next.Data == data)
                {
                    node.Next = node.Next.Next;
                    return first;
                }
                node = node.Next;
            }
            return first;
        }

        public static Node AddToTail(Node first, int data)
        {
            if (first == null)
            {
                return new Node(data, null);
            }
            Node node = first;
            while (node.Next != null)
            {
                node = node.Next;
            }
            Node newNode = new Node(data, null);
            node.Next = newNode;
            return first;
        }

        public static Node AddToHead(Node first, int data)
        {
            if (first == null)
            {
                return new Node(data, null);
            }
            Node newNode = new Node(data, null);
            newNode.Next = first;
            return newNode;
        }

        public static void DisplayLinkedList(Node first)
        {
            Node node = first;
            String a = first.Data.ToString() + " => ";
            while (node.Next != null)
            {
                node = node.Next;
                a += node.Data.ToString() + " => ";
            }

            a = a.Remove(a.Length - 4, 4);

            Console.WriteLine(a);
        }
    }
}
