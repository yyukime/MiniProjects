using System;
using Bank;


namespace BankUI;

public class Authentication
{
    public static User? Authenticate()
    {
        do
        {
            int selection = UI.Authenticate();

            switch (selection)
            {
                case 1:
                    {
                        User? foundUser = LogIn();
                        if (foundUser == null) continue; // credentials wrong or user does not exist
                        return foundUser;
                    }
                case 2:
                    {
                        User? newUser = CreateNewUser();
                        if (newUser == null) continue; // User already exists
                        return newUser;
                    }
                case 3:
                    {
                        return null;
                    }
            }

        }
        while (true);
    }
    public static User? LogIn()
    {
        string email = UI.Template("Log in", "E-Mail");
        string password = UI.Template("Log in", "password");
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

        if (!Hub.AllUsers.Equals(newUser))
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
            string firstName = UI.Template("Create User", "first name");
            if (firstName.Any(char.IsDigit)) continue;
            string lastName = UI.Template("Create User", "last name");
            if (lastName.Any(char.IsDigit)) continue;
            return (firstName, lastName);
        }
        while (true);
    }


    public static string SetEmail()
    {
        do
        {
            string input = UI.SetEmail();
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
            string input = UI.SetPassword();
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




}
