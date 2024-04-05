using System;

public class Leveling
{
    private int _points;
    private int _level;
    private decimal _previousBalance;

    public Leveling()
    {
        _points = 0;
        _level = 1;
        _previousBalance = 0;
    }

    public void UpdatePoints(decimal amount)
    {
        int pointsToAdd = (int)(amount / 100); // Example: 1 point for every $100 deposited
        _points += pointsToAdd;

        // Check if the balance exceeds $500 increments and increase the level accordingly
        if ((int)(amount / 500) > (int)(_previousBalance / 500))
        {
            _level++;
        }

        _previousBalance = amount;
    }


    public int GetCurrentLevel()
    {
        return _level;
    }
}
