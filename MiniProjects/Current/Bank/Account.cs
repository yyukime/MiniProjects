using System;

namespace Bank;

public class Account
{
    private string firstName;
    private string lastName;
    private string email;
    private Guid ID;
    private string password;
    private List<BankAccount> AccountsBankAccounts { get;  set; }// list of all BankAccounts that have a Owner? 

    public Account(string firstName, string lastName, string email, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        AccountsBankAccounts = new();
        ID = Guid.NewGuid();
    }

        public List<BankAccount> GetOwnedAccounts(Account owner)
    {
        List<BankAccount> byThisUser = new();
        foreach (BankAccount bankAccount in AccountsBankAccounts)
        {
            if (owner == bankAccount.owner) 
            {
                byThisUser.Add(bankAccount);
            }
        }
        return byThisUser;
    }

    public void OpenedBankAccount(BankAccount BAcc)
    {
        AccountsBankAccounts.Add(BAcc);
    }
}
