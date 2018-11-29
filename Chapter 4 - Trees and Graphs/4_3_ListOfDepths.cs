using Chapter_4.DataStructures;
using Chapter_4.TestObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_4
{
    public class _4_3_ListOfDepths
    {

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
        }

    }

    public class _4_3_ListOfDepthsTests
    {
        readonly _4_3_ListOfDepths _practice = new _4_3_ListOfDepths();

        [Test]
        public void _4_3_ListOfDepths()
        {
            Node root = TestBinarySearchTrees.ValidBinarySearchTree();

            var result = _practice.Problem_4_3(root);

            Assert.NotNull(result);
        }

    }

}
