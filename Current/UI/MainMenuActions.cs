using System;
using Bank;
using UI;

namespace BankUI;

public class MainMenuActions
{
    public static (User?, bool) LogIn()
    {
        string? pswdInput;
        string? emailInput;
        do
        {
            Console.Clear();
            Console.WriteLine("- Log in -");
            Console.WriteLine();
            Console.Write("Password:");
            pswdInput = Console.ReadLine();
            Console.Write("Email:");
            emailInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pswdInput) || string.IsNullOrWhiteSpace(emailInput)) continue; // Can do this shorter? Too lazy to look up 
            break;
        }
        while (true);
        return Bank.User.LogIn(pswdInput, emailInput);
    }

    public static User NewUser()
    {
        string password = SetPassword();
        string email = SetEmail();

        // firstname + lastname
        string firstname = Txt("first name");
        string lastname = Txt("last name");

        if (firstname.Any(char.IsDigit)) throw new Exception("goofy name");
        if (lastname.Any(char.IsDigit)) throw new Exception("goofy lastname");
        bool isLoggedIn = true; // correct?

        User CreatedUser = new(firstname, lastname, email, password, isLoggedIn);
        Hub.AllUsers.Add(CreatedUser);
        return CreatedUser;
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
        while (true);
    }

    public static void Exit()
    {
        Environment.Exit(0); // ??ok
    }
}
