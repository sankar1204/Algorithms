using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Overloading
    {
        internal void TestMethod(int i, bool flag = false, string str = "")
        {
            Console.WriteLine($"{ i} : {flag} : {str}");
        }
    }
}
