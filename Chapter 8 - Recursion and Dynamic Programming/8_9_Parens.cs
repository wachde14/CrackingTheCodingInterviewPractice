using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Parens: Implement an algorithm to print all valid (i.e., properly opened and closed) combinations
    /// of n pairs of parentheses.
    /// EXAMPLE
    /// Input: 3
    /// Output: ((() ) ) , (() () ) , (() ) () , () (() ) , () () ()
    /// </summary>
    class _8_9_Parens
    {
        public List<string> Problem_8_9(int count)
        {
            int newStringSize = count * 2;
            StringBuilder str = new StringBuilder(newStringSize);
            for (int i = 0; i < newStringSize; i++)
            {
                str.Insert(0,'A');
            }

            List<string> result = new List<string>();

            AddParens(result, count, count, str, 0);

            return result;
        }

        void AddParens(List<string> result, int leftRem, int rightRem, StringBuilder str, int index)
        {
            if (leftRem < 0 || rightRem < leftRem)
                return;

            if (leftRem == 0 && rightRem == 0)
            {
                result.Add(str.ToString());
            }
            else
            {
                str[index] = Convert.ToChar("(");
                AddParens(result, leftRem - 1, rightRem, str, index + 1);

                str[index] = Convert.ToChar(")");
                AddParens(result, leftRem, rightRem - 1, str, index + 1);
            }
        }
    }

    [TestFixture]
    class _8_9_ParensTests
    {
        readonly _8_9_Parens _practice = new _8_9_Parens();

        [TestCase(2, 2)]
        [TestCase(3, 5)]
        [TestCase(4, 14)]
        public void _8_9_Parens_TestCases(int inputCount, int expectedTotal)
        {
            List<string> result = _practice.Problem_8_9(inputCount);

            Assert.AreEqual(expectedTotal, result.Count);
        }
    }
}
