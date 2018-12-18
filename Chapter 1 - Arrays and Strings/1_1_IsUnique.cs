using System.Collections.Generic;
using NUnit.Framework;

namespace Chapter_1___Arrays_and_Strings
{
    /// <summary>
    /// Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
    /// cannot use additional data structures?
    /// </summary>
    class _1_1_IsUnique
    {
        public bool IsUniqueCharsWithDataStructures(string str)
        {
            HashSet<char> charSet = new HashSet<char>();

            foreach (char ch in str)
            {
                if (!charSet.Contains(ch))
                {
                    charSet.Add(ch);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
        public bool IsUniqueCharsWithoutDataStructures(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                string substring = str.Substring(i + 1);
                char currChar = str[i];

                for (int k = 0; k < substring.Length; k++)
                {
                    if (substring[k] == currChar)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
    public class _1_1_IsUniqueTests
    {
        readonly _1_1_IsUnique _practice = new _1_1_IsUnique();

        [TestCase("abc", true)]
        [TestCase("abca", false)]
        [TestCase("", true)]
        public void _1_1_IsUniqueCharsWithDataStructures_WithTestCases_ShouldReturnExpected(string input, bool expected)
        {
            bool result = _practice.IsUniqueCharsWithDataStructures(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase("abc", true)]
        [TestCase("abca", false)]
        [TestCase("", true)]
        public void _1_1_IsUniqueCharsWithoutDataStructures_WithTestCases_ShouldReturnExpected(string input, bool expected)
        {
            bool result = _practice.IsUniqueCharsWithoutDataStructures(input);

            Assert.AreEqual(expected, result);
        }
    }
}
