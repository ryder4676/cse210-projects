using System;
using System.Collections.Generic;
using System.Timers;

public class AccountManager
{
    private Rewards _rewards;
    private Leveling _leveling;
    private List<Account> _accounts;

    public AccountManager()
    {
        _accounts = new List<Account>();
        _rewards = new Rewards();
        _leveling = new Leveling();
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
            Console.WriteLine("6. Quit");
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
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private void CreateAccount()
    {
        Console.WriteLine("\nChoose Account Type:");
        Console.WriteLine("1. Savings Account");
        Console.WriteLine("2. Checking Account");
        Console.WriteLine("3. Line of Credit Account");
        Console.Write("Enter account type: ");
        int accountType = int.Parse(Console.ReadLine());

        switch (accountType)
        {
            case 1:
                _accounts.Add(new SavingsAccount(_rewards, _leveling)); // Pass Rewards and Leveling instances
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
        Console.WriteLine($"\nAccount Details: Current Level: {_leveling.GetCurrentLevel()}");
        foreach (var account in _accounts)
        {
            Console.WriteLine(account);
        }
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
