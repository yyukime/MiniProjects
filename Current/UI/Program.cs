using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Bank;


namespace BankUI;

public class Program
{

    public static void Main()
    {
        User? activeUser = Authentication.Authenticate();
        if (activeUser == null) return;



    }
    public static Bank.Bank? SelectBank(User activeUser)
    {
        List<Bank.Bank> BanksForUser = Hub.GetBanksForUser(activeUser);
        int Selection = UI.SelectBank(BanksForUser, activeUser);

        if (Selection == BanksForUser.Count + 1) return null; // User selected: go back!

        return BanksForUser[Selection];
    }

    public static BankAccount? SelectBankAccount(User activeUser, Bank.Bank SelectedBank)
    {
        List<BankAccount> UserAccounts = SelectedBank.BankAccountsForUser(activeUser);
        int Selection = UI.SelectBankAccount(UserAccounts);
        if(Selection == UserAccounts.Count + 1) return null;
        return UserAccounts[Selection];
    }









}
