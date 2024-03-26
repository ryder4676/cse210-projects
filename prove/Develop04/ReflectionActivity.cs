class ReflectingActivity : Activity
{
    private List<string> _prompts;

    private List<string> _questions;

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
        Thread.Sleep(3000); // Wait for 3 seconds before asking the first question
        int elapsedSeconds = 0;
        while (elapsedSeconds < _duration)
        {
            string question = GetRandomQuestion();
            DisplayQuestions(question);
            Thread.Sleep(3000); // Wait for 3 seconds before asking the next question
            elapsedSeconds += 3;
        }
        base.DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random rand = new Random();
        int index = rand.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayPrompt(string prompt)
    {
        Console.WriteLine(prompt);
    }

    private void DisplayQuestions(string question)
    {
        Console.WriteLine(question);
        Console.Write("Your response: ");
        // Here you can implement logic to read and process the user's response
        // For simplicity, let's just wait for the user to press Enter
        Console.ReadLine();
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
