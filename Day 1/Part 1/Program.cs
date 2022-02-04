/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: December 1, 2021
 * 
 * Day 1 Part 1
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
            //read input
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 1\Part 1\input.txt");

            var linesList = new List<string>(lines);

            int currentReading = 0;
            int previousReading = 0;
            int numberOfIncreases = 0;

            for (int count=1; count<linesList.Count; count++)
            {
                currentReading = Convert.ToInt32(linesList[count]);
                previousReading = Convert.ToInt32(linesList[count -1]);

                if (currentReading > previousReading)
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
