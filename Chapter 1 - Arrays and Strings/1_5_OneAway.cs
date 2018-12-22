using NUnit.Framework;

namespace Chapter_1___Arrays_and_Strings
{
    /// <summary>
    /// One Away: There are three types of edits that can be performed on strings: insert a character,
    /// remove a character, or replace a character.Given two strings, write a function to check if they are
    /// one edit (or zero edits) away.
    /// EXAMPLE
    /// pale, ple -> true
    /// pales, pale -> true
    /// pale, bale -> true
    /// pale, bae -> false
    /// </summary>
    class _1_5_OneAway
    {
        public bool IsOneEditAway(string str1, string str2)
        {
            if (str1.Length == str2.Length)
            {
                return IsOneReplacementAway(str1, str2);
            }

            if (str1.Length - 1 == str2.Length)
            {
                return IsOneInsertionAway(str1, str2);
            }

            if (str2.Length - 1 == str1.Length)
            {
                return IsOneInsertionAway(str2, str1);
            }

            return false;
        }

        bool IsOneInsertionAway(string smallerString, string LargerString)
        {
            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < LargerString.Length; i++)
            {
                if (smallerString[index1] != LargerString[index2])
                {
                    if (index1 != index2)
                        return false;

                    index1++;
                }
                else
                {
                    index1++;
                    index2++;
                }
            }

            return true;
        }

        bool IsOneReplacementAway(string str1, string str2)
        {
            bool foundDifference = false;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    if (foundDifference)
                        return false;

                    foundDifference = true;
                }
            }

            return true;
        }
    }

    public class _1_5_OneAwayTests
    {
        readonly _1_5_OneAway _practice = new _1_5_OneAway();

        [TestCase("pale", "ple", true)]
        [TestCase("pales", "pale", true)]
        [TestCase("pale", "bale", true)]
        [TestCase("pale", "bae", false)]
        public void _1_5_OneAway_WithTestCases_ShouldReturnExpected(string input1, string input2, bool expected)
        {
            bool result = _practice.IsOneEditAway(input1, input2);

            Assert.AreEqual(expected, result);
        }
    }
}
