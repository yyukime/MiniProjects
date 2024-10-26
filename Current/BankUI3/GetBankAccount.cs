using Bank;

namespace BankUI3;

public class GetBankAccount
{
    public static BankAccount? CreateOrSelectOrBack(Bank.Bank bank, User user)
    {

        while (true)
        {
            int selection = Program.SelectionTemplate("Please Select", ["Select Account", "Open Account"], true);

            switch (selection)
            {
                case 1:
                {
                    BankAccount? selectedAccount = SelectAccount(bank, user);
                    if (selectedAccount == null) continue;
                    return selectedAccount;
                }
                case 2:
                {
                    BankAccount? newAccount = CreateAccount(bank, user);
                    if (newAccount == null) continue;
                    return newAccount;
                }
                case 3:
                    return null;
            }
        }
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
        string localWhat = "bank accounts pin with at least 4 digits or 'b' to abort";
        string pin = Program.Enter(localWhat, input => input == "b" || input.Length >= 4 && input.All(char.IsDigit)); // is input == "b" working?
        if (pin == "b") return null;
        BankAccount? foundAccount = selectedBank.OpenBankAccount(user, pin);
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