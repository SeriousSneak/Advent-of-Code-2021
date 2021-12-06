/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: Dec 5, 2021
 * 
 * Day 3 Part 1
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
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 3\Part 1\input.txt");

            var linesList = new List<string>(lines);

            string gammaRate="";
            string epsilonRate = "";

            int numLength = linesList[0].Length;
            int totalNumbers = linesList.Count;

            string[,] stringArray = new string[totalNumbers,numLength];

            //create an array with each digit in a single cell
            for (int row = 0; row < totalNumbers; row++)
            {
                for (int col = 0; col < numLength; col++)
                {
                    stringArray[row, col] = linesList[row].Substring(col, 1);
                }
            }


            //find gamma rate and epsilon rate
            for (int col = 0; col < numLength; col++)
            {
                int countOnes = 0;
                int countZeros = 0;

                for (int row = 0; row < totalNumbers; row++)
                {
                    if (stringArray[row,col] == "0")
                    {
                        countZeros++;
                    }
                    else
                    {
                        countOnes++; ;
                    }
                }

                if (countZeros > countOnes)
                {
                    gammaRate = gammaRate + "0";
                    epsilonRate = epsilonRate + "1";
                }
                else
                {
                    gammaRate = gammaRate + "1";
                    epsilonRate = epsilonRate + "0";
                }


            }

            int gammaInt = Convert.ToInt32(gammaRate, 2);
            int epsilonInt = Convert.ToInt32(epsilonRate, 2);

            Console.WriteLine("Gamma rate: " + gammaRate + "(" + gammaInt + ")");
            Console.WriteLine("Epsilon rate: " + epsilonRate + "(" + epsilonInt + ")");

            int totalPowerConsumption = gammaInt * epsilonInt;

            Console.WriteLine("Total Power Consumption (Gamma rate x Epsilon rate = " + totalPowerConsumption);

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
