using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    class _8_7_PermutationsWithoutDups
    {
        public List<string> Problem_8_7(string str)
        {
            List<string> result = new List<string>();
            GetPerms("", str, result);
            return result;
        }

        public void GetPerms(string prefix, string remainder, List<string> result)
        {
            if (remainder.Length == 0)
                result.Add(prefix);

            int remainderLength = remainder.Length;
            for (int i = 0; i < remainderLength; i++)
            {
                string before = remainder.Substring(0, i);
                string after = remainder.Substring(i + 1);
                char c = remainder[i];
                GetPerms(prefix + c, before + after, result);
            }
        }

        public List<string> GetPermutation(string unique)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(unique))
            {
                result.Add("");
                return result;
            }

            for (int i = 0; i < unique.Length; i++)
            {
                string left = unique.Substring(0, i);
                string right = unique.Substring(i + 1, unique.Length - i - 1);

                List<string> partialPermutation = GetPermutation(left + right);
                string charBetweenLeftAndRight = unique[i].ToString();
                foreach (string perm in partialPermutation)
                {
                    result.Add(charBetweenLeftAndRight + perm);
                }
            }

            return result;
        }


    }

    [TestFixture]
    class _8_7_PermutationsWithoutDupsTests
    {
        readonly _8_7_PermutationsWithoutDups _practice = new _8_7_PermutationsWithoutDups();

        [TestCase("AB", 2)]
        [TestCase("ABC", 6)]
        [TestCase("ABCD", 24)]
        [TestCase("ABCDE", 120)]
        public void _8_7_PermutationsWithoutDups_Tests(string input, int expectedTotal)
        {
            List<string> result = _practice.GetPermutation(input);

            Assert.AreEqual(expectedTotal, result.Count);
        }

    }

}
