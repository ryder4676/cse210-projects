using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(int duration) : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration)
    {
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


            // Read the input directly
            input = Console.ReadLine();
            items.Add(input);
            itemCount++;
           
                TimeSpan elapsedTime = DateTime.Now - startTime;
                if (elapsedTime.TotalSeconds >= _duration)
                    break;// Increment item count
            
        }

        return itemCount;
    }

    private void DisplayItemCount(int itemCount)
    {
        Console.WriteLine($"You listed {itemCount} items.");
    }
}

