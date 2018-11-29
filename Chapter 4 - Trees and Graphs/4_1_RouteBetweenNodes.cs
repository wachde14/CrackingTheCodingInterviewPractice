using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_4
{
    /// <summary>
    /// Route Between Nodes: Given a directed graph, design an algorithm to find out whether there is a
    /// route between two nodes.
    /// </summary>
    public class _4_1_RouteBetweenNodes
    {
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

    }

    public class _4_1_RouteBetweenNodesTests
    {
        readonly _4_1_RouteBetweenNodes _practice = new _4_1_RouteBetweenNodes();

        [Test]
        public void _4_1_RouteBetweenNodes()
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
