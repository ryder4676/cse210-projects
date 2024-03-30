class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No need to initialize _recordedDateTime here
    }
    public override void RecordEvent()
    {

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

        return $"EternalGoal,{_shortName},{_description},{_points}";
    }
}