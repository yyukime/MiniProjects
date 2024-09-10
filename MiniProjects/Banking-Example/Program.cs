using BankingExample;
using System.Data;
using System.Reflection.Metadata.Ecma335;

List<Bank> loadedBanks = LoadBanks();
List<User> loadedUsers = [];


User? selectedUser = null;

// Login to bank (user)
// select bank
// select account
// select action 
// perform action 
// restart
// we dont have ToString > when ToString override > override for all classes? 

// Check age for user creation 18+ etc. 
// TODO: Enter email txt

// TODO: example data initialization -> create banks and users, create accounts in banks etc.

Ui();

return;

void Ui()
{
    while (true)
    {
        Console.Clear();
        PrintTitle();

        // -> Create User
        // -> Login to User
        // -> Select Bank as User
        //    -> Select Account for user
        //        -> Account actions

        Console.WriteLine("1. Create user");
        Console.WriteLine("2. Login to user");
        if (selectedUser is not null)
        {
            Console.WriteLine($"3. Select bank as ({selectedUser.FirstName} {selectedUser.LastName})");
        }

        Console.WriteLine("Select an option:");

        var consoleKeyInfo = Console.ReadKey().KeyChar;

        if (!int.TryParse(consoleKeyInfo.ToString(), out int selectedOption))
        {
            continue;
        }

        switch (selectedOption)
        {
            case 1:
                User createdUser = CreateUser();
                loadedUsers.Add(createdUser);
                break;
            case 2:
                LoginToUser();
                break;
            case 3:
                if (selectedUser is null)
                {
                    continue;
                }

                continue;
            default:
                continue;
        }
    }
}

void PrintTitle()
{
    if (selectedUser is null)
    {
        Console.WriteLine("Welcome to the ATM");
    }
    else
    {
        Console.WriteLine($"Welcome to the ATM -> {selectedUser}");
    }

    Console.WriteLine();
}

void PrintBanks()
{
    for (int index = 0; index < loadedBanks.Count; index++)
    {
        var bank = loadedBanks[index];
        Console.WriteLine($"{index}: {bank}");
    }
}

User CreateUser()
{
    while (true)
    {
        Console.Clear();
        PrintTitle();

        Console.WriteLine("1. Create user");

        Console.WriteLine("Enter first name:");
        string? firstName = Console.ReadLine();

        Console.WriteLine("Enter last name:");
        string? lastName = Console.ReadLine();

        Console.WriteLine("Enter E-Mail:");
        string? email = Console.ReadLine();

        bool validAge = false;
        int age = -1;

        while (!validAge) // mit agecheckuser() kombinieren?
        {
            Console.WriteLine("Enter age:");
            string? ageStr = Console.ReadLine();
            validAge = int.TryParse(ageStr, out age);
        }

        if (!ageCheckUser(age))
        {
            Console.WriteLine("Invalid age... Press anything to try again");
            Console.ReadKey();  continue; // bewege ich mich auf dünnem Eis?
        }

        Console.WriteLine("Create a password:");
        string? password = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(firstName)
            || string.IsNullOrWhiteSpace(lastName)
            || string.IsNullOrWhiteSpace(email)
            || string.IsNullOrWhiteSpace(password))
        {
            continue;
        }

        var newUser = new User(firstName, lastName, email, age, password);

        Console.WriteLine($"Created user: {newUser}");
        Console.WriteLine("Is this information correct? y/n");

        var consoleKeyInfo = Console.ReadKey();
        var keyChar = consoleKeyInfo.Key;

        // if (Console.ReadKey().Key != ConsoleKey.Y)
        if (keyChar != ConsoleKey.Y)
        {
            continue;
        }

        return newUser;
    }
}

void LoginToUser()
{
    while (true)
    {
        selectedUser = null;
        Console.Clear();
        PrintTitle();

        Console.WriteLine("User Login");
        Console.WriteLine("Enter the email:");
        var email = Console.ReadLine();

        User? matchingUser = null;
        foreach (var user in loadedUsers)
        {
            if (user.Email == email)
            {
                matchingUser = user;
            }
        }

        // User? matchingUser = loadedUsers.FirstOrDefault(u => u.Email == email);

        if (matchingUser is null)
        {
            continue;
        }

        Console.WriteLine("Enter the password:");
        var password = Console.ReadLine();

        if (!matchingUser.Login(password))
        {
            continue;
        }

        selectedUser = matchingUser;
        return;
    }
}

Bank SelectBank()
{
    while (true)
    {
        Console.Clear();
        PrintTitle();
        PrintBanks();
        Console.WriteLine("Please select a Bank:");

        string? readLine = Console.ReadLine();
        if (readLine == null)
        {
            continue;
        }

        if (!int.TryParse(readLine, out int selectedBankIndex))
        {
            continue;
        }

        if (selectedBankIndex >= loadedBanks.Count || selectedBankIndex < 0)
        {
            continue;
        }

        return loadedBanks[selectedBankIndex];
    }

    // switch (mode)
    // {
    //     case 1:
    //         Console.WriteLine($"Your selection: {bank1}"); // Why does {bank1} or {bank1.toString} not work? 
    //         break;
    //     case 2:
    //         Console.WriteLine($"Your selection: {bank2}");
    //         break;
    //     case 3:
    //         Console.WriteLine($"Your selection: {bank3}");
    //         break;
    // }
}

List<Bank> LoadBanks()
{
    Bank bank1 = new("Norisbank", Bank.GenerateBlz());
    Bank bank2 = new("ING", Bank.GenerateBlz());
    Bank bank3 = new("N26", Bank.GenerateBlz());

    return [bank1, bank2, bank3];
}

bool ageCheckUser(int reqAgeUser)
{
    return (reqAgeUser >= 18); // return (age != 18 | age >18
}