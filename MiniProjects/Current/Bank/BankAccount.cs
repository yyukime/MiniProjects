using System;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Bank;

public class BankAccount 
{
    public string iban { get; init;}
    public Account owner { get; init; } // should not be public WHAT THE FLIP? 
    private Bank bank;
    private decimal balance; 
    private string pin;
    public bool Isloggedin { get; private set; }
    
    
    /// List<BankAccounts> BankAccsByOwner 

    public BankAccount(Account Owner, Bank bank, string pin) // like so?
    {
        this.owner = Owner;
        this.bank = bank;
        this.pin = pin;
        this.balance = 0;
        this.iban = GenIBAN(bank.BLZ);
    }

    private static string GenIBAN(int BLZ)
    {
        Random random = new();
        string paddedBLZ = BLZ.ToString().PadLeft(4, '0'); // padding for case of BLZ sub 1k so 15 -> 0015
        string AccNumber = random.Next(0, 999_999).ToString().PadLeft(6, '0');
        string IBAN = paddedBLZ + "-" + AccNumber;
        return IBAN;
    }

    public bool MoneyTransfer(BankAccount receiver, decimal amount)
    {
        if (balance < amount || amount <= 0) return false;
        this.balance -= amount;
        receiver.balance += amount;
        return true;
    }

    public (decimal, Status) CheckBalance(Account account) // Maybe GUID and not account for this and Transfer/Deposit?
    {
        if (account != owner) return (-1, Status.AccountMisMatch); // why no bool? -> For each return a different UI element
        if (Isloggedin == false) return (-1, Status.NotLoggedIn);// for example "this is not your account" or "you are not logged in, please enter your pin to continue"
        return (balance, Status.Successful); 
    }
    
    public void LogIn(string pin)
    {
       if (pin == this.pin) Isloggedin = true;
    }

    public bool Deposit(string pin, decimal amount)
    {
        if (!Isloggedin) return false; 
        if (pin != this.pin) return false; //
        if (amount <= 0) return false;
        balance += amount;
        return true;
    }

        public bool Withdraw(string pin, decimal amount)
    {
        if (!Isloggedin) return false;
        if (pin != this.pin) return false;
        if (amount <= 0) return false;
        if (amount > balance) return false;
        balance -= amount;
        return true;
    }



    // OpenAccount()
    
}

