/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: December 6
 * 
 * Day 3 Part 2
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
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 3\Part 2\input.txt");

            //I will be taking destrucive actions on the list, and so I've created two of them. One to figure out the Oxygen rating, and the other to figure out the CO2 rating
            var linesListOxygen = new List<string>(lines);
            var linesListCO2 = new List<string>(lines);


            int numLengthOxygen = linesListOxygen[0].Length;
            int totalNumbersOxygen = linesListOxygen.Count;

            int numLengthCO2 = linesListCO2[0].Length;
            int totalNumbersCO2 = linesListCO2.Count;


            //Determine Oxygen Generator Rating
            for (int col = 0; col < numLengthOxygen; col++)
            {
                int countOnes = 0;
                int countZeros = 0;

                for (int row = 0; row < totalNumbersOxygen; row++)
                {
                    if (linesListOxygen[row].Substring(col, 1) == "0")
                    {
                        countZeros++;
                    }
                    else
                    {
                        countOnes++;
                    }
                }

                //if countOnes > countZeros, keep number if start with one
                //if countOnes == countZeros, keep number if start with one
                //if countZeros > countOnes, keep number if start with zero                      
                for (int row = 0; row < totalNumbersOxygen; row++)
                {
                    if ((countZeros == countOnes) || (countZeros < countOnes)) //keep numbers that start with one
                    {
                        if (linesListOxygen[row].Substring(col, 1) == "0")
                        {
                            linesListOxygen.RemoveAt(row);
                            row--;
                        }
                    }
                    else if (countZeros > countOnes) //keep numbers that start with zero
                    {
                        if (linesListOxygen[row].Substring(col, 1) == "1")
                        {
                            linesListOxygen.RemoveAt(row);
                            row--;
                        }
                    }
                    totalNumbersOxygen = linesListOxygen.Count;

                    if (totalNumbersOxygen == 1)  //break out of loop
                    {
                        row = totalNumbersOxygen + 1;
                        col = numLengthOxygen + 1;
                    }
                }
            }


            //Determine CO2 Scrubber Rating
            for (int col = 0; col < numLengthCO2; col++)
            {
                int countOnes = 0;
                int countZeros = 0;

                for (int row = 0; row < totalNumbersCO2; row++)
                {
                    if (linesListCO2[row].Substring(col, 1) == "0")
                    {
                        countZeros++;
                    }
                    else
                    {
                        countOnes++;
                    }
                }

                //if countOnes > countZeros, keep number if start with zero
                //if countOnes == countZeros, keep number if start with zero
                //if countZeros > countOnes, keep number if start with one                      
                for (int row = 0; row < totalNumbersCO2; row++)
                {
                    if ((countZeros == countOnes) || (countZeros < countOnes)) //keep numbers that start with zero
                    {
                        if (linesListCO2[row].Substring(col, 1) == "1")
                        {
                            linesListCO2.RemoveAt(row);
                            row--;
                        }
                    }
                    else if (countZeros > countOnes) //keep numbers that start with one
                    {
                        if (linesListCO2[row].Substring(col, 1) == "0")
                        {
                            linesListCO2.RemoveAt(row);
                            row--;
                        }
                    }
                    totalNumbersCO2 = linesListCO2.Count;

                    if (totalNumbersCO2 == 1)  //break out of loop
                    {
                        row = totalNumbersCO2 + 1;
                        col = numLengthCO2 + 1;
                    }
                }
            }

            int oxygenInt = Convert.ToInt32(linesListOxygen[0], 2);
            int CO2Int = Convert.ToInt32(linesListCO2[0], 2);


            Console.WriteLine("Oxygen Generator Rating: " + linesListOxygen[0] + "(" + oxygenInt + ")");
            Console.WriteLine("CO2 Scrubber Rating: " + linesListCO2[0] + "(" + CO2Int + ")");

            int lifeSupportRating = oxygenInt * CO2Int;

            Console.WriteLine("The Life Support Rating is (Oxygen Generator Rating * CO2 Scrubber Rating = " + lifeSupportRating);

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
