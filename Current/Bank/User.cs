using System;
using System.ComponentModel;
using System.Dynamic;
using System.Net.NetworkInformation;

namespace Bank;

public class User
{
    private string firstName;
    private string lastName;
    private string email;
    private Guid ID;
    internal string password; // must be internal for deleteAccount in Bank Class 
    public bool AccountLogin { get; private set; }

    internal bool isLoggedIn { get; private set; }



    public User(string firstName, string lastName, string email, string password, bool isLoggedIn)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        this.isLoggedIn = isLoggedIn;

        ID = Guid.NewGuid();
    }

    public static bool LogIn(string password, string email)
    {
        foreach (User user in Hub.AllUsers)
        {
            if (user.password != password && user.email != email) continue;
            return true;
        }
        return false; // user either does not exist // either password or email is wrong   
    }

    public static void UserInfo(User user)
    {
        Console.Clear();
        Console.WriteLine("- Account Information -");
        Console.WriteLine();
        Console.WriteLine($"Name: {user.lastName}, {user.firstName}");
        Console.WriteLine($"Email: {user.email}");
        char[] hpword = user.password.ToArray();
        for (int i = 0; i > user.password.Length; i++)
        {
            hpword[i] = '*';
        }
        string displayPassword = new(hpword);
        Console.WriteLine($"Password: {displayPassword}");
    }










}
