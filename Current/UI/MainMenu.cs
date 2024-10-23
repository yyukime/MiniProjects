using System;
using Bank;

namespace BankUI;

public class BankMenu
{
    public static Bank.Bank? SelectBank(User activeUser)
    {
        List<Bank.Bank> BanksForUser = Hub.GetBanksForUser(activeUser);
        int Selection = UI.Bank(BanksForUser, activeUser);

        if (Selection == BanksForUser.Count + 1)
        {
            return null; // User selected: go back
        }

        return BanksForUser[Selection];
    }

}



