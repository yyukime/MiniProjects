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
        int MainMenuSelection = MainMenu();

        User? ActiveUser = MainMenuLoop(MainMenuSelection);
        if (ActiveUser == null) throw new Exception("Kill yourself");
    }
    public static User? MainMenuLoop(int MainMenuSelection)
    {
        int[] validSelections = {1, 2, 3};
        if(!validSelections.Contains(MainMenuSelection)) throw new Exception("Selection Input not valid");
        switch (MainMenuSelection)
        {
            case 1:
                {
                    (User? thisRealUser, bool UserLogIn) = MainMenuActions.LogIn();
                    if (UserLogIn == false || thisRealUser == null) throw new Exception("Account LogIn failed. User does not Exist or Password || Email is wrong");
                    return thisRealUser;
                }
            case 2:
                {
                    User newUser = MainMenuActions.NewUser();
                    Bank.User.UserInfo(newUser);
                    return newUser;
                }
            case 3: MainMenuActions.Exit(); return null;
        }
        return null;
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
            Console.WriteLine("[3]: Exit");
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
