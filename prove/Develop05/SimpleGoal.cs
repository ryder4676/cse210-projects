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
        _isComplete = true; // Update _isComplete to true when the goal is recorded
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        // Implement how to represent SimpleGoal as a string
        // return $"Name: {_shortName}, Description: {_description}, Points: {_points}, IsComplete: {_isComplete}";
        return $"SimpleGoal:{_shortName},{_description},{_points}";
    }

    public override string GetDetailsString()
    {
        return $"{_shortName}: {_description} (Complete: {_isComplete})";
    }
}