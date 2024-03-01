using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq; // For ToList() method

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        List<string> prompts = LoadPromptsFromFile("prompts.txt");

        Random random = new Random();

        while (true)
        {   
            Console.WriteLine("Choose what you want to do:\n");
            // sets the choices available for the user
            Console.WriteLine("1. Write a new journal entry ");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save journal to a file ");
            Console.WriteLine("4. Load journal from a file ");
            Console.WriteLine("5. Save journal to MongoDB");// ######## EXCEED REQUIREMENTS BY ADDING A SAVE TO MONGODB CALLED FROM JOURNAL>CS ########
            Console.WriteLine("6. Get journal from MongoDB");// #######################################################################################
            Console.WriteLine("7. Exit Program ");

            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    // This part is enclosed in square brackets [] which is used to access elements within an array (similar to a list). 
                    // Here, prompts is the name of the array that likely contains a list of text prompts.
                    // The .Next() method takes one argument, which specifies the upper bound (exclusive) for the random number generation.  
                    // In this case, prompts.Count refers to the length of the prompts array, ensuring 
                    // the generated random number is within the valid range of indexes for the array.
                    string randomPrompt = prompts[random.Next(prompts.Count)];
                    Console.WriteLine($"Prompt: {randomPrompt}");
                    // Lets the user know it wants you to write something for the response to the prompt
                    Console.Write("Response: ");
                    // accepts the input for the response
                    string response = Console.ReadLine();
                    // creates a journal entry that saves the randomPrompt, response, and date of the entry
                    //.ToString() converts it into a text representation (e.g., "2024-02-29 10:45:20").
                    JournalEntry newEntry = new JournalEntry(randomPrompt, response, DateTime.Now.ToString());
                    journal.AddEntry(newEntry);
                    break;
                case 2:
                    journal.DisplayEntries();
                    break;
                case 3:
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    // SaveToFile(): This is a method (or function) belonging to the journal object. 
                    //Its purpose is to save the contents of the journal to a file.
                    // saveFilename: This is a variable that holds the name of the file where you want to save the journal data. For example, 
                    // it could be something like "my_journal.txt".
                    journal.SaveToFile(saveFilename);
                    break;
                case 4: Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case 5:
                    journal.SaveToMongoDB();
                    break;
                case 6:
                    // Add logic to retrieve entries from MongoDB
                    break;
                case 7: 
                    Console.WriteLine("Thanks for journalling today, Bye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }

    } 
    // Function to load prompts from a file
static List<string> LoadPromptsFromFile(string filename)
{
    //This line declares and initializes a new List<string> named prompts.
    // List<string> is a generic collection in C# that can hold a sequence of elements of type string.
    // Here, it is intended to store a collection of prompts.
    List<string> prompts = new List<string>();
    try
    {
        // This requires 'using System.Linq;' for .ToList()
        prompts = File.ReadAllLines(filename).Select(line => line.Trim()).ToList();
    } 
    catch (FileNotFoundException)
    {
        Console.WriteLine($"File '{filename}' not found.");
        
    }
    
    return prompts;
}

}