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

        do
        {
            string updatedhWord = new(lhWord);
            int turnType = SelectTurnType(lhWord, hp);

            string charTurnOutput;
            switch (turnType)
            {
                case 1:
                    {
                        char c = CharTurnP1(updatedhWord, hp);
                        charTurnOutput = CharTurnP2(lhWord, lowerWord, c);
                        if (charTurnOutput == lowerWord) WinScreen();
                        charTurnOutput = updatedhWord;
                        break;
                    }
                case 2:
                    {
                        if (WordTurn(updatedhWord, lowerWord, hp)) WinScreen();
                        break;
                    }
            }

            if (hp == 1) FailScreen();
            hp -= 1;
            
            Console.WriteLine("Your guess was wrong!");
            Console.WriteLine($"You have {hp}hp left");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
        }
        while (true);
    }

    static public int SelectTurnType(string updatedhWord, int hp) // faster as boolean?
    {
        do
        {
            Console.WriteLine($"Current Word: {updatedhWord}");
            Console.WriteLine($"Current HP: {hp}");
            Console.WriteLine();
            Console.WriteLine("- Select a Turn type - ");
            Console.WriteLine();
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

        char[] chArray = lowerWord.ToArray();

        for(int i = 0; i < chArray.Length; i++)
        {
            chArray[i] = '?';
        }
        string hword = new(chArray);
        return (hword, lowerWord);
    }

    public static char CharTurnP1(string updatedhWord,int hp)
    {
        do
        {
            Console.Clear();
            Console.WriteLine($"Current Word: {updatedhWord}");
            Console.WriteLine($"Current HP: {hp}");
            Console.WriteLine();
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

    private static bool WordTurn(string updatedhWord, string word, int hp)
    {
        do
        {
            Console.Clear();
            Console.WriteLine($"Current Word: {updatedhWord}");
            Console.WriteLine($"Current HP: {hp}");
            Console.WriteLine();
            Console.WriteLine("- Guess the word -");
            Console.WriteLine();
            Console.WriteLine($"Your word currently looks like this: {updatedhWord}");
            Console.WriteLine();
            Console.Write("Enter your guess: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            if (input.Length! > 1) continue;
            if (input.Any(char.IsDigit)) continue;

            return input == word;
        }
        while (true);
    }

    private static void WinScreen()
    {
        Console.WriteLine("Wooho");
    }

    private static void FailScreen()
    {
        Console.WriteLine("You died");
    }

}


