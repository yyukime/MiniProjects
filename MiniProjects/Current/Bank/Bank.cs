using System;
using System.ComponentModel;

namespace Bank;

public class Bank
{
    
    public string Name { get; init; }
    public int BLZ { get; init; }
    public List<Account> registeredAccounts;

    // Private List<BankAccount> ThisBanksBankAccounts >> good idea? 

    public Bank(string name, int BLZ) // internal (only in here) for using hub class with other projects
    {
        registeredAccounts = new();
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
        if (registeredAccounts.Contains(account)) 
        {
            return false;
        }
        registeredAccounts.Add(account); 
        return true;
    }

    public bool DeleteAccount(Account account)
    {
        return registeredAccounts.Remove(account); 
    }

}

