public class CheckingAccount : Account
{
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
        return base.ToString() + $", Checking Account";
    }
    public void DepositReward(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Reward deposited: {amount:C}");
    }
}