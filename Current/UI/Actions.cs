using System;
using System.Collections.Concurrent;
using System.Net.NetworkInformation;
using Bank;

namespace BankUI;

public class Actions
{
    public static (bool, decimal?) Deposit(BankAccount selectedAccount) // true: action successful // false: user gave up
    {
        do
        {
            (decimal amount, string pin, bool back) = UI.Deposit();
            if (back) return (false, null);
            BankAccountStatus result = selectedAccount.Deposit(amount, pin);

            switch (result)
            {
                case BankAccountStatus.wrongPin:
                    {
                        Console.WriteLine("The pin you entered was wrong..");
                        Console.WriteLine("Press enter to try again...");
                        Console.WriteLine();
                        Console.WriteLine("or [b] to give up");
                        string? input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input)) continue;
                        string trim = input.Trim();
                        if (trim == "b") return (true, null);
                        break; // should not be reachable
                    }
                case BankAccountStatus.IllegalArgument:
                    {
                        Console.WriteLine("The amount you typed in is not valid..");
                        Console.WriteLine("Press enter to try again");
                        Console.WriteLine();
                        Console.WriteLine("or [b] to give up");
                        string? input = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(input)) continue;
                        string trim = input.Trim();
                        if (trim == "b") return (true, null);
                        break; // should not be reachable
                    }
                case BankAccountStatus.Successful:
                    {
                        return (false, amount);
                    }
            }
        }
        while (true);
    }
}
