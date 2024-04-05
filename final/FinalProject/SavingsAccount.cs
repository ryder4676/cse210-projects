using System;

public class SavingsAccount : Account
{
    private const decimal InterestRate = 0.02m;
    private System.Timers.Timer _interestTimer;
    private Rewards _rewards;
    private Leveling _leveling;
    private Achievement _achievement;

    public SavingsAccount(Rewards rewards, Leveling leveling, Achievement achievement)
    {
        _rewards = rewards;
        _leveling = leveling;
        _achievement = achievement;
        _interestTimer = new System.Timers.Timer(60000); // 1 minute
        _interestTimer.Elapsed += AccumulateInterest;
        _interestTimer.AutoReset = true;
        _interestTimer.Enabled = true;
    }

    private void AccumulateInterest(object sender, System.Timers.ElapsedEventArgs e)
    {
        Balance += Balance * InterestRate;
    }

    public override void Deposit(decimal amount)
    {
        _rewards.UpdateLevel(Balance + amount); // Update rewards level based on balance
        _leveling.UpdateLevel(Balance + amount); // Update leveling based on balance
        Balance += amount;
        Console.WriteLine($"Deposit of {amount:C} successful.");
        if (Balance >= 500 && Balance - amount < 500)
        {
            _achievement.AddAchievementRecord(Balance);
        }
    }

    public override void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }
        Balance -= amount;
        Console.WriteLine($"Withdrawal of {amount:C} successful.");
    }

    public override void MakePurchase(decimal amount)
    {
        Console.WriteLine("Purchases not allowed for savings account.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Savings Account";
    }
}
