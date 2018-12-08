using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Power Set: Write a method to return all subsets of a set.
    /// </summary>
    public class _8_4_PowerSet
    {
        public List<List<int>> Problem_8_4(List<int> set, int index)
        {
            if (set == null || set.Count == 0)
                return null;

            return CreatePowerSet(set, index);
        }

        public List<List<int>> CreatePowerSet(List<int> set, int index)
        {
            List<List<int>> allSubSets;
            if (set.Count == index)
            {
                allSubSets = new List<List<int>>();
                allSubSets.Add(new List<int>());
            }
            else
            {
                allSubSets = CreatePowerSet(set, (index + 1));
                int item = set[index];
                
                List<List<int>> moreSubSets = new List<List<int>>();
                foreach (var subset in allSubSets)
                {
                    List<int> newSubSet = new List<int>();
                    newSubSet.AddRange(subset);
                    newSubSet.Add(item);
                    moreSubSets.Add(newSubSet);
                }
                allSubSets.AddRange(moreSubSets);
            }

            return allSubSets;
        }

    }

    [TestFixture]
    class _8_4_PowerSetTests
    {
        readonly _8_4_PowerSet _practice = new _8_4_PowerSet();

        [Test]
        public void _8_4_PowerSet_Test1()
        {
            List<int> set = new List<int>() {1, 2};

            List<List<int>> result = _practice.Problem_8_4(set, 0);

            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void _8_4_PowerSet_Test2()
        {
            List<int> set = new List<int>() { 1, 2, 3 };

            List<List<int>> result = _practice.Problem_8_4(set, 0);

            Assert.AreEqual(8, result.Count);
        }

        [Test]
        public void _8_4_PowerSet_Test3()
        {
            List<int> set = new List<int>() { 1 };

            List<List<int>> result = _practice.Problem_8_4(set, 0);

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void _8_4_PowerSet_Test4()
        {
            List<int> set = new List<int>() { };

            List<List<int>> result = _practice.Problem_8_4(set, 0);

            Assert.AreEqual(null, result);
        }

        [Test]
        public void _8_4_PowerSet_Test5()
        {
            List<int> set = null;

            List<List<int>> result = _practice.Problem_8_4(set, 0);

            Assert.AreEqual(null, result);
        }
    }
}

