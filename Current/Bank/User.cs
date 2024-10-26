using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Bank;

public class User
{
    private readonly string firstName;
    private readonly string lastName;
    internal readonly string email;
    private readonly Guid ID;
    private readonly string password;

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
        char[] hiddenPassword = user.password.ToArray();
        for (int i = 0; i > user.password.Length; i++)
        {
            hiddenPassword[i] = '*';
        }
        string displayPassword = new(hiddenPassword);
        Console.WriteLine($"Password: {displayPassword}");
    }


    public bool MatchPassword(string password)
    {
        return this.password == password;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not User user)
        {
            return false;
        }
        
        if (user.firstName == this.firstName
         && user.lastName == this.lastName
         && user.email .Equals(this.email, StringComparison.InvariantCultureIgnoreCase)
         && user.password == this.password)
            return true;

        return false;
    }
    public override int GetHashCode() => HashCode.Combine(firstName, lastName, email, password);

    public bool LogIn(string inEmail, string inPassword)
    {
        return (this.email == inEmail && this.password == inPassword);
    }

    public string GetUserName()
    {
        return this.firstName + " " + this.lastName;
    }
    


}
