using Chapter_4.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_4
{
    /// <summary>
    /// Build Order: You are given a list of projects and a list of dependencies (which is a list of pairs of
    /// projects, where the second project is dependent on the first project). All of a project's dependencies
    /// must be built before the project is. Find a build order that will allow the projects to be built.If there
    /// is no valid build order, return an error.
    /// </summary>
    public class _4_7_BuildOrder
    {
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

    }


    public class _4_7_BuildOrderTests
    {
        readonly _4_7_BuildOrder _practice = new _4_7_BuildOrder();

        [Test]
        public void _4_7_BuildOrder()
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

    }
}
