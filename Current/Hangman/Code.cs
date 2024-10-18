using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Assemblies;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.XPath;

namespace Hangman;

public class Code
{

    public static void Main()
    {
        string word
        string m1;
        bool m2;


        SelectTurnType("word", out m1, out m2); // use status to know which value to grab? 
        Console.ReadKey();

    }

    static public Status SelectTurnType(string lowerWord, out string m1, out bool m2)
    {
        while (true)
        {

            Console.Clear();

            // pls select:


            string? stringInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stringInput)) continue;
            if (stringInput.Length > 1) continue;
            if (!stringInput.All(char.IsDigit)) continue;
            int input = int.Parse(stringInput); // why worse thant !tryparse -> continue;

            // switch statement
            switch (input)
            {
                case 1: m1 = CTurn(lowerWord); m2 = false; return Status.Char; // I know that m2 = false is not a incorrect word guess because Status.Char is given with it; 
                case 2: m2 = GuessWord(lowerWord); m1 = "m2 was chosen"; return Status.Word; // I know m1="m2 was chosen" is a placeholder as guess cannot be more than 1 word;
            }
        }
    }
    private static string CTurn(string lowerWord) // return string fe ("- - l l - ") -> (Hallo)
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
            uScores[i] = '?';
        }
        foreach (int i in indexes)
        {
            uScores[i] = glC;
        }
        string output = new(uScores);
        return output;
    }

    private static string ReadFile()// string path or constance? 
    {
        //
        Random rIndex = new();
        int index;
        string sWord;
        string lowerWord;
        //
        string path = "Examplepath"; //! 
        // 

        // either use generic path or select path every time
      
        string allText = File.ReadAllText(path);
        string[] s = allText.Split([' ', ',', '\t', '\n', '.', '(', ')', '{', '}', '[', ']', '\r']);
        index = rIndex.Next(0, s.Length);
        sWord = s[index];
        if (string.IsNullOrWhiteSpace(sWord)) throw new ArgumentException("index empty");
        lowerWord = sWord.ToLower();
        return lowerWord; 
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
            if (input.ToArray().Length > 1) continue;
            string lowerGuess = input.ToLower();
            return lowerWord == lowerGuess;
        }
    }



}