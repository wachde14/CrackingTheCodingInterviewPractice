using FluentAssertions;
using NUnit.Framework;

namespace Chapter_1___Arrays_and_Strings
{
    /// <summary>
    /// URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
    /// has sufficient space at the end to hold the additional characters, and that you are given the "true"
    /// length of the string. (Note: if implementing in Java, please use a character array so that you can
    /// perform this operation in place.)
    /// EXAMPLE
    /// Input: "Mr John Smith ", 13
    /// Output: "Mr%20John%20Smith"
    /// </summary>
    class _1_3_URLify
    {
        //C# easy solution to bypass the manual string manipulation required in C++
        public string URLify(string str)
        {
            str = str.Trim();

            return str.Replace(" ", "%20");
        }
    }

    public class _1_3_URLifyTests
    {
        readonly _1_3_URLify _practice = new _1_3_URLify();

        [TestCase("Mr John Smith ", "Mr%20John%20Smith")]
        public void _1_3_URLify_WithTestCases_ShouldReturnExpected(string input, string expected)
        {
            string result = _practice.URLify(input);

            expected.Should().BeEquivalentTo(result);
        }
    }
}
