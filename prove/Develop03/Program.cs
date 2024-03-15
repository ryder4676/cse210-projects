using System; // For basic system functionalities
using System.Collections.Generic; // For Stack<T> data structure
using System.Linq; // For LINQ methods, such as .Select()

class Program
{
    static void Main(string[] args)
    {
        // Create a reference object for the book of James, chapter 1, verses 5 to 6
        var reference = new Reference("James", 1, 5, 6);

        // Define the scripture text
        var scriptureText = "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, and upbraideth not; and it shall be given him. But let him ask in faith, nothing wavering. For he that wavereth is like a wave of the sea driven with the wind and tossed.";

        // Create a Scripture object with the provided reference and scripture text
        var scripture = new Scripture(reference, scriptureText);

        // Stack to keep track of indices of hidden words
        Stack<int> hiddenWordIndices = new Stack<int>();

        // Main game loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress 'Enter' to hide multiple words, Type 'r' and press 'Enter' to reveal hidden words, or Type 'quit' and press Enter to exit program.");

            var input = Console.ReadLine()?.ToLower();

            if (input == "") // Like having Enter as the input
            {
                int wordsToHide = 3; // Number of words to hide
                if (!scripture.HideRandomWords(wordsToHide, hiddenWordIndices))
                {
                    Console.WriteLine("All words have been hidden! Thanks for playing!");
                    break;
                }
            }
            else if (input == "quit") // Quit the program
            {
                Console.WriteLine("Exiting the program...");
                break;
            }
            else if (input == "r") // Reveal hidden words
            {
                int wordsToReveal = 3; // Number of words to reveal
                scripture.RevealWords(wordsToReveal, hiddenWordIndices);
            }
            else // Invalid input
            {
                Console.WriteLine("Invalid input. Press enter to continue or type 'quit' to exit.");
            }
        }

        Console.WriteLine("Thanks for playing!");
    }
}
// #####################################################################################################################
// ###### Added a RevealWords based on the order they were hidden. #### FOR ABOVE and BEYOND assignment criteria. ######
// ###### It how reverses  words being hidden in the order they were hidden why typed 'r'.                        ######
// #####################################################################################################################