public abstract class Account
{
    private static int _nextAccountNumber = 1;

    public int AccountNumber { get; }
    public decimal Balance { get; protected set; }

    public Account()
    {
        AccountNumber = _nextAccountNumber++;
    }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
    public abstract void MakePurchase(decimal amount);

    public override string ToString()
    {
        return $"Account Number: {AccountNumber}, Balance: {Balance:C}";
    }
}