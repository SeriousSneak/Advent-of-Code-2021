/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: January 3, 2022
 * 
 * Day 6 Part 2
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

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

            string[] values = linesList[0].Split(',');

            long[] lanternFishTracking = new long[10];

            for (int x = 0; x < values.Length; x++)
            {
                lanternFishTracking[Convert.ToInt32(values[x])]++;
            }

            //in Part 1, when I tried to loop it 256 times I received an out of memory error. For Part 2, I am instead keeping track of how many fish are on each day with this 10 cell array.
            for (int day = 0; day < 256; day++)
            {
                long newBabies = lanternFishTracking[0];

                lanternFishTracking[0] = lanternFishTracking[1];
                lanternFishTracking[1] = lanternFishTracking[2];
                lanternFishTracking[2] = lanternFishTracking[3];
                lanternFishTracking[3] = lanternFishTracking[4];
                lanternFishTracking[4] = lanternFishTracking[5];
                lanternFishTracking[5] = lanternFishTracking[6];
                lanternFishTracking[6] = lanternFishTracking[7] + newBabies;
                lanternFishTracking[7] = lanternFishTracking[8];
                lanternFishTracking[8] = lanternFishTracking[9] + newBabies;
            }

            long lanternFishTotal = 0;
            for (int x = 0; x < lanternFishTracking.Length; x++)
            {
                lanternFishTotal += lanternFishTracking[x];
            }


            Console.WriteLine("There would be " + lanternFishTotal + " lantern fish.");
            Console.WriteLine("");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
