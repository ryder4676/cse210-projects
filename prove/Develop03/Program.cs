using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("James", 1,5,6);
        var scriptureText = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tossed.";
        var scripture = new Scripture(reference, scriptureText);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide a word or type 'quit' to exit.");
            var input = Console.ReadLine();

            if (scripture.IsCompletelyHidden() || (input?.ToLower() == "quit" && !scripture.IsCompletelyHidden()))
                break;

            scripture.HideRandomWords(3);
        }

        if (scripture.IsCompletelyHidden())
        {
            Console.WriteLine("All words have been hidden! Thanks for playing!");
        }
        else
        {
            Console.WriteLine("Thanks for playing!");
        }
    }
}