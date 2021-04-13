using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP1_files_lists_TextProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            testMethod();
        }

        static void testMethod()
        {
            Random randNum = new Random();
            int newRandNum = 0;
            //string myDir = "temp";
            //string myFile = "test.txt";
            string myDirPath = @"C:\temp";
            string path = @"C:\temp\test.txt";

           // Console.WriteLine($"CurrentDirectory: {Environment.CurrentDirectory}\n");
           // Console.WriteLine($"SystemDirectory: {Environment.SystemDirectory}\n");
           // Console.WriteLine($"TempDirectory: {Environment.GetEnvironmentVariable("TEMP")}\n");

            //string fname = Path.Combine(Directory.GetCurrentDirectory(), "test.txt");
            if(Directory.Exists(myDirPath))
            {
             //   Console.WriteLine($"{myDirPath} is a valid directory\n");
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("program");
                    sw.WriteLine("loop");
                    sw.WriteLine("break");
                    sw.WriteLine("for");
                    sw.WriteLine("list");
                    sw.WriteLine("method");
                    sw.WriteLine("property");
                }
                
            }

            List<string> wordsInFile = new List<string>();
            List<char> charsInWord = new List<char>();
            List<char> guess = new List<char>();
            char guessLetter = '*';
            int wordCount = 0;

            // check if File exists
            if (File.Exists(path))
            {
                
                StreamReader reader = new StreamReader(path);
                string curLine;
                while ((curLine = reader.ReadLine()) != null)
                { 
                    wordsInFile.Add(curLine);
                }
                reader.Close();

                Console.WriteLine("------------------------------");
                Console.WriteLine("|    CPSC1012 Hnagman Game   |");
                Console.WriteLine("------------------------------");
                bool playagain = true;
                while (playagain)
                {
                    Console.WriteLine("I have picked a random word on programming.");
                    Console.WriteLine("Your task is to guess the correct word\n");

                    newRandNum = RandomNumber(randNum, wordsInFile.Count);
                    string data = wordsInFile[newRandNum];
                    charsInWord.AddRange(data);
                    for (int i = 0; i < charsInWord.Count; i++)
                    {
                        guess.Add('*');
                    }

                    //code for ap
                    bool invalidInput = true;
                    while (invalidInput)
                    {   
                        try
                        {
                            Console.Write($"Guess the letter ");

                            for (int i = 0; i < guess.Count; i++)
                            {
                                Console.Write($"{guess[i]}");
                            }

                            Console.Write(" > ");
                            guessLetter = char.Parse(Console.ReadLine());

                            if (guess.Contains(guessLetter))
                                Console.WriteLine($"{guessLetter} is already in the word");

                            else
                            {
                                if (charsInWord.Contains(guessLetter))
                                {
                                    for (int i = 0; i < guess.Count; i++)
                                    {
                                        if (guessLetter == charsInWord[i])
                                            guess[i] = guessLetter;
                                        else
                                        {    
                                            if (guess[i] == '*')
                                                invalidInput = true;
                            
                                            else
                                                invalidInput = false;
                                        }
                                    }
                                }

                                else
                                {
                                    Console.WriteLine($"{guessLetter} is not in the word");
                                    wordCount = wordCount + 1;
                                }
                            }   
                        }

                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message} Try again.");
                        }
                    }
                    Console.WriteLine($"\nThe word is {data}.");
                    Console.WriteLine($"You missed {wordCount} time(s)");
                    invalidInput = true;
                    guess.Clear();
                    charsInWord.Clear();
                    wordCount = 0;
                    
                    while (invalidInput)
                    {
                        try
                        {
                            Console.WriteLine($"Do you want to play again? (y/n)");
                            char again = char.Parse(Console.ReadLine());
                            if (again == 'y')
                                invalidInput = false;
                            else if (again == 'n')
                            {
                                invalidInput = false;
                                playagain = false;
                                Console.WriteLine("Thank you for playing");
                            }
                            else
                                Console.WriteLine("Invalid input. Try again");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message} Try again.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"The filename {path} does not exist.");
            }

        }

        static int RandomNumber(Random randNum, int wordsInFile)
        {
            int newRandNum = randNum.Next(0, wordsInFile - 1);

            return newRandNum;
        }
    }
}
