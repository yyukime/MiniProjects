using System;
using System.Data;
using System.IO;
using System.Linq;

namespace WordCounter__in_VSC_;

public class Class1
{
    public static void Main(string[] args)
    {
        Menu();
    }
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please Enter a File to read:");
            string? UserInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(UserInput))
            {
                break;
            }
            else
            {
                try
                {
                    WordCount(UserInput);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    Console.ReadKey();
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
        string? WordInput;
        int UserWord = 0;

        while (true)
        {    
            Console.WriteLine("Please Enter a Word to search for:");
            WordInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(WordInput)) break;
            Console.Clear();
        }

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
                
                if (word == WordInput) UserWord++;
                break;           
            }
        }


    }    
}








