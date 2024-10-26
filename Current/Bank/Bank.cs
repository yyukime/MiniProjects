using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Bank;

public class Bank
{

    public string Name { get; init; }
    public int BLZ { get; init; }

    internal Dictionary<User, List<BankAccount>> Registered;

    public Bank(string name, int BLZ) 
    {
        Name = name;
        this.BLZ = BLZ;
    }

    public static int GenerateBLZ()
    {
        Random random = new();
        int BLZ = random.Next(0, 9999);
        return BLZ;
    }

    public bool RegisterUserAtBank(User user)
    {
        if (Registered.ContainsKey(user))
        {
            return false;
        }
        Registered.Add(user, new List<BankAccount>());
        return true;
    }

    public BankAccount? OpenBankAccount(User account, string pin)
    {
        BankAccount bankAccount = new(account, this, pin);
        Registered[account].Add(bankAccount);
        return bankAccount;
    }

    public BankStatus DeleteUser(User account, string password) // Account class does not have bool IsLoggedIn (doesnt need to?)
    {
        if (!Registered.ContainsKey(account)) return BankStatus.NoAccountWithBank;
        Registered.Remove(account);
        return BankStatus.Successful;
                
    }
    
    public (BankAccount?, bool found) GetBankAccountTroughIBAN(string IBAN)
    {
        foreach (KeyValuePair<User, List<BankAccount>> kvp in Registered)
        {
            foreach (BankAccount acc in kvp.Value)
            {
                if (acc.iban != IBAN) continue;
                return (acc, true);
            }
        }
        return (null, false);
    }

    public List<BankAccount> GetBankAccountsForUser(User user)
    {
        return Registered[user];
    }

}

