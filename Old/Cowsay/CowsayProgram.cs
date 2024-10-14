int input;

while (true)
{
    Console.WriteLine("Enter 1 for a surprise");
    try
    {
        input = int.Parse(Console.ReadLine()!);

        if (input == 1)
        {
            Cowsay();
            break;
        }
        else
        {
            Console.WriteLine("I said press 1 you goof... Press any key to retry");
            Console.ReadKey();

        }
        Console.Clear();
    }
    catch
    {
        Console.Clear();
    }
}

static void Cowsay()
{
    Console.WriteLine("_________________");
    Console.WriteLine("< Csharp Rocks >");
    Console.WriteLine("-----------------");
    Console.WriteLine();
    Console.WriteLine("\\    ^__^");
    Console.WriteLine(" \\   (00) \\______");
    Console.WriteLine("     (__) \\       )\\/\\");
    Console.WriteLine("           ||----w|");
    Console.WriteLine("           ||    ||");
}
