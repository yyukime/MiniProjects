using System;
using System.Collections.Concurrent;
using System.Net.NetworkInformation;
using Bank;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace BankUI;

public class Actions
{
    public static (bool, decimal?) Deposit(BankAccount selectedAccount) // true: action successful // false: user gave up
    {
        string LogInPin = UI.EnterPin();
        if (!selectedAccount.LogIn(LogInPin))
        {
            Console.WriteLine("Authentication failed... Press enter to continue");
            return (true, null);
        }

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


    public static void Transfer(BankAccount sender)
    {
        BankAccount? receiver;
        string pin = UI.EnterPin();
        if (!sender.LogIn(pin))
        {
            Console.WriteLine("Authentication failed... Press enter to continue");
            return;
        }

        while (true)
        {
            string? IBAN = UI.EnterIBAN();

            if (IBAN == null) return; // go back 

            string[] strings = IBAN.Split("-");
            Bank.Bank? receiverBank = GetBank(strings[0]); // returns null to retry after displaying stuff
            if (receiverBank == null) continue;
            (receiver, bool exists) = receiverBank.GetBankAccountTroughIBAN(IBAN);

            if (!exists)
            {
                Console.WriteLine($"'{receiverBank.Name}' with BLZ '{strings[1]}' does not have an Account with IBAN '{strings[2]}'...");
                Console.WriteLine("press enter to return");
                return;
            }

            break;
        }

        // get Amount
        (decimal amount, bool back) = UI.EnterAmount();
        if (back) return;
        BankAccountStatus status = sender.TransferMoney(receiver!, amount);

        switch (status)
        {
            case BankAccountStatus.NoMoney:
                {
                    Console.Clear();
                    Console.WriteLine("You are broke");
                    Console.WriteLine("Press any key to return");
                    Console.ReadLine();
                    return;
                }
            case BankAccountStatus.Successful:
                {
                    Console.Clear();
                    Console.WriteLine($"Successfully send {amount}$");
                    Console.WriteLine("Press enter to return..");
                    Console.ReadLine();
                    return;
                }
        }

    }

    public static Bank.Bank? GetBank(string BLZ)
    {
        (Bank.Bank? bank, BankStatus result) = Hub.GetBankByBLZ(BLZ);
        switch (result)
        {
            case BankStatus.BankIsNotReal:
                {
                    Console.Clear();
                    Console.WriteLine("The BLZ '{BLZ}'is wrong or the Bank does not exist");
                    Console.WriteLine("Press enter to try again");
                    Console.ReadLine();
                    return null;
                }
            case BankStatus.IllegalArgument:
                {
                    Console.Clear();
                    Console.WriteLine("The BLZ '{BLZ}' is not a valid format..");
                    Console.WriteLine("please pay attention to the IBAN-Format: [0123]-[456789]");
                    Console.WriteLine("Press enter to try again");
                    Console.ReadLine();
                    return null;
                }
            case BankStatus.Successful:
                {
                    return bank;
                }
        }
        return null;
    }

    public static (string?, decimal?) Withdraw(BankAccount selectedAccount)
    {
        string pin = UI.EnterPin();
        if(!selectedAccount.LogIn(pin))
        {
            Console.Clear();
            Console.WriteLine("Authentication failed.. Press enter to continue...");
            return (null, null);
        }

        (decimal amount, bool back) = UI.EnterAmount();

    }


}
