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
        index += 1; // Console.WriteLine($"[{i + 1}] {options[i]}");
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

    public static void ControlGetBankAccountInformation(BankAccount account)
    {
        
    }
    
    

    public static void TEST()
    {
        User user1 = new User("John", "Doe", "john.doe@example.com", "Password123");
        User user2 = new User("Jane", "Smith", "jane.smith@example.com", "Password123");
        User user3 = new User("Alice", "Johnson", "alice.johnson@example.com", "Password123");


        Bank bank1 = new("Bank of America", 1000);
        Bank bank2 = new("Wells Fargo", 1001);
        Bank bank3 = new("Chase Bank", 1002);
        
        Hub.AllUsers.AddRange(new List<User> { user1, user2, user3 });
        Hub.AllBanks.AddRange(new List<Bank> { bank1, bank2, bank3 });
        
        bool b1 = bank1.RegisterUserAtBank(user1);
        bool b2 = bank2.RegisterUserAtBank(user2);
        bool b3 = bank3.RegisterUserAtBank(user3);
    

    }
}