using Chapter_4.DataStructures;
using Chapter_4.HelperMethods;
using Chapter_4.TestObjects;
using NUnit.Framework;
using System;

namespace Chapter_4
{
    public class _4_11_RandomNode
    {
        public char Problem_4_11(Node root)
        {
            return GetRandomNode(root);
        }

        char GetRandomNode(Node root)
        {
            string traversalString = string.Empty;
            traversalString = Traversals.InOrder(root, traversalString);

            Random rnd = new Random();
            int randomNumber = rnd.Next(0, traversalString.Length);

            return traversalString[randomNumber];
        }

    }

    public class _4_11_RandomNodeTests
    {
        readonly _4_11_RandomNode _practice = new _4_11_RandomNode();

        [Test]
        public void _4_11_RandomNode()
        {
            Node root = TestBinarySearchTrees.ValidBinarySearchTree();

            char result = _practice.Problem_4_11(root);
            double convertedResult = char.GetNumericValue(result);

            Assert.That(convertedResult > 0 && convertedResult < 8);
        }
    }

}
