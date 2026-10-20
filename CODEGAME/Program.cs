using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CODEGAME
{
    internal class Program
    {
        static string SecretNumber;
        static string Answer;
        static List<string> GuessHistory = new List<string>();
        static List<int> CorrectNumberHistory = new List<int>();
        static List<int> CorrectPositionHistory = new List<int>();

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== Welcome to CODEGAME! =====");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nWould you like to play? (Y/N): ");
                string choice = Console.ReadLine().ToUpper();
                Console.ResetColor();

                if (choice == "Y")
                {
                    GetSecretNumber();
                    Game();
                }

                else if (choice == "N")
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("===== Thank you for playing! =====");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nPress any key to end");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid input. Press any key to try again");
                    Console.ResetColor();
                    Console.ReadKey();
                }

            }
        }

        static void Game()
        {
            int maxAttempts = 6;
            int attempts = 0;
            int CorrectPosition = 0;
            int CorrectNumber = 0;

            GuessHistory.Clear();
            CorrectNumberHistory.Clear();
            CorrectPositionHistory.Clear();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("===== Welcome to CODEGAME! =====");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("   GUESS THE SECRET NUMBER\n");
                Console.WriteLine("Rules: Answer should be 3 digits long");
                Console.WriteLine("       Only type digits from 1 to 6");
                Console.WriteLine("       Do not type repeating numbers such as 313 or 444\n");
                Console.WriteLine($"Attempts Left: {maxAttempts - attempts}/{maxAttempts}");
                Console.WriteLine($"Correct Numbers: {CorrectNumber}");
                Console.WriteLine($"Correct Positions: {CorrectPosition}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] History");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter your number (Enter 1 to check history): ");
                Console.ResetColor();

                Answer = Console.ReadLine();

                if (Answer == "1")
                {
                    History();
                    continue;
                }

                if (Answer.Length != 3 ||
                    Answer[0] < '1' || Answer[0] > '6' ||
                    Answer[1] < '1' || Answer[1] > '6' ||
                    Answer[2] < '1' || Answer[2] > '6' ||
                    Answer[0] == Answer[1] ||
                    Answer[0] == Answer[2] ||
                    Answer[1] == Answer[2])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid guess!");
                    Console.WriteLine("Enter 3 different digits from 1 to 6.");
                    Console.WriteLine("Press any key to try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                CorrectNumber = CorrectNumberValidation();
                CorrectPosition = CorrectPositionValidation();

                GuessHistory.Add(Answer);
                CorrectNumberHistory.Add(CorrectNumber);
                CorrectPositionHistory.Add(CorrectPosition);

                attempts++;

                if (Answer == SecretNumber)
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You have guessed the secret number!");
                    Console.WriteLine($"The secret number was {SecretNumber}!");
                    Console.WriteLine("Press any key to end");
                    Console.ReadKey();
                    break;
                }

                if (attempts >= maxAttempts)
                {
                    Console.Clear();
                    Console.WriteLine("MAX ATTEMPTS REACHED");
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine($"The secret number was {SecretNumber}!");
                    Console.WriteLine("Press any key to end");
                    Console.ReadKey();
                    break;
                }

            }
        }

        static void History()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========== GUESS HISTORY ==========");
                Console.ResetColor();

                if (GuessHistory.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nNo guesses recorded yet.");
                    Console.ResetColor();
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    for (int i = 0; i < GuessHistory.Count; i++) 
                    {
                        Console.WriteLine($"Guess: {GuessHistory[i]} | " +
                            $"Correct Numbers: {CorrectNumberHistory[i]} | " +
                            $"Correct Positions: {CorrectPositionHistory[i]}");
                    }
                    Console.ResetColor();
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[0] Return to Game");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter your choice: ");
                Console.ResetColor();

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Press any key to try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }

        static void GetSecretNumber()
        {
            Random random = new Random();

            int secNum1 = random.Next(1, 7);
            int secNum2;
            int secNum3;

            do
            {
                secNum2 = random.Next(1, 7);
            }
            while (secNum2 == secNum1);

            do
            {
                secNum3 = random.Next(1, 7);
            }
            while (secNum3 == secNum1 || secNum3 == secNum2);

            SecretNumber = $"{secNum1}{secNum2}{secNum3}";
        }

        static int CorrectNumberValidation()
        {
            int CorrectNumber = 0;
            for (int i = 0; i < SecretNumber.Length; i++) 
            {
                for (int j = 0; j < SecretNumber.Length; j++)
                {
                    if (Answer[j] == SecretNumber[i])
                    {
                        CorrectNumber++;
                    }
                }
            }

            return CorrectNumber;
        }

        static int CorrectPositionValidation()
        {
            int CorrectPosition = 0;
            for (int i = 0; i < SecretNumber.Length; i++)
            {
                if (Answer[i] == SecretNumber[i])
                {
                    CorrectPosition++;
                }
            }

            return CorrectPosition;
        }
    }
}
