using FluentAssertions;
using NUnit.Framework;
using static Chapter_8___Recursion_and_Dynamic_Programming.DataStructures.ColorEnum;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Paint Fill: Implement the "paint fill" function that one might see on many image editing programs.
    /// That is, given a screen(represented by a two-dimensional array of colors), a point, and a new color,
    /// fill in the surrounding area until the color changes from the original color.
    /// </summary>
    class _8_10_PaintFill
    {
        public bool Problem_8_10(Color[,] screen, int r, int c, Color newColor)
        {
            if (screen[r, c] == newColor)
                return false;

            return PaintFill(screen, r, c, screen[r, c], newColor);
        }

        bool PaintFill(Color[,] screen, int r, int c, Color oldColor, Color newColor)
        {
            if (r < 0 || r >= screen.GetLength(0) || c < 0 || c >= screen.GetLength(1))
            {
                return false;
            }

            if (screen[r, c] == oldColor)
            {
                screen[r, c] = newColor;
                PaintFill(screen, r - 1, c, oldColor, newColor); //up
                PaintFill(screen, r + 1, c, oldColor, newColor); //down
                PaintFill(screen, r, c - 1, oldColor, newColor); //left
                PaintFill(screen, r, c + 1, oldColor, newColor); //right
            }

            return true;
        }
    }

    [TestFixture]
    class _8_10_PaintFillTests
    {
        readonly _8_10_PaintFill _practice = new _8_10_PaintFill();

        [Test]
        public void _8_10_PaintFill_Test1()
        {
            Color[,] screen = new Color[,]
            {
                {Color.Black, Color.Black, Color.Black},
                {Color.Black, Color.Black, Color.Black},
                {Color.Black, Color.Black, Color.Red}
            };

            Color[,] expected = new Color[,]
            {
                {Color.Green, Color.Green, Color.Green},
                {Color.Green, Color.Green, Color.Green},
                {Color.Green, Color.Green, Color.Red}
            };


            bool result = _practice.Problem_8_10(screen, 1, 1, Color.Green);

            screen.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void _8_10_PaintFill_Test2()
        {
            Color[,] screen = new Color[,]
            {
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Red,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Red,Color.Black,Color.Red,Color.Red,Color.Black},
                {Color.Red,Color.Red,Color.Red,Color.Red,Color.Red},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
            };

            Color[,] expected = new Color[,]
            {
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Green,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Green,Color.Black,Color.Green,Color.Green,Color.Black},
                {Color.Green,Color.Green,Color.Green,Color.Green,Color.Green},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
            };


            bool result = _practice.Problem_8_10(screen, 1, 0, Color.Green);

            screen.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void _8_10_PaintFill_Test3()
        {
            Color[,] screen = new Color[,]
            {
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Red,Color.Red,Color.Red,Color.Red,Color.Red,Color.Red},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black}
            };

            Color[,] expected = new Color[,]
            {
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Black,Color.Black,Color.Black,Color.Black,Color.Black,Color.Black},
                {Color.Red,Color.Red,Color.Red,Color.Red,Color.Red,Color.Red},
                {Color.Green,Color.Green,Color.Green,Color.Green,Color.Green,Color.Green},
                {Color.Green,Color.Green,Color.Green,Color.Green,Color.Green,Color.Green}
            };

            bool result = _practice.Problem_8_10(screen, 4, 3, Color.Green);

            screen.Should().BeEquivalentTo(expected);
        }
    }
}
