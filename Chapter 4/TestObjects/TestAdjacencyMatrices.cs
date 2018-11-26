using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_4.TestObjects
{
    public static class TestAdjacencyMatrices
    {
        public static int[,] NoConnectionsFromNode0()
        {
            int[,] graph = new int[,]{{0,0,0,0,0,0},
                {0,0,0,1,1,0},
                {0,1,0,0,0,0},
                {0,0,1,0,1,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,0}};

            return graph;
        }

        public static int[,] ExampleFromBookPage107()
        {
            int[,] graph = new int[,]{{0,1,0,0,1,1},
                {0,0,0,1,1,0},
                {0,1,0,0,0,0},
                {0,0,1,0,1,0},
                {0,0,0,0,0,0},
                {0,0,0,0,0,0}};

            return graph;
        }

    }
}
