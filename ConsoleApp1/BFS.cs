using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// will demonstrate applications of BFS like
    ///  - To find the level of each node
    ///  - 0-1 BFS to find out shortest distance between source and any given node in the tree.
    /// </summary>
    internal class BFS
    {
        // - To find the level of each node
        internal void PrintNodeLevel()
        {
            //0,1,2,3,4,5,6,7    
            int[,] input = new int[,] { {0,1,1,1,0,0,0,0 },
                                        {1,0,0,0,1,1,0,0 },
                                        {1,0,0,0,0,0,1,1 },
                                        {1,0,0,0,0,0,0,1 },
                                        {0,1,0,0,0,0,0,0 },
                                        {0,1,0,0,0,0,0,0 },
                                        {0,0,1,0,0,0,0,0 },
                                        {0,0,1,1,0,0,0,0 }};
            int source = 0;

            int length = 8;

            int[] nodes = new int[length];
            for (int y = 0; y < length; y++)
            {
                nodes[y] = y;
            }

            bool[] visited = new bool[length];
            int[] levelOfNode = new int[length];

            Queue<int> queue = new Queue<int>();
            int i = source;
            int level = 0;
            levelOfNode[source] = level;
            queue.Enqueue(nodes[source]);

            while (queue.Count > 0)
            {
                source = queue.Dequeue();
                visited[source] = true;

                for (int x = 0; x < length; x++)
                {
                    if (input[source, x] != 0 &&
                        !visited[x]
                        )
                    {

                        queue.Enqueue(x);
                        levelOfNode[x] = levelOfNode[source] + 1;
                    }
                }
            }

            for (int j = 0; j < nodes.Length; j++)
            {
                Console.WriteLine($"{nodes[j]} {levelOfNode[j]}");
            }
        }
    }
}
