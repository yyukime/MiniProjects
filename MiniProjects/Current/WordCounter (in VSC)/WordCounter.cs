using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime;
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
                if (!string.IsNullOrWhiteSpace(path))
                {
                    Text(path);
                    Console.WriteLine("Mode: "); string? mode = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(mode))
                    {

                        if (int.TryParse(mode, out int modeInt))
                        {
                            switch (modeInt)
                            {
                                case 1: WordCount(path); break;
                                case 2: SearchForWord(path); break;
                                case 3: UniqueWord(path); break;
                            }
                        }
                    }
                }
            }
        }     
    }

    public static void WordCount(string path)
    {
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
        int i = 1;


        // Dictionary\
        Dictionary<string, int> dict = new();

        string[] allLines = File.ReadAllLines(path);

        foreach (string line in allLines)
        {
            string[] lineWords = line.Split([' ', ',', '\t', '\n', '.', '(', ')', '{', '}', '[', ']']);

            foreach (string word in lineWords)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                if (!dict.TryAdd(word, i))
                {
                    dict[word]++;
                }
            }
        }

        // List<string> values = new();
        // File.WriteAllLines(@"C:\Users\gemba\Documents\test\tmp\TESTCOPY.txt", values);
        // values.Add(output.Key + ": " + output.Value);

        foreach (KeyValuePair<string, int> output in dict.OrderByDescending(KVP => KVP.Value))
        {

            for (int o = 0; o < 10; o++)
            {
                Console.WriteLine(output.Key + ": " + output.Value);
            }
        }

        Console.ReadKey();
    }

    public static void Text(string path)
    {
        Console.WriteLine("--Please select a mode--");
        Console.WriteLine($"You are analysing: {path}");
        Console.WriteLine("1: Display the total amount of words");
        Console.WriteLine("2: Search for the amount of times a specific word occurs");
        Console.WriteLine("3: List the 15 most used words");

    }
}









