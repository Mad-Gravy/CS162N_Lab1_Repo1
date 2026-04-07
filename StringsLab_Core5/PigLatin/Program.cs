// Joseph Teague, CS162N w/ Lindy Stewart, 3/29/2026
using System;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    // changing of the notes:
    /*  1.==============================================================================================
		Design and implement a program that processes a string entered from the keyboard.  The application will
		- convert the string to upper and lowercase
		- reverse the string
		- count the number punctuation characters in the string
		- find the index of the first vowel in the string
		- divide the string up into "words"
		
		2.==============================================================================================
		Design and implement a program that converts a sentence entered by the user into pig latin.
		- version 1 - 	moves the first character to the end and adds ay
		- version 2 - 	words that start with vowels - add way to the end
						words that start with consonants - same as version 1
						
    */
    public static void Main()
    {
        Console.WriteLine("Please enter a word or phrase.  Press the ENTER key when you're done.");
        string input = Console.ReadLine();

        // uppercase and lowercase
        string lower = input.ToLower();
        Console.WriteLine("Converted to lowercase: " + lower);
        string upper = input.ToUpper();
        Console.WriteLine("Converted to uppercase: " + upper);

        // iterate through a string with a foreach loop
        string reverse = "";
        foreach (char c in input)
            reverse = c + reverse;
        Console.WriteLine("In reverse: " + reverse);

        // use Char method.  Note that most of the Char methods are static - they get called on a CLASS
        // Math.pow is a static method.  gen.Next(..) gets called on a random OBJECT and is NOT static
        int pCount = 0;
        foreach (char c in input)
            if (Char.IsPunctuation(c))
                pCount++;
        Console.WriteLine("Puncutation count: " + pCount);

        // find the index of the first vowel in a string
        // see the method IsVowel below

        /* deleted block after filling out IndexOfFirstVowel method. */

        int vIndex = IndexOfFirstVowel(input);
        Console.WriteLine("The index of the first vowel is: " + vIndex);

        // create an array of strings from a string.  Default delimiter is white space.
        string[] words = input.Split();
        foreach (string word in words)
            Console.WriteLine("String split into individual words: " + word);

        // Calling/Testing Objective of Lab 1, Ex 1.
        // Lab 1, Ex 2 Complete: Correct capitalization.
        // Lab 1, Ex 3 Completed previously via instructional video.

        string pig1 = PigLatin1(words[0]);
        Console.WriteLine($"The word {words[0]} in pig latin is: {pig1}");

        string pig2 = PigLatin2(words[0]);
        Console.WriteLine("The word {0} in pig latin is: {1}", words[0], pig2);

        char b = 'b';
        Console.WriteLine("Here's a character: " + b);
        int asciiOFb = (int)b;
        Console.WriteLine("Here's its ascii value: " + asciiOFb);
        char bPlus1 = (char)(asciiOFb + 1);
        Console.WriteLine("Here's the character after adding 10 to it's ascii value: " + bPlus1);
        char z = 'z';
        Console.WriteLine("Here's a character: " + z);
        int asciiOFz = (int)z;
        Console.WriteLine("Here's its ascii value: " + asciiOFz);
        char zPlus1 = (char)(asciiOFz + 1);
        Console.WriteLine("Here's the character after adding 1 to it's ascii value: " + zPlus1);
        Console.WriteLine("Darn!  z should be translated to a");
    }

    // I'll do this with you in a screen cast
    static bool IsVowel(char c)
    {
        string vowels = "aeiouAEIOU";
        for(int i = 0;i < vowels.Length; i++)
        {
            if (vowels[i] == c)
            {
                return true;
            }
        }
        return false;
    }

    // I'll do this with you in a screen cast
    static int IndexOfFirstVowel(string s)
    {
        for(int i = 0; i < s.Length; i++)
        {
            if (IsVowel(s[i]))
                return i;
        }
        return -1;
    }

    // Punctuation Method using built-in C# check
    static bool IsPunctuation(char c)
    {
        return char.IsPunctuation(c);
    }

    // I'll do this in the screen cast
    static string PigLatin1(string s)
    {
        string punc = "";
        string temp = "";

        foreach (char c in s)
        {
            if (IsPunctuation(c))
                punc += c;
            else
                temp += c;
        }
        s = temp;

        if (string.IsNullOrEmpty(s))
            return punc;

        string pigString = "";

        // Check if word is capitalized and store in boolean, then make sure first character is lowercase for conversion
        bool capitalized = char.IsUpper(s[0]);
        s = s.ToLower();

        int i = IndexOfFirstVowel(s);

        if (IsVowel(s[0]) && s[0] != 'y')
        {
            pigString = string.Concat(s, "yay");
        }
        else if (i > 0)
        {
            pigString = s[i..] + s[..i] + "ay";
        }
        else
        {
            pigString = string.Concat(s, "ay");
        }

        // Check if word needs to be properly capitalized again and convert if necessary.
        if(capitalized)
        {
            pigString = (char.ToUpper(pigString[0]) + pigString[1..]);
        }
        return pigString + punc;
    }

    // I'll do this with you in a screen cast
    static string PigLatin2(string s)
    {
        return s;
    }
}