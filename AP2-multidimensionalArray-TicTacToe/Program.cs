using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_multidimensionalArray_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************");
            Console.WriteLine("* Tic-Tac-Toe Game *");
            Console.WriteLine("********************");
            var game = new TicTacToe();
            
            Console.WriteLine("The cell numbers for the game are shown below.");
            game.Draw();
            
            Play(game);
        }

        static void Play(TicTacToe game)
        {           
            bool playAgain = true;
            while (playAgain)
            {
                game.DrawBlank();
                game.PlayTurn();

                bool invalidInput = true;
                while (invalidInput)
                {
                    try
                    {    Console.WriteLine("Would you like to play again? (y|n)");
                        char again = char.Parse(Console.ReadLine());
                        if (again == 'y')
                            invalidInput = false;

                        else if (again == 'n')
                        {
                            playAgain = false;
                            invalidInput  =false;
                            Console.WriteLine("Thank you for playing");
                        }
                        else
                            Console.WriteLine("Invalid Input. Playing again");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}. Try again");
                    }
                }
            }            
        }
    }
}