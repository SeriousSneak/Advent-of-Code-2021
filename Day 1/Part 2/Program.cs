/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: December 1, 2021
 * 
 * Day 1 Part 2
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 1\Part 2\input.txt");

            var linesList = new List<string>(lines);

            int firstSum = 0;
            int secondSum = 0;
            int numberOfIncreases = 0;

            for (int count = 0; count < (linesList.Count - 3); count++)
            {
                firstSum = Convert.ToInt32(linesList[count]) + Convert.ToInt32(linesList[count + 1]) + Convert.ToInt32(linesList[count + 2]);
                secondSum = Convert.ToInt32(linesList[count + 1]) + Convert.ToInt32(linesList[count + 2]) + Convert.ToInt32(linesList[count + 3]);

                if (secondSum > firstSum)
                {
                    numberOfIncreases++;
                }
            }

            
            Console.WriteLine("There are " + numberOfIncreases + " increases.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
