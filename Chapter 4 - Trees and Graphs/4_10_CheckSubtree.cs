using Chapter_4.DataStructures;
using Chapter_4.HelperMethods;
using Chapter_4.TestObjects;
using NUnit.Framework;

namespace Chapter_4
{
    /// <summary>
    /// Check Subtree: Tl and T2 are two very large binary trees, with Tl much bigger than T2. Create an
    /// algorithm to determine ifT2 is a subtree of Tl.
    /// A tree T2 is a subtree of Tl if there exists a node n in Tl such that the subtree of n is identical to T2.
    /// That is, if you cut off the tree at node n, the two trees would be identical.
    /// </summary>
    public class _4_10_CheckSubtree
    {
        public bool Problem_4_10(Node bigTree, Node smallTree)
        {
            //return isSubTreeUsingStringComparison(bigTree, smallTree);

            return isSubTreeUsingTraversalComparison(bigTree, smallTree);
        }

        bool isSubTreeUsingTraversalComparison(Node bigTree, Node smallTree)
        {
            if (smallTree == null)
                return true;

            return isSubTree(bigTree, smallTree);
        }

        bool isSubTree(Node bigTree, Node smallTree)
        {
            if (bigTree == null)
            {
                return false;
            }

            if (bigTree.data == smallTree.data && isMatchingTree(bigTree, smallTree))
                return true;

            return isSubTree(bigTree.left, smallTree) || isSubTree(bigTree.right, smallTree);
        }

        bool isMatchingTree(Node bigTree, Node smallTree)
        {
            if (bigTree == null && smallTree == null)
            {
                return true;
            }

            if (bigTree == null || smallTree == null)
            {
                return false;
            }

            if (bigTree.data != smallTree.data)
            {
                return false;
            }

            return isMatchingTree(bigTree.right, smallTree.right) && isMatchingTree(bigTree.left, smallTree.left);
        }


        bool isSubTreeUsingStringComparison(Node bigTree, Node smallTree)
        {
            string bigTreePreOrderString = string.Empty;
            bigTreePreOrderString = Traversals.PreOrderWithNulls(bigTree, bigTreePreOrderString);

            string bigTreeInOrderString = string.Empty;
            bigTreeInOrderString = Traversals.InOrderWithNulls(bigTree, bigTreeInOrderString);

            string smallTreePreOrderString = string.Empty;
            smallTreePreOrderString = Traversals.PreOrderWithNulls(smallTree, smallTreePreOrderString);

            string smallTreeInOrderString = string.Empty;
            smallTreeInOrderString = Traversals.InOrderWithNulls(smallTree, smallTreeInOrderString);

            return bigTreeInOrderString.Contains(smallTreeInOrderString) &&
                   bigTreePreOrderString.Contains(smallTreePreOrderString);
        }
    }

    public class _4_10_CheckSubtreeTests
    {
        readonly _4_10_CheckSubtree _practice = new _4_10_CheckSubtree();

        [Test]
        public void _4_10_CheckSubtree()
        {
            Node bigTree = TestBinarySearchTrees.ValidBinarySearchTree();
            Node smallTree = TestBinarySearchTrees.SubtreeOfValidBinarySearchTree();

            bool result = _practice.Problem_4_10(bigTree, smallTree);

            Assert.AreEqual(true, result);
        }

    }
}
