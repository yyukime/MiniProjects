int result;
int num2;
int num1;

for (num1 = 1; num1 <= 10; num1++)
{
    for (num2 = 1; num2 < 10; num2++)
    {
        result = num1 * num2;
        Console.WriteLine($"{num1} x {num2} = {result}");
    }

    result = num1 * num2;
    Console.WriteLine($"{num1} x {num2} = {result}");

  
}

Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
System.Environment.Exit(0);

