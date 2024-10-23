using System;
using Bank;

namespace BankUI;

public class UI
{

    public static int Authenticate()
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

    public static string Template(string title, string what)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($" -- {title} -- ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"Please enter your {what}: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            if (input.Length! > 1) continue; // ?
            return input;
        }
    }

    public static string SetEmail()
    {
        do
        {
            Console.Clear();
            Console.WriteLine(" -- Create User -- ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please note: Emails are in the format name@domain.com");
            Console.WriteLine("Supported services: gmail.com | mail.yahoo.com | outlook.com");
            Console.WriteLine();
            Console.Write($"Please enter your E-Mail: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            return input;
        }
        while (true);
    }

    public static string SetPassword()
    {
        do
        {
            Console.Clear();
            Console.WriteLine(" -- Create User -- ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Requirements: Atleast one letter, atleast one capital letter, atleast 8 characters");
            Console.WriteLine();
            Console.Write($"Please enter your password: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            return input;
        }
        while (true);
    }

    public static int Actions()
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
            string? stringInput = Console.ReadLine();

            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int output)) continue;
            return output;
        }
        while (true);
    }

    public static int SelectBank(List<Bank.Bank> BanksForUser, User activeUser)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Bank -");
            Console.WriteLine();
            Console.WriteLine("--------");
            for (int i = 1; i < BanksForUser.Count; i++)
            {
                Console.WriteLine($"[{i}]: {BanksForUser[i].Name}");
            }
            Console.WriteLine($"[{BanksForUser.Count + 1}]: exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();
            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int output)) continue;
            return output;
        }
        while (true);
    }

    public static int SelectBankAccount(List<BankAccount> UserAccounts)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Bank -");
            Console.WriteLine();
            Console.WriteLine("--------");
            for (int i = 1; i < UserAccounts.Count; i++)
            {
                Console.WriteLine($"[{i}]: Account with Iban: ******{UserAccounts[i].GetShortBankAccountIBAN}");
            }
            Console.WriteLine($"[{UserAccounts.Count + 1}]: exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();
            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int output)) continue;
            return output;
        }
        while (true);
    }




}
