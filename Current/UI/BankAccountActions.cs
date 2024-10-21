using System;
using System.Net.NetworkInformation;
using Bank;

namespace BankUI;

public class BankAccountActions
{
    public static (string, decimal) InputIBANAndAmount(BankAccount sender)
    {
        decimal amountDecimal;
        string? ibanInput;
        do
        {
            Console.Clear();
            Console.WriteLine("Please pay attention to the Layout: BLZ-IBAN");
            Console.WriteLine();
            Console.Write("Please enter the receiver's IBAN: ");
            ibanInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ibanInput)) continue;
            break;
        }
        while (true);
        do
        {
            Console.Clear();
            Console.WriteLine("Please pay attention to the Layout: 00.00$");
            Console.WriteLine();
            Console.Write("Please enter the amount: ");
            string? stringDecimalInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stringDecimalInput)) continue;
            if (!decimal.TryParse(stringDecimalInput, out amountDecimal)) continue;
            break;
        }
        while (true);
        return (ibanInput, amountDecimal);
    }

    public static (BankAccount?, bool) MatchIBANandInput(string inputIBAN)
    {
        foreach (Bank.Bank b in Hub.AllBanks)
        {
            foreach (KeyValuePair<Bank.User, List<BankAccount>> keyValuePair in b.Registered)
            {
                foreach (BankAccount acc in keyValuePair.Value)
                {
                    if (inputIBAN != acc.GetIBAN(acc)) continue;
                    return (acc, true);
                }
            }
        }
        return (null, false);
    }

    public static (string, decimal) ActionsUI()
    {
        decimal amount;
        string pin;
        do
        {
            Console.Clear();
            Console.Write("Please enter the amount: ");
            string? stringInput = Console.ReadLine();
            if (!decimal.TryParse(stringInput, out amount)) continue;
            break;
        }
        while (true);
        do
        {
            Console.Clear();
            Console.Write("Please enter your pin: ");
            pin = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(pin)) continue;
            break;
        }
        while (true);
        return (pin, amount);

    }
}
