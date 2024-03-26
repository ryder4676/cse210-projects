using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity(int duration) : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
        _prompts = LoadPromptsFromFile("listingPrompts.txt");
    }

    public new void Run()
    {
        base.DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        DisplayPrompt(prompt);
        Console.WriteLine("Start listing items. Press Enter after each item.");
        int itemCount = GetListFromUser();
        DisplayItemCount(itemCount);
        base.DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private void DisplayPrompt(string prompt)
    {
        Console.WriteLine(prompt);
    }

    private int GetListFromUser()
    {
        List<string> items = new List<string>();
        string input;
        int itemCount = 0;
        DateTime startTime = DateTime.Now;

        while (true)
        {
            input = Console.ReadLine();
            items.Add(input);
            itemCount++;

            TimeSpan elapsedTime = DateTime.Now - startTime;
            if (elapsedTime.TotalSeconds >= _duration)
                break;
        }

        return itemCount;
    }

    private void DisplayItemCount(int itemCount)
    {
        Console.WriteLine($"You listed {itemCount} items.");
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


