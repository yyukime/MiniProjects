// int input; // not sexy

while (true)
{
    try
    {
        Console.Clear();
        Console.WriteLine("Enter a year to check if it is a leap year");
        int input = int.Parse(Console.ReadLine()!);

        Console.Clear();

        string isLeapYearText = IsLeapYear(input) ? $"{input} is a leap year" : $"{input} is not a leap year";
        Console.WriteLine(isLeapYearText);
        
        // if (IsLeapYear(input))
        // {
            // Console.WriteLine($"{input} is a leap year");
        // }
        // else
        // {
            // Console.WriteLine($"{input} is not a leap year");
        // }

        Console.WriteLine();
        Console.WriteLine("Press any button to exit");
        Console.ReadKey();
    }
    catch
    {
        Console.Clear(); // too many of these
        Console.WriteLine("ERROR: Wrong Input format");
        Console.WriteLine("Press any key to try again");
        Console.ReadKey();
    }
}

static bool IsLeapYear (int year)  // isLeapYear --> IsLeapYear
{
    // Can be simplified, but not necessarily easier to read
    return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
    
    
    // if (year % 4 == 0)
    // {
    //     if (year % 100 != 0) // is there not dividable by operator? -> Well % is pretty much the best you get, it's the remainder or rest whatever you wanna call it...
    //         return true;
    // }
    // return false;
}

