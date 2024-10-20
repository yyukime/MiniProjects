using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using Bank;
using BankUI;

namespace UI;

public class UI
{
    public static void Main() // string[] args?
    {
        // Main Menu
        do
        {
            int MainMenuInt = MainMenu();

            switch (MainMenuInt)
            {
                case 1:  bool UserLogIn = UserLoggedOutActions.LogIn(); break;
                case 2: 
                {
                    User newUser = UserLoggedOutActions.NewUser();
                    Bank.User.UserInfo(newUser);
                    Console.ReadKey();
                    break;
                }
            }
        }
        while(true);
    }

    public static (BankAccount, int) BankAccountMenu(BankAccount account)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("[1]: Money Transfer");
            Console.WriteLine("[2]: Deposit");
            Console.WriteLine("[3]: Withdraw");
            Console.WriteLine("[4]: go back");
            Console.WriteLine("--------");
            Console.Write("Selection: ");

            string? @string = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(@string)) continue;
            if (!int.TryParse(@string, out int input)) continue;
            return (account, input);
        }
        while (true);
    }

    public static int BankMenu(User loggedinUser) // only accessible if user logged in 
    {  
        do
        {
            Console.Clear();
            List<Bank.Bank> BankList = Hub.GetBanksForUser(loggedinUser);

            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");

            for (int i = 1; i < BankList.Count; i++)
            {
                Console.WriteLine($"[{i}]: {BankList[i].Name}");
            }
            Console.WriteLine($"[{BankList.Count + 1}]: exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? @string = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(@string)) continue;
            if (!int.TryParse(@string, out int input)) continue;

            return input;
        }
        while (true);
    }


    public static int MainMenu()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("[1]: Log into User");
            Console.WriteLine("[2]: Create New User");
            Console.WriteLine("[3]: exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? @string = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(@string)) continue;
            if (!int.TryParse(@string, out int input)) continue;
            return input;
        }
        while (true);
    }

}
