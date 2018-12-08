using System;
using NUnit.Framework;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Magic Index: A magic index in an array A[ 1...n-1] is defined to be an index such that A[ i]
    /// i.Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in
    /// array A.
    /// FOLLOW UP
    /// What if the values are not distinct?
    /// </summary>
    class _8_3_MagicIndex
    {
        public int Problem_8_3_Distinct(int[] array)
        {
            return GetMagicIndexDistinct(array, 0, array.Length - 1);
        }

        int GetMagicIndexDistinct(int[] array, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (array[mid] == mid)
            {
                return mid;
            }

            if (mid > array[mid])
            {
                return GetMagicIndexDistinct(array, mid + 1, end);
            }
            else
            {
                return GetMagicIndexDistinct(array, start, mid - 1);
            }
        }

        public int Problem_8_3_NotDistinct(int[] array)
        {
            return GetMagicIndexNotDistinct(array, 0, array.Length - 1);
        }

        int GetMagicIndexNotDistinct(int[] array, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int midIndex = (start + end) / 2;
            int midValue = array[midIndex];

            if (midValue == midIndex)
            {
                return midIndex;
            }

            int leftIndex = Math.Min(midIndex - 1, midValue);
            int left = GetMagicIndexNotDistinct(array, start, leftIndex);
            if (left >= 0)
                return left;

            int rightIndex = Math.Max(midIndex + 1, midValue);
            int right = GetMagicIndexNotDistinct(array, rightIndex, end);

            return right;
        }

    }

    [TestFixture]
    class _8_3_MagicIndexTests
    {
        readonly _8_3_MagicIndex _practice = new _8_3_MagicIndex();

        [Test]
        public void _8_3_MagicIndex_Distinct_Test1()
        {
            int[] inputArray = new int[] {-40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13};

            int result = _practice.Problem_8_3_Distinct(inputArray);

            Assert.AreEqual(7, result);
        }

        [Test]
        public void _8_3_MagicIndex_Distinct_Test2()
        {
            int[] inputArray = new int[] { -40, -20, -1, 1, 2, 3, 5, 6, 9, 12, 13 };

            int result = _practice.Problem_8_3_Distinct(inputArray);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void _8_3_MagicIndex_NotDistinct_Test1()
        {
            int[] inputArray = new int[] { -10, -5, -2, -2, -2, 3, 4, 6, 9, 12, 13 };

            int result = _practice.Problem_8_3_NotDistinct(inputArray);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void _8_3_MagicIndex_NotDistinct_Test2()
        {
            int[] inputArray = new int[] { -10, -5, 2, 2, 2, 3, 4, 7, 9, 12 ,13};

            int result = _practice.Problem_8_3_NotDistinct(inputArray);

            Assert.AreEqual(2, result);
        }

    }
}
