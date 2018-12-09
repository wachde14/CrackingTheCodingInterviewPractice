using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Permutations with Duplicates: Write a method to compute all permutations of a string whose
    /// characters are not necessarily unique.The list of permutations should not have duplicates.
    /// </summary>
    class _8_8_PermutationsWithDups
    {
        public List<string> Problem_8_8(string str)
        {
            List<string> result = new List<string>();

            Dictionary<char, int> map = buildFreqTable(str);
            GetPerms(map, "", str.Length, result);

            return result;
        }

        void GetPerms(Dictionary<char, int> map, string prefix, int remaining, List<string> result)
        {
            if (remaining == 0)
            {
                result.Add(prefix);
                return;
            }

            foreach (char ch in map.Keys.ToList())
            {
                int count = map[ch];
                if (count > 0)
                {
                    map[ch]--;
                    GetPerms(map, prefix + ch, remaining - 1, result);
                    map[ch] = count;
                }
            }

        }
        Dictionary<char, int> buildFreqTable(string str)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char ch in str)
            {
                if (!map.ContainsKey(ch))
                {
                    map.Add(ch, 0);
                }
                map[ch]++;
            }

            return map;
        }

    }

    [TestFixture]
    class _8_8_PermutationsWithDupsTests
    {
        readonly _8_8_PermutationsWithDups _practice = new _8_8_PermutationsWithDups();

        [TestCase("AAB", 3)]
        [TestCase("AABB", 6)]
        public void _8_8_PermutationsWithDups_TestCases(string input, int expectedTotal)
        {
            List<string> result = _practice.Problem_8_8(input);

            Assert.AreEqual(expectedTotal, result.Count);
        }
    }
}


