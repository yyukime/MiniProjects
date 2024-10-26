using System.Security.Principal;
using Bank;

namespace BankUI3;

public class Actions
{

    public static void SelectAndHandle(BankAccount bankAccount)
    {
        while (true)
        {
            int selection = Program.SelectionTemplate("Please Select", ["Deposit","Withdraw","Transfer","Close Account"], true);

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
            string enter = Program.Enter("amount or 'b' to go back", input => decimal.TryParse(input, out amount) && amount > 0);
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
            string enter = Program.Enter("amount or 'b' to go back", input => decimal.TryParse(input, out amount) && amount > 0);
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
            string enter = Program.Enter("amount or 'b' to go back", input => decimal.TryParse(input, out amount) && amount > 0);
            if (enter == "b") continue;
            
            while (true)
            {
                
            }
            
         
        }

 
        
    }
    
    private static void CloseAccount(BankAccount account)
    {
        string pin = Program.Enter("enter your pin to confirm account deletion \n or 'b' to go back",
            input => input == "b" || input.Length >= 4 && input.All(char.IsDigit));
        
        if (!account.LogIn(pin))
        {
            Console.Clear();
            Console.WriteLine("Authentication failed... Press any key to try again...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Account deletion complete... Press any key to return...");
        Console.ReadKey();
    }

}
