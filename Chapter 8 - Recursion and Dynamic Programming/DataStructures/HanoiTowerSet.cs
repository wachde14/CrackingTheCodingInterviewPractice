namespace Chapter_8___Recursion_and_Dynamic_Programming.DataStructures
{
    public class HanoiTowerSet
    {
        public HanoiTower[] Towers;
        private const int AmountOfTowers = 3;

        public HanoiTowerSet(int amountOfDiscs)
        {
            InitializeTowers(AmountOfTowers);
            InitializeFirstTowerDiscs(amountOfDiscs);
        }

        private void InitializeFirstTowerDiscs(int amountOfDiscs)
        {
            for (int i = amountOfDiscs; i > 0; i--)
            {
                Towers[0].Add(i);
            }
        }

        private void InitializeTowers(int amountOfTowers)
        {
            Towers = new HanoiTower[amountOfTowers];

            for (int i = 0; i < amountOfTowers; i++)
            {
                Towers[i] = new HanoiTower(i);
            }
        }
    }
}
