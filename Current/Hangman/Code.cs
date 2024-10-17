using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Assemblies;
using System.Runtime.CompilerServices;

namespace Hangman;

public class Code
{
    public static void Main()
    {

    }

    static public void SelectTurnType(string lowerWord)
    {
        while (true)
        {

            Console.Clear();

            bool gW = new();
            // pls select:


            string? stringInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stringInput)) continue;
            if (stringInput.Length > 1) continue;
            if (!stringInput.All(char.IsDigit)) continue;
            int input = int.Parse(stringInput); // why worse thant !tryparse -> continue;

            // switch statement
            switch (input)
            {
                case 1: CTurn(lowerWord); break;
                case 2: gW = GuessWord(lowerWord); break;
            }
            // char gc present || bool true/false present



        }

    }
    private static void CTurn(string lowerWord) // return string fe ("- - l l - ") -> (Hallo)
    {
        // 
        char glC;
        
        Console.Write("Enter your next guess:");
        string? input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("input is null or empty");
        if (input.Length > 1) throw new Exception("too long");
        
        glC = Convert.ToChar(input[0]);
        if (!char.IsLetter(glC)) throw new Exception("not a letter");
        
        char.ToLower(glC);  
        //
        //
        List<int> indexes = SubmitChar(lowerWord, glC);

        char[] uScores = lowerWord.ToArray();
        for (int i = 0; i < uScores.Length; i++)
        {
            uScores[i] = '_';
        }
        foreach (int i in indexes)
        {
            uScores[i] = glC;
        }

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
        int index = rIndex.Next(0, s.Length);
        string sWord = s[index];
        if (string.IsNullOrWhiteSpace(sWord)) throw new ArgumentException("index empty");
        string word = sWord.ToLower();
        return word; // word.ToArray(); In method or in UI
    }

    private static List<int> SubmitChar(string lowerWord, char lowerC) // all, will be given in lowercase
    {
        // Readfile()
        // SelectWord()
        List<int> indexes = new();
        if (string.IsNullOrWhiteSpace(lowerWord)) throw new ArgumentException("string value may be null");
        List<char> index = lowerWord.ToList();

        for (int i = 0; i < index.Count; i++)
        {
            if (lowerC != index[i]) continue;
            indexes.Add(i);
        }
        return indexes; 
    }

    private static bool GuessWord(string lowerWord)
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter your next guess: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            string lowerGuess = input.ToLower();
            return lowerWord == lowerGuess;
        }
    }



}