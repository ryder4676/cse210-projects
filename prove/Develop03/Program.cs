using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
{
    var reference = new Reference("James", 1, 5, 6);
    var scriptureText = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tossed.";
    var scripture = new Scripture(reference, scriptureText);

    Stack<int> hiddenWordIndices = new Stack<int>();

    while (true)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress 'Enter' to hide multiple words, Type 'r' and press 'Enter' to reveal hidden words, or type 'quit' and press Enter to exit program.");

        var input = Console.ReadLine()?.ToLower();

        if (input == "")
        {
            int wordsToHide = 3;
            if (!scripture.HideRandomWords(wordsToHide, hiddenWordIndices))
            {
                Console.WriteLine("All words have been hidden! Thanks for playing!");
                break;
            }
        }
        else if (input == "quit")
        {
            Console.WriteLine("Exiting the program...");
            break;
        }
        else if (input == "r")
        {
            int wordsToReveal = 3;
            scripture.RevealWords(wordsToReveal, hiddenWordIndices);
        }
        else
        {
            Console.WriteLine("Invalid input. Press enter to continue or type 'quit' to exit.");
        }
    }

    Console.WriteLine("Thanks for playing!");
}
}