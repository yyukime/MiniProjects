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

            // Initialize variables for parsing
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
                num1 = Convert.ToDouble(input.Substring(0, operationIndex).Trim(), CultureInfo.InvariantCulture);

                // Extract the second number
                num2 = Convert.ToDouble(input.Substring(operationIndex + 1).Trim(), CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format.");
                return;
            }

            double result = 0;

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
                        Console.WriteLine("Error: Division by zero is not allowed.");
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
