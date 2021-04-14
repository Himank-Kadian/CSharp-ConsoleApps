using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreportfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
            Purpose:    To make a slot machine which takes money from the user and gives back random slots. These determine how much money they made.
 
            Input:      Amount to play with. Yes/No if they want to play again.
 
            Output:     The randomized slots and if the user won or not. Total amount inserted by the user. Total amount won by the user. Net profit of the user.

            Author:           Himank Kadian 
            Last modified:    2019.10.30
            */

            Console.WriteLine("------------------------");
            Console.WriteLine("|Slot Machine Simulator|");
            Console.WriteLine("------------------------");
            int totalDeposit = 0;
            int totalWinning = 0;
            int winning = 0;
            bool playagain = true;
            while (playagain)
            {
                bool invalidInput = true;
                while (invalidInput)
                {
                    Console.Write("Enter the amount to deposit into the slot machine: ");
                    int deposit = int.Parse(Console.ReadLine());

                    if (deposit > 0)
                    {
                        invalidInput = false;
                        Random rnd = new Random();

                        int slot1 = rnd.Next(0, 5);
                        int slot2 = rnd.Next(0, 5);
                        int slot3 = rnd.Next(0, 5);

                        string word1 = "a";
                        string word2 = "b";
                        string word3 = "c";

                        // determining the word for first slot

                        if (slot1 == 0)
                        {
                            word1 = "Cherries";
                        }
                        else if (slot1 == 1)
                        {
                            word1 = "Oranges";
                        }
                        else if (slot1 == 2)
                        {
                            word1 = "Plums";
                        }
                        else if (slot1 == 3)
                        {
                            word1 = "Bells";
                        }
                        else if (slot1 == 4)
                        {
                            word1 = "Melons";
                        }
                        else
                        {
                            word1 = "Bars";
                        }

                        // determining the word for second slot

                        if (slot2 == 0)
                        {
                            word2 = "Cherries";
                        }
                        else if (slot2 == 1)
                        {
                            word2 = "Oranges";
                        }
                        else if (slot2 == 2)
                        {
                            word2 = "Plums";
                        }
                        else if (slot2 == 3)
                        {
                            word2 = "Bells";
                        }
                        else if (slot2 == 4)
                        {
                            word2 = "Melons";
                        }
                        else
                        {
                            word2 = "Bars";
                        }

                        // determining the word for third slot

                        if (slot3 == 0)
                        {
                            word3 = "Cherries";
                        }
                        else if (slot3 == 1)
                        {
                            word3 = "Oranges";
                        }
                        else if (slot3 == 2)
                        {
                            word3 = "Plums";
                        }
                        else if (slot3 == 3)
                        {
                            word3 = "Bells";
                        }
                        else if (slot3 == 4)
                        {
                            word3 = "Melons";
                        }
                        else
                        {
                            word3 = "Bars";
                        }

                        if ((slot1 == slot2) && (slot2 == slot3) && (slot3 == slot1))

                        {
                            Console.WriteLine($"{word1} {word2} {word3}");
                            Console.WriteLine($"All words match! You won 3x.");
                            winning = 3 * deposit;
                        }

                        else if ((slot1 == slot2) || (slot2 == slot3) || (slot3 == slot1))
                        {
                            Console.WriteLine($"{word1} {word2} {word3}");
                            Console.WriteLine($"Two words match. You won 2x.");
                            winning = 2 * deposit;
                        }

                        else
                        {
                            Console.WriteLine($"{word1} {word2} {word3}");
                            Console.WriteLine($"No words match. You won $0.");

                        }

                        totalDeposit = totalDeposit + deposit;
                        totalWinning = totalWinning + winning;
                    }

                    else
                        Console.WriteLine($"\"{deposit}\" is not a valid amount. Try again");
                }

                string restart = "a";
                Console.WriteLine("Do you want to play again (y/n)?");
                restart = Console.ReadLine().ToLower();

                if (restart == "n")
                {
                    playagain = false;
                    Console.WriteLine($"Total amount deposited: {totalDeposit:c2}");
                    Console.WriteLine($"Total amount won: {totalWinning:c2}");
                    Console.WriteLine($"Net gain/loss total: {(totalWinning - totalDeposit):c2}");
                }

                else if (restart == "y")
                    playagain = true;

                else
                {
                    bool tryAgain = true;
                    while (tryAgain)
                    {
                        Console.WriteLine($"\"{restart}\" is not a valid option. Please try again.");
                        Console.WriteLine("Do you want to play again (y/n)?");
                        string option = Console.ReadLine().ToLower();

                        if (option == "y")
                        {
                            tryAgain = false;
                            restart = "y";
                        }

                        else if (option == "n")
                        {
                            tryAgain = false;
                            playagain = false;
                            Console.WriteLine($"Total amount deposited: {totalDeposit:c2}");
                            Console.WriteLine($"Total amount won: {totalWinning:c2}");
                            Console.WriteLine($"Net gain/loss total: {(totalWinning - totalDeposit):c2}");
                        }
                    }
                }


            }
        }
    }
}

