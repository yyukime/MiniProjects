using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Bank;

public class Bank
{
    
    public string Name { get; init; }
    public int BLZ { get; init; }

    public Dictionary<Account, List<BankAccount>> Registered;

    public Bank(string name, int BLZ) // internal (only in here) for using hub class with other projects
    {
        this.Name = name;
        this.BLZ = BLZ;
    }

    public static int GenerateBLZ()
    {
        Random random = new();
        int BLZ = random.Next(0, 9999);
        return BLZ;
    }

    public bool RegisterAccount(Account account)
    {
        if (Registered.ContainsKey(account)) 
        {
            return false;
        }
        Registered.Add(account, new List<BankAccount>());
        return true;
    }

   public Status CreateBankAccount(Account account, string pin) // Pin must be formatted correctly 
   {
        if (!Registered.ContainsKey(account)) return Status.NoAccountWithBank;
        if (string.IsNullOrWhiteSpace(pin)) return Status.IllegalArgument;
        BankAccount bankAccount = new(account, this, pin); 
        return Status.Successful;
   }


    
}

