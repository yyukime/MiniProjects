using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Bank;


namespace BankUI;

public class Program
{


    public static void Main()
    {
        Hub.AllUsers.AddRange([
    new User("John", "Doe", "john.doe@gmail.com", "password123"),
            new User("Jane", "Smith", "jane.smith@gmail.com", "password123"),
            new User("Alice", "Johnson", "alice.johnson@gmail.com", "password123"),
            new User("Bob", "Brown", "bob.brown@gmail.com", "password123"),
            new User("Charlie", "Davis", "charlie.davis@gmail.com", "password123"),
            new User("Donna", "Miller", "donna.miller@gmail.com", "password123"),
            new User("Edward", "Wilson", "edward.wilson@gmail.com", "password123"),
            new User("Fiona", "Moore", "fiona.moore@gmail.com", "password123"),
            new User("George", "Taylor", "george.taylor@gmail.com", "password123"),
            new User("Hannah", "Anderson", "hannah.anderson@gmail.com", "password123")
]);

        Hub.AllBanks.AddRange([
            new("Bank of America", 1000),
            new("Wells Fargo", 1001),
            new("Chase Bank", 1002),
            new("Citibank", 1003),
            new("U.S. Bank", 1004),
            new("PNC Bank", 1005),
            new("Capital One", 1006),
            new("TD Bank", 1007),
            new("BB&T", 1008),
            new("SunTrust Bank", 1009)
        ]);

        User? activeUser = Authentication.Authenticate();
        if (activeUser == null) return;

        while (true)
        {
            Bank.Bank UserBank = SelectBank(activeUser);

            while (true)
            {
                BankAccount? SelectedBankAccount = SelectBankAccount(activeUser, UserBank);
                if (SelectedBankAccount == null) break;
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
        do
        {
            List<BankAccount> UserAccounts = SelectedBank.BankAccountsForUser(activeUser);
            int Selection = UI.SelectBankAccount(UserAccounts);
            if (Selection == -1) return null;

            if (UserAccounts[Selection].LogIn(UI.EnterPin())) return UserAccounts[Selection];

            Console.WriteLine("Authentication failed... Press enter to continue");
            continue;
        }
        while (true);
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
                        Actions.Transfer(SelectedBankAccount);
                        continue;
                    }
                case 2: // Deposit
                    {
                        (bool back, decimal? amount) = Actions.Deposit(SelectedBankAccount);
                        if (back) continue;
                        Console.WriteLine($"You successfully Deposited {amount}$.. Press enter to return continue...");
                        Console.ReadLine();
                        return;
                    }
                case 3: // Withdraw
                    {
                        (bool success, decimal? amount) = Actions.Withdraw(SelectedBankAccount);
                        if (!success) continue;
                        Console.Clear();
                        Console.WriteLine($"You have successfuly withdrawn {amount}$");
                        Console.WriteLine("press enter to continue");
                        Console.ReadLine();
                        return;
                    }
                case 4: return; //what?
            }
        }
        while (true);
    }










}
