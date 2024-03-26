using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private DateTime startTime; // Declare startTime variable

    public ReflectingActivity(int duration) : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
    {
        _prompts = LoadPromptsFromFile("reflectingPrompts.txt");
        _questions = LoadPromptsFromFile("reflectingQuestions.txt");
    }

    public new void Run()
    {
        base.DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        DisplayPrompt(prompt);
        Console.WriteLine("Start listing items. Press Enter after each item.");
        startTime = DateTime.Now; // Record the start time
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

        while (true)
        {
            input = Console.ReadLine();
            items.Add(input);
            itemCount++;

            TimeSpan elapsedTime = DateTime.Now - startTime;
            int remainingSeconds = _duration - (int)elapsedTime.TotalSeconds;
            if (remainingSeconds <= 0)
                break;
            else
                Console.WriteLine($"Time remaining: {remainingSeconds} seconds"); // Display remaining time
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
