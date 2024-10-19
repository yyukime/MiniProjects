using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Assemblies;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.XPath;
using Microsoft.VisualBasic;

namespace Hangman;

public class Code
{

    public static void Main()
    {
        // Credit words.txt https://github.com/Xethron/Hangman.git\
        // Variables
        int hp = 9;
        string path = "/home/joshuagemba/Documents/github/MiniProjects/Current/Hangman/words.txt";

        // Get Word and lowerHiddenWordArray (Will reconstruct soon)
        (string lhWord, string lowerWord) = InitWord(path);  // sets successfully  

        // Ui 
        Console.WriteLine("Welcome to Hangman");
        Console.WriteLine();
        Console.WriteLine($"Your (hidden) word is {lhWord} . It has {lhWord.Length} characters");
        Console.WriteLine("Press any key to start playing...");
        Console.ReadKey();
        string updatedhWord = new(lhWord);

        while (true)
        {
            int turnType = SelectTurnType(lhWord);
            string charTurnOutput;
            char? c = null;

            switch (turnType)
            {
                case 1: c = CharTurnP1(updatedhWord); break;
            }
            
            if (c != null)
            {
                CharTurnP2(lhWord, lowerWord,  c); // how to not have to make c in method CharTurnP2 nullable here? As I cannot arg(char c!) and KNOW it cannot be null?
            }
    

            updatedhWord = charTurnOutput;


        }
    }

    static public int SelectTurnType(string lhWord) // faster as boolean?
    {
        do
        {
            Console.WriteLine("- Select a Turn type - ");
            Console.WriteLine();
            Console.WriteLine($"Your word currently looks like this: {lhWord}");
            Console.WriteLine();
            Console.WriteLine("[1]: Guess a character:");
            Console.WriteLine("[2]: Guess a Word:");
            Console.Write("Selection: ");
            string? @string = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(@string)) continue;
            if (@string.Length > 1) continue;
            if (!int.TryParse(@string, out int input)) continue;
            return input;
        }
        while (true);

    }


    private static (string, string) InitWord(string path)// string path or constance? 
    {
        //
        Random rIndex = new();
        int seed;
        string Word;
        string lowerWord;
        string chHidden;

        string allText = File.ReadAllText(path);
        string[] s = allText.Split([' ', ',', '\t', '\n', '.', '(', ')', '{', '}', '[', ']', '\r']);
        //
        seed = rIndex.Next(0, s.Length);
        Word = s[seed];
        //
        if (string.IsNullOrWhiteSpace(Word)) throw new ArgumentException("chosen word empty");
        //
        lowerWord = Word.ToLower();
        chHidden = lowerWord;

        foreach (Index index in chHidden)
        {
            chHidden.Replace(chHidden[index], '?');
        }

        string hword = new(chHidden);

        return (hword, lowerWord);
    }

    public static char CharTurnP1(string updatedhWord)
    {
        do
        {
            Console.Clear();
            Console.WriteLine("- Guess a character -");
            Console.WriteLine();
            Console.WriteLine($"Your word currently looks like this: {updatedhWord}");
            Console.WriteLine();
            Console.Write("Enter your guess: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            if (input.Length > 1) continue;
            char c = input[0];
            return c;
        }
        while (true);
    }

    public static string CharTurnP2(string lh, string w, char guess)
    {
        if (lh.Length != w.Length) throw new Exception("take antidepressants");

        List<int> indexes = new();
        if (string.IsNullOrWhiteSpace(w)) throw new ArgumentException("string value may be null");
        List<char> index = w.ToList();
        for (int i = 0; i < index.Count; i++)
        {
            if (guess != index[i]) continue;
            indexes.Add(i);
        }

        char[] lhArray = lh.ToArray();

        for (int i = 0; i < lh.Length; i++)
        {
            if (lh[i] != guess) continue;
            lhArray[i] = guess;
        }
        string output = new(lhArray);
        return output;
    }

}


