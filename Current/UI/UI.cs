using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
            int[] valid = [1, 2, 3];
            if (!valid.Contains(input)) continue;
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

    public static int SelectAction()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("[1]: Transfer");
            Console.WriteLine("[2]: Deposit");
            Console.WriteLine("[3]: Withdraw");
            Console.WriteLine("[4]: go back");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();
            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int output)) continue;
            int[] valid = [1, 2, 3, 4];
            if (!valid.Contains(output)) continue;
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
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();
            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int output)) continue;
            if (output > BanksForUser.Count || output < 1) continue;
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
            Console.WriteLine($"[b]: go back");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stringInput)) continue;
            string trim = stringInput.Trim();
            if (trim == "b") return -1;
            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int output)) continue;
            if (output > UserAccounts.Count || output < 1) continue;
            return output;
        }
        while (true);
    }

    public static (decimal, string, bool) Deposit() // rebuild // add no -1
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Please enter the amount, or [b] to go back: "); // currently pin CAN BE 1;
            string? stringAmount = Console.ReadLine();
            if (stringAmount == "b") return (1, "b", true);
            if (!decimal.TryParse(stringAmount, out decimal amount)) continue;

            Console.Clear();
            Console.Write("Please enter your pin, or [b] to change the amount: ");
            string? pin = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pin)) continue;
            if (pin == "b") continue;

            return (amount, pin, false);
        }
    }

    public static (decimal, bool) EnterAmount()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Please enter the amount, or [b] to go back: ");
            string? stringAmount = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stringAmount)) continue;
            string trim = stringAmount.Trim();
            if (trim == "b") return (-1, true);
            if (!decimal.TryParse(stringAmount, out decimal amount)) continue;
            if (amount <= 0) continue;
            return (amount, false);
        }
    }

    public static string? EnterIBAN()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Please enter the receivers IBAN or [b] to go back");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            string trim = input.Trim();
            if (trim == "b") return null;


            if (input.Length != 11) continue;
            return input;


            // 1234 [-] 123456
        }
    }

    public static string EnterPin()
    {
        do
        {
            Console.Clear();
            Console.Write("Please enter your pin: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            return input;
        }
        while (true);
    }

}
