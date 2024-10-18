using System;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Bank;

public class Bank
{

    public string Name { get; init; }
    public int BLZ { get; init; }

    public Dictionary<User, List<BankAccount>> Registered;

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

    public Status CreateBankAccount(User account, string pin) // Pin must be formatted correctly 
    {
        if (!Registered.ContainsKey(account)) return Status.NoAccountWithBank;
        if (string.IsNullOrWhiteSpace(pin)) return Status.IllegalArgument;
        BankAccount bankAccount = new(account, this, pin);
        Registered[account].Add(bankAccount);
        return Status.Successful;
    }

    public Status DeleteUser(User account, string password) // Account class does not have bool IsLoggedIn (doesnt need to?)
    {
        if (password != account.password) return Status.wrongPin;
        Registered.Remove(account);
        return Status.Successful;
    }

    public void CloseAccount(BankAccount account, User user)
    {
        // var L = Registered.GetValueOrDefault(user);
        // L.Remove(account);

        Registered[user].Remove(account);
        
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
        return (null, false); // how to make better
    }

    


}

