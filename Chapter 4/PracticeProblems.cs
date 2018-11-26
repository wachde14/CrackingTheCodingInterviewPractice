using Chapter_4.DataStructures;
using Chapter_4.HelperMethods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_4
{
    public class PracticeProblems
    {
        #region 4.12
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
        #endregion

        #region 4.11
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
        #endregion

        #region 4.10
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
        #endregion

        #region 4.9
        //public NodeWithParent Problem_4_9(NodeWithParent node1, NodeWithParent node2)
        //{
        //    //return FirstCommonAncestorWithParents(node1, node2);
        //}

        #endregion

        #region 4.8
        public NodeWithParent Problem_4_8(NodeWithParent node1, NodeWithParent node2)
        {
            return FirstCommonAncestorWithParents(node1, node2);
        }

        NodeWithParent FirstCommonAncestorWithParents(NodeWithParent node1, NodeWithParent node2)
        {
            int depth1 = GetDepth(node1);
            int depth2 = GetDepth(node2);

            int difference = Math.Abs(depth1 - depth2);

            if (depth1 < depth2)
            {
                for (int i = 0; i < difference; i++)
                {
                    node2 = node2.parent;
                }
            }

            if (depth2 < depth1)
            {
                for (int i = 0; i < difference; i++)
                {
                    node1 = node1.parent;
                }
            }

            while (node1.parent != null && node2.parent != null && node1 != node2)
            {
                node1 = node1.parent;
                node2 = node2.parent;
            }

            if (node1 == node2)
            {
                return node1;
            }

            return null;
        }

        int GetDepth(NodeWithParent node)
        {
            NodeWithParent runnerNode = new NodeWithParent(0);
            runnerNode = node;

            int count = 0;
            while (runnerNode != null)
            {
                count++;
                runnerNode = runnerNode.parent;
            }

            return count;
        }
        #endregion

        #region 4.7
        public List<string> Problem_4_7(char[][] dependencies, char[] projects)
        {
            return BuildOrder(dependencies, projects);
        }

        List<string> BuildOrder(char[][] dependencies, char[] projects)
        {
            List<string> buildOrder = new List<string>();

            NamedDirectedNodeManager nodeManager = CreateGraph(dependencies, projects);

            List<NamedDirectedNode> processedNodes = new List<NamedDirectedNode>();


            bool keepProcessing = true;
            while (keepProcessing)
            {
                keepProcessing = false;

                foreach (NamedDirectedNode currNode in nodeManager.nodes)
                {
                    if (!nodeManager.DoesNodeHaveIncoming(currNode))
                    {
                        if (!processedNodes.Contains(currNode))
                        {
                            buildOrder.Add(currNode.name);
                            processedNodes.Add(currNode);
                            keepProcessing = true;
                        }
                    }
                }

                foreach (NamedDirectedNode currNode in processedNodes)
                {
                    currNode.children.Clear();
                }

                if (!keepProcessing)
                {
                    if (processedNodes.Count == projects.Length)
                    {
                        return buildOrder;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }

        NamedDirectedNodeManager CreateGraph(char[][] dependencies, char[] projects)
        {
            List<NamedDirectedNode> nodeList = new List<NamedDirectedNode>();
            foreach (char projectName in projects)
            {
                NamedDirectedNode newNode = new NamedDirectedNode(projectName.ToString());
                nodeList.Add(newNode);
            }

            NamedDirectedNodeManager nodeManager = new NamedDirectedNodeManager();
            nodeManager.nodes = nodeList;

            foreach (char[] dependency in dependencies)
            {
                NamedDirectedNode parent = nodeManager.GetNodeByName(dependency[0].ToString());
                NamedDirectedNode child = nodeManager.GetNodeByName(dependency[1].ToString());

                parent.children.Add(child);
            }

            return nodeManager;
        }
        #endregion

        #region 4.6
        public NodeWithParent Problem_4_6(NodeWithParent treeNode)
        {
            return InorderSuccessor(treeNode);
        }

        NodeWithParent InorderSuccessor(NodeWithParent treeNode)
        {
            if (treeNode.right != null)
            {
                NodeWithParent n;
                n = treeNode.right;

                while (n.left != null)
                {
                    n = n.left;
                }

                return n;
            }

            NodeWithParent m = treeNode.parent;
            while (m != null && treeNode.data > m.data)
            {
                m = m.parent;
            }

            return m;
        }
        #endregion

        #region 4.5
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
        #endregion

        #region 4.4
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
        #endregion

        #region 4.3
        public List<List<int>> Problem_4_3(Node root)
        {
            List<List<int>> depthList = new List<List<int>>();

            CreateDepthList(root, 0, depthList);

            return depthList;
        }

        void CreateDepthList(Node root, int depth, List<List<int>> depthList)
        {
            if (root == null) return;

            if (depthList.ElementAtOrDefault(depth) == null)
            {
                depthList.Add(new List<int>() { root.data });
            }
            else
            {
                depthList[depth].Add(root.data);
            }

            CreateDepthList(root.left, depth + 1, depthList);
            CreateDepthList(root.right, depth + 1, depthList);

            return;
        }
        #endregion

        #region 4.2
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


        #endregion

        #region 4.1
        public bool Problem_4_1(int[,] graph, int source, int dest)
        {
            int[] visited = BFS(graph, source);

            if (visited[dest] == 1)
                return true;

            return false;
        }

        int[] BFS(int[,] graph, int source)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);

            int numberofNodes = graph.GetLength(0);
            int[] visited = new int[numberofNodes];
            visited[source] = 1;

            while (queue.Count != 0)
            {
                int currRow = queue.Dequeue();

                for (int currColumn = 0; currColumn < numberofNodes; currColumn++)
                {
                    if (graph[currRow, currColumn] == 1)
                    {
                        if (visited[currColumn] != 1)
                        {
                            visited[currColumn] = 1;
                            queue.Enqueue(currColumn);
                        }
                    }
                }
            }

            return visited;
        }
        #endregion
    }
}
