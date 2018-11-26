using Chapter_4.DataStructures;
using Chapter_4.TestObjects;
using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_4
{
    [TestFixture]
    public class PracticeProblemsTests
    {
        readonly PracticeProblems _practice = new PracticeProblems();

        [Test]
        public void Question_4_12()
        {
            Node root = TestBinarySearchTrees.WithNegativeEdgeValues();

            int result = _practice.Problem_4_12(root, 4);

            Assert.AreEqual(4, result);
        }

        [Test]
        public void Question_4_11()
        {
            Node root = TestBinarySearchTrees.ValidBinarySearchTree();

            char result = _practice.Problem_4_11(root);
            double convertedResult = char.GetNumericValue(result);

            Assert.That(convertedResult > 0 && convertedResult < 8);
        }

        [Test]
        public void Question_4_10()
        {
            Node bigTree = TestBinarySearchTrees.ValidBinarySearchTree();
            Node smallTree = TestBinarySearchTrees.SubtreeOfValidBinarySearchTree();

            bool result = _practice.Problem_4_10(bigTree, smallTree);

            Assert.AreEqual(true, result);
        }


        [Test]
        public void Question_4_9()
        {

        }

        [Test]
        public void Question_4_8()
        {
            //Arrange
            NodeWithParent node1 = new NodeWithParent(1);
            NodeWithParent node2 = new NodeWithParent(2);
            NodeWithParent node3 = new NodeWithParent(3);
            NodeWithParent node4 = new NodeWithParent(4);
            NodeWithParent node5 = new NodeWithParent(5);
            NodeWithParent node6 = new NodeWithParent(6);
            NodeWithParent node7 = new NodeWithParent(7);
            NodeWithParent node8 = new NodeWithParent(8);
            NodeWithParent node9 = new NodeWithParent(9);
            NodeWithParent node10 = new NodeWithParent(10);

            node1.left = node2;
            node1.right = node3;

            node2.parent = node1;
            node2.left = node4;

            node3.parent = node1;
            node3.left = node5; node3.right = node6;

            node4.parent = node2;
            node4.right = node7;

            node5.parent = node3;

            node6.parent = node3;
            node6.left = node8; node6.right = node9;

            node7.parent = node4;

            node8.parent = node6;
            node8.right = node10;

            node9.parent = node6;

            node10.parent = node8;

            //Act
            NodeWithParent result = _practice.Problem_4_8(node8, node9);

            //Assert
            Assert.AreSame(node6, result);
        }


        [Test]
        public void Question_4_7()
        {
            //Arrange
            char[] projects = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };

            char[][] dependencies = new char[][]
            {
                new char[]{'d', 'g'},
                new char[]{'f', 'c'},
                new char[]{'f', 'b'},
                new char[]{'c', 'a'},
                new char[]{'b', 'a'},
                new char[]{'f', 'a'},
                new char[]{'a', 'e'},
                new char[]{'b', 'e'},
            };

            List<string> expected = new List<string>() { "d", "f", "b", "c", "g", "a", "e" };

            //Act
            List<string> result = _practice.Problem_4_7(dependencies, projects);

            //Assert 
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void Question_4_6()
        {
            //Arrange
            NodeWithParent node1 = new NodeWithParent(1);
            NodeWithParent node2 = new NodeWithParent(2);
            NodeWithParent node3 = new NodeWithParent(3);
            NodeWithParent node4 = new NodeWithParent(4);
            NodeWithParent node5 = new NodeWithParent(5);
            NodeWithParent node6 = new NodeWithParent(6);
            NodeWithParent node7 = new NodeWithParent(7);
            NodeWithParent node8 = new NodeWithParent(8);
            NodeWithParent node9 = new NodeWithParent(9);
            NodeWithParent node10 = new NodeWithParent(10);
            NodeWithParent node11 = new NodeWithParent(11);
            node1.parent = node2;

            node2.left = node1;
            node2.right = node3;
            node2.parent = node4;

            node3.parent = node2;

            node4.left = node2;
            node4.right = node5;
            node4.parent = node6;

            node5.parent = node4;

            node6.left = node4;
            node6.right = node8;

            node7.parent = node8;

            node8.left = node7;
            node8.right = node10;
            node8.parent = node6;

            node9.parent = node10;

            node10.left = node9;
            node10.right = node11;
            node10.parent = node8;

            node11.parent = node10;

            //Act
            var result1 = _practice.Problem_4_6(node1);
            var result2 = _practice.Problem_4_6(node2);
            var result3 = _practice.Problem_4_6(node3);
            var result4 = _practice.Problem_4_6(node4);
            var result5 = _practice.Problem_4_6(node5);
            var result6 = _practice.Problem_4_6(node6);
            var result7 = _practice.Problem_4_6(node7);
            var result8 = _practice.Problem_4_6(node8);
            var result9 = _practice.Problem_4_6(node9);
            var result10 = _practice.Problem_4_6(node10);
            var result11 = _practice.Problem_4_6(node11);

            //Assert
            Assert.AreEqual(node2, result1);
            Assert.AreEqual(node3, result2);
            Assert.AreEqual(node4, result3);
            Assert.AreEqual(node5, result4);
            Assert.AreEqual(node6, result5);
            Assert.AreEqual(node7, result6);
            Assert.AreEqual(node8, result7);
            Assert.AreEqual(node9, result8);
            Assert.AreEqual(node10, result9);
            Assert.AreEqual(node11, result10);
            Assert.AreEqual(null, result11);

        }


        [Test]
        public void Question_4_5()
        {
            Node root = TestBinarySearchTrees.ValidBinarySearchTree();

            bool result = _practice.Problem_4_5(root);

            Assert.AreEqual(true, result);
        }


        [Test]
        public void Question_4_4()
        {
            Node root = TestBinarySearchTrees.UnbalancedBinarySearchTree2();

            bool result = _practice.Problem_4_4(root);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void Question_4_3()
        {
            Node root = TestBinarySearchTrees.ValidBinarySearchTree();

            var result = _practice.Problem_4_3(root);

            Assert.NotNull(result);
        }

        [Test]
        public void Question_4_2()
        {
            int[] minimalTreeArray = new int[] { 1, 2, 3, 5, 6, 7, 9, 64, 555 };

            Node root = _practice.Problem_4_2(minimalTreeArray);

            Assert.NotNull(root);
        }


        [Test]
        public void Question_4_1()
        {
            int[,] graph = new int[,]{{0,1,0,0,1,1},
                {0,0,0,1,1,0},
                {0,1,0,0,0,0},
                {0,0,1,0,1,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,0}};

            bool result = _practice.Problem_4_1(graph, 1, 3);

            Assert.AreEqual(true, result);

        }
    }
}
