using System;

public class StreakGoal : Goal
{
    private int _currentStreak;
    private int _streakTarget;
    private static readonly Dictionary<int, int> StreakPointsMap = new Dictionary<int, int>
    {
        { 7, 100 },
        { 14, 250 },
        { 21, 500 },
        { 28, 1000 }
    };

    public StreakGoal(string name, string description, int points, int streakTarget) : base(name, description, points)
    {
        _currentStreak = 0;
        _streakTarget = streakTarget;
    }
    public void SetCurrentStreak(int currentStreak)
    {
        _currentStreak = currentStreak;
    }
    public override void RecordEvent()
    {
        // Increment current streak and check if it meets or exceeds the streak target
        _currentStreak++;
        if (_currentStreak >= _streakTarget)
        {
            // Get the points for the completed streak from the map
            if (StreakPointsMap.TryGetValue(_streakTarget, out int streakPoints))
            {
                _points += streakPoints;
                Console.WriteLine($"Congratulations! Streak goal '{_shortName}' completed for {_streakTarget} days. Bonus points added: {streakPoints}");
            }
            else
            {
                Console.WriteLine($"Error: Points for {_streakTarget}-day streak not found in the map.");
            }
            // Reset current streak
            _currentStreak = 0;
        }
        else
        {
            Console.WriteLine($"Streak goal '{_shortName}' current streak: {_currentStreak} day(s).");
        }
    }

    public override bool IsComplete()
    {
        return false; // Streak goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} - ({_description})";
    }

    public override string GetStringRepresentation()
    {
        // Convert the DateTime object to a string using a custom format
        string recordedDateTimeString = _recordedDateTime.ToString("MM/dd/yyyy HH:mm:ss");
        return $"StreakGoal:{_shortName},{_description},{_points},{_streakTarget},{_currentStreak}";
    }
}
