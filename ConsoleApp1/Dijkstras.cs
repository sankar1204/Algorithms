using System;

namespace ConsoleApp1
{
    class Dijkstras
    {
        internal void Demo()
        {
            int[,] input = new int[,]{ { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                       { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                       { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                       { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                       { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                       { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                       { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                       { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                       { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            int source = 0;

            bool[] vertices = new bool[9];
            for (int i = 1; i < 9; i++)
            {
                vertices[i] = false;
            }
            vertices[source] = true;

            int[] shortPath = DijkstrasAlgorithm(input, 0, vertices);
            for (int l = 0; l < 9; l++)
            {
                Console.WriteLine($"{l} {shortPath[l]}");
            }
        }

        internal int[] DijkstrasAlgorithm(int[,] inputArray, int source, bool[] vertices)
        {
            // array to hold shortest distance for each node from source
            int[] shortestPath = new int[9];
           
            // mark all nodes as int max value so that we will get to know which node is processed
            for (int i = 0; i < 9; i++)
            {
                shortestPath[i] = Math.Abs(int.MaxValue);                
            }
            // distance for source node from source node would be zero
            shortestPath[source] = 0;

            for (int i = 0; i < 9; i++) // number of vertices or length of vertices
            {
                // find the adjacent vertices of source and fill to shortestpath array
                for (int j = 0; j < 9; j++)
                {
                    // if node is already visited skip it
                    // if inputArray[i, j] = 0 which means there is node edge from i, j, so skip it
                    // inputArray[source, j] + shortestPath[source] < shortestPath[j] this means,
                    // if the newly calculated distance is larger than the old value skip it
                    if (inputArray[source, j] != 0 &&
                        !vertices[j] &&
                        inputArray[source, j] + shortestPath[source] < shortestPath[j])
                    {
                        shortestPath[j] = shortestPath[source] + inputArray[source, j];
                    }
                }

                // find the next vertex to be visited
                int index = 0;
                int temp = Math.Abs(int.MaxValue);

                for (int k = 0; k < 9; k++)
                {
                    if (!vertices[k] &&
                        shortestPath[k] < temp)
                    {
                        temp = shortestPath[k];
                        index = k;
                    }
                }
                source = index;
                // mark the vertes has visited
                vertices[source] = true;
            }
            return shortestPath;
        }
    }
}
