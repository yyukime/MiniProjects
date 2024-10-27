using System;
using System.Data;
using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;


namespace Bank;

public class Hub
{
    private static readonly List<User> AllUsers = new();
    private static readonly List<Bank> AllBanks = new();


    
    public static List<Bank> GetBanksForUser(User user)
    {
        List<Bank> UsersBanks = new();
        foreach (Bank bank in AllBanks)
        {
            if (!bank.Registered.ContainsKey(user)) continue;
            UsersBanks.Add(bank);
        }
        return UsersBanks;
    }

    public static (User?, bool) LogIn(string password, string email)
    {
        foreach (User thisUser in Hub.AllUsers)
        {
            if (thisUser.email == email && thisUser.MatchPassword(password)) return (thisUser, true);
        }
        return (null, false); 
    }
    

    public static Bank GetBankByIndex(int index)
    {
        index += 1;   // Console.WriteLine($"[{i + 1}] {options[i]}");
        return AllBanks[index];
    }


    public static bool TryAddUser(User user)
    {
        if (AllUsers.Contains(user)) return false;
        AllUsers.Add(user);
        return true;
    }

    public static bool TryAddBank(Bank bank)
    {
        if (AllBanks.Contains(bank)) return false;
        AllBanks.Add(bank);
        return true;
    }

    public static List<string> GetAllBankStringListExceptWhereUserExists(User user)
    {
        var allBankStringList = new List<string>();
        var banksForUser = GetBanksForUser(user);
        foreach (Bank x in Hub.AllBanks.Except(banksForUser))
        {
            allBankStringList.Add(x.Name + " " + $"[{x.BLZ}]");
        }
        return allBankStringList;
    }

    public static List<string> GetAllBanksStringList()
    {
        var allBankStringList = new List<string>();
        foreach (Bank b in Hub.AllBanks)
        {
            allBankStringList.Add(b.Name + " " + $"[{b.BLZ}]");
        }
        return allBankStringList;
    }
    
    public static void TEST()
    {     
        Hub.AllUsers.AddRange([
            new User("John", "Doe", "john.doe@example.com", "Password123"),
            new User("Jane", "Smith", "jane.smith@example.com", "Password123"),
            new User("Alice", "Johnson", "alice.johnson@example.com", "Password123"),
            new User("Bob", "Brown", "bob.brown@example.com", "Password123"),
            new User("Charlie", "Davis", "charlie.davis@example.com", "Password123"),
            new User("Donna", "Miller", "donna.miller@example.com", "Password123"),
            new User("Edward", "Wilson", "edward.wilson@example.com", "Password123"),
            new User("Fiona", "Moore", "fiona.moore@example.com","Password123"),
            new User("George", "Taylor", "george.taylor@example.com", "Password123"),
            new User("Hannah", "Anderson", "hannah.anderson@example.com", "Password123")
        ]);

        Hub.AllBanks.AddRange([
            new("Bank of America", 1000),
            new("Wells Fargo", 1001),
            new("Chase Bank", 1002),
            new("Citibank", 1003),
            new("U.S. Bank", 1004),
            new("PNC Bank", 1005),
            new("Capital One", 1006),
            new("TD Bank", 1007),
            new("BB&T", 1008),
            new("SunTrust Bank", 1009)
        ]);}




}
