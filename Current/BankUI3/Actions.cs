using Bank;

namespace BankUI3;

public class Actions
{
    public static void SelectAndHandle(BankAccount bankAccount)
    {
        while (true)
        {
            int selection = Program.SelectionTemplate("Please Select",
                ["Deposit", "Withdraw", "Transfer", "Show Account information", "Close Account"], true);

            switch (selection)
            {
                case 1:
                {
                    bool success = Deposit(bankAccount);
                    if (!success) continue;
                    return;
                }
                case 2:
                {
                    bool success = Withdraw(bankAccount);
                    if (!success) continue;
                    return;
                }
                case 3:
                {
                    bool success = Transfer(bankAccount);
                    if (!success) continue;
                    return;
                }
                case 4:
                {
                   
                    
                    bool success = DisplayAccountInformation(bankAccount);
                    if (!success) continue;
                    return;
                }
                case 5:
                {
                    bool success = CloseAccount(bankAccount);
                    if (!success) continue;
                    return;
                }
                case 6:
                {
                    return;
                }
            }
        }
    }

    private static bool Withdraw(BankAccount account)
    {
        string pin;
        decimal amount = new();
        while (true)
        {
            pin = Program.Enter("pin or 'b' to go back",
                input => input == "b" || input.Length >= 4 && input.All(char.IsDigit));
            if (pin == "b") return false;
            string enter = Program.Enter("amount or 'b' to go back",
                input => decimal.TryParse(input, out amount) && amount > 0);
            if (enter == "b") continue;
            break;
        }

        return account.Withdraw(pin, amount);
    }

    private static bool Deposit(BankAccount account)
    {
        string pin;
        decimal amount = new();
        while (true)
        {
            pin = Program.Enter("pin or 'b' to go back",
                input => input == "b" || input.Length >= 4 && input.All(char.IsDigit));
            if (pin == "b") return false;
            string enter = Program.Enter("amount or 'b' to go back",
                input => decimal.TryParse(input, out amount) && amount > 0);
            if (enter == "b") continue;
            break;
        }

        return account.Deposit(pin, amount);
    }

    private static bool Transfer(BankAccount account)
    {
        string pin;
        decimal amount = new();

        while (true)
        {
            pin = Program.Enter("pin or 'b' to go back",
                input => input == "b" || input.Length >= 4 && input.All(char.IsDigit));
            if (pin == "b") return false;
            string enter = Program.Enter("amount or 'b' to go back",
                input => input == "b" || decimal.TryParse(input, out amount) && amount > 0); // fixed not going back because 'input == "b" ||' was missing
            if (enter == "b") continue;

            while (true)
            {
                Bank.Bank? receiverBank = FindBank();
                if (receiverBank == null) break;

                string iban = Program.Enter($"receivers IBAN or 'b' to go back {receiverBank.BLZ}- ",
                    input => input.Length == 6 && input.All(char.IsDigit));
                if (iban == "b") continue;

                (BankAccount? foundBA, bool found) =
                    receiverBank.GetBankAccountTroughIBAN($"{receiverBank.BLZ}-{iban}");

                if (foundBA == null || !found)
                {
                    Console.WriteLine($"Bank Account [{receiverBank.BLZ}-{iban}] does not exist");
                    Console.WriteLine("Press any key to try again");
                    return false;
                }

                bool success = account.TransferMoney(foundBA, pin, amount);
                if (!success) break; // why not return false as everything is handled in method?

                Console.WriteLine($"You succesfully transfered {amount} to {receiverBank.BLZ}{foundBA.GetShortBankAccountIBAN(foundBA)}");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                return true;
            }
        }
    }

    private static bool CloseAccount(BankAccount account)
    {
        string pin = Program.Enter("enter your pin to confirm account deletion \n or 'b' to go back",
            input => input == "b" || input.Length >= 4 && input.All(char.IsDigit));
        if (pin == "b") return false;

        if (!account.LogIn(pin))
        {
            Console.Clear();
            Console.WriteLine("Authentication failed... Press any key to try again...");
            Console.ReadKey();
            return false;
        }

        bool success = account.CloseBankAccount();

        if (success) // Why can't I if(account.CloseBankAccount())
        {
            Console.WriteLine("Account deletion complete... Press any key to return...");
            Console.ReadKey();
            return true;
        }

        Console.WriteLine("Something went wrong... Press any key to try again...");
        return false;
    }

    private static Bank.Bank? FindBank()
    {
        var BankList = Hub.GetAllBanksStringList();
        int selection = Program.SelectionTemplate("Select receivers Bank", BankList, true);
        if (selection == BankList.Count + 1) return null;
        return Hub.GetBankByIndex(selection);
    }

    private static bool DisplayAccountInformation(BankAccount account)
    {
        string pin;
        while (true)
        {
            pin = Program.Enter("pin or 'b' to go back",
                input => input == "b" || input.Length >= 4 && input.All(char.IsDigit));
            if (pin == "b") return false;
            break;
        }
        
        (string iban, string owner, decimal balance ) = account.GetBankAccountInformation();
        Console.Clear();
        Console.WriteLine("Account Information:");
        Console.WriteLine($"Account Owner: {owner}");
        Console.WriteLine($"Account IBAN : {iban}");
        Console.WriteLine($"Account Balance : {balance}$");
        Console.WriteLine();
        Console.WriteLine("Please press enter to continue...");
        Console.ReadLine();
        return true;
    }
}