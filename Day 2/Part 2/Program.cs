/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: December 2, 2021
 * 
 * Day 2 Part 2
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
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 2\Part 2\input.txt");

            //creating a List with the input
            var linesList = new List<string>(lines);

            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;

            for (int loop = 0; loop < linesList.Count; loop++)
            {
                string movement = linesList[loop];

                //This will split a string based on a single character
                string[] subStrings = movement.Split(' ');

                string direction = subStrings[0];
                int distance = Convert.ToInt32(subStrings[1]);

                if (direction == "forward")
                {
                    horizontalPosition += distance;
                    depth += aim * distance;
                }
                else if (direction == "up")
                {
                    aim -= distance;

                }
                else if (direction == "down")
                {
                    aim += distance;
                }
            }

            int answer = depth * horizontalPosition;
            Console.WriteLine("The depth multipled by the horizontal position is " + depth + " * " + horizontalPosition + " = " + answer);


            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}