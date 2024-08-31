using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    class Program
    {


        static void Main()
        {

            while (true)
            {
                try
                {

                    RunProgram();
                    break;

                }
                catch
                {
                    Console.Clear();
                    // Wanted to Console.Writeline($"Your input {stringInput} is not a number, therefore I cant check if its a prime number"); BUT {stringInput} -> not available in context... Why?
                }



            }
        }

        private static void RunProgram()
        {
            Console.WriteLine("Input a number to check if it is a prime number:");
            string? stringInput = Console.ReadLine();
            int input;
            input = int.Parse(stringInput);

            if (Logic(input))
            {
                Console.WriteLine("The Number is a prime number");
            }
            else
            {
                Console.WriteLine("The Number is NOT a prime number"); // Could use String interpolation: Console.WriteLine($"The Number {checkNumber} is Not a prime number");
            }
        }

        static bool Logic(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }     
    }    
}

