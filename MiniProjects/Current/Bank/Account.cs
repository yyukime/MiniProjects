using System;

namespace Bank;

public class Account
{
    private string firstName;
    private string lastName;
    private string email;
    private Guid ID;
    private string password;
    
    
    public Account(string firstName, string lastName, string email, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
        ID = Guid.NewGuid();
    }

    
  
}
