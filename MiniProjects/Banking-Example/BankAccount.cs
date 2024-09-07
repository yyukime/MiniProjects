namespace BankingExample;

public class BankAccount
{
    public string IBAN { get; }
    public User Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string iban, User owner)
    {
        IBAN = iban;
        Owner = owner;
        Balance = 0;
    }

    public bool Withdraw(string password, int amount)
    {
        if (!Owner.Login(password))
        {
            return false;
        }

        Balance -= amount;
        return true;
    }

    public bool Deposit(string password, int amount)
    {
        if (!Owner.Login(password))
        {
            return false;
        }

        Balance += amount;
        return true;
    }

    /// <summary>
    /// Retrieves the current balance of the bank account if the provided password is correct.
    /// </summary>
    /// <param name="password">The password to authenticate the account owner.</param>
    /// <returns>The current balance of the account if authentication is successful; otherwise, int.MinValue.</returns>
    public decimal CheckBalance(string password)
    {
        if (!Owner.Login(password))
        {
            return int.MinValue;
        }

        return Balance;
    }

    public bool Transfer(string password, decimal amount, BankAccount destination)
    {
        if (!Owner.Login(password))
        {
            return false;
        }

        Balance -= amount;
        destination.Balance += amount;
        
        return true;
    }
}
