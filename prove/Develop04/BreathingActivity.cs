public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing", 0)
    {
    }
    public void Run()
    {
        DisplayStartingMessage();

        // Prompt the user for the duration of the session
        Console.Write("How long, in seconds, would you like for your session? ");
        // Retrieve duration from the base class
        // int duration;

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid input. Duration should be a positive integer.");
            Console.Write("How long, in seconds, would you like for your session? ");
        }

        
        Console.WriteLine("Get ready to breath...");
        ShowSpinner(3);
        // Calculate the number of breath cycles based on total duration and breath duration
        int breathCycles = (_duration / 10); // Each breath cycle (inhale + exhale) lasts up to 10 seconds (5 seconds inhale + 5 seconds exhale)

        for (int i = 0; i < breathCycles; i++)
        {
            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            ShowCountDown(5); // Inhale for up to 5 seconds
            Console.WriteLine("Breathe out...");
            ShowCountDown(5); // Exhale for up to 5 seconds
        }

        DisplayEndingMessage(); // Show ending message
    }

}