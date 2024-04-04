using System;

public class SavingsAccount : Account
{
    private const decimal InterestRate = 0.02m;
    private System.Timers.Timer _interestTimer; // Fully qualify Timer class

    public SavingsAccount()
    {
        _interestTimer = new System.Timers.Timer(60000); // 1 minute
        _interestTimer.Elapsed += AccumulateInterest;
        _interestTimer.AutoReset = true;
        _interestTimer.Enabled = true;
    }

    private void AccumulateInterest(object sender, System.Timers.ElapsedEventArgs e) // Fully qualify ElapsedEventArgs class
    {
        Balance += Balance * InterestRate;
        // Console.WriteLine($"Interest accrued: {Balance * InterestRate:C}");
    }

    public override void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposit of {amount:C} successful.");
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
}
