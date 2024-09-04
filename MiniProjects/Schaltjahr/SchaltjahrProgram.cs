

while (true)
{
    try
    {

        Console.Clear();
        Console.WriteLine("Enter a year to check if it is a leap year");
        int input = int.Parse(Console.ReadLine()!);

        if (isLeapYear(input))
        {
            Console.Clear(); // look comment under
            Console.WriteLine($"{input} is a leap year");
            Console.WriteLine();
            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
        else
        {
            Console.Clear(); // Better way to remove clutter in console apps?
            Console.WriteLine($"{input} is not a leap year");
            Console.WriteLine();
            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
        break;
;
    }
    catch
    {
        Console.Clear(); // too many of these
        Console.WriteLine("ERROR: Wrong Input format");
        Console.WriteLine("Press any key to try again");
        Console.ReadKey();
    }
}

static bool isLeapYear (int year)
{
    if (year % 4 == 0)
    {
        if (year % 100 != 0) // is there not dividable by operator?
            return true;
    }
    return false;
}

