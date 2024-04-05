using System;

public class Rewards
{
    private decimal _previousBalance;

    public Rewards()
    {
        _previousBalance = 0;
    }

    public void CheckRewards(decimal currentBalance, Account account)
    {
        decimal increment = 500;
        decimal rewardAmount = 25;

        // Check if the balance crosses multiples of $500 and deposit rewards into the checking account
        if (currentBalance >= increment && _previousBalance < currentBalance && account is SavingsAccount || account is CheckingAccount)
        {
            decimal previousIncrement = Math.Floor(_previousBalance / increment);
            decimal currentIncrement = Math.Floor(currentBalance / increment);

            if (currentIncrement > previousIncrement)
            {
                if (account is CheckingAccount checkingAccount)
                {
                    checkingAccount.DepositReward(rewardAmount * (currentIncrement - previousIncrement));
                }
            }
        }

        _previousBalance = currentBalance;
    }
}