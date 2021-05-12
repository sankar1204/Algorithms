using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Overloading obj = new Overloading();
            //obj.TestMethod(1);
            //obj.TestMethod(1,true);

            //Regex reg = new Regex("^[1-9]{1}([0-9]{9})+$");
            //string str;
            //while (true)
            //{
            //    str= Console.ReadLine();
            //    Console.WriteLine($"{reg.IsMatch(str)}");
            //}
            //string str = Console.ReadLine();
            //new StringReverse().ReverseStringRecursively(str, 0, str.Length);

            Dijkstras algo = new Dijkstras();
            algo.Demo();
            Console.ReadLine();
            
        }
    }
}
