/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date:
 * 
 * Day 6 Part 2
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 6\Part 1\input.txt");
            var linesList = new List<string>(lines);

            //the input file has a single line, so I have hard coded index 0 here
            string[] values = linesList[0].Split(',');
            List<int> lanternFishList = new List<int>();

            for (int x = 0; x < values.Length; x++)
            {
                lanternFishList.Add(Convert.ToInt32(values[x]));
            }

//initialize a long array here with 10 cells


            //Console.WriteLine("There would be " + lanternFishList.Count + " lantern fish.");
            Console.WriteLine("");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
