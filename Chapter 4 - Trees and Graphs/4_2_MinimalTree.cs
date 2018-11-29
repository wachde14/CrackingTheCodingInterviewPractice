using Chapter_4.DataStructures;
using NUnit.Framework;

namespace Chapter_4
{
    /// <summary>
    /// Minimal Tree: Given a sorted (increasing order) array with unique integer elements, write an
    /// algorithm to create a binary search tree with minimal height.
    /// </summary>
    public class _4_2_MinimalTree
    {
        public Node Problem_4_2(int[] bstArray)
        {
            int length = bstArray.Length;

            Node root = CreateBinarySearchTree(bstArray, 0, length - 1);

            return root;
        }

        Node CreateBinarySearchTree(int[] bstArray, int start, int end)
        {
            if (start == end)
            {
                return new Node(bstArray[start]);
            }

            int mid = (start + end + 1) / 2;

            Node root = new Node(bstArray[mid]);

            if (start > mid - 1)
                root.left = null;
            else
                root.left = CreateBinarySearchTree(bstArray, start, mid - 1);

            if (mid + 1 > end)
                root.right = null;
            else
                root.right = CreateBinarySearchTree(bstArray, mid + 1, end);

            return root;
        }
    }

    public class _4_2_MinimalTreeTests
    {
        readonly _4_2_MinimalTree _practice = new _4_2_MinimalTree();

        [Test]
        public void _4_2_MinimalTree()
        {
            int[] minimalTreeArray = new int[] { 1, 2, 3, 5, 6, 7, 9, 64, 555 };

            Node root = _practice.Problem_4_2(minimalTreeArray);

            Assert.NotNull(root);
        }

    }

}
