using System.Collections.Generic;
using NUnit.Framework;

namespace Chapter_1___Arrays_and_Strings
{
    /// <summary>
    /// Check Permutation: Given two strings, write a method to decide if one is a permutation of the
    /// other.
    /// </summary>
    class _1_2_CheckPermutation
    {
        public bool IsPermutation(string str1, string str2)
        {
            Dictionary<char, int> charCountDict = new Dictionary<char, int>();

            foreach (char ch in str1)
            {
                if (!charCountDict.ContainsKey(ch))
                {
                    charCountDict.Add(ch, 1);
                }
                else
                {
                    charCountDict[ch]++;
                }
            }

            foreach (char ch in str2)
            {
                if (!charCountDict.ContainsKey(ch))
                {
                    return false;
                }

                charCountDict[ch]--;
                if (charCountDict[ch] < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class _1_2_CheckPermutationTests
    {
        readonly _1_2_CheckPermutation _practice = new _1_2_CheckPermutation();

        [TestCase("abc", "cba", true)]
        [TestCase("abc", "ssss", false)]
        [TestCase("abcd", "efgh", false)]
        public void _1_2_CheckPermutation_WithTestCases_ShouldReturnExpected(string input1, string input2, bool expected)
        {
            bool result = _practice.IsPermutation(input1, input2);

            Assert.AreEqual(expected, result);
        }
    }
}
