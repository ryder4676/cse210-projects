public class GoalLeveling
{
    private int _points;
    private int _level;

    // Constructor
    public GoalLeveling()
    {
        _points = 0;
        _level = 1; // Start at level 1
    }
    

    // Method to increment points and handle level up
    public void IncrementPoints(int pointsToAdd)
    {
        _points += pointsToAdd;

        // Check if the user has reached the next level (every 50 points)
        int newLevel = (_points / 50) + 1; // Add 1 to start at level 1

        if (newLevel > _level)
        {
            Console.WriteLine($"Congratulations! You've reached level {newLevel}!");
            _level = newLevel;
        }
    }

    // Method to display points and level
    public void DisplayPoints()
    {
        Console.WriteLine($"You have {_points} points and you are currently on level {_level}.");
    }
}
