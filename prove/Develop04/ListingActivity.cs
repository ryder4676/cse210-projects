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
        Thread.Sleep(3000); // Wait for 3 seconds before asking the user to start listing
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
        Console.WriteLine("Start listing items. Press Enter after each item. Enter 'done' when finished.");
        List<string> items = new List<string>();
        string input;
        int elapsedTime = 0;
        int itemCount = 0;

        while (elapsedTime < _duration)
        {
            input = Console.ReadLine();
            if (input.ToLower() == "done")
                break;
            items.Add(input);
            itemCount++;
            elapsedTime += 3; // Assume 3 seconds per item, adjust as needed
        }

        return itemCount;
    }

    private void DisplayItemCount(int count)
    {
        Console.WriteLine($"You listed {count} items.");
    }
}
