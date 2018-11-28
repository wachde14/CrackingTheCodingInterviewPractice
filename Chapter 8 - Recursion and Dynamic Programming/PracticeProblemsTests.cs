using NUnit.Framework;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    [TestFixture]
    class PracticeProblemsTests
    {
        readonly PracticeProblems _practice = new PracticeProblems();

        [Test]
        public void Question_8_1()
        {
            int inputSteps = 2;
            int expected = 2;

            int result = _practice.Problem_8_1(inputSteps);

            Assert.AreEqual(expected, result);
        }
    }
}
