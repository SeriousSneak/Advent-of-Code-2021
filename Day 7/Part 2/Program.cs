/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date:
 *
 * Project details
 *    Targeting .net Core 3.1
 *    Created with Visual Studio 2022 on Windows 11
 *
 * Day 7 Part 1
 * 
 */

using System;

namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();



            //Console.WriteLine("The median is " + medianValue + ".");
            //Console.WriteLine("The total fule used is " + totalFuelUsed + ".");
            Console.WriteLine("");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
