using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class StringReverse
    {
        /// <summary>
        /// Reverses the string recursively
        /// </summary>
        internal void ReverseStringRecursively(string line, int index, int length) {
            if (index == length-1) {
                Console.Write(line[index]);
                return;
            }
            ReverseStringRecursively(line, index+1, length);
            Console.Write(line[index]);
        }
    }
}
