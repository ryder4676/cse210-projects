class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity(int duration) : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration)
    {
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
}
