using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace NumberGuessingGame
{




    class Program
    {
        static void Main(string[] args)
        {

            // Switch statement??
            // ^ ichb indumm

            while (true)
            {
                try
                {
                    // -> user gives custom range ! 
                    // -> play again ! 

                    // -> output what the actual guess would have been HDSLKFJDSKLFSJKLFS??? 

                    RunProgram();

                }
                catch
                {
                    Console.Clear();

                }


            }

        }
        public static void RunProgram()
        {
            Console.WriteLine(" "); // elegance 100 

            Random randomNumber = new();


            Console.WriteLine("Please define the input range by highest value:");
            int inputInt;
            inputInt = int.Parse(Console.ReadLine()!); // dont want to hurt csharp feelings with ! 
            int rNumber = randomNumber.Next(inputInt);
            Console.WriteLine($"Try to guess a number between 1 and {inputInt}:");

            string? stringInput = Console.ReadLine();
            int intInput;
            intInput = int.Parse(stringInput!); // can look better ? organize 
                                                //^ I hate this


            // nach 2 Stundne > mein auge zuckt von alleine
            if (TestInput(intInput))
            {
                Console.WriteLine("You guessed correctly");
                Console.WriteLine();
                Console.WriteLine("Press 1 to play again");
                Console.WriteLine("Press any other key to exit");
                ConsoleKeyInfo playAgainKeyInfo = Console.ReadKey();
                ConsoleKey playAgainKey = playAgainKeyInfo.Key;

                if (playAgainKey == ConsoleKey.D1)
                {
                    RunProgram();
                }
                else
                {
                    Console.Clear();
                    System.Environment.Exit(0);
                }
            }
            else
            {

                Console.Clear();
                Console.WriteLine("You guessed: " + intInput); // ugly
                Console.WriteLine($"The correct input was {rNumber}"); // want organization: using class
                Console.WriteLine();
                Console.WriteLine("Press 1 to play again");
                Console.WriteLine("Press any other key to exit");
                ConsoleKeyInfo playAgainKeyInfo = Console.ReadKey();
                ConsoleKey playAgainKey = playAgainKeyInfo.Key;

                if (playAgainKey == ConsoleKey.D1)
                {
                    Console.Clear();
                    RunProgram();
                }
                else
                {
                    Console.Clear();
                    System.Environment.Exit(0);
                }
            }
            bool TestInput(int number)
            {
                if (number == rNumber) return true;
                return false;
            }
        }

    }
}

