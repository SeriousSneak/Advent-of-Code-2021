/* Advent of Code 2021
 * 
 * Programmer: Andrew Stobart
 * Date: December 10, 2021
 * 
 * Day 4 Part 2
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Data;

namespace Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2021\Advent-of-Code-2021\Day 4\Part 1\input.txt");

            int count = 0;
            ArrayList callNumbers = new ArrayList();
            string[,] bingoCard = new string[5, 5];
            List<string[,]> bingoCardsList = new List<string[,]>();
            int row = 0;

            //read the data into variables
            foreach (var line in lines)
            {
                string[] stringSeparators = new string[] { " ", "," };
                string[] subStrings = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                //our first line contains the numbers that we will be calling
                if (count == 0)
                {
                    for (int x = 0; x < subStrings.Length; x++)
                    {
                        callNumbers.Add(subStrings[x]);
                    }
                    count++;
                }
                else if (line == "")
                {
                    row = 0;
                }
                //if statement to check for space, then you know you need to go onto the next card
                else if (line != "")
                {
                    //populate card array one line at a time
                    for (int loop = 0; loop < 5; loop++)
                    {
                        bingoCard[row, loop] = subStrings[loop];
                    }
                    row++;

                    //fill the last row of the card to all zeros
                    if (row == 5)
                    {
                        //this puts a copy of bingoCard into the list, as opposed to putting a reference in which would cause the value added to the list change if the original object changes
                        bingoCardsList.Add((string[,])bingoCard.Clone());
                    }
                }
            }


            //process the data
            int winner = 0;
            int puzzleAnswer = 0;

            for (int callNumberLoop = 0; callNumberLoop < callNumbers.Count; callNumberLoop++)
            {
                string lastCalledNumber = callNumbers[callNumberLoop].ToString();
                for (int bingoCardNumber = 0; bingoCardNumber < bingoCardsList.Count; bingoCardNumber++)
                {
                    for (int cardRow = 0; cardRow < 5; cardRow++)
                    {
                        for (int cardCol = 0; cardCol < 5; cardCol++)
                        {
                            if (bingoCardsList[bingoCardNumber][cardRow, cardCol] == callNumbers[callNumberLoop].ToString())
                            {
                                //put "C-" in front of a number once it has been called
                                bingoCardsList[bingoCardNumber][cardRow, cardCol] = "C-" + bingoCardsList[bingoCardNumber][cardRow, cardCol];
                            }
                        }
                    }


                    //check if our card is a winner
                    winner = 0;
                    //check rows for a winner
                    for (int rowCheck = 0; rowCheck < 5; rowCheck++)
                    {
                        for (int colCheck = 0; colCheck < 5; colCheck++)
                        {
                            //get the first character in the cell. If it starts with 'C' then that number has been called
                            if (bingoCardsList[bingoCardNumber][rowCheck, colCheck][0] == 'C')
                            {
                                winner++;
                                if (winner == 5 && bingoCardsList[bingoCardNumber][0,0][0] != 'W') //don't calculate a puzzleAnswer if the card has previously won
                                {
                                    //we have a winner. Calculate the puzzle answer
                                    puzzleAnswer = calculateAnswer(lastCalledNumber, bingoCardsList[bingoCardNumber]);
                                    
                                    //mark the card as a winner
                                    bingoCardsList[bingoCardNumber][0, 0] = "W-" + bingoCardsList[bingoCardNumber][0,0];

                                    //break out of the loop here
                                    colCheck = 5;
                                    rowCheck = 5;
                                }
                            }
                            //move on as this row will not be a winner if any cell does not have a C in it
                            else
                            {
                                colCheck = 5;
                                winner = 0;
                            }
                        }
                    }


                    //check cols for a winner
                    if (winner != 5)
                        //check cols for a winner
                        for (int colCheck = 0; colCheck < 5; colCheck++)
                        {
                            for (int rowCheck = 0; rowCheck < 5; rowCheck++)
                            {
                                //get the first character in the cell. If it starts with 'C' then that number has been called
                                if (bingoCardsList[bingoCardNumber][rowCheck, colCheck][0] == 'C')
                                {
                                    winner++;
                                    if (winner == 5 && bingoCardsList[bingoCardNumber][0, 0][0] != 'W') //don't calculate a puzzleAnswer if the card has previously won
                                    {
                                        //we have a winner. Calculate the puzzle answer
                                        puzzleAnswer = calculateAnswer(lastCalledNumber, bingoCardsList[bingoCardNumber]);

                                        //mark the card as a winner
                                        bingoCardsList[bingoCardNumber][0, 0] = "W-" + bingoCardsList[bingoCardNumber][0, 0];

                                        //break out of the loop here
                                        colCheck = 5;
                                        rowCheck = 5;
                                    }
                                }
                                //move on as this row will not be a winner if any cell does not have a C in it
                                else
                                {
                                    rowCheck = 5;
                                    winner = 0;
                                }
                            }
                        }
                }
            }


            
            
            //will be the puzzleAnswer of the last card that won
            Console.WriteLine("The puzzle answer is " + puzzleAnswer);
            


            watch.Stop();
            Console.WriteLine("");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        public static int calculateAnswer(string lastCalledNumber, string[,] winningBoard)
        {
            int answer = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (winningBoard[row, col][0] != 'C')
                    {
                        answer += Convert.ToInt32(winningBoard[row, col]);
                    }
                }
            }

            return (answer * Convert.ToInt32(lastCalledNumber));
        }
    }
}
