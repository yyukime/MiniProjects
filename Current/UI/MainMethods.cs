using System;
using Bank;


namespace BankUI;

public class MainMethods
{
    public static User? LogIn()
    {
        string email = Txt("Log in", "E-Mail");
        string password = Txt("Log in", "password");
        (User? foundUser, bool exists) = Hub.LogIn(password, email);

        if (!exists)
        {
            Console.Clear();
            Console.WriteLine("ERROR: You may have entered wrong credentials or not have an account");
            Console.WriteLine();
            Console.WriteLine("press Enter to try again..");
            Console.ReadLine();
            return null;
        }
        return foundUser!;
    }
    public static User? CreateNewUser()
    {
        (string firstName, string Lastname) = SetName();
        User newUser = new(firstName, Lastname, SetEmail(), SetPassword());

        if (!Hub.AllUsers.Contains(newUser))
        {
            Console.Clear();
            Console.WriteLine("User already exists.. Press Enter to continue..");
            Console.ReadLine();
            return null;
        }
        Hub.AllUsers.Add(newUser);
        return newUser;
    }

    public static (string, string) SetName()
    {
        do
        {
            string firstName = Txt("Create User", "first name");
            if (firstName.Any(char.IsDigit)) continue;
            string lastName = Txt("Create User", "last name");
            if (lastName.Any(char.IsDigit)) continue;
            return (firstName, lastName);
        }
        while (true);
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


            bool supported = false;
            string[] supportedEmails = { "gmail.com", "mail.yahoo.com", "outlook.com" };
            string[] split = input.ToLower().Split("@");

            foreach (string s in supportedEmails)
            {
                if (!split.Contains(s)) continue;
                supported = true;
            }

            if (!supported)
            {
                Console.Clear();
                Console.WriteLine("Your E-Mail provider is not supported... Press Enter to try again");
                Console.ReadLine();
                continue;
            }

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

            bool ok = false;
            if (input.Length < 8)
            {
                Console.Clear();
                Console.WriteLine("Your password is too short, press Enter to retry");
                Console.ReadLine();
                continue;
            }

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
        while (true);
    }
    public static string Txt(string title, string what)
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

}
