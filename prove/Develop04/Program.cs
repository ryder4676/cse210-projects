using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Activity App!");

        

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                Console.Write("Enter your choice: ");
            }

            if (choice == 4)
            {
                Console.WriteLine("Exiting the program...");
                break;
            }

            switch (choice)
            {
                case 1:

                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;

                case 2:
                    Console.Write("Enter duration for Reflecting Activity (in seconds): ");
                    int duration = int.Parse(Console.ReadLine());
                    ReflectingActivity reflectingActivity = new ReflectingActivity(duration);
                    reflectingActivity.Run();

                    break;

                case 3:
                    Console.Write("Enter duration for Listing Activity (in seconds): ");
                    int listingDuration = int.Parse(Console.ReadLine());
                    ListingActivity listingActivity = new ListingActivity(listingDuration);
                    listingActivity.Run();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid activity.");
                    break;
            }
        }
    }

    public static List<string> LoadPromptsFromFile(string filename)
    {
        List<string> prompts = new List<string>();
        try
        {
            prompts = File.ReadAllLines(filename).ToList();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found.");
        }

        return prompts;
    }
}