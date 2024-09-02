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



            while (true)
            {
                try
                {
                    // -> user gives custom range ! 
                    // -> play again
                    // -> output what the actual guess would have been

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
            Console.WriteLine(" ");

            Console.WriteLine("Please define the input range by highest value:");
            int inputInt;
            inputInt = int.Parse(Console.ReadLine());

            Console.WriteLine($"Try to guess a number between 1 and {inputInt}:");
            string? stringInput = Console.ReadLine();
            int intInput;
            intInput = int.Parse(stringInput);

            if (TestInput(intInput))
            {
                Console.WriteLine("You guessed correctly");
                Console.WriteLine("///");
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
                Console.WriteLine("Wrong!");

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


            bool TestInput(int number)
            {

                Random randomNumber = new();
                int rNumber = randomNumber.Next(inputInt);
                if (number == rNumber) return true;

                return false;



            }


        }

    }
}

// int[] RNGNumberRange = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };
//Random rngNumber = new(); rngNumber.Next(10);

//logic:
// generate a number 
// turn user input into int
// check if input matches pre generated number

//program:
// provide basic text and request user input
// output result 
// maybe add a "play again?" button