using NUnit.Framework;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Coins: Given an infinite number of quarters (25 cents), dimes (1 O cents), nickels (5 cents), and
    /// pennies(1 cent), write code to calculate the number of ways of representing n cents.
    /// </summary>
    class _8_11_Coins
    {
        public int Problem_8_11(int totalAmount)
        {
            int[] denoms = { 25, 10, 5, 1 };

            return MakeChange(totalAmount, denoms, 0);
        }

        int MakeChange(int totalAmount, int[] denoms, int index)
        {
            if (index >= denoms.Length - 1)
                return 1;

            int denomAmount = denoms[index];
            int ways = 0;

            for (int i = 0; i * denomAmount <= totalAmount; i++)
            {
                int amountRemaining = totalAmount - (i * denomAmount);
                ways += MakeChange(amountRemaining, denoms, index + 1);
            }

            return ways;
        }

    }

    [TestFixture]
    class _8_11_CoinsTests
    {
        readonly _8_11_Coins _practice = new _8_11_Coins();

        [TestCase(2, 1)]
        [TestCase(5, 2)]
        [TestCase(10, 4)]
        [TestCase(25, 13)]
        public void _8_11_Coins_TestCases(int amountOfChange, int expectedTotalWays)
        {
            int result = _practice.Problem_8_11(amountOfChange);

            Assert.AreEqual(expectedTotalWays, result);
        }
    }
}
