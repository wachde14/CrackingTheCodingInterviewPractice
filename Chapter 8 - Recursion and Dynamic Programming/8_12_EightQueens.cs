using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Eight Queens:Write an algorithm to print all ways of arranging eight queens on an 8x8 chess board
    /// so that none of them share the same row, column, or diagonal.In this case, "diagonal" means all
    /// diagonals, not just the two that bisect the board.
    /// </summary>
    public class _8_12_EightQueens
    {
        public readonly int GridSize = 8;
        public void PlaceQueens(int row, int[] columns, List<int[]> results)
        {
            if (row == GridSize)
            {
                int[] clone = new int[GridSize];
                columns.CopyTo(clone, 0);
                results.Add(clone);
            }
            else
            {
                for (int col = 0; col < GridSize; col++)
                {
                    if (CheckValid(columns, row, col))
                    {
                        columns[row] = col; // Place queen
                        PlaceQueens(row + 1, columns, results);
                    }
                }
            }
        }

        bool CheckValid(int[] columns, int rowl, int column1)
        {
            for (int row2 = 0; row2 < rowl; row2++)
            {
                int column2 = columns[row2];
                /* Check if (row2, column2) invalidates (rowl, columnl) as a queen spot. */

                /* Check if rows have a queen in the same column */
                if (column1 == column2)
                {
                    return false;
                }

                /* Check diagonals: if the distance between the columns equals the distance between the rows, then they're in the same diagonal. */
                int columnDistance = Math.Abs(column2 - column1);

                /* rowl > row2, so no need for abs */
                int rowDistance = rowl - row2;
                if (columnDistance == rowDistance)
                {
                    return false;
                }
            }

            return true;
        }
    }

    [TestFixture]
    class _8_12_EightQueensTests
    {
        readonly _8_12_EightQueens _practice = new _8_12_EightQueens();

        [Test]
        public void _8_12_EightQueens_With8x8Board_ShouldReturn92Solutions()
        {
            int[] columns = new int[_practice.GridSize];
            List<int[]> result = new List<int[]>();

            _practice.PlaceQueens(0, columns, result);

            Assert.AreEqual(92, result.Count);
        }
    }

}
