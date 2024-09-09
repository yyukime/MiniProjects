
using BankingExample;


Bank Bank1 = new("Norisbank", "1233213");
Bank Bank2 = new("ING", "232534432");
Bank Bank3 = new("N26", "4831-204081923");

User User1 = new("John", "Doe", "John.Doe@email.com", 18, "PasswordStrong123");

// select bank
// Login to bank (user)
// select account
// select action 
// perform action 
// restart
// we dont have ToString > when ToString override > override for all classes? 


while (true)
{
    Console.WriteLine(User1.ToString());
    Ui();

    try
    {
        int ConsoleRead = int.Parse(Console.ReadLine()!); // how to ? here? 
        SelectBank(ConsoleRead);

    }
    catch
    {
        Console.Clear();
    }
    Console.ReadLine();
}

void Ui()
{
    Console.WriteLine("Welcome to the ATM");
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("Press 1 for Norisbank");
    Console.WriteLine("Press 2 for ING");
    Console.WriteLine("Press 3 for N26");
    Console.WriteLine("Please select a Bank:");
}

void SelectBank(int mode)
{
    Console.Clear();
    switch (mode)
    {
        case 1:
            Console.WriteLine($"Your selection: {Bank1.ToString()}"); // Why does {bank1} or {bank1.toString} not work? 
            break;
        case 2:
            Console.WriteLine($"Your selection: {Bank2.ToString}");
            break;
        case 3:
            Console.WriteLine($"Your selection: {Bank3.ToString}");
            break;
    }
}

