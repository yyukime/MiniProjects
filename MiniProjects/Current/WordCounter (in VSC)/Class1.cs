using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime;

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
            string? path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path))
            {
                break;
            }
            else
            {
                try
                {
                    SearchForWord(path);
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
        
        // Dictionary
        

    }


}









