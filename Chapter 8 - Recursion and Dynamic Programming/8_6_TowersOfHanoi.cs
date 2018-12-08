using Chapter_8___Recursion_and_Dynamic_Programming.DataStructures;
using NUnit.Framework;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    class _8_6_TowersOfHanoi
    {
        public void Problem_8_6(ref HanoiTowerSet towerSet, int amountOfDiscs)
        { 
            towerSet.Towers[0].moveDiscs(amountOfDiscs, towerSet.Towers[2], towerSet.Towers[1]);
        }
    }

    [TestFixture]
    class _8_6_TowersOfHanoiTests
    {
        readonly _8_6_TowersOfHanoi _practice = new _8_6_TowersOfHanoi();

        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(10)]
        public void _8_6_TowersOfHanoi_Test1(int amountOfDiscs)
        {
            HanoiTowerSet towerSet = new HanoiTowerSet(amountOfDiscs);

            _practice.Problem_8_6(ref towerSet, amountOfDiscs);

            Assert.AreEqual(amountOfDiscs, towerSet.Towers[2].GetAmountOfDiscs());
        }
    }
}
