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
        static void Main(string[] args)
        {
            GetSecretNumber();
            int maxAttempts = 6;
            int attempts = 0;
            int CorrectPosition = 0;
            int CorrectNumber = 0;

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Welcome to CODEGAME!");
                Console.WriteLine("GUESS THE SECRET NUMBER");
                Console.WriteLine($"Attempts Left: {attempts}/6");
                Console.WriteLine($"Correct Numbers: {CorrectNumber}");
                Console.WriteLine($"Correct Positions: {CorrectPosition}");
                Console.WriteLine($"Your Previous Answer: {Answer}");
                Console.Write("\nEnter your number: ");
                Answer = Console.ReadLine();

                if (Answer != SecretNumber)
                {
                    attempts++;
                    CorrectNumber = CorrectNumberValidation();
                    CorrectPosition = CorrectPositionValidation();
                    
                    if (attempts >= maxAttempts)
                    {
                        Console.Clear();
                        Console.WriteLine("MAX ATTEMPTS REACHED");
                        Console.WriteLine("GAME OVER");
                        Console.WriteLine("Press any key to end");
                        Console.ReadKey();
                        break;
                    }
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You have guessed the secret number!");
                    Console.WriteLine($"The secret number was {SecretNumber}!");
                    Console.WriteLine("Press any key to end");
                    Console.ReadKey();
                    break;
                }
            }
        }

        static void GameMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to CODEGAME!");
                Console.Write("Would you like to play? (Y/N)");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "Y")
                {

                }

                else if (choice == "N")
                {
                    Console.WriteLine("");
                }

                else
                {
                    Console.WriteLine("Invalid input. Press any key to try again");
                    Console.ReadKey();
                }

            }
           

        }

        static void GetSecretNumber()
        {
            Random num1 = new Random();
            Random num2 = new Random();
            Random num3 = new Random();
            int secNum1;
            int secNum2;
            int secNum3;

            secNum1 = num1.Next(1, 6);
            while (true)
            {
                secNum2 = num2.Next(1, 6);

                if (secNum2 == secNum1)
                {
                    secNum2 = num2.Next(1, 6);
                }

                else
                {
                    break;
                }
            }

            while (true)
            {
                secNum3 = num3.Next(1, 6);

                if (secNum3 == secNum1 || secNum3 == secNum2)
                {
                    secNum3 = num3.Next(1, 6);
                }

                else
                {
                    break;
                }
            }

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
