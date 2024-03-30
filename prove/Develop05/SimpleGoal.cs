using System;

public class SimpleGoal : Goal
{
    private bool _isComplete; // Variable to track if the goal is complete
    // Constructor to initialize SimpleGoal with name, description, and points
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }
    public override void RecordEvent()
    {
        _recordedDateTime = DateTime.Now;
        Console.WriteLine($"Event recorded at: {_recordedDateTime}");
        _isComplete = true; // Update _isComplete to true when the goal is recorded
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        // Convert the DateTime object to a string using a custom format
        string recordedDateTimeString = _recordedDateTime.ToString("MM/dd/yyyy HH:mm:ss");

        // Implement how to represent SimpleGoal as a string
        return $"SimpleGoal,{_shortName},{_description},{_points},{recordedDateTimeString}";
    }
    public override string GetDetailsString()
    {
        string completeness = _isComplete ? "[x]" : "[ ]";
        return $"{completeness} {_shortName} - ({_description})";
    }
}