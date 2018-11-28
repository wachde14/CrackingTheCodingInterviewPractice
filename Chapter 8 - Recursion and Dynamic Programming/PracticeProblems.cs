using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_8___Recursion_and_Dynamic_Programming
{
    public class PracticeProblems
    {
        #region 8.1
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
        #endregion
    }
}
