namespace BankingExample;

public class Bank
{
    public string Name { get; }
    public string BLZ { get; }

    public List<User> Users { get; }
    public List<BankAccount> Accounts { get; }

    public Bank(string name, string blz)
    {
        Name = name;
        BLZ = blz;
        Users = [];
        Accounts = [];
    }

    public bool AddUser(User userToAdd)
    {
        if (Users.Contains(userToAdd))
        {
            return false;
        }

        Users.Add(userToAdd);
        return true;
    }

    public bool RemoveUser(User userToRemove)
    {
        return Users.Remove(userToRemove);
    }

    public bool CreateAccount(User user)
    {
        if (!Users.Contains(user))
        {
            return false;
        }

        var newIban = GenerateIban();
        var account = new BankAccount(newIban, user);

        Accounts.Add(account);
        return true;
    }

    public bool DeleteAccount(BankAccount accountToDelete, string password)
    {
        if (!Accounts.Contains(accountToDelete))
        {
            return false;
        }

        if (!accountToDelete.Owner.Login(password))
        {
            return false;
        }

        return Accounts.Remove(accountToDelete);
    }

    public List<BankAccount> GetAccounts(User user)
    {
        if (!Users.Contains(user))
        {
            return [];
        }

        return Accounts.Where(acc => acc.Owner == user).ToList();

        // List<BankAccount> accounts = [];
        // foreach (var item in Accounts)
        // {
        //     if (item.Owner == user)
        //     {
        //         accounts.Add(item);
        //     }
        // }
        //
        // return accounts;
    }

    private string GenerateIban()
    {
        var rand = new Random();
        int i1 = rand.Next(1000);
        int i2 = rand.Next(1000);
        int i3 = rand.Next(1000);

        return $"{BLZ}-{i1}-{i2}-{i3}";
    }

    public override string ToString()
    {
        string BankInformation = ($"{Name}, BLZ: {BLZ}");
        return BankInformation;
    }

}