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

        while (true)
        {
            Bank.Bank UserBank = SelectBank(activeUser);

            while (true)
            {
                BankAccount? SelectedBankAccount = SelectBankAccount(activeUser, UserBank);
                if (SelectedBankAccount == null) break; // If user enters bogus number while selection account, this will happen?
                SelectAction(SelectedBankAccount);
            }

        }



    }
    public static Bank.Bank SelectBank(User activeUser)
    {
        List<Bank.Bank> BanksForUser = Hub.GetBanksForUser(activeUser);
        int Selection = UI.SelectBank(BanksForUser, activeUser);

        // if (Selection == BanksForUser.Count + 1) return null; // User selected: go back! // Cannot happen!!!!

        return BanksForUser[Selection];
    }

    public static BankAccount? SelectBankAccount(User activeUser, Bank.Bank SelectedBank)
    {
        List<BankAccount> UserAccounts = SelectedBank.BankAccountsForUser(activeUser);
        int Selection = UI.SelectBankAccount(UserAccounts);
        if (Selection == -1) return null;
        return UserAccounts[Selection];
    }

    public static void SelectAction(BankAccount SelectedBankAccount)
    {
        int Selection = UI.SelectAction();
        do
        {
            switch (Selection)
            {
                case 1: // Transfer
                    {
                        return;
                    }
                case 2: // Deposit
                    {
                        (bool back, decimal? amount) = Actions.Deposit(SelectedBankAccount);
                        if (back) continue;
                        Console.WriteLine($"You successfully Deposited {amount}");
                        Console.ReadLine();
                        return;
                    }
                case 3: // Withdraw
                case 4: return; //what?
            }
        }
        while (true);
    }










}
