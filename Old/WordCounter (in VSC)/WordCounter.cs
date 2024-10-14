using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Runtime.Loader;
using System.Security.Authentication;

namespace WordCounter__in_VSC_;

public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Enter a path to analyse: ");
            string? path = Console.ReadLine();
            while (true)
            {
                if (string.IsNullOrWhiteSpace(path)) break;
                Text(path);
                Console.Write("Mode: "); string? mode = Console.ReadLine();

                if (!int.TryParse(mode, out int modeInt)) continue;
                switch (modeInt)
                {
                    case 1: WordCount(path); break;
                    case 2: SearchForWord(path); break;
                    case 3: UniqueWord(path); break;
                    default: Console.WriteLine("Invalid mode, press any key to try again.."); Console.ReadKey(); break;
                }
            }
        }
    }

    public static void WordCount(string path)
    {
        Console.Clear();
        int wordAmount = 0;

        string[] allLines = File.ReadAllLines(path);

        foreach (string line in allLines)
        {
            string[] lineWords = line.Split(" ");
            foreach (string word in lineWords)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    continue;
                }
                wordAmount++;
            }
        }

        Console.WriteLine($"WordAmount: {wordAmount}");
        Console.ReadKey();
    }

    public static void SearchForWord(string path)
    {
        Console.Clear();
        string? wordInput;
        int userWordCount = 0;

        while (true)
        {
            Console.WriteLine("Please Enter a Word to search for:");
            wordInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(wordInput)) break;
            Console.Clear();
        }

        string[] allLines = File.ReadAllLines(path);

        foreach (string line in allLines)
        {
            string[] lineWords = line.Split(" ");

            foreach (string word in lineWords)
            {
                if (string.IsNullOrWhiteSpace(word) || !word.Equals(wordInput)) continue;
                userWordCount++;
            }
        }

        Console.WriteLine($"Your word was found {userWordCount} times \npress any key to exit...");
        Console.ReadKey();
    }

    public static void UniqueWord(string path)
    {
        Console.Clear();
        int i = 1;

        Dictionary<string, int> dict = new();

        string allText = File.ReadAllText(path);
        string[] words = allText.Split([' ', ',', '\t', '\n', '.', '(', ')', '{', '}', '[', ']', '\r']);

        foreach (string word in words)
        {
            if (!dict.TryAdd(word, i)) continue;
            dict[word]++;
        }

        // List<string> values = new();
        // File.WriteAllLines(@"C:\Users\gemba\Documents\test\tmp\TESTCOPY.txt", values);
        // values.Add(output.Key + ": " + output.Value);

        int o = 0;
        foreach (KeyValuePair<string, int> output in dict.OrderByDescending(KVP => KVP.Value))
        {
            o++;
            Console.WriteLine(output.Key + ": " + output.Value);
            if (o == 10) break;
        }
        // for (int o = 0; o < 10; o++)
        Console.WriteLine();
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    public static void Text(string path)
    {
        Console.Clear();
        Console.WriteLine("--Please select a mode--");
        Console.WriteLine($"You are analysing: {path}");
        Console.WriteLine();
        Console.WriteLine("1: Display the total amount of words");
        Console.WriteLine("2: Search for the amount of times a specific word occurs");
        Console.WriteLine("3: List the 15 most used words");

    }
}









