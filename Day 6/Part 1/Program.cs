/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: January 3, 2022
 * 
 * Day 6 Part 1
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_1
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

            for (int x=0; x<values.Length; x++)
            {
                lanternFishList.Add(Convert.ToInt32(values[x]));
            }

            for (int loop = 0; loop < 80; loop++)
            {
                int addBaby = 0;
                for (int fishNumber=0; fishNumber < lanternFishList.Count; fishNumber++)
                {
                    if (lanternFishList[fishNumber] == 0)
                    {
                        lanternFishList[fishNumber] = 6;
                        addBaby++;
                    }
                    else
                    {
                        lanternFishList[fishNumber]--;
                    }
                }
                for (int newChildren = 0; newChildren < addBaby; newChildren++)
                {
                    lanternFishList.Add(8);
                }
            }

            
            watch.Stop();

            Console.WriteLine("There would be " + lanternFishList.Count + " lantern fish.");
            Console.WriteLine("");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
