using System;
using System.Collections.Generic;
using System.Text;

class MorseCodeDecoder
{
    public static string Decode(string morseCode)
    {
        // Remove any leading and trailing white spaces from the input morseCode string
        morseCode = morseCode.Trim();

        // Dictionary to map Morse code to characters
        // This is used to look up the Morse code and get the corresponding character
        Dictionary<string, char> morseToChar = new Dictionary<string, char>()
        {
            { ".-", 'A' }, { "-...", 'B' }, { "-.-.", 'C' }, { "-..", 'D' }, { ".", 'E' },
            { "..-.", 'F' }, { "--.", 'G' }, { "....", 'H' }, { "..", 'I' }, { ".---", 'J' },
            { "-.-", 'K' }, { ".-..", 'L' }, { "--", 'M' }, { "-.", 'N' }, { "---", 'O' },
            { ".--.", 'P' }, { "--.-", 'Q' }, { ".-.", 'R' }, { "...", 'S' }, { "-", 'T' },
            { "..-", 'U' }, { "...-", 'V' }, { ".--", 'W' }, { "-..-", 'X' }, { "-.--", 'Y' },
            { "--..", 'Z' }, { "-----", '0' }, { ".----", '1' }, { "..---", '2' }, { "...--", '3' },
            { "....-", '4' }, { ".....", '5' }, { "-....", '6' }, { "--...", '7' }, { "---..", '8' },
            { "----.", '9' }, { "...---...", 'S' } // SOS
        };

        // StringBuilder to build the decoded message
        StringBuilder result = new StringBuilder();

        // Split the morse code by 3 spaces to separate words
        // This will create an array where each element is a Morse-coded word
        string[] words = morseCode.Split(new string[] { "   " }, StringSplitOptions.None);

        // Loop through each Morse-coded word
        foreach (var word in words)
        {
            // Split the Morse-coded word by a single space to get the individual letters
            string[] letters = word.Split(' ');

            // Loop through each Morse-coded letter
            foreach (var letter in letters)
            {
                // Try to get the character corresponding to the Morse code
                // If successful, append the character to the result StringBuilder
                if (morseToChar.TryGetValue(letter, out char decodedChar))
                {
                    result.Append(decodedChar);
                }
            }

            // Add a space after each word
            result.Append(' ');
        }

        // Convert the StringBuilder to string and remove any trailing space
        return result.ToString().Trim();
    }

    // Main function for testing the Decode method
    public static void Main()
    {
        Console.WriteLine(MorseCodeDecoder.Decode(".... . -.--   .--- ..- -.. .")); // Should print "HEY JUDE"!
    }
}
