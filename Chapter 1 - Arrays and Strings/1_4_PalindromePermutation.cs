using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_1___Arrays_and_Strings
{
    /// <summary>
    /// Palindrome Permutation: Given a string, write a function to check if it is a permutation of
    /// a palindrome.A palindrome is a word or phrase that is the same forwards and backwards.A
    /// permutation is a rearrangement of letters. The palindrome does not need to be limited to just
    /// dictionary words.
    /// EXAMPLE
    /// Input: Tact Coa
    /// Output: True (permutations: "taco cat'; "atc o eta·; etc.)
    /// </summary>
    class _1_4_PalindromePermutation
    {
        public bool IsPalindromeOfPermutation(string str)
        {
            if (str == null)
                return true;

            str = str.Trim().Replace(" ", "").ToLower();

            Dictionary<char, int> charCountDict = new Dictionary<char, int>();
            foreach (char ch in str)
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

            int oddCount = 0;
            foreach (int charFrequency in charCountDict.Values)
            {
                if (charFrequency % 2 != 0)
                {
                    oddCount++;
                    if (oddCount > 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public class _1_4_PalindromePermutationTests
    {
        readonly _1_4_PalindromePermutation _practice = new _1_4_PalindromePermutation();

        [TestCase("Tact Coa", true)]
        [TestCase("carrace", true)]
        [TestCase("abc", false)]
        [TestCase("", true)]
        public void _1_3_URLify_WithTestCases_ShouldReturnExpected(string input, bool expected)
        {
            bool result = _practice.IsPalindromeOfPermutation(input);

            Assert.AreEqual(expected, result);
        }
    }
}
