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
                    ReadFile(UserInput);
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Something went wrong... Press any key to try again");
                    Console.ReadKey();
                }
            }
        }
    }

    public static void ReadFile(string UserInput)
    {
        //Fields
        int wordAmount = 0;
        // string[] words;

        // List amount of words
        string[] AllLines = File.ReadAllLines(UserInput);
        foreach (string Line in AllLines)
        {
            wordAmount++;
        }

        // read all words
        foreach (string Line in AllLines)
        {
            // words = Line.Split(" ");
            // string[] lineWords = Line.Split("");
        }

        

        // string output = string.Join(", ", words);
        // why does 'words' not exist?

        

        Console.WriteLine($"WordAmount: {wordAmount}");
        



        
    }


}


