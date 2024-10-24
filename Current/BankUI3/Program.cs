using System;

namespace BankUI3;

public class Program
{
    public static void Main()
    {



    }


    public static int Menu1()
    {
        Console.WriteLine("[Layer1]")
        Console.WriteLine("[1] select Bank")
        Console.WriteLine("[2] Register with Bank")
        int input = int.Parse(Console.ReadLine())
        return input;
    }
    public static void Interpreter1()
    {
        int input = Layer1Input();

        switch (input)
        {
            case 1:
                {
                    // call method select Bank;
                    // Method selectBank has either (bank, bool) or returns null when back is selected
                    // if selectBank == back = restart this method
                    // ONLY works if using 2 methods OR when using 2 Loops
                    break;
                }
            case 2:
                {
                    // call method register with Bank
                    break;
                }
        }
    }


    public static (string, void) SelectBank()
    {
        int input;
        do
        {

            Console.WriteLine("Please select Bank:")
            Console.WriteLine("[1] Bank1"); // Maybe call method that does this?
            Console.WriteLine("[2] Bank2"); //
            Console.WriteLine("[3] back");
            input = int.Parse(Console.ReadLine());
            // ...

            // if input == back
            return;


            // if input is valid 
            break;
        }
        

        switch (input)
        {
            case 1: 
            {
                // call SelectBankAccount Method
                // if method returns null or bool 
                return;
            }
        }



    }
}
