using Chapter_4.DataStructures;

namespace Chapter_4.TestObjects
{
    public static class TestBinarySearchTrees
    {

        public static Node WithNegativeEdgeValues()
        {
            Node root = new Node(2);
            Node node2b = new Node(2);
            Node node3 = new Node(3);
            Node node0 = new Node(0);
            Node node1 = new Node(1);
            Node nodeNeg1a = new Node(-1);
            Node nodeNeg1b = new Node(-1);

            root.left = node2b;
            root.right = node3;

            node2b.left = node0;
            node2b.right = node1;

            node3.left = nodeNeg1a;
            node3.right = nodeNeg1b;

            return root;
        }

        public static Node InvalidBinarySearchTree()
        {
            Node node5 = new Node(5);
            Node node10 = new Node(10);
            Node node20 = new Node(20);
            Node node25 = new Node(25);
            Node node30 = new Node(30);

            Node root = new Node(20);
            root.left = node10;
            root.right = node30;

            node10.left = node5;
            node10.right = node25;

            return root;
        }

        public static Node UnbalancedBinarySearchTree()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            Node node7 = new Node(7);

            Node root = new Node(1);
            root.left = node2;
            root.right = node3;

            node3.left = node7;
            node3.right = node6;

            node2.left = node4;

            node4.left = node5;

            return root;
        }

        public static Node UnbalancedBinarySearchTree2()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            Node node7 = new Node(7);

            Node root = new Node(1);
            root.left = node2;
            root.right = node3;

            node3.left = node7;
            node3.right = node6;

            node2.left = node4;

            node4.left = node5;

            return root;
        }

        public static Node ValidBinarySearchTree()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);
            Node node7 = new Node(7);

            Node root = new Node(4);
            root.left = node2;
            root.right = node6;

            node2.left = node1;
            node2.right = node3;

            node6.right = node7;
            node6.left = node5;


            return root;
        }

        public static Node SubtreeOfValidBinarySearchTree()
        {
            Node node1 = new Node(1);
            Node node2 = new Node(2);
            Node node3 = new Node(3);

            node2.left = node1;
            node2.right = node3;

            return node2;
        }


    }
}
