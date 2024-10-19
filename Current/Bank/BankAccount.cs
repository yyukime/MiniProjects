using System;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Bank;

public class BankAccount 
{
    internal string iban { get; init;} // changed from public to internal
    internal User owner;
    private Bank bank;
    private decimal balance; 
    internal string pin;
    internal  bool correctPin { get; private set; } // change from public to internal
   
    /// List<BankAccounts> BankAccsByOwner 

    public BankAccount(User Owner, Bank bank, string pin) // like so?
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

    public BankAccountStatus TransferMoney(BankAccount receiver, decimal amount)
    {
        if (balance < amount) return BankAccountStatus.NoMoney;
        if(amount <= 0 ) return BankAccountStatus.IllegalArgument;
        this.balance -= amount;
        receiver.balance += amount;
        return BankAccountStatus.Successful;
    }

    public bool LogIn(string pin) // 12.10 17:40 - from void to bool
    {
       if (pin != this.pin) return false;
       return true;
    }

    public BankAccountStatus Deposit(string pin, decimal amount)
    {
        if (!correctPin) return BankAccountStatus.NotLoggedIn; 
        if (pin != this.pin) return BankAccountStatus.wrongPin;
        if (amount <= 0) return BankAccountStatus.IllegalArgument;
        balance += amount;
        return BankAccountStatus.Successful;
    }

    public BankAccountStatus Withdraw(string pin, decimal amount)
    {
        if (!correctPin) return BankAccountStatus.NotLoggedIn;
        if (pin != this.pin) return BankAccountStatus.wrongPin;
        if (amount > this.balance) return BankAccountStatus.NoMoney;
        if (amount <= 0) return BankAccountStatus.IllegalArgument;
        balance -= amount;
        return BankAccountStatus.Successful;
    }













}

