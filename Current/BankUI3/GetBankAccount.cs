using Bank;

namespace BankUI3;

public class GetBankAccount
{
    public static BankAccount? SelectOrBackOrCreateBankAccount()
    {
        
        int selection = Program.SelectionTemplate("Please Select", ["Select Account", "Open Account"], true);


        return null;
    }
    
    private static BankAccount? SelectAccount(Bank.Bank selectedBank, User user)
    {
        var bankAccounts = selectedBank.GetBankAccountsForUser(user);
        var stringList = ConvertBankAccountListToStringList(selectedBank, bankAccounts);
        int selection = Program.SelectionTemplate("Please Select", stringList, true);
        if (selection == stringList.Count + 1) return null;
        
        return selectedBank.GetBankAccountsForUser(user)[selection - 1];
    }

    private static BankAccount? CreateAccount(Bank.Bank selectedBank, User user)
    {
        string pin = Program.Enter("bank accounts pin with at least 4 digits", input => input.Length >= 4 && input.All(char.IsDigit));
        (BankAccount? foundAccount, bool success) = selectedBank.OpenBankAccount(user, pin);
        if (!success) return null;
        return foundAccount;
    }

    private static List<string> ConvertBankAccountListToStringList(Bank.Bank selectedBank, List<BankAccount> bankAccounts)
    {
        List<string> stringList = [];
        foreach (BankAccount acc in bankAccounts)
        {
            stringList.Add($"{selectedBank.Name}-Account with Iban {selectedBank.BLZ}-****{acc.GetShortBankAccountIBAN(acc)}");
        }
        return stringList;
    }
}