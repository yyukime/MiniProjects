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

    public static (User?, bool) LogIn(string password, string email)
    {
        foreach (User thisUser in Hub.AllUsers)
        {
            if (thisUser.password != password && thisUser.email != email) continue;
            return (thisUser, true);
        }
        User? NullUser = null;
        return (NullUser, false); // user either does not exist // either password or email is wrong   
    }

    public static void UserInfo(User user)
    {
        Console.Clear();
        Console.WriteLine("- Account Information -");
        Console.WriteLine();
        Console.WriteLine($"Name: {user.lastName}, {user.firstName}");
        Console.WriteLine($"Email: {user.email}");
        char[] hpassword = user.password.ToArray();
        for (int i = 0; i > user.password.Length; i++)
        {
            hpassword[i] = '*';
        }
        string displayPassword = new(hpassword);
        Console.WriteLine($"Password: {displayPassword}");
    }










}
