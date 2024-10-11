using System;
using System.Data;
using Microsoft.VisualBasic;


namespace Bank;

public class Hub : BankAccount
{
    public static readonly List<Account> AllAccounts = new();
    public static readonly List<Bank> AllBanks = new(); 
 
    
    public Hub(Account Owner, Bank bank, string pin) : base(Owner, bank, pin)
    { 

    }

   public (decimal, Status) CheckBalance(Account account) 
    {
        if (account != owner) return (-1, Status.AccountMisMatch); 
        if (Isloggedin == false) return (-1, Status.NotLoggedIn);
        return (balance, Status.Successful); 
    }
    
        public Status Withdraw(string pin, decimal amount)
    {
        if (!Isloggedin) return Status.NotLoggedIn;
        if (pin != this.pin) return Status.wrongPin;
        if (amount <= 0) return Status.valueFormatError;
        if (amount > balance) return Status.NoMoney;
        balance -= amount;
        return Status.Successful;
    }

    // public Status GetBankAccounts()
    // {
    //     if (Isloggedin == false) return Status.NotLoggedIn;
        

    // }

    


    
}
