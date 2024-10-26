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
        int hp = 2;
        string path = "words.txt";

        // Get Word and lowerHiddenWordArray (Will reconstruct soon)
        (string lhWord, string lowerWord) = InitWord(path);  // sets successfully  

        // Ui 
        Console.WriteLine("Welcome to Hangman");
        Console.WriteLine();
        Console.WriteLine($"Your (hidden) word is {lhWord} . It has {lhWord.Length} characters");
        Console.WriteLine("Press any key to start playing...");
        Console.ReadLine();



        string updatedhWord = new(lhWord);
        string charTurnOutput;

        do
        {
            Console.Clear();
            int turnType = SelectTurnType(lhWord, hp);



            switch (turnType)
            {
                case 1:
                    {
                        char c = CharTurnP1(updatedhWord, hp);
                        charTurnOutput = CharTurnP2(updatedhWord, lowerWord, c, out bool p2Correct);
                        if (charTurnOutput == lowerWord) WinScreen();
                        updatedhWord = charTurnOutput;

                        if (p2Correct is true)
                        {
                            Console.WriteLine($"Your guess was correct! // You guess {c}.");
                            Console.WriteLine($"Your new word is: {updatedhWord}");
                            Console.WriteLine("Press any key to try again");
                            Console.ReadLine();
                            continue;
                        }

                        break;

                    }
                case 2:
                    {
                        if (WordTurn(updatedhWord, lowerWord, hp)) WinScreen();
                        break;
                    }
            }
            hp -= 1;
            Console.WriteLine($"Your guess was wrong // You have {hp}hp left.");
            Console.WriteLine("Press any key to try again");
            Console.ReadLine();
        }
        while (hp >= 1);
        FailScreen();
    }

    static public int SelectTurnType(string updatedhWord, int hp) // faster as boolean?
    {
        do
        {
            Console.Clear();
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

        for (int i = 0; i < chArray.Length; i++)
        {
            chArray[i] = '?';
        }
        string hword = new(chArray);
        return (hword, lowerWord);
    }

    public static char CharTurnP1(string updatedhWord, int hp)
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

    public static string CharTurnP2(string lh, string w, char guess, out bool p2Correct)
    {
        if (lh.Length != w.Length) throw new Exception("take antidepressants");

        List<int> correctIndexes = new();
        if (string.IsNullOrWhiteSpace(w)) throw new ArgumentException("string value may be null");
        List<char> index = w.ToList();

        for (int i = 0; i < index.Count; i++)
        {
            if (guess != index[i]) continue;
            correctIndexes.Add(i);
        }

        char[] lhArray = lh.ToArray();
        foreach (int i in correctIndexes)
        {

            lhArray[i] = guess;
        }

        string output = new(lhArray);
        if (output != lh)
        {
            p2Correct = true;
            return output;  // if input(updatedHStrign != new string) => no changes to string == wrong guess /// so if != correctly guessed (someting)
        }
        p2Correct = false;
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


