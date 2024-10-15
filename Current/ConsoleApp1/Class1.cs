using System;

namespace ConsoleApp1;

public class Class1
{
    public static void Main(string[] args)
    {
        SetPassword("password");
    }

    private void Welcome()
    {
        Console.WriteLine("Welcome to the Bank terminal");
        Console.WriteLine();
        Console.WriteLine("1. Log in as User");
        Console.WriteLine("2. Create User account");
        Console.Write("Select what you want to do:"); var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) Console.WriteLine("Input == NullOrWhiteSpace");
        if (int.TryParse(input, out int value)) ;
        {
            switch (value)
            {
                case 1: Console.WriteLine("Method1"); break;
                case 2: Console.WriteLine("Method 2"); break;
            }
        }
        Console.WriteLine("ERROR ERROR ERROR ");


    }

    private void LogIn()
    {
        // In order to log in -> Input email, password
    }

    private static void CreateUser()
    {
        string firstName = Txt("first name");
        string lastName = Txt("last name");
        string email = Txt("Email");


    }

    private static string Txt(string what)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("-- Creat User --");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"Please Enter your {what}: "); var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;
            return input;
        }
    }

    private static string SetPassword(string what)
    {
        while (true)
        {
            string input = null;
            string req = $"Your Password {input} does not meet the password requirements";
            Console.Clear();
            Console.WriteLine("-- Creat User --");
            Console.WriteLine();
            Console.WriteLine("Your password has to be atleast 8 characters long. It has to contain atleast 1 capital letter");
            Console.Write($"Please Enter your {what}: "); input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;
            if (input.Length < 8) Console.WriteLine(req);
            string[] pw = input.Split();
            return pw.ToString();
        }

    }


    // User user1 = new User();

}
