using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_multidimensionalArray_TicTacToe
{
    public class TicTacToe
    {
        private char[,] _board = new char[3, 3];

        public char[,] Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
            }
        }

        public TicTacToe()
        {
            int count = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = count.ToString()[0];
                    count++;
                }
            }
        }

        public void Draw()
        {
            Console.WriteLine("\n-------------");
            Console.WriteLine($"| {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} |");
            Console.WriteLine("-------------");
            Console.WriteLine($"| {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]} |");
            Console.WriteLine("-------------");
        }

        public void PlayTurn()
        {
            int player = 3;
            int flag = 0;
            char token = 'X';

            do
            {
                if (player % 2 == 0)                                                    //Starts with Player X and keeps changing between Player X and Player O  
                {
                    token = 'O';
                    player++;
                }

                else
                {
                    token = 'X';
                    player++;
                }

                Console.Write($"Enter cell number (1-9) for player {token}: ");         //Puts an X or O in position taken from the user.
                int position = int.Parse(Console.ReadLine());

                if (position == 1)
                    if (Board[0, 0] == ' ')                                             //Checks if the position is blank or not.
                        {Board[0, 0] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                else if (position == 2)
                    if (Board[0, 1] == ' ')
                        {Board[0, 1] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                if (position == 3)
                    if (Board[0, 2] == ' ')
                        {Board[0, 2] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                if (position == 4)
                    if (Board[1, 0] == ' ')
                        {Board[1, 0] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                if (position == 5)
                    if (Board[1, 1] == ' ')
                        {Board[1, 1] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                if (position == 6)
                    if (Board[1, 2] == ' ')
                        {Board[1, 2] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                if (position == 7)
                    if (Board[2, 0] == ' ')
                        {Board[2, 0] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                if (position == 8)
                    if (Board[2, 1] == ' ')
                        {Board[2, 1] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }

                if (position == 9)
                    if (Board[2, 2] == ' ')
                        {Board[2, 2] = token;}
                    else
                    {
                        Console.WriteLine("Position is already taken");
                        player--;
                    }                    

                Console.WriteLine("\n-------------");
                Console.WriteLine($"| {Board[2, 0]} | {Board[2, 1]} | {Board[2, 2]} |");
                Console.WriteLine("-------------");
                Console.WriteLine($"| {Board[1, 0]} | {Board[1, 1]} | {Board[1, 2]} |");
                Console.WriteLine("-------------");
                Console.WriteLine($"| {Board[0, 0]} | {Board[0, 1]} | {Board[0, 2]} |");
                Console.WriteLine("-------------");
                Console.WriteLine("\n");
                
                flag = CheckWin();                                                          // calling of check win  

            } while (flag != 1 && flag != -1);                                              // This loop runs until either a player has won or the grid is full.

            if (flag == 1)                                                                  
                Console.WriteLine($"Player {token} has won");

            else                                                                            
                Console.WriteLine("Draw");
        }

        public void DrawBlank()                                                              // Draws a box with every position as a blank
        {
            {Board[0, 0] = ' ';}
            {Board[0, 1] = ' ';}
            {Board[0, 2] = ' ';}
            {Board[1, 0] = ' ';}
            {Board[1, 1] = ' ';}
            {Board[1, 2] = ' ';}
            {Board[2, 0] = ' ';}
            {Board[2, 1] = ' ';}
            {Board[2, 2] = ' ';}
        }

        public int CheckWin()                                                           //Checks if any player has won. Returns 1 for win, -1 for draw and 0 for neither.
        {
            if (Board[0, 0] != (' ') || Board[0, 1] != (' ') || Board[0, 2] != (' '))   //Makes sure bottom row is not empty
            {
                if (Board[0, 0] == Board[0, 1] && Board[0, 2] == Board[0, 1])           //Checks bottom row match
                    return 1; 
            }
            
            if (Board[1, 0] != (' ') || Board[1, 1] != (' ') || Board[1, 2] != (' '))   //Makes sure middle row is not empty
            {
                if (Board[1, 0] == Board[1, 1] && Board[1, 2] == Board[1, 1])           //Checks middle row match
                    return 1;
            }

            if (Board[2, 0] != (' ') || Board[2, 1] != (' ') || Board[2, 2] != (' '))   //Makes sure top row is not empty
            {
                if (Board[2, 0] == Board[2, 1] && Board[2, 2] == Board[2, 1])            //Checks bottom row match
                    return 1;
            }

            if (Board[0, 0] != (' ') || Board[1, 0] != (' ') || Board[2, 0] != (' '))   //Makes sure left column is not empty
            {
                if (Board[0, 0] == Board[1, 0] && Board[1, 0] == Board[2, 0])           //Checks left column match
                    return 1;
            }

            if (Board[0, 1] != (' ') || Board[1, 1] != (' ') || Board[2, 1] != (' '))   //Makes sure middle column is not empty
            {
                if (Board[0, 1] == Board[1, 1] && Board[1, 1] == Board[2, 1])           //Checks middle column match
                    return 1;
            }

            if (Board[0, 2] != (' ') || Board[1, 2] != (' ') || Board[2, 2] != (' '))   //Makes sure right column is not empty
            {
                if (Board[0, 2] == Board[1, 2] && Board[1, 2] == Board[2, 2])           //Checks right column match
                    return 1;
            }

            if (Board[1, 1] != (' '))                                                   //Makes sure middle box is not empty
            {
                if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])           //Checks diagonal 1
                    return 1;
                else if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])      //Checks diagonal 2
                    return 1;
            }

            if ((Board[0, 0] != ' ') &&                                                 //Makes sure no box is empty
                (Board[0, 1] != ' ') &&
                (Board[0, 2] != ' ') &&
                (Board[1, 0] != ' ') &&
                (Board[1, 1] != ' ') &&
                (Board[1, 2] != ' ') &&
                (Board[2, 0] != ' ') &&
                (Board[2, 1] != ' ') &&
                (Board[2, 2] != ' '))
                    return -1;                                                          // returns draw

            else 
                return 0;                                                               // returns 0 if no win/draw
        }
    }
}