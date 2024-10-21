using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Bank;

public class Bank
{

    public string Name { get; init; }
    public int BLZ { get; init; }

    internal Dictionary<User, List<BankAccount>> Registered;

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

    public bool RegisterAccount(User account)
    {
        if (Registered.ContainsKey(account))
        {
            return false;
        }
        Registered.Add(account, new List<BankAccount>());
        return true;
    }

    public BankStatus CreateBankAccount(User account, string pin) // Pin must be formatted correctly 
    {
        if (!Registered.ContainsKey(account)) return BankStatus.NoAccountWithBank;
        if (string.IsNullOrWhiteSpace(pin)) return BankStatus.IllegalArgument;
        BankAccount bankAccount = new(account, this, pin);
        Registered[account].Add(bankAccount);
        return BankStatus.Successful;
    }

    public BankStatus DeleteUser(User account, string password) // Account class does not have bool IsLoggedIn (doesnt need to?)
    {
        if (password != account.password) return BankStatus.wrongPassword;
        if (!Registered.ContainsKey(account)) return BankStatus.NoAccountWithBank;
        Registered.Remove(account);
        return BankStatus.Successful;
    }

    public BankStatus CloseAccount(BankAccount account, User user)
    {
        // var L = Registered.GetValueOrDefault(user);
        // L.Remove(account);

        if(!Registered.ContainsKey(user)) return BankStatus.NoAccountWithBank;
        Registered[user].Remove(account);
        return BankStatus.Successful;
        
        
        // possible to do with only value?
    }

    public (BankAccount?, bool b) GetBankAccountTroughIBAN(string IBAN)
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

    


}

