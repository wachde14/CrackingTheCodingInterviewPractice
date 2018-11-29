using Chapter_4.DataStructures;
using Chapter_4.TestObjects;
using NUnit.Framework;

namespace Chapter_4
{
    /// <summary>
    /// Paths with Sum: You are given a binary tree in which each node contains an integer value (which
    /// might be positive or negative). Design an algorithm to count the number of paths that sum to a
    /// given value.The path does not need to start or end at the root or a leaf, but it must go downwards
    /// (traveling only from parent nodes to child nodes).
    /// </summary>
    public class _4_12_PathsWithSums
    {
        public int Problem_4_12(Node root, int targetSum)
        {
            int totalPaths = CountPathsWithSum(root, targetSum);

            return totalPaths;
        }

        int CountPathsWithSum(Node root, int targetSum)
        {
            if (root == null)
                return 0;

            int pathsFromRoot = CountPathsWithSumFromNode(root, targetSum, 0);
            int pathsFromLeft = CountPathsWithSum(root.left, targetSum);
            int pathsFromRight = CountPathsWithSum(root.right, targetSum);

            return pathsFromRoot + pathsFromLeft + pathsFromRight;
        }

        int CountPathsWithSumFromNode(Node node, int targetSum, int currentSum)
        {
            if (node == null)
                return 0;

            currentSum += node.data;

            int totalPaths = 0;
            if (currentSum == targetSum)
            {
                totalPaths++;
            }

            totalPaths += CountPathsWithSumFromNode(node.left, targetSum, currentSum);
            totalPaths += CountPathsWithSumFromNode(node.right, targetSum, currentSum);
            return totalPaths;
        }

    }

    public class _4_12_PathsWithSumsTests
    {
        readonly _4_12_PathsWithSums _practice = new _4_12_PathsWithSums();

        [Test]
        public void _4_12_PathsWithSum()
        {
            Node root = TestBinarySearchTrees.WithNegativeEdgeValues();

            int result = _practice.Problem_4_12(root, 4);

            Assert.AreEqual(4, result);
        }
    }
}
