using Bank;

namespace BankUI3;

public class Program
{
    public static void Main()
    {


    }


    public static int SelectionTemplate(string title, List<string> options, bool canBack = false)
    {
        while (true)
        {
            
            Console.Clear();
            Console.WriteLine($"-- {title} --");
            Console.WriteLine();
            
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {options[i]}");
            }
            
            if (canBack)
            {
                Console.WriteLine($"[{options.Count + 1}] or go back:");
            }
            
            Console.Write("Select an option: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int result)) continue;

            int boolPatch = 0;
            if (canBack)
            {
                boolPatch = 1;
            }
            
            if (result > options.Count + boolPatch|| result <= 0) continue;
            
            return result;
        }
    }

    public static string Enter(string what, Func<string, bool>? condition = null)
    {
        while (true)
        {
            Console.Write($"Please enter your {what}: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input) && (condition == null || condition(input))) return input;
            Console.Clear();
        }
        
    }
}