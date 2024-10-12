using System;

namespace Bank;

public class User
{
    private string firstName;
    private string lastName;
    private string email;
    private Guid ID;
    internal string password; // must be internal for deleteAccount in Bank Class 
    public bool AccountLogin { get; private set;}
  
    

    public User(string firstName, string lastName, string email, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.password = password;
      
        ID = Guid.NewGuid();
    }

 


}
