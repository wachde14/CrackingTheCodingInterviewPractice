using Chapter_4.DataStructures;

namespace Chapter_4.HelperMethods
{
    public static class Traversals
    {
        public static string InOrderWithNulls(Node root, string answer)
        {
            if (root == null) return answer + "0";

            answer = InOrderWithNulls(root.left, answer);
            answer += (root.data);
            answer = InOrderWithNulls(root.right, answer);

            return answer;
        }
        public static string InOrder(Node root, string answer)
        {
            if (root == null) return answer;

            answer = InOrder(root.left, answer);
            answer += (root.data);
            answer = InOrder(root.right, answer);

            return answer;
        }

        public static string PreOrder(Node root, string answer)
        {
            if (root == null) return answer;

            answer += (root.data);
            answer = PreOrder(root.left, answer);
            answer = PreOrder(root.right, answer);

            return answer;
        }

        public static string PreOrderWithNulls(Node root, string answer)
        {
            if (root == null) return answer + "0";

            answer = PreOrderWithNulls(root.left, answer);
            answer = PreOrderWithNulls(root.right, answer);
            answer += (root.data);

            return answer;
        }

        public static string PostOrder(Node root, string answer)
        {
            if (root == null) return answer;

            answer += (root.data);
            answer = PreOrder(root.left, answer);
            answer = PreOrder(root.right, answer);

            return answer;
        }

        public static string PostOrderWithNulls(Node root, string answer)
        {
            if (root == null) return answer + "0";

            answer = PreOrderWithNulls(root.left, answer);
            answer = PreOrderWithNulls(root.right, answer);
            answer += (root.data);

            return answer;
        }

    }
}
