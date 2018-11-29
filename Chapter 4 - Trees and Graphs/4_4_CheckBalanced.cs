using Chapter_4.DataStructures;
using Chapter_4.TestObjects;
using NUnit.Framework;
using System;

namespace Chapter_4
{
    /// <summary>
    /// Check Balanced: Implement a function to check if a binary tree is balanced. For the purposes of
    /// this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any
    /// node never differ by more than one.
    /// </summary>
    class _4_4_CheckBalanced
    {
        public bool Problem_4_4(Node root)
        {
            return CheckBalanced(root);
        }

        int GetDepth(Node root)
        {
            if (root == null)
                return 0;

            return (Math.Max(GetDepth(root.left), GetDepth(root.right)) + 1);
        }


        bool CheckBalanced(Node root)
        {
            if (root == null)
                return true;

            int leftDepth = GetDepth(root.left);
            int rightDepth = GetDepth(root.right);
            int difference = leftDepth - rightDepth;

            if (Math.Abs(difference) > 1)
                return false;

            bool leftCheck = CheckBalanced(root.left);
            bool rightCheck = CheckBalanced(root.right);

            return (leftCheck && rightCheck);
        }

    }

    public class _4_4_ListOfDepthsTests
    {
        readonly _4_4_CheckBalanced _practice = new _4_4_CheckBalanced();

        [Test]
        public void _4_4_ListOfDepths()
        {
            Node root = TestBinarySearchTrees.UnbalancedBinarySearchTree2();

            bool result = _practice.Problem_4_4(root);

            Assert.AreEqual(false, result);
        }

    }

}
