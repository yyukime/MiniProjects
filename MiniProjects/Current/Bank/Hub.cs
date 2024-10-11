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






}
