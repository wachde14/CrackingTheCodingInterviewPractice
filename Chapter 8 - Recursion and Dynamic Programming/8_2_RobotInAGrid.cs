using Chapter_8___Recursion_and_Dynamic_Programming.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Robot in a Grid: Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
    /// The robot can only move in two directions, right and down, but certain cells are "off limits" such that
    /// the robot cannot step on them.Design an algorithm to find a path for the robot from the top left to
    /// the bottom right.
    /// </summary>
    class _8_2_RobotInAGrid
    {
        public List<Point> Problem_8_2(bool[,] maze)
        {
            if (maze == null || maze.Length == 0)
                return null;

            int rows = maze.GetLength(0);
            int columns = maze.GetLength(1);
            List<Point> path = new List<Point>();

            if (GetPath(maze, rows - 1, columns - 1, path))
            {
                return path;
            }

            return null;
        }

        public bool GetPath(bool[,] maze, int currRow, int currColumn, List<Point> path)
        {
            if (currRow < 0 || currColumn < 0 || maze[currRow, currColumn] == false) 
                return false;

            if (currRow == 0 && currColumn == 0)
            {
                path.Add(new Point(currRow, currColumn));
                return true;
            }

            if (GetPath(maze, currRow - 1, currColumn, path) || GetPath(maze, currRow, currColumn - 1, path))
            {
                path.Add(new Point(currRow, currColumn));
                return true;
            }

            return false;
        }
    }

    [TestFixture]
    class _8_2_RobotInAGridTests
    {
        readonly _8_2_RobotInAGrid _practice = new _8_2_RobotInAGrid();

        [Test]
        public void _8_2_TripleStep_Test1()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, true},
                {true, true, true},
                {true, true, true}
            };

            List<Point> result = _practice.Problem_8_2(maze);

            Assert.AreEqual(5, result.Count);
        }

        [Test]
        public void _8_2_TripleStep_Test2()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, false},
                {true, true, true},
                {true, true, true}
            };

            List<Point> result = _practice.Problem_8_2(maze);

            Assert.AreEqual(5, result.Count);
        }


        [Test]
        public void _8_2_TripleStep_Test3()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, false},
                {true, false, true},
                {false, true, true}
            };

            List<Point> result = _practice.Problem_8_2(maze);

            Assert.AreEqual(null, result);
        }

        [Test]
        public void _8_2_TripleStep_Test4()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, true, true, true},
                {true, false, true, true, true},
            };

            List<Point> result = _practice.Problem_8_2(maze);

            Assert.AreEqual(6, result.Count);
        }

        [Test]
        public void _8_2_TripleStep_Test5()
        {
            bool[,] maze = new bool[,]
            {
                {true, true },
                {false,true },
                {true, true },
                {true, true },
                {true, true },
                {true, true },
                {true, true }
            };

            List<Point> result = _practice.Problem_8_2(maze);

            Assert.AreEqual(8, result.Count);
        }
    }
}

