using System;
using System.Buffers;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Bank;

public class BankAccount
{
    internal string iban { get; init; } // changed from public to internal
    internal User owner;
    private Bank bank;
    private decimal balance;
    private string pin;
    internal bool correctPin { get; private set; } // change from public to internal

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

    public bool TransferMoney(BankAccount receiver, string pin, decimal amount)
    {
        if (pin != this.pin)
        {
            AuthenticationFailedCLI();
            return false;
        }

        if (balance < amount)
        {
            Console.Clear();
            Console.WriteLine("Insufficient balance...");
            Console.WriteLine($"You have {balance}$ and tried to transfer {amount}$");
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
            return false;
        }

        if (amount < 0) throw new Exception("This should have been handled before calling this Method");

        this.balance -= amount;
        receiver.balance += amount;

        return true;
    }

    public bool LogIn(string pin) // 12.10 17:40 - from void to bool
    {
        if (pin != this.pin) return false;
        return true;
    }

    public bool Deposit(string pin, decimal amount)
    {
        if (pin == null) throw new ArgumentNullException(nameof(pin));

        if (pin != this.pin)
        {
            AuthenticationFailedCLI();
            return false;
        }

        if (amount < 0) throw new Exception("This should have been handled before calling this Method");
        
        Console.WriteLine($"You have successfully withdrawn {amount}");
        Console.WriteLine($"Your new account balance is {balance + amount}$");
        balance += amount;
        return true;
    }

    public bool Withdraw(string pin, decimal amount)
    {
        if (pin != this.pin)
        {
            AuthenticationFailedCLI();
            return false;
        }

        if (balance < amount)
        {
            Console.Clear();
            Console.WriteLine("Insufficient balance...");
            Console.WriteLine($"You have {balance}$ and tried to withdraw {amount}$");
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
            return false;
        }
        Console.WriteLine($"You have successfully withdrawn {amount}");
        Console.WriteLine($"Your new account balance is {balance - amount}$");
        balance -= amount;
        return true;
    }

    public string GetShortBankAccountIBAN(BankAccount account)
    {
        char[] ibanArray = account.iban.ToArray();
        int count = ibanArray.Length;
        int[] lastDigits = [count - 1, count];
        string output = string.Concat(lastDigits.Select(x => x.ToString())); // add to TechSupportQueue!!! 
        return output;
    }

    public bool CloseBankAccount()
    {
        return this.bank.Registered[this.owner].Remove(this); // does this work?
    }

    private static void AuthenticationFailedCLI()
    {
        Console.Clear();
        Console.WriteLine("Authentication failed... Press any key to try again...");
        Console.ReadKey();
    }

    private void InsufficientBalanceCLI(decimal amount)
    {
        Console.Clear();
        Console.WriteLine("Insufficient balance...");
        Console.WriteLine($"You have {balance}$ and tried to withdraw {amount}$");
        Console.WriteLine("Press any key to try again...");
        Console.ReadKey();
    }

    public (string, string, decimal) GetBankAccountInformation()
    {
        return (iban,  owner.GetUserName(),  balance);
    }
}