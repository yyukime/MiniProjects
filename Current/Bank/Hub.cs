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
    


    
    public static (Bank?, BankStatus) GetBankByBLZ(string BLZInput)
    {
        Bank? correctBank = null;
        if(!int.TryParse(BLZInput, out int BLZ)) return (correctBank, BankStatus.IllegalArgument);
        foreach (Bank bank in AllBanks) 
        {
            if (bank.BLZ != BLZ) continue;
            correctBank = bank; 
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
