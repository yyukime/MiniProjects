using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Security.Authentication;

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
                    UniqueWord(path);
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
        int i = 1;
        int val = 1;
       
        // Dictionary\
        Dictionary<string, int> dict = new();
       
        string[] allLines = File.ReadAllLines(path);

        foreach (string line in allLines)
        {
            string[] lineWords = line.Split([' ', ',', '\t', '\n', '.', '(',')','{','}','[',']']);
            
            foreach (string word in lineWords)
            {
                if (string.IsNullOrWhiteSpace(word)) continue; 

                if (!dict.TryAdd(word, i)) 
                {
                    dict[word] ++; // = ++ // = val +=1 // val = i +1; etc.. 
                }
               
            }   
        }

        // List<string> values = new();

        foreach (KeyValuePair<string, int> output in dict.OrderByDescending(KVP => KVP.Value))
        {
            // values.Add(output.Key + ": " + output.Value);
            Console.WriteLine(output.Key + ": " + output.Value);  
        }
        
        // File.WriteAllLines(@"C:\Users\gemba\Documents\test\tmp\TESTCOPY.txt", values);
        Console.ReadKey();


    }


}









