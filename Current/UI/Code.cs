using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security;
using System.Text.RegularExpressions;
using Bank;

namespace UI;

public class Code
{
    public static void Main() // string[] args?
    {
        //...
        // maybe add islogged in to user? 
        // why would multiple users exist? 
        // realistically if this is a atm --> user has to log into 
    }

    public static void SpawnUser()
    {
        string password = SetPassword();
        string email = SetEmail();

        // firstname + lastname
        string firstname = Txt("first name");
        string lastname = Txt("last name");

        if (firstname.Any(char.IsDigit)) throw new Exception("goofy name");
        if (lastname.Any(char.IsDigit)) throw new Exception("goofy lastname");

        User user = new(firstname, lastname, email, password);
        Hub.AllUsers.Add(user);
    }

    public static string SetPassword()
    {
        bool ok = false;

        string? input = Txt("password");

        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("input is null");
        if (input.Length < 8) throw new ArgumentException("Password too short");

        char[] result = input.ToCharArray();

        foreach (char c in result)
        {
            if (!char.IsUpper(c)) continue;
            ok = true;
            break;
        }
        if (!ok) throw new ArgumentException("no capital or no letters");
        return input;
    }

    public static string SetEmail()
    {
        bool supportedbool = false;

        string[] supported = { "gmail.com", "mail.yahoo.com", "outlook.com" };
        string email = EmailTxt("Email");
        string[] split = email.ToLower().Split("@");

        foreach (string s in supported)
        {
            if (!split.Contains(s)) continue;
            supportedbool = true;
        }
        if (!supportedbool) throw new ArgumentException("Unsupported Email or Wrong Format");

        return email;
    }

    public static string Txt(string what)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(" -- Create User -- ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"Please enter your {what}: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            return input;
        }
    }

    public static string EmailTxt(string what)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(" -- Create User -- ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please note: Emails are in the format name@domain.com");
            Console.WriteLine("Supported services: gmail.com | mail.yahoo.com | outlook.com");
            Console.WriteLine();
            Console.Write($"Please enter your {what}: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            return input;
        }
    }

    public static string PasswordTxt(string what)
    {
        do
        {
            Console.Clear();
            Console.WriteLine(" -- Create User -- ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Requirements: Atleast one letter, atleast one capital letter, atleast 8 characters");
            Console.WriteLine();
            Console.Write($"Please enter your {what}: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            return input;
        }
        while(true);
    }

    public static void LogInUser()
    {
        // TODO : Fancy up console.writeline(); ! 
        string? pswdInput;
        string? emailInput;

        do
        {
            Console.Clear();
            Console.Write("Password:");
            pswdInput = Console.ReadLine();
            Console.Write("Email:");
            emailInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pswdInput) || string.IsNullOrWhiteSpace(emailInput)) continue; // Can do this shorter? Too lazy to look up 
            break;
        }
        while(true);
    }

    public static int BankAccountMenu()
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
            return input;
        }
        while (true);
    }

    public static int BankMenu()
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("[1]: Log in");
            Console.WriteLine("[2]: Create new Bank Account");
            Console.WriteLine("[3]: Delete Bank Account"); // If deleted: Money transfers in another account (selected) or gets 'withdrawn' (deleted)
            Console.WriteLine("[4]: go back");
            Console.WriteLine("--------");
            Console.Write("Selection: ");

            string? @string = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(@string)) continue;
            if (!int.TryParse(@string, out int input)) continue;
            return input;

        }
        while (true);
    }

    public static int UserLoggedInMenu(User loggedinUser) // either give user or have user log in 
    {
        // If User is logged in        
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

    public static int UserLoggedOutMenu()
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
