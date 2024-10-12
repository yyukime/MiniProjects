using System;
using System.Data;
using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;


namespace Bank;

public class Hub
{
    public static readonly List<User> AllAccounts = new();
    public static readonly List<Bank> AllBanks = new(); 
    

    // void TestMain() -> how I expect below to play out in UI 
    // {
    //     Bank correct = new();
    //     GetBankByBLZ(out correct);
    //     correct == correctBank; //true
    // }
    
    public Status GetBankByBLZ(string BLZInput, out Bank? correctBank) // cannot return with (Bank, Status) as no Bank object is in hand ? Idk whas happaning
    {
        correctBank = null;
        if(!int.TryParse(BLZInput, out int BLZ)) return Status.IllegalArgument;
        foreach (Bank bank in AllBanks) 
        {
            if (bank.BLZ != BLZ) continue;
            correctBank = bank; // expected: returns correctBank now set as bank
        }
        return Status.Successful;
    }

    public List<Bank> GetBanksForUser(User user)
    {
        List<Bank> UsersBanks = new();
        foreach (Bank bank in AllBanks)
        {
            if(!bank.Registered.ContainsKey(user)) continue;
            UsersBanks.Add(bank);
        }
        return UsersBanks;
    }

}
