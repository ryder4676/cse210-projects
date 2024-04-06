using System;
using System.Collections.Generic;
using System.Timers;

public class AccountManager
{
    private Rewards _rewards;
    private Achievement _achievement;
    private List<Account> _accounts;
    private Leveling _leveling; // Define leveling field

    public AccountManager()
    {
        _accounts = new List<Account>();
        _rewards = new Rewards(_achievement);
        _achievement = new Achievement();
        _leveling = new Leveling(_achievement); // Initialize leveling
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nAccount Manager Menu:");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Make Purchase");
            Console.WriteLine("5. Display Account Details");
            Console.WriteLine("6. View Achievement Records");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    MakePurchase();
                    break;
                case 5:
                    DisplayAccountDetails();
                    break;
                case 6:
                    DisplayAchievementRecords();
                    break;
                case 7:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    public void CreateAccount()
    {
        Console.WriteLine("\nChoose Account Type:");
        Console.WriteLine("1. Savings Account ");
        Console.WriteLine("   --> For every $500 you save you will increase your level!");
        Console.WriteLine("2. Checking Account");
        Console.WriteLine("3. Line of Credit Account");
        Console.Write("Enter account type: ");
        int accountType = int.Parse(Console.ReadLine());

        switch (accountType)
        {
            case 1:
                _accounts.Add(new SavingsAccount(_rewards, _leveling, _achievement));
                break;
            case 2:
                _accounts.Add(new CheckingAccount());
                break;
            case 3:
                _accounts.Add(new LineOfCreditAccount());
                break;
            default:
                Console.WriteLine("Invalid account type.");
                break;
        }
    }

    private void Deposit()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter deposit amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Account account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Deposit(amount);
            _leveling.UpdateLevel(account.Balance); // Update leveling after deposit with the updated account balance
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    private void Withdraw()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter withdrawal amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Account account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    private void MakePurchase()
    {
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter purchase amount: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        Account account = FindAccount(accountNumber);
        if (account != null)
        {
            account.MakePurchase(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    private void DisplayAccountDetails()
    {
        Console.WriteLine($"\nAccount Details: Level: {_leveling.GetCurrentLevel()}");
        foreach (var account in _accounts)
        {
            Console.WriteLine(account);
        }
    }

    private void DisplayAchievementRecords()
    {
        _achievement.DisplayRecords();
    }

    private Account FindAccount(int accountNumber)
    {
        foreach (var account in _accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                return account;
            }
        }
        return null;
    }
}
