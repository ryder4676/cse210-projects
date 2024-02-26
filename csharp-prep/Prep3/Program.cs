using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the playAgain variable to true
        bool playAgain = true;

        // Main game loop
        while (playAgain)
        {
            // Generate a random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            // Initialize guess variables
            int guess;
            int guessCount = 0;

            // Guessing loop
            while (true)
            {
                // Prompt the user for a guess
                Console.Write("What is your guess? ");
                string guessNumber = Console.ReadLine();
                guess = int.Parse(guessNumber);
                guessCount++;

                // Provide feedback based on the user's guess
                if (guess > magicNumber)
                {
                    Console.WriteLine($"The magic number is lower than {guess}");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine($"The magic number is higher than {guess}");
                }
                else
                {
                    // The correct guess scenario
                    Console.Write($"Correct {magicNumber} was the magic number, and it took you {guessCount} guesses!");
                    break; // Exit the guessing loop
                }
            }

            // Ask the user if they want to play again
            Console.WriteLine();
            Console.Write("Do you want to play again? (yes/no): ");
            string playAgainResponse = Console.ReadLine().ToLower();
            playAgain = (playAgainResponse == "yes");
        }
    }
}
