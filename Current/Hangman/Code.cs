using System;

namespace Hangman;

public class Code
{
    public static void Main()
    {

    }

    public static char Turn()
    {
        Console.Write("Enter your next guess:");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("input is null or empty");
        if (input.Length > 1) throw new Exception("too long");
        char c = Convert.ToChar(input[0]);
        if (!char.IsLetter(c)) throw new Exception("not a letter retard");
        return c;
        
    }

    public static void ReadFile()
    {
        // either use generic path or select path every time
        string path;
        string allText = File.ReadAllText(path);

    }
}
