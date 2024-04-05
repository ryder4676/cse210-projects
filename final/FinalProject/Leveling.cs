public class Leveling
{
    protected int _level;
    protected Achievement _achievement;
    protected decimal _previousBalance;
    protected decimal _incrementAmount; // Add a field to store the increment amount

    public Leveling(Achievement achievement = null)
    {
        _level = 1;
        _achievement = achievement;
        _previousBalance = 0;
        _incrementAmount = 500; // Set the default increment amount
    }

    public virtual void UpdateLevel(decimal amount)
    {
        // Calculate the total deposited amount including the current deposit
        decimal totalDeposited = _previousBalance + amount;

        // Calculate how many times the increment amount fits into the total deposited amount
        int levelIncrement = (int)Math.Floor(totalDeposited / _incrementAmount);

        // Check if the level should be incremented
        if (levelIncrement > _level)
        {
            // Increment the level by the difference between the new level increment and the current level
            _level += (levelIncrement - _level);

            // Add achievement record for each level increase
            for (int i = 0; i < levelIncrement - _level; i++)
            {
                AddAchievementRecord(_incrementAmount * (i + 1)); // Assuming each level increase is based on $500 increments
            }
        }

        // Update the previous balance to the total deposited amount
        _previousBalance = totalDeposited;
    }

    public int GetCurrentLevel()
    {
        return _level;
    }

    public void SetIncrementAmount(decimal amount)
    {
        _incrementAmount = amount;
    }

    protected void AddAchievementRecord(decimal amount)
    {
        _achievement?.AddAchievementRecord(amount);
    }
}
