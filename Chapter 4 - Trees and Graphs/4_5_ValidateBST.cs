using Chapter_4.DataStructures;
using Chapter_4.TestObjects;
using NUnit.Framework;

namespace Chapter_4
{
    /// <summary>
    /// Validate BST: Implement a function to check if a binary tree is a binary search tree.
    /// </summary>
    public class _4_5_ValidateBST
    {
        public bool Problem_4_5(Node root)
        {
            return IsBinarySearchTree(root, null, null);
        }

        bool IsBinarySearchTree(Node root, int? min, int? max)
        {
            if (root == null)
                return true;

            if (min != null && root.data < min)
            {
                return false;
            }

            if (max != null && root.data >= max)
            {
                return false;
            }

            if (root.left != null && root.data <= root.left.data)
            {
                return false;
            }

            if (root.right != null && root.data >= root.right.data)
            {
                return false;
            }

            return IsBinarySearchTree(root.left, min, root.data) && IsBinarySearchTree(root.right, root.data, max);
        }

    }

    public class _4_5_ValidateBstTests
    {
        readonly _4_5_ValidateBST _practice = new _4_5_ValidateBST();

        [Test]
        public void _4_5_ValidateBST()
        {
            Node root = TestBinarySearchTrees.ValidBinarySearchTree();

            bool result = _practice.Problem_4_5(root);

            Assert.AreEqual(true, result);
        }

    }
}
