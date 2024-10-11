using System;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;

namespace Bank;

public class BankAccount 
{
    public string iban { get; init;}
    protected Account owner;
    private Bank bank;
    protected decimal balance; 
    protected string pin;
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









}

