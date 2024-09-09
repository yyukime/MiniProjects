namespace BankingExample;

public class User
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public int Age { get; }

    private string _password;

    public User(string firstName, string lastName, string email, int age, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Age = age;
        _password = password;
    }

    public bool Login(string? loginPassword)
    {
        return _password == loginPassword;
    }

    public bool IsAdult()
    {
        return Age >= 18;
    }

    public bool UpdatePassword(string oldPassword, string password)
    {
        if (!Login(oldPassword))
        {
            return false;
        }

        _password = password;
        return true;
    }

    public override string ToString()
    {
        return $"Name: {FirstName}, {LastName}, {Age} years old, Email: {Email}";
    }
}