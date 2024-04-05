public class Rewards : Leveling
{
    public Rewards(Achievement achievement) : base(achievement)
    {
    }

    public override void UpdateLevel(decimal amount)
    {
        decimal increment = 500;

        if (amount >= increment && _previousBalance < amount)
        {
            decimal previousIncrement = Math.Floor(_previousBalance / increment);
            decimal currentIncrement = Math.Floor(amount / increment);

            if (currentIncrement > previousIncrement)
            {
                _level++;
                AddAchievementRecord(amount); // Add achievement record
            }
        }

        _previousBalance = amount;
    }
}