using System;
using System.Collections.Generic;

namespace Chapter_8___Recursion_and_Dynamic_Programming.DataStructures
{
    public class HanoiTower
    {
        private Stack<int> discs;
        private int index;

        public HanoiTower(int i)
        {
            discs = new Stack<int>();
            index = i;
        }

        public void Add(int disc)
        {
            if (discs.Count > 0 && discs.Peek() <= disc)
            {
                throw new Exception("Cannot place disk");
            }

            discs.Push(disc);
        }

        public void MoveTopTo(HanoiTower tower)
        {
            int top = discs.Pop();
            tower.Add(top);
        }

        public void moveDiscs(int n, HanoiTower destination, HanoiTower buffer)
        {
            if (n > 0)
            {
                moveDiscs(n - 1, buffer, destination);
                MoveTopTo(destination);
                buffer.moveDiscs(n - 1, destination, this);
            }
        }

        public int GetAmountOfDiscs()
        {
            return discs.Count;
        }
    }
}
