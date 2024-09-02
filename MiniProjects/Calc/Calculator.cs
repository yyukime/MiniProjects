using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Calc
{
    class Fields
    {
        static public int modeSelection = new();
        static public float inputInteger1;
        static public float inputInteger2;
        // static public ConsoleKeyInfo playAgainKeyInfo
        
    }
    class Program : Fields
    {
        static void Main(string[] args)
        {
            while (true)
            {

                
                ProgramMethod();
                

                try
                {
                    ModeSelectionMethod();
                }
                catch
                {
                    Console.Clear();
                }              
            }
        }

        static void ModeSelectionMethod()
        {
            
            modeSelection = int.Parse(Console.ReadLine()!); // dont be mean remove "!" 

            switch (modeSelection)
            {
                case 1:
                    OperatorAdd();
                    break;
                case 2:
                    OperatorDivide();
                    break;
                case 3:
                    OperatorSubtract();
                    break;
                case 4:
                    OperatorMultiply();
                    break;
                case 5:
                    OperatorDivisionRemainder();
                    break;
            }         
            Console.WriteLine("Press any key to calculate again");
            // ConsoleKeyInfo playAgainKeyInfo = Console.ReadKey();
            // ConsoleKey plaAgainKey = playAgainKeyInfo.Key(); Non-invocable Member (...) cannot be used like a method 
            Console.ReadKey();
        }

        static void ProgramMethod()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Calculator");
            Console.WriteLine();
            Console.WriteLine("This Calculator features:");
            Console.WriteLine("Addition(+) | Multiplication(*) | Division(/) | Subtraction (-) | Division Remainder (%)");
            Console.WriteLine();
            Console.WriteLine("Select your preffered mode using Numbers 1-5");
        }

        static void OperatorAdd()
        {
            Console.Clear();
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("-Addition-");
                    Console.WriteLine();
                    Console.WriteLine("Add your first Integer:");
                    inputInteger1 = float.Parse(Console.ReadLine()!);
                    break;
                }
                catch
                {
                    Console.WriteLine("Looks like your input was not a Number... ");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                }

            }

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("-Addition-");
                    Console.WriteLine();
                    Console.WriteLine("Add your second Integer:");
                    inputInteger2 = float.Parse(Console.ReadLine()!);
                    break;
                }
                catch
                {
                    Console.WriteLine("Looks like your input was not a Number... ");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();

                }

            }

            string result = Convert.ToString(inputInteger1 + inputInteger2);
            Console.WriteLine($"The result is {result}"); // should I use ("The result is" + result); ??
            // Console.ReadKey();




        }
        static void OperatorDivide()
        {

        }
        static void OperatorSubtract()
        {

        }       
        static void OperatorMultiply()
        {

        }
        static void OperatorDivisionRemainder()
        {

        }

        // static void Calculations()

    }
}




