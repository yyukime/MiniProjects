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
        SpawnUser();
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
        while (true)
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
    }

    public static void LogInUser()
    {
        // TODO : Fancy up console.writeline(); ! 
        string? pswdInput;
        string? emailInput;

        while (true)
        {
            Console.Clear();
            Console.Write("Password:");
            pswdInput = Console.ReadLine();
            Console.Write("Email:");
            emailInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(pswdInput) || string.IsNullOrWhiteSpace(emailInput)) continue; // Can do this shorter? Too lazy to look up 
            break;
        }



        





    }








}
