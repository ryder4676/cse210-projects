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
        DateTime today = DateTime.Today;

        if (_recordedDateTime.Date == today.AddDays(-1)) // Check if the previous event was recorded yesterday
        {
            _currentStreak++; // Increment streak if recorded on consecutive days
        }
        else
        {
            _currentStreak = 1; // Reset streak if not recorded on consecutive days
        }

        _recordedDateTime = DateTime.Now;

        if (_currentStreak >= _streakTarget)
        {
            // Handle streak completion
        }

        // Print the current streak
        Console.WriteLine($"Streak goal '{_shortName}' current streak: {_currentStreak} day(s).");
    }

    public override bool IsComplete()
    {
        return false; // Streak goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_currentStreak})";
    }

    public override string GetStringRepresentation()
    {
        //     // Convert the DateTime object to a string using a custom format
        //     string recordedDateTimeString = _recordedDateTime.ToString("MM/dd/yyyy HH:mm:ss");
        //     return $"Streak,{_currentStreak}{recordedDateTimeString}";
        // }
        // Print the current streak
        return $"Current streak: {_currentStreak} day(s).";
    }
}
