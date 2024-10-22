using System;
using System.Runtime.InteropServices;
using Bank;

namespace BankUI;

public class BankUI
{
    public static void Main()
    {
        MainMenu();
    }

    public static void MainMenu()
    {
        do
        {
            int selection = MainSelection();

            switch (selection)
            {
                case 1:
                    {
                        User? foundUser = MainMethods.LogIn();
                        if (foundUser == null) continue;
                                               
                        break;
                    }
                case 2:
                    {
                        User? newUser = MainMethods.CreateNewUser();
                        if (newUser == null) continue;

                        break;

                    }
            }
        }
        while (true);

    }

    public static int MainSelection()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("[1]: Log into User");
            Console.WriteLine("[2]: Create New User");
            Console.WriteLine("[3]: Exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();

            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int input)) continue;
            int[] validSelections = { 1, 2, 3 };
            if (!validSelections.Contains(input)) continue;
            return input;
        }
        while (true);
    }









}
