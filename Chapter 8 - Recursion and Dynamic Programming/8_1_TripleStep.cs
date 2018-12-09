using NUnit.Framework;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    /// <summary>
    /// Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
    ///steps at a time.Implement a method to count how many possible ways the child can run up the
    ///stairs.
    /// </summary>
    public class _8_1_TripleStep
    {
        public int Problem_8_1(int targetSteps)
        {
            return CountSteps(0, targetSteps);
        }

        public int CountSteps(int stepsMoved, int targetSteps)
        {
            if (stepsMoved == targetSteps)
            {
                return 1;
            }

            if (stepsMoved > targetSteps)
            {
                return 0;
            }

            return CountSteps(stepsMoved + 1, targetSteps)
                   + CountSteps(stepsMoved + 2, targetSteps)
                   + CountSteps(stepsMoved + 3, targetSteps);

        }
    }

    [TestFixture]
    class _8_1_TripleStepsTests
    {
        readonly _8_1_TripleStep _practice = new _8_1_TripleStep();

        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(4, 7)]
        public void _8_1_TripleStep_TestCases(int inputSteps, int expected)
        {
            int result = _practice.Problem_8_1(inputSteps);

            Assert.AreEqual(expected, result);
        }
    }
}
