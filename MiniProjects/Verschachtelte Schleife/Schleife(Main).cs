// int result;
// int num2;
// int num1;

for (int num1 = 1; num1 <= 10; num1++)
{
    Console.WriteLine($"{num1}:");
    for (int num2 = 1; num2 <= 10; num2++)
    {
        int result = num1 * num2;
        Console.WriteLine($"{num1} x {num2} = {result}");
    }

    Console.WriteLine(); // just better overview
    Console.WriteLine();
    
    // result = num1 * num2;
    // Console.WriteLine($"{num1} x {num2} = {result}");
}

// Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

//System.Environment.Exit(0);  // <- why?
