using NUnit.Framework;
using System.Text;

namespace Chapter_1___Arrays_and_Strings
{
    /// <summary>
    /// String Compression: Implement a method to perform basic string compression using the counts
    /// of repeated characters.For example, the string aabcccccaaa would become a2blc5a3.If the
    /// "compressed" string would not become smaller than the original string, your method should return
    /// the original string. You can assume the string has only uppercase and lowercase letters(a - z).
    /// </summary>
    class _1_6_StringCompression
    {
        public string GetCompressedString(string input)
        {
            StringBuilder compressedString = new StringBuilder();

            for(int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                int consecutiveCount = 1;
                while (i + 1 < input.Length && input[i] == input[i + 1])
                {
                    consecutiveCount++;
                    i++;
                }

                compressedString.Append(currChar);
                compressedString.Append(consecutiveCount);
            }

            string result = compressedString.ToString();
            if (result.Length > input.Length)
                return input;

            return result;
        }
    }

    public class _1_6_StringCompressionTests
    {
        readonly _1_6_StringCompression _practice = new _1_6_StringCompression();

        [TestCase("aabcccccaaa", "a2b1c5a3")]
        [TestCase("abcdefg", "abcdefg")]
        [TestCase("aabbccddeee", "a2b2c2d2e3")]
        [TestCase("", "")]
        public void _1_6_StringCompression_WithTestCases_ShouldReturnExpected(string input, string expected)
        {
            string result = _practice.GetCompressedString(input);

            Assert.AreEqual(expected, result);
        }
    }
}
