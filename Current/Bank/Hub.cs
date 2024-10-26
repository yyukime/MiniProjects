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


}
