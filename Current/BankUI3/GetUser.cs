using System.Diagnostics.CodeAnalysis;
using Bank;

namespace BankUI3;

public static class GetUser
{
    public static User SelectAndHandle()
    {
        
        
        while (true)
        {
            int selection = Program.SelectionTemplate("Please Select one", ["Create User", "Log In"]);


            switch (selection)
            {
                case 1:
                {
                    Console.Clear();
                    User? newUser = CreateNewUser();
                    if (newUser == null) continue;
                    return newUser;
                }
                case 2:
                {
                    Console.Clear();
                    User? foundUser = LogIn();
                    if (foundUser == null)
                    {
                        Console.WriteLine("User not found. press any key to try again");
                        Console.ReadKey();
                        continue;
                    }
                    Console.Clear();
                    Console.WriteLine($"Welcome {foundUser.GetUserName()}");
                    Thread.Sleep(1500);
                    return foundUser;
                }
            }
            
            
        }
        
        
    }


    private static User? CreateNewUser()
    {
        string firstName = Program.Enter("first name", input => input.All(char.IsLetter) && input.Length > 1);
        string lastName = Program.Enter("last name", input => input.All(char.IsLetter) && input.Length > 1);
        string email = Program.Enter("Email",  input => input.Contains('@') && input.Length > 1);
        string password = Program.Enter("password with at least one capital letter and a minimum of eight characters", input => input.Any(char.IsUpper) && input.Length >= 8);
   
        
        User newUser = new User(firstName, lastName, email, password);
        bool confirm = ConfirmUserCreation(newUser);
        if (!confirm) return null;
        if (Hub.TryAddUser(newUser)) return newUser;
        Console.Clear();
        Console.WriteLine("User already exists. Press any key to try again");
        Console.ReadKey();
        return null;
    }

    private static User? LogIn()
    {
        string password = Program.Enter("password", input => input.Any(char.IsUpper) && input.Length >= 8);
        string email = Program.Enter("Email", condition: input => input.Contains('@') && input.Length > 1);
        (User? authUser, bool found) = Hub.LogIn(password, email);
        if(found) return authUser;
        return null;
    }

    private static bool ConfirmUserCreation(User user)
    {
        while (true)
        {
            Console.Clear();
            User.UserInfo(user);
            Console.WriteLine();

            Console.Write("Is this information correct? (y/n): ");
            string? input = Console.ReadLine();
            if (input == "y") return true;
            if (input == "n") return false;
        }
    }
}