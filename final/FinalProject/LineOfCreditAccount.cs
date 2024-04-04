using System;

public class LineOfCreditAccount : Account
{
    private const decimal InterestRate = 0.05m;
    private System.Timers.Timer _interestTimer;

    public LineOfCreditAccount()
    {
        _interestTimer = new System.Timers.Timer(120000); // 2 minutes
        _interestTimer.Elapsed += ChargeInterest;
        _interestTimer.AutoReset = true;
        _interestTimer.Enabled = true;
    }

    private void ChargeInterest(object sender, System.Timers.ElapsedEventArgs e)
    {
        if (Balance < 0)
        {
            decimal interestAmount = Math.Abs(Balance) * InterestRate;
            Balance -= interestAmount;
            // Console.WriteLine($"Interest charged: {interestAmount:C}");
        }
    }

    public override void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposit of {amount:C} successful.");
    }

    public override void Withdraw(decimal amount)
    {
        Balance -= amount;
        Console.WriteLine($"Withdrawal of {amount:C} successful.");
    }

    public override void MakePurchase(decimal amount)
    {
        Balance -= amount;
        Console.WriteLine($"Purchase of {amount:C} successful.");
    }

    public override string ToString()
    {
        return base.ToString() + $", Line of Credit Account";
    }
}
