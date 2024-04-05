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
        if (amount >= _incrementAmount && _previousBalance < _incrementAmount)
        {
            _level++;
            AddAchievementRecord(amount); // Add achievement record
        }

        _previousBalance = amount;
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
