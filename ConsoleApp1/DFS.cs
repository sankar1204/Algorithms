using System;
using System.Collections;

namespace Algorithms
{
    /// <summary>
    /// To traverse the tree in DFS order
    /// </summary>
    internal class DFS
    {
        internal int[,] DefaultInput = new int[5, 5] {
        { 0,1,1,0,0},
        { 1,0,1,1,0},
        { 1,1,0,1,0},
        { 0,1,1,0,1},
        { 0,0,0,1,0} };
        internal void Run(int[,] inputArray, int nodesCount, int rootNode)
        {
            Stack stack = new Stack();
            int[] visited = new int[nodesCount];
            int[] adjacentNodes = new int[nodesCount];

            stack.Push(rootNode);
            while (stack.Count != 0)
            {
                int node = Convert.ToInt32(stack.Pop());
                visited[node] = 1;
                Console.WriteLine(node);
                int k = 0;
                for (int i = 0; i < nodesCount; i++)
                {
                    if (inputArray[node, i] == 1 &&
                        visited[i] != 1)
                    {
                        stack.Push(i);
                    }
                }
            }
        }
    }
}
