using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("John", 3, 16);
        var scriptureText = "For God so loved the world that He gave His one and only Son";
        var scripture = new Scripture(reference, scriptureText);

    while (true)
    {
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress enter to hide a word or type 'quit' to exit.");
        var input = Console.ReadLine();

        if (scripture.AreAllWordsHidden || (input?.ToLower() == "quit" && !scripture.AreAllWordsHidden))
            break;

        scripture.HideRandomWord();
    }

    if (scripture.AreAllWordsHidden)
    {
        Console.WriteLine("All words have been hidden! Thanks for playing!");
    }
    else
    {
        Console.WriteLine("Thanks for playing!");
    }

    }
}