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
        public void _1_3_URLify_WithTestCases_ShouldReturnExpected(string input1, string input2, bool expected)
        {
            bool result = _practice.IsOneEditAway(input1, input2);

            Assert.AreEqual(expected, result);
        }
    }

}
