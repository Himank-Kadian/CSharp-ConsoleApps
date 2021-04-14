using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
            Purpose:    To make CPSC Lotto Centre which asks the user if they want to play/change numbers for the games or exit.
 
            Input:      Main Menu                           : Which numbers to change or which game to play
                        Change Lotto MAX or 6/49            : If they want to generate it automatically or manually. Enter the numbers if manually.
                        
            Output:     Main Menu                           : Takes the user to the game they want to play or numbers they want to change, loops back after a game is done, exits the game if they wish so.
                        Change Lotto MAX or 6/49 or EXTRA   : Shows the new numbers to the user
                        Lotto MAX or Lotto EXtra            : Shows the user the current numbers, their numbers and their prize.

            Author:           Himank Kadian 
            Last modified:    16.11.2019
*/

namespace CorePortfolio5_Himank_Kadian
{
    class Program
    {
        static void Main(string[] args)
        {
            //Loops the initial options and takes the user to their option.
            bool invalidInput = true;
            int[] lottoMax = new int [8];
            int[] lotto649 = new int [7];
            int[] lottoExtra = new int [7];
            (lottoMax, lotto649, lottoExtra) = FirstNumbers();      //Used to get initial values for each game. Would suggest to look into it at the end
            while(invalidInput)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("|               Lotto Centre              |");
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("| 1. Change Lotto MAX winning numbers     |");
                Console.WriteLine("| 2. Change Lotto 6/49 winning numbers    |");
                Console.WriteLine("| 3. Change Lotto Extra winning numbers   |");
                Console.WriteLine("| 4. Play Lotto MAX                       |");
                Console.WriteLine("| 5. Play Lotto 6/49                      |");
                Console.WriteLine("| 0. Exit Program                         |");
                Console.WriteLine("-------------------------------------------");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    Console.Write("\n");

                    if (choice == 1)
                       lottoMax = LottoMaxNumbers(lottoMax);
                    else if (choice == 2)
                       lotto649 = Lotto649Numbers(lotto649);
                    else if (choice == 3)
                       lottoExtra =  LottoExtraNumbers(lottoExtra);
                    else if (choice == 4)
                        LottoMax(lottoMax, lottoExtra);
                    else if (choice == 5)
                        Lotto649(lotto649, lottoExtra);
                    else if (choice == 0)
                        invalidInput = false;
                    else
                        Console.WriteLine("Error: Invalid Input");
                }

                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static int[] LottoMaxNumbers(int[] lottoMax)
        {
            //Changes the winning numbers for Lotto MAX
            int lottoCount = 7;
            LottoPrint("The current winning numbers are: ", lottoMax, lottoCount);
            lottoMax = new int[50];

            for (int i = 1; i <= lottoMax.Length; i++)
                lottoMax[i-1] = i;

            Random rnd = new Random();
            lottoMax = LottoRandom(rnd, lottoMax);
            
            Console.Write("Would you like to generate or enter winning numbers (g/e): ");
            bool invalidInput = true;
            while(invalidInput)
            {
                try
                {
                    char generate = char.Parse(Console.ReadLine());
                    if (generate == 'g')
                    {
                        lottoMax = LottoRandom(rnd, lottoMax);
                        LottoPrint("The new Lotto MAX winning numbers are: ", lottoMax, lottoCount);
                        Console.Write("\n");
                        invalidInput = false;
                    }

                    else if (generate == 'e')
                    {
                        for (int i = 0; i < lottoCount; i++)
                        {   
                            Console.Write($"Enter number #{i+1}: ");
                            lottoMax[i] = int.Parse(Console.ReadLine());
                        }
                        Console.Write($"Enter bonus number: ");
                        lottoMax[8] = int.Parse(Console.ReadLine());

                        LottoPrint("The new Lotto MAX winning numbers are: ", lottoMax, lottoCount);
                        Console.Write("\n");
                        invalidInput = false;
                    }

                    else
                        Console.WriteLine($"Error: Invalid input");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return lottoMax;
        }

        static int[] LottoRandom(Random rnd, int[] lotto)
        {
            //Randomizes numbers for all three game types
            for (int i = 0; i < lotto.Length; i++)
            {
                int num = rnd.Next(lotto.Length);

                int tmp = lotto[i];
                lotto[i] = lotto[num];
                lotto[num] = tmp;
            }
            return lotto;
        }

        static int LottoPrint(string prompt, int[] lotto, int lottoCount)
        {
            //Prints out the current/new numbers for Lotto MAX and Lotto 6/49
            Console.Write($"{prompt}");
            for (int i = 0; i < lottoCount; i++)
            {
                int num = lotto[i];
                Console.Write($"{num}, ");                
            }

            int bonus = lotto[lottoCount + 1];
            Console.Write($"(Bonus: {bonus})\n");

            return bonus;
        }

        static int[] Lotto649Numbers(int[] lotto649)
        {
            //Changes the winning numbers for Lotto 6/49
            int lottoCount = 6;
            LottoPrint("The current winning numbers are: ", lotto649, lottoCount);
            lotto649 = new int[49];

            for (int i = 1; i <= lotto649.Length; i++)
                lotto649[i-1] = i;

            Random rnd = new Random();
            lotto649 = LottoRandom(rnd, lotto649);
           
            Console.Write("Would you like to generate or enter winning numbers (g/e): ");
            bool invalidInput = true;
            while(invalidInput)
            {
                try
                {
                    char generate = char.Parse(Console.ReadLine());
                    if (generate == 'g')
                    {
                        lotto649 = LottoRandom(rnd, lotto649);
                        LottoPrint("The new Lotto MAX winning numbers are: ", lotto649, lottoCount);
                        Console.Write("\n");
                        invalidInput = false;
                    }

                    else if (generate == 'e')
                    {
                        for (int i = 0; i < lottoCount; i++)
                        {   
                            Console.Write($"Enter number #{i+1}: ");
                            lotto649[i] = int.Parse(Console.ReadLine());
                        }
                        Console.Write($"Enter bonus number: ");
                        lotto649[7] = int.Parse(Console.ReadLine());

                        LottoPrint("The new Lotto MAX winning numbers are: ",lotto649, lottoCount);
                        Console.Write("\n");
                        invalidInput = false;
                    }

                    else
                        Console.WriteLine($"Error: Invalid input");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return lotto649;
        }

        static int[] LottoExtraNumbers(int[] lottoExtra)
        {
            //Changes the winning numbers for Lotto Extra
            int lottoCount = 7;
            LottoExtraPrint("The current lotto extra number is: ", lottoExtra, lottoCount);

            lottoExtra = new int[10];

            for (int i = 0; i < lottoExtra.Length; i++)
                lottoExtra[i] = i;

            Random rnd = new Random();
            lottoExtra = LottoRandom(rnd, lottoExtra);
            
            Console.Write("\n");

            lottoExtra = LottoRandom(rnd, lottoExtra);
            LottoExtraPrint("The new lotto extra number is: ", lottoExtra, lottoCount);
            
            return lottoExtra;
        }

        static void LottoExtraPrint(string prompt, int[] lotto, int lottoCount)
        {
            //Prints the current/new winning numbers for Lotto Extra
            Console.Write($"{prompt}");
            for (int i = 0; i < lottoCount; i++)
            {
                int num = lotto[i];
                Console.Write($"{num}");                
            }
            Console.Write("\n");
        }

        static void LottoMax(int[] lotto, int[] lottoEx)
        {
            //Plays the whole LottoMax game
            int lottoCount = 7;
            int bonus = LottoPrint("The current winning numbers are: ", lotto, lottoCount);
            LottoExtraPrint("The current lotto extra number is: ", lottoEx, lottoCount);

            int[] lottoPlayer = new int[50];

            for (int i = 1; i <= lottoPlayer.Length; i++)
                lottoPlayer[i-1] = i;

            int[] lottoExtra = new int[10];
            for (int i = 0; i < lottoExtra.Length; i++)
                lottoExtra[i] = i;

            Random rnd = new Random();
            lottoPlayer = LottoRandom(rnd, lottoPlayer);
            lottoExtra = LottoRandom(rnd, lottoExtra);
            int playerBonus = LottoPrint("Your current lotto max quick pick numbers are: ", lottoPlayer, lottoCount);
            LottoExtraPrint("Your current lotto extra quick pick numbers are: ", lottoExtra, lottoCount);

            int match = LottoMatch(lotto, lottoPlayer, lottoCount);
            int extraMatch = LottoExtraMatch(lottoEx, lottoExtra, lottoCount);
            LottoMaxResult(match, extraMatch, bonus, playerBonus);
        }

        static void Lotto649(int[] lotto , int[] lottoEx)
        {
            //Plays the whole Lotto 6/49 game
            int lottoCount = 6;
            int lottoExtraCount = 7;
            int bonus = LottoPrint("The current winning numbers are: ", lotto, lottoCount);
            LottoExtraPrint("The current lotto extra number is: ", lottoEx, lottoExtraCount);

            int[] lottoPlayer = new int[49];

            for (int i = 1; i <= lottoPlayer.Length; i++)
                lottoPlayer[i-1] = i;

            int[] lottoExtra = new int[10];
            for (int i = 0; i < lottoExtra.Length; i++)
                lottoExtra[i] = i;

            Random rnd = new Random();
            lottoPlayer = LottoRandom(rnd, lottoPlayer);
            lottoExtra = LottoRandom(rnd, lottoExtra);
            int playerBonus = LottoPrint("Your current lotto 6/49 quick pick numbers are: ", lottoPlayer, lottoCount);
            LottoExtraPrint("Your current lotto extra quick pick numbers are: ", lottoExtra, lottoExtraCount);

            int match = LottoMatch(lotto, lottoPlayer, lottoCount);
            int extraMatch = LottoExtraMatch(lottoEx, lottoExtra, lottoExtraCount);
            Lotto649Result(match, extraMatch, bonus, playerBonus);
        }

        static int LottoMatch(int[] lotto, int[] lottoPlayer, int lottoCount)
        {
            //Checks the matches for Lotto MAX and Lotto 6/49
            int match = 0;
            for (int i = lottoCount-1; i >= 0; i--)    
            {
                for (int x = lottoCount-1; x>= 0; x--)
                if (lotto[i] == lottoPlayer[x])
                match = match + 1;
            }

            return match;
        }

        static int LottoExtraMatch(int[] lotto, int[] lottoPlayer, int lottoCount)
        {
            //Checks the matches for Lotto Extra
            int match = 0;

            for (int i = lottoCount-1; i >= 0; i--)    
            {
                if (lotto[i] == lottoPlayer[i])
                match = match + 1;
                else
                    i = -1;
            }

            return match;
        }

        static void Lotto649Result(int match, int extraMatch, int bonus, int playerBonus)
        {
            //Finds the result for Lotto 6/49 and prints the prize for Lotto 6/49 and Lotto Extra
            string prize = "";
            switch(match)
            {
                case 2:
                    if (bonus == playerBonus)
                        prize = "$5";
                    else
                        prize = "Free Play";
                    break;

                case 3:
                    prize = "$10";
                    break;

                case 4:
                    prize = "Share of 9.5% of the Pools Fund";
                    break;

                case 5:
                    if (bonus == playerBonus)
                        prize = "Share of 6% of the Pools Fund";
                    else
                        prize = "Share of 5% of the Pools Fund";
                    break;
                case 6:
                    prize = "Win or share Jackpot(79.5% of the Pools Fund)";
                    break;

                default:
                    prize = "Nothing :(";
                    break;
            }
            string extraPrize = LottoExtraResult(extraMatch);
            Console.Write($"\nYour Lotto Max match: {match}\n");
            Console.Write($"Your Lotto Max prize: {prize}\n");
            Console.Write($"Your Lotto Extra match: {extraMatch} digits\n");
            Console.Write($"Your Lotto Extra prize: {extraPrize}\n\n");
        }

        static void LottoMaxResult(int match, int extraMatch, int bonus, int playerBonus)
        {
            //Finds the result for Lotto Max and prints the prize for Lotto MAX and Lotto Extra
            string prize = "";
            switch(match)
            {
                case 3:
                    if (bonus == playerBonus)
                        prize = "$20";
                    else
                        prize = "Free Play";
                    break;

                case 4:
                    if (bonus == playerBonus)
                        prize = "Share of 2.75% of Pools Fund";
                    else
                        prize = "$20";
                    break;

                case 5:
                    if (bonus == playerBonus)
                        prize = "Share of 1.5% of Pools Fund";
                    else
                        prize = "Share of 3.5% of Pools Fund";
                    break;

                case 6:
                    if (bonus == playerBonus)
                        prize = "Share of 2.5% of the Pools Fund";
                    else
                        prize = "Share of 2.5% of the Pools Fund";
                    break;

                case 7:
                    prize = "Win or share Jackpot of at least $10 Million or 87.25% of Pools Fund";
                    break;

                default:
                    prize = "Nothing :(";
                    break;
            }

            string extraPrize = LottoExtraResult(extraMatch);
            Console.Write($"\nYour Lotto 6/49 match: {match}\n");
            Console.Write($"Your Lotto 6/49 prize: {prize}\n");
            Console.Write($"Your Lotto Extra match: {extraMatch} digits\n");
            Console.Write($"Your Lotto Extra prize: {extraPrize}\n\n");
        }

        static string LottoExtraResult(int extraMatch)
        {
            //Finds the result and prize for Lotto extra and sends it back to print it out
            string prize = "";
            switch(extraMatch)
            {
                case 1:
                    prize = "$2";
                    break;

                case 2:
                    prize = "$10";
                    break;;

                case 3:
                    prize = "$50";
                    break;

                case 4:
                    prize = "$100";
                    break;

                case 5:
                    prize = "$1,000";
                    break;

                case 6:
                    prize = "$100,000";
                    break;

                case 7:
                    prize = "$250,000";
                    break;

                default:
                    prize = "Nothing :(";
                    break;
            }
            return prize;
        }

        static (int[], int[], int[]) FirstNumbers()
        {
            int[] lottoMax = new int[50];

            for (int i = 1; i <= lottoMax.Length; i++)
                lottoMax[i-1] = i;

            Random rnd = new Random();
            lottoMax = LottoRandom(rnd, lottoMax);

            int[] lotto649 = new int[49];

            for (int i = 1; i <= lotto649.Length; i++)
                lotto649[i-1] = i;

            rnd = new Random();
            lotto649 = LottoRandom(rnd, lotto649);

            int[] lottoExtra = new int[10];

            for (int i = 0; i < lottoExtra.Length; i++)
                lottoExtra[i] = i;

            rnd = new Random();
            lottoExtra = LottoRandom(rnd, lottoExtra);

            return (lottoMax, lotto649, lottoExtra);
        }
    }
}