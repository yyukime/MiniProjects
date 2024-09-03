
string? input = Console.ReadLine();
string[] parts = input.Split(' ');

Console.WriteLine(parts[1]);

if (parts.Length != 3)
{
    Console.WriteLine(" Invalid input format ");
    return;
}

double num1 = Convert.ToDouble(parts[0]);
string operation = parts[1];
double num2 = Convert.ToDouble(parts[2]);

Console.WriteLine(operation);
Console.WriteLine(num1);
Console.WriteLine(num2);

/* Solution
 
using System;
using System.Globalization;

namespace ManualParsingCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input: Read the entire line
            Console.Write("Enter the calculation (e.g., 5 + 3): ");
            string input = Console.ReadLine().Trim();

            // Initialize variables for parsing (& RESULT ??? HEY)
            double num1 = 0, num2 = 0;
            char operation = '\0';
            int operationIndex = -1;


            // Process: Manually parse the input to find the operation and numbers
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    operation = input[i];
                    operationIndex = i;
                    break;
                }
            }

            if (operationIndex == -1)
            {
                Console.WriteLine("Error: No valid operation found.");
                return;
            }

            try
            {
                // Extract the first number
                num1 = Convert.ToDouble(input.Substring(0, operationIndex).Trim(), CultureInfo.InvariantCulture; >> HILFE

                // Extract the second number
                num2 = Convert.ToDouble(input.Substring(operationIndex + 1).Trim(), CultureInfo.InvariantCulture); >> HILFE
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format.");
                return;
            }

            double result = 0; WARUM DOUBLE NICHT OBEN DEFINIEREN?

            // Perform the operation
            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is a no no.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid operation.");
                    return;
            }

            // Output: Display the result
            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
        }
    }
}


*/