using System;
using System.ComponentModel;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

namespace Bank;

public class User
{
    private string firstName;
    private string lastName;
    internal string email;
    private Guid ID;
    private string password;

    public User(string firstName, string lastName, string email, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        ID = Guid.NewGuid();

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

 
    public bool MatchPassword(string password)
    {
        return this.password != password;
    }










}
