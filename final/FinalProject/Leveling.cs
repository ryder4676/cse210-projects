using System;
using System.Collections.Generic;

public class Leveling
{
    protected int _level;
    private Achievement _achievement;
    protected decimal _previousBalance;

    public Leveling(Achievement achievement = null)
    {
        _level = 1;
        _achievement = achievement;
        _previousBalance = 0;
    }

    public virtual void UpdateLevel(decimal amount)
    {
        // To be implemented in derived classes
    }

    public int GetCurrentLevel()
    {
        return _level;
    }
}