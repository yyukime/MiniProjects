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

namespace Hangman;

public class Code
{

    public static void Main()
    {
        // Credit wordmaster.txt https://github.com/Xethron/Hangman.git\
        // Variables
        int hp = 9;
        string path = "/home/joshuagemba/Documents/github/MiniProjects/Current/Hangman/words.txt";
        string lowerWord;
        string lhWord;
        string m1;
        bool m2;

         
        // Get Word and lowerHiddenWordArray (Will reconstruct soon)
        (lhWord, lowerWord) = InitWord(path);  // sets successfully  

        // Ui 
        Console.WriteLine("Welcome to Hangman");
        Console.WriteLine();
        Console.WriteLine($"Your word is {lhWord} . It has {lhWord.Length} characters");

        while (true)
        {
            SelectTurnType(lhWord.ToArray(), lowerWord, out m1, out m2); // use status to know which value to grab?  <- stupid idea <- stupid idea to call this stupid idea actually 
            char youSelected = new();

            foreach (char c in lowerWord)
            {
                if (c == '?') continue;
                youSelected = c;
                break;
            }

            // example turn ch 
            Console.WriteLine($"You guessed the character: {youSelected}");
            Console.WriteLine();
            if (m1 == lhWord)
            {
                hp -= 1;
                Console.WriteLine($"Tough luck... Your new hp is {hp}");
            }
            else
            {
                Console.WriteLine($"You have found the following characters: {m1}");
            }
            Console.WriteLine("press any key to retry");    // how to construct output based on status returned
            Console.ReadKey();
        }
    }

    static public Status SelectTurnType(char[] lhWordArray, string lowerWord, out string m1, out bool m2)
    {
        while (true)
        {

            Console.Clear();

            // pls select:


            string? stringInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(stringInput)) continue;
            if (stringInput.Length > 1) continue;
            if (!stringInput.All(char.IsLetter)) continue;
            int input = int.Parse(stringInput); // why worse thant !tryparse -> continue;

            // switch statement
            switch (input)
            {
                case 1: m1 = CTurn(lhWordArray, lowerWord); m2 = false; return Status.Char; // I know that m2 = false is not a incorrect word guess because Status.Char is given with it; 
                case 2: m2 = WTurn(lowerWord); m1 = "m2 was chosen"; return Status.Word; // I know m1="m2 was chosen" is a placeholder as guess cannot be more than 1 word;
            }
            // Why return status? I would hope I can do If(Status x) -> Code for char turn
        }
    }
    private static string CTurn(char[] lhWord, string lowerWord) // return string fe ("- - l l - ") -> (Hallo)
    {
        // 
        char glC;
        List<int> indexes = new();
        // 

        Console.Write("Enter your next guess:");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input)) throw new ArgumentException("input is null or empty");
        if (input.Length > 1) throw new Exception("too long");
        glC = input[0];
        if (!char.IsLetter(glC)) throw new Exception("not a letter");
        char.ToLower(glC);
        indexes = MatchChar(lowerWord, glC);
        foreach (int i in indexes)
        {
            if(lhWord[i] != glC) continue;
            lhWord[i] = glC; 
            
        }
        string output = new(lhWord);
        return output;
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


    private static List<int> MatchChar(string lowerWord, char lowerC) // all, will be given in lowercase
    {

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


    private static bool WTurn(string lowerWord)
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Enter your next guess: ");
            string? input = Console.ReadLine().ToLower();
            if (string.IsNullOrWhiteSpace(input)) continue;
            if (input.Length <= 1) continue;
            string lowerGuess = input.ToLower();
            return lowerWord == lowerGuess;
        }
    }


}