/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: January 9, 2022
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
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 7\Part 1\input.txt");

            //mac
            //var lines = File.ReadLines(@"/Users/andrew/Temp/Advent-of-Code-2021/Day 7/Part1/input.txt");

            var linesList = new List<string>(lines);

            //the input file has a single line, so I have hard coded index 0 here
            string[] values = linesList[0].Split(',');
            List<int> crabValues = new List<int>();

            for (int x = 0; x < values.Length; x++)
            {
                crabValues.Add(Convert.ToInt32(values[x]));
            }

            int[] temp = crabValues.ToArray();

            decimal medianValue = 0;
            Array.Sort(temp);
            int count = temp.Length;
            if (count == 0)
            {
                throw new InvalidOperationException("Empty collection");
            }
            else if (count % 2 == 0)
            {
                // count is even, average two middle elements
                int a = temp[count / 2 - 1];
                int b = temp[count / 2];
                //return (a + b) / 2m;
                medianValue = (a + b) / 2m;
            }
            else
            {
                // count is odd, return the middle element
                //return temp[count / 2];
                medianValue = temp[count / 2];
            }

            watch.Stop();

            //371 is not correct. This is actually the number they need to align to. I now need to figure out how much fuel is used and that will be the answer.

            int totalFuelUsed = 0;

            for (int loop = 0; loop < crabValues.Count; loop++)
            {
                if (crabValues[loop] < medianValue)
                {
                    totalFuelUsed += Convert.ToInt32(medianValue) - crabValues[loop];
                }
                else if (crabValues[loop] > medianValue)
                {
                    totalFuelUsed += crabValues[loop] - Convert.ToInt32(medianValue);
                }
            }

            Console.WriteLine("The median is " + medianValue + ".");
            Console.WriteLine("The total fule used is " + totalFuelUsed + ".");
            Console.WriteLine("");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}