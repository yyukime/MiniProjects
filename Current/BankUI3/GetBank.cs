using System.Diagnostics;
using Bank;

namespace BankUI3;

public class GetBank
{
    public static Bank.Bank? SelectOrRegister(User user)
    {
        
        while (true)
        {

            int selection = Program.SelectionTemplate("Please Select",["Select Bank", "Register at Bank"], true);
            if (selection == 3) return null;

            Bank.Bank? selectedBank = selection switch
            {
                1 => SelectBank(user),
                2 => RegisterWithBank(user),
                _ => throw new UnreachableException("WHAAT")
            };
            if (selectedBank is null) continue;
            return selectedBank;
        }
        
    }

    
    private static Bank.Bank? SelectBank(User user)
    {
        var banks = Hub.GetBanksForUser(user);
        var stringList = ConvertBankListToStringList(banks);
        int selection = Program.SelectionTemplate("Select what Bank?", stringList, true);
        if (selection == stringList.Count + 1) return null;
        return banks[selection - 1];
    }
    
    
    private static Bank.Bank? RegisterWithBank(User user)
    {
        var allBankStringList = Hub.GetAllBankStringListExceptWhereUserExists(user);
        int selection = Program.SelectionTemplate("Register at what Bank?", allBankStringList, true);
        if (selection == allBankStringList.Count + 1) return null;
        Hub.GetBankByIndex(selection).RegisterUserAtBank(user);
        return Hub.GetBankByIndex(selection - 1);
    }
    
    
    private static List<string> ConvertBankListToStringList(List<Bank.Bank> banks)
    {
        var stringList =  new List<string>();
        foreach (Bank.Bank x in banks)
        {
            stringList.Add(x.Name + " " + $"[{x.BLZ}]");
        }
        return stringList;
    }
    
    
    
    
    
    
    




    
        
    


}