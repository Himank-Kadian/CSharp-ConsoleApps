using System;

namespace ConsoleApp2
 /* 
            Purpose:    To make CPSC casino which asks the user if they want to play craps, pig or exit.
 
            Input:      Main Menu : Which game to play
                        Craps     : Amount to bet, if they want to play again or not
                        Pig       : Point total to play, roll again or not

            Output:     Main Menu : Takes the user to the game they want to play, loops back after a game is done, exits the game if they wish so.
                        Craps     : Tells the user the outcome of the game. Loops if they want to play again. Gives them their net income if they exit.
                        Pig       : The user's roll(s). The computer's roll(s). The winner of the game

            Author:           Himank Kadian 
            Last modified:    13.11.2019

            NOTE: Game of Pig was coded based on the specification provided by my instructor and is not accurate with the real game's logic.
*/

{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Loop for main menu and error checking for input (Did not use try catch on string because could not find a way to make it crash so I thought it would be better to save lines of code)
            bool running = true;
            while (running)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("|      Casino      |");
                Console.WriteLine("-------------------");
                Console.WriteLine("|  1. Play Craps  |");
                Console.WriteLine("|  2. Play Pig    |");
                Console.WriteLine("|  0. Exit        |");
                Console.WriteLine("-------------------");

                bool invalidInput = true;
                while (invalidInput)
                {
                    Console.Write("Enter your choice: ");
                    string game = Console.ReadLine();

                    if (game == "1")
                    {
                        invalidInput = false;
                        GameOfCraps();
                    }

                    else if (game == "2")
                    {
                        invalidInput = false;
                        GameOfPig();
                    }

                    else if (game == "0")
                    {
                        invalidInput = false;
                        running = false;
                        Console.WriteLine("Thanks for stopping by");
                    }

                    else
                        Console.WriteLine($"{game} is not a valid input. Please try again");
                }
            }
        }

        static void GameOfCraps()
        {
            //Loop for game of craps
            Console.WriteLine("-----------------");
            Console.WriteLine("| Game of Craps |");
            Console.WriteLine("-----------------");
            int finalAmount = 0;
            bool running = true;
            while(running)
            {
                int amount = CrapsAmount();
                Random rnd = new Random();
                int sumOfRolls = CrapsRandom(rnd);

                int totalWinnings = CrapsMath(sumOfRolls, rnd, amount);
                finalAmount = finalAmount + totalWinnings;
                char again = CrapsPlayAgain();
               
                if (again == 'N')
                {
                    Console.WriteLine($"Net winning: {finalAmount:c2}");
                    running = false;
                }
                else if (again == 'Y')
                    running = true;                
            }
        }
       
        static int CrapsAmount()
        {
            //Error checking for amount input
            bool invalidInput = true;
            int amount = 0;
            while (invalidInput)
            {
                try
                {
                    Console.Write("Enter amount to bet: ");
                    amount = int.Parse(Console.ReadLine());
                    if (amount > 0)
                        invalidInput = false;
                    else
                        Console.WriteLine("Error: Number must be greater than zero.");
                }

                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return amount;
        }

        static int CrapsRandom(Random rnd)
        {
            //Randomizes 2 dice rolls and gives back the sum
            int dice1 = rnd.Next(1, 7);
            int dice2 = rnd.Next(1, 7);
            int sumOfRolls = dice1 + dice2;
            Console.WriteLine($"You rolled {dice1} + {dice2} = {sumOfRolls}");

            return sumOfRolls;
        }

        static int CrapsMath(int sumOfRolls, Random rnd, int amount)
        {
            int totalWinnings = 0;

            //Came-out-roll win or lose logic
            if (sumOfRolls == 7 || sumOfRolls == 11)
            {
                Console.WriteLine($"You won");
                totalWinnings = totalWinnings + amount;
            }

            else if (sumOfRolls == 2 || sumOfRolls == 3 || sumOfRolls == 12)
            {
                Console.WriteLine($"You lost");
                totalWinnings = totalWinnings - amount;
            }

            //Point roll win or lose login
            else
            {
                Console.WriteLine($"Point is {sumOfRolls}");
                int point = sumOfRolls;
                int temp;                                               //Using a temporary variable to grab new random values
                bool invalidInput = true;
                while (invalidInput)
                {
                    temp = CrapsRandom(rnd);
                    if (temp == 7)
                    {
                        Console.WriteLine("You lost");
                        totalWinnings = totalWinnings - amount;
                        invalidInput = false;
                    }
                    else if (temp == point)
                    {
                        Console.WriteLine("You won");
                        totalWinnings = totalWinnings + amount;
                        invalidInput = false;
                    }
                }
            }
            return totalWinnings;
        }

        static char CrapsPlayAgain()
        {
            //Error checking for play again input
            char again = '*';
            bool invalidInput = true;
            while (invalidInput)
                {
                try
                    {
                        Console.WriteLine("Would you like to play again? (Y|N)");
                        again = char.Parse(Console.ReadLine().ToUpper());

                        if (again == 'N' || again == 'Y')
                        invalidInput = false;
                        
                        else
                        Console.WriteLine("Error: Invalid input.");
                    }

                catch(Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            return again;
        }

        static void GameOfPig()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("| Game of Pig |");
            Console.WriteLine("---------------");

            PigResult();
        }

        static void PigResult()
        {
            //Gathers value from other methods and loops the game until someone wins.
            int point = PigPoint(); 
            
            int sumOfPlayer = 0;
            int sumOfComputer = 0;
            int totalPlayer = 0;    //totalPlayer variable keeps track of the value in sumOfPlayer and passes it through PigPlayer to keep it updating.
            int totalComputer = 0;  //totalComputer variable keeps track of the computer's dice's sum lets the user know if the computer won.
            bool running = true;
            while (running)
            {
                sumOfPlayer = PigPlayer(point, totalPlayer);
                totalPlayer = sumOfPlayer;

                Console.WriteLine($"\nYour turn point total is: {sumOfPlayer}\n");

                if (sumOfPlayer >= point)
                {
                    Console.WriteLine("You win!!");
                    running = false;
                }

                else
                {   
                    sumOfComputer = PigComputer(point, totalComputer);
                    totalComputer = totalComputer + sumOfComputer;
                    Console.WriteLine($"\nComputer turn point total is: {totalComputer}\n");
                    
                    if (totalComputer >= point)
                    {
                        Console.WriteLine("Computer wins");
                        running = false;
                    }
                }
            }
        }

        static int PigPoint()
        {
            //Error checking for point input
            bool invalidInput = true;
            int point = 0;
            while (invalidInput)
            {
                try
                {
                    Console.Write("Enter the point total to play for: ");
                    point = int.Parse(Console.ReadLine());
                    if (point > 0)
                        invalidInput = false;
                    else
                        Console.WriteLine("Error: Number must be greater than zero.");
                }

                catch(Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            return point;
        }

        static int PigPlayer(int point, int sumOfDice)
        {
            //Human player turn logic. Takes in the point and the current sum of the user's rolls and asks if they want to roll or hold.
            bool running = true;
            Random rnd = new Random();

            Console.WriteLine("It's your turn.");
            int dice = PigRandom(rnd);
            Console.WriteLine($"You rolled {dice}");
            sumOfDice = sumOfDice + dice;
            {
                while (running)
                {
                    try
                    {                
                        if (sumOfDice < point)
                        {
                            Console.WriteLine("Enter r to roll or h to hold (r/h):");
                            char roll = char.Parse(Console.ReadLine().ToLower());
            
                            if (roll == 'r')
                            {   
                                dice = PigRandom(rnd);
                                if (dice == 1)
                                {
                                    running = false;
                                }
                                else
                                {   
                                    sumOfDice = sumOfDice + dice;
                                    running = true;
                                }
                                Console.WriteLine($"You rolled {dice}");
                            }

                            else if (roll == 'h')
                                {
                                    Console.WriteLine("You hold.");
                                    running = false;
                                }
                            else
                                Console.WriteLine($"Error: {roll} is an invalid input.");
                        }

                        else
                            running = false;
                    }

                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }
            return sumOfDice;
        }

        static int PigComputer(int point, int totalComputer)
        {
            //Computer player turn logic. Plays until it hits 1 or the sum of rolls is =< 10 or if it has won.
            bool invalidInput = true;
            int dice = 0;
            Random rnd = new Random();
            int sumOfDice = 0;
            while (invalidInput)
            {                
                if (sumOfDice < 10 && (totalComputer + sumOfDice < point))
                {
                    dice = PigRandom(rnd);

                    if (dice == 1)
                        invalidInput = false;

                    else
                    {   
                        sumOfDice = sumOfDice + dice;
                    }
                    Console.WriteLine($"Computer rolled {dice}");
                }
                else
                    invalidInput = false;
            }
            if (dice != 1 && totalComputer + sumOfDice < point)
                Console.WriteLine($"Computer Holds");

            return sumOfDice;
        }

        static int PigRandom(Random rnd)
        {
            //Randomizes one dice roll and gives it back
            int dice = rnd.Next(1, 7);
            return dice;
        }
    }
}
