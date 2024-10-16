using System;
using System.Configuration.Assemblies;

namespace Hangman;

public class Code
{
    public static void Main()
    {

    }

    private static char Turn()
    {
        Console.Write("Enter your next guess:");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("input is null or empty");
        if (input.Length > 1) throw new Exception("too long");
        char c = Convert.ToChar(input[0]);
        if (!char.IsLetter(c)) throw new Exception("not a letter retard");
        return c;
    }

    private static string[] ReadFile() // maybe give path?
    {
        // either use generic path or select path every time
        string path = "Examplepath";
        string allText = File.ReadAllText(path);
        string[] allWords = allText.Split([' ', ',', '\t', '\n', '.', '(', ')', '{', '}', '[', ']', '\r']);
        return allWords;
    }

    private static string SelectWord(string[] s)
    {
        Random rIndex = new();
        rIndex.Next(0, s.Length);
        int index = Convert.ToInt32(rIndex); // why int.parse not work?
        string word = s[index];
        if (string.IsNullOrWhiteSpace(word)) throw new ArgumentException("index empty");
        return word; // word.ToArray();
    }

    private static void Game(string word)
    {
        // Readfile()
        // SelectWord()
        if (string.IsNullOrWhiteSpace(word)) throw new ArgumentException("string value may be null");
        char[] chars = word.ToArray(); // "can be simplified: [.. word]" WHAT THE ...?

    }


}
