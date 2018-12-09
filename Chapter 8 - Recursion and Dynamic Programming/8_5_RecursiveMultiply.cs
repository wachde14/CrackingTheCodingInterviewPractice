using NUnit.Framework;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Recursive Multiply: Write a recursive function to multiply two positive integers without using
    /// the* operator (or / operator). You can use addition, subtraction, and bit shifting, but you should
    /// minimize the number of those operations.
    /// </summary>
    class _8_5_RecursiveMultiply
    {
        public int RecursiveMultiplyBasic(int a, int b, int total)
        {
            if (b == 0)
                return total;

            total += a;

            return RecursiveMultiplyBasic(a, b - 1, total);
        }

        public int RecursiveMultiplyBetter(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            if (a == 1)
                return b;
            if (b == 1)
                return a;

            int small, big;
            if (a <= b)
            {
                small = a; big = b;
            }
            else
            {
                small = b; big = a;
            }

            return Multiply(small, big);
        }

        private int Multiply(int small, int big)
        {
            if (small == 1)
                return big;

            if (small % 2 == 0)
            {
                int total = Multiply(small >> 1, big);
                return (total + total);
            }
            else
            {
                int total = Multiply(small >> 1, big);
                return (total + total + big);
            }
        }

    }

    [TestFixture]
    class _8_5_RecursiveMultiplyTests
    {
        readonly _8_5_RecursiveMultiply _practice = new _8_5_RecursiveMultiply();

        [TestCase(5, 5, 25)]
        [TestCase(4, 6, 24)]
        [TestCase(15, 15, 225)]
        [TestCase(0, 5, 0)]
        public void _8_5_RecursiveMultiplyBasic_TestCases(int a, int b, int expected)
        {
            int result = _practice.RecursiveMultiplyBasic(a, b, 0);

            Assert.AreEqual(expected, result);
        }

        [TestCase(5, 5, 25)]
        [TestCase(4, 6, 24)]
        [TestCase(15, 15, 225)]
        [TestCase(0, 5, 0)]
        public void _8_5_RecursiveMultiplyBetter_TestCases(int a, int b, int expected)
        {
            int result = _practice.RecursiveMultiplyBetter(a, b);

            Assert.AreEqual(expected, result);
        }
    }
}
