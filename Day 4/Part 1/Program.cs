/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: 
 * 
 * Day 4 Part 1
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
            //CONCEPT CODE
            int[,] a1 = new int[4, 4] {
                        {0, 1, 2, 3} ,
                        {4, 5, 6, 7} ,
                        {8, 9, 10, 11} ,
                        {12, 13, 14, 15}
                        };


            int[,] a2 = new int[4, 4] {
                        {20, 21, 22, 23} ,
                        {24, 25, 26, 27} ,
                        {28, 29, 210, 211} ,
                        {212, 213, 214, 215}
                        };


            List<int[,]> bingoCards = new List<int[,]>();

            bingoCards.Add(a1);
            bingoCards.Add(a2);


            int bob = 0;

            bob = bingoCards[0][1,3];

            Console.WriteLine(bob);
            //END CONCEPT CODE
            




            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
