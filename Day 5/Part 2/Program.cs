/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: December 17, 2021
 * 
 * Day 5 Part 2
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
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            List<int[]> ventLines = new List<int[]>();
            int[] inputRow = new int[4];

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 5\Part 2\input.txt");

            int largestInputNumber = 0; //will be used to calculate how big our ventMap array should be
            foreach (var line in lines)
            {
                string[] stringSeparators = new string[] { " ", ",", "->" };
                string[] subStrings = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (int x = 0; x < 4; x++)
                {
                    inputRow[x] = Convert.ToInt32(subStrings[x]);

                    if (inputRow[x] > largestInputNumber)
                    {
                        largestInputNumber = inputRow[x];
                    }
                }
                //puts a copy of the inputRow array into the list, as opposed to putting a reference in which would cause the value added to the list to change if the original array changed
                ventLines.Add((int[])inputRow.Clone());
            }

            int mapSize = (int)Math.Ceiling(largestInputNumber / 100.0) * 100;  //rounds to the nearest 100
            int[,] ventMap = new int[mapSize, mapSize];
            //int[,] ventMap = new int[10, 10];   //hard coded for testing

            //loop through the input
            for (int count = 0; count < ventLines.Count; count++)
            {
                int x1 = ventLines[count][0];
                int y1 = ventLines[count][1];
                int x2 = ventLines[count][2];
                int y2 = ventLines[count][3];

                if (x1 == x2)  //the line is vertical
                {
                    int startingVerticalPosition = 0;
                    int endingVerticalPosition = 0;
                    if (y1 > y2)
                    {
                        startingVerticalPosition = y2;
                        endingVerticalPosition = y1;
                    }
                    else
                    {
                        startingVerticalPosition = y1;
                        endingVerticalPosition = y2;
                    }

                    //add 1 to each cell that the line crosses, including the starting and ending points
                    for (int verticalPosition = startingVerticalPosition; verticalPosition <= endingVerticalPosition; verticalPosition++)
                    {
                        ventMap[x1, verticalPosition] += 1;
                    }
                }
                else if (y1 == y2) //the line is hohrizontal
                {
                    int startingHorizontalPosition = 0;
                    int endingHorizontalPosition = 0;
                    if (x1 > x2)
                    {
                        startingHorizontalPosition = x2;
                        endingHorizontalPosition = x1;
                    }
                    else
                    {
                        startingHorizontalPosition = x1;
                        endingHorizontalPosition = x2;
                    }

                    //add 1 to each cell that the line crosses, including the starting and ending points
                    for (int horizontalPosition = startingHorizontalPosition; horizontalPosition <= endingHorizontalPosition; horizontalPosition++)
                    {
                        ventMap[horizontalPosition, y1] += 1;
                    }
                }
                else //the line is diagonal
                {
                    //I want to loop such that I draw the line from left to right
                    if (x1 < x2)
                    {
                        //x1 is on the left and x2 is on the right
                        if (y1 < y2)   //line looks like \
                        {
                            for (int XPosition = x1; XPosition <= x2; XPosition++)
                            {
                                ventMap[XPosition, (y1 + (XPosition - x1))] += 1;
                            }
                        }
                        else    //line looks like /
                        {
                            for (int XPosition = x1; XPosition <= x2; XPosition++)
                            {
                                ventMap[XPosition, (y1 - (XPosition - x1))] += 1;
                            }
                        }
                    }
                    else
                    {
                        //x2 is on the left and x1 is on the right
                        if (y2 < y1)   //line looks like \
                        {
                            for (int XPosition = x2; XPosition <= x1; XPosition++)
                            {
                                ventMap[XPosition, (y2 + (XPosition - x2))] += 1;
                            }
                        }
                        else    //line looks like /
                        {
                            for (int XPosition = x2; XPosition <= x1; XPosition++)
                            {
                                ventMap[XPosition, (y2 - (XPosition - x2))] += 1;
                            }
                        }
                    }
                }

            }

            /*
            //print out vent map
            for (int y = 0; y < ventMap.GetLength(0); y++)
            {
                for (int x = 0; x < ventMap.GetLength(1); x++)
                {
                    Console.Write(ventMap[x, y] + " ");
                }
                Console.WriteLine();
            }
            */


            //find the number of points that have 2 or more lines crossing it
            int answer = 0;

            for (int x = 0; x < ventMap.GetLength(0); x++)
            {
                for (int y = 0; y < ventMap.GetLength(1); y++)
                {
                    if (ventMap[x, y] >= 2)
                    {
                        answer++;
                    }
                }
            }


            watch.Stop();
            Console.WriteLine("There are " + answer + " spaces that have 2 or more lines crossing it.");
            Console.WriteLine();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
