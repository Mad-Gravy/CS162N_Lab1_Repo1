// Joseph Teague, CS 162N w/ Lindy Stewart, 3/29/2026

using System;

namespace ShiftCypher
{
    class Program
    {

        public static void Main()
        {
            //Set a shift value
            Random rng = new Random();
            int shift = rng.Next(-10, 11);

            // Deliver instructions and acquire input
            Console.WriteLine("Let's lay with Shift Cyphers! Or 'Caesar Cyphers,' if you prefer!");
            Console.WriteLine("Give us a word you would like to encrypt with the Cypher: ");
            string input = Console.ReadLine();

            // Pass input and shift to the encryption method
            string output = WordEncryption(input, shift);

            // Deliver result
            Console.WriteLine($"After encrypting your input with a cypher shift of {shift}, your input becomes: ");
            Console.WriteLine(output);

        }

        //---- Methods ----------------------------------------

        static string WordEncryption(string input, int shift)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                int ascii = (int)letter;

                if (letter == ' ')
                {
                    output += letter;
                }
                else if (char.IsPunctuation(letter))
                {
                    output += letter;
                }
                else if (char.IsLower(letter))
                {
                    output += (char)(((letter - 'a' + shift + 26) % 26) + 'a'); ; // stole this code from the internet to fix my blunder lol
                }
                else if (char.IsUpper(letter))
                {
                    output += (char)(((letter - 'A' + shift + 26) % 26) + 'A'); ;
                }
            }
            return output;
        }
    }
}
