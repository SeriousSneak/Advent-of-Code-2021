/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date:
 *
 * Project details
 *    Targeting .net Core 3.1
 *    Created with Visual Studio 2019 on Mac OS
 *
 * Day 7 Part 1
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            //windows
            //var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 6\Part 1\input.txt");

            //mac
            //var lines = File.ReadLines(@"/Users/andrew/OneDrive/Work/Code/Advent of Code/2021/Advent-of-Code-2021/Day 6/Part 2/input.txt");


            watch.Stop();

            Console.WriteLine("");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
