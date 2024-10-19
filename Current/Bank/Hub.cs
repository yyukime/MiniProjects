using System;
using System.Data;
using System.IO.Pipes;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;


namespace Bank;

public class Hub
{
    public static readonly List<User> AllUsers = new();
    public static readonly List<Bank> AllBanks = new(); 
    

    // void TestMain() -> how I expect below to play out in UI 
    // {
    //     Bank correct = new();
    //     GetBankByBLZ(out correct);
    //     correct == correctBank; //true
    // }
    
    public static (Bank?, BankStatus) GetBankByBLZ(string BLZInput) // cannot return with (Bank, Status) as no Bank object is in hand ? Idk whas happaning
    {
        Bank? correctBank = null;
        if(!int.TryParse(BLZInput, out int BLZ)) return (correctBank, BankStatus.IllegalArgument);
        foreach (Bank bank in AllBanks) 
        {
            if (bank.BLZ != BLZ) continue;
            correctBank = bank; // expected: returns correctBank now set as bank
        }
        return (correctBank,BankStatus.Successful);
    }

    public static List<Bank> GetBanksForUser(User user)
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
