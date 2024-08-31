using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace NumberGuessingGame
{


    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    // -> user gives custom range
                    // -> play again
                    // -> output what the actual guess would have been
                    
                    RunProgram();
                    break;
                }
                catch
                {
                    Console.Clear();
                }
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void RunProgram()
        {
            Console.WriteLine("Try to guess a number between 1 and 10");
            string? stringInput = Console.ReadLine();
            int intInput;
            intInput = int.Parse(stringInput);

            if (TestInput(intInput))
            {
                Console.WriteLine("You guessed correctly");
            }
            else
            {
                Console.WriteLine("WRONG!");
            }

            static bool TestInput(int number)
            {
                Random randomNumber = new Random();
                int rNumber = randomNumber.Next(10);
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