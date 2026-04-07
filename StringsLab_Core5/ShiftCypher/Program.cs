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
                else if (letter == 'z')
                {
                    output += (char)('a' + (shift - 1));
                }
                else if (letter == 'Z')
                {
                    output += (char)('A' + (shift - 1));
                }
                else
                {
                    output += (char)(letter + shift);
                }
            }
            return output;
        }
    }
}
