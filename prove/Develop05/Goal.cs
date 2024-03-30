using System;

public abstract class Goal
{
    // Fields to store basic information about the goal
    protected string _shortName;    // Short name of the goal
    protected string _description;  // Description of the goal
    protected int _points;          // Point value associated with the goal

    // Constructor to initialize the goal with name, description, and points
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;

    }
    // Method to get the short name of the goal
    public string GetShortName()
    {
        return _shortName;
    }
    public int GetPoints()
    {
        return _points;
    }


    // Abstract method to be implemented by subclasses to handle recording of events
    public abstract void RecordEvent();

    // Abstract method to be implemented by subclasses to determine if the goal is complete
    public abstract bool IsComplete();

    // Method to generate a string with details of the goal for display in a list
    public abstract string GetDetailsString();

    // Abstract method to be implemented by subclasses to provide string representation of the goal
    public abstract string GetStringRepresentation();
}
