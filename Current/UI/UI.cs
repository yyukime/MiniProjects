using System;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;
using Bank;
using BankUI;

namespace UI;

public class UI
{
    public static void Main() // string[] args?
    {
        //Main menu
        int MainMenuSelection = UI.MainMenuSelection();
        User? activeUser = MainMenuSwitch(MainMenuSelection);

        if (activeUser == null) throw new Exception("case 3 exit for some reason?");

        //Select Bank
        Bank.Bank selectedBank = BankSelectionMenu(activeUser);
        //Select BankAccount
        BankAccount SelectedBankAccount = BankAccountSelection(activeUser, selectedBank);
        //Select BankAccountAction
        int BankAccountAction = BankAccountMenu(SelectedBankAccount);


    }
    public static User? MainMenuSwitch(int MainMenuSelection)
    {
        switch (MainMenuSelection)
        {
            case 1:
                {
                    (User? thisRealUser, bool UserLogIn) = MainMenuActions.LogIn();
                    if (UserLogIn == false || thisRealUser == null) throw new Exception("Account LogIn failed. User does not Exist or Password || Email is wrong");
                    return thisRealUser;
                }
            case 2:
                {
                    User newUser = MainMenuActions.NewUser();
                    Bank.User.UserInfo(newUser);
                    return newUser;
                }
            case 3: MainMenuActions.Exit(); return null;
        }
        return null;
    }

    public static int BankAccountMenu(BankAccount account)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("[1]: Money Transfer");
            Console.WriteLine("[2]: Deposit");
            Console.WriteLine("[3]: Withdraw");
            Console.WriteLine("[4]: go back");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();

            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int output)) continue;
            return output;
        }
        while (true);
    }

    public static Bank.Bank BankSelectionMenu(User loggedinUser) // only accessible if user logged in 
    {
        do
        {
            Console.Clear();
            List<Bank.Bank> BankList = Hub.GetBanksForUser(loggedinUser);

            Console.Clear();
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            for (int i = 1; i < BankList.Count; i++)
            {
                Console.WriteLine($"[{i}]: {BankList[i].Name}");
            }
            Console.WriteLine($"[{BankList.Count + 1}]: exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();
            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int input)) continue;
            return BankList[input];
        }
        while (true);
    }

    public static int MainMenuSelection()
    {
        do
        {
            Console.Clear();

            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            Console.WriteLine("[1]: Log into User");
            Console.WriteLine("[2]: Create New User");
            Console.WriteLine("[3]: Exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();

            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int input)) continue;
            int[] validSelections = { 1, 2, 3 };
            if (!validSelections.Contains(input)) continue;
            return input;
        }
        while (true);
    }

    private static BankAccount BankAccountSelection(User activeUser, Bank.Bank selectedBank)
    {
        do
        {
            Console.Clear();
            List<BankAccount>? BankAccountsForUser;
            if (!selectedBank.Registered.TryGetValue(activeUser, out BankAccountsForUser)) throw new Exception("Unreachable 'This user does not have BankAcocunts'");
            if (BankAccountsForUser == null) throw new Exception("Unreachable: null-value for key activeUser");
            Console.WriteLine("- Select Action -");
            Console.WriteLine();
            Console.WriteLine("--------");
            for (int i = 1; i < BankAccountsForUser.Count; i++)
            {
                Console.WriteLine($"[{i}]: Account with IBAN: ******{BankAccountsForUser[i].GetShortBankAccountIBAN}"); // !No BankAccount ToString// Display method?
            }
            Console.WriteLine($"[{BankAccountsForUser.Count + 1}]: exit");
            Console.WriteLine("--------");
            Console.Write("Selection: ");
            string? stringInput = Console.ReadLine();

            if (stringInput?.Length != 1) continue;
            if (!int.TryParse(stringInput, out int input)) continue;
            BankAccount selectedBankAccount = BankAccountsForUser[input];
            return selectedBankAccount;
        }
        while (true);
    }

    public static void BankAccountAction(int selection, BankAccount account)
    {

        switch (selection)
        {
            case 1:
                {
                    (string iban, decimal amount) = BankAccountActions.InputIBANAndAmount(account);
                    (BankAccount? receiver, bool works) = BankAccountActions.MatchIBANandInput(iban);
                    if (receiver == null) throw new Exception("This should not happen");
                    Bank.BankAccountStatus plswork = account.TransferMoney(receiver, amount);
                    break;
                }
            case 2:
                {
                    (string pin, decimal amount) = BankAccountActions.ActionsUI();
                    BankAccountStatus result = account.Deposit(pin, amount);
                    if (result != BankAccountStatus.Successful) throw new Exception("Deposit failed");
                    Console.WriteLine("You deposited {amount} successfully");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                }
            case 3:
                {
                    (string pin, decimal amount) = BankAccountActions.ActionsUI();
                    BankAccountStatus result = account.Withdraw(pin, amount);
                    if (result != BankAccountStatus.Successful) throw new Exception("Withdraw failed");
                    Console.WriteLine("You have withdrawn{amount} successfully, please stand by as the machine prints the money..");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                }
            case 4:
            {
                break; //what does this do?
            }

        }

    }

}
