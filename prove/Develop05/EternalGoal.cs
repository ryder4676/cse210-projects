class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No need to initialize _recordedDateTime here
    }
    public override void RecordEvent()
    {
        _recordedDateTime = DateTime.Now;
    }
    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }
    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} - ({_description})";
    }
    public override string GetStringRepresentation()
    {
        // Convert the DateTime object to a string using a custom format
        string recordedDateTimeString = _recordedDateTime.ToString("MM/dd/yyyy HH:mm:ss");
        return $"EternalGoal,{_shortName},{_description},{_points},{recordedDateTimeString}";
    }
}