using System.Diagnostics;
using Chapter_2___Linked_Lists.DataStructures;

namespace Chapter_2___Linked_Lists.HelperMethods
{
    static class LinkedListUtilityMethods
    {
        public static bool AreLinkedListsEqual(Node list1, Node list2)
        {
            if (GetLinkedListSize(list1) != GetLinkedListSize(list2))
            {
                return false;
            }

            while (list1 != null)
            {
                if (list1.Data != list2.Data)
                {
                    return false;
                }

                list1 = list1.Next;
                list2 = list2.Next;
            }

            return true;
        }

        public static int GetLinkedListSize(Node first)
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

        public static Node CloneList(Node first)
        {
            if (first == null)
                return null;

            Node newHead = new Node(first.Data);
            Node NewPtr = newHead;

            Node OriginalPtr = first.Next;
            while (OriginalPtr != null)
            {
                Node newNode = new Node(OriginalPtr.Data);
                NewPtr.Next = newNode;

                NewPtr = NewPtr.Next;
                OriginalPtr = OriginalPtr.Next;
            }

            return newHead;
        }
    }
}
