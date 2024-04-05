public class Achievement : Leveling
{
    private List<string> _records;

    public Achievement() : base()
    {
        _records = new List<string>();
    }

    public override void UpdateLevel(decimal amount)
    {
        if (amount >= 500 && _previousBalance < 500)
        {
            _level++;
            AddAchievementRecord(amount);
        }
        _previousBalance = amount;
    }

    public void AddAchievementRecord(decimal amount)
    {
        _records.Add($"{DateTime.Now}: Deposit of ${amount} achieved a new level!");
    }

    public void DisplayRecords()
    {
        Console.WriteLine("\nAchievement Records:");
        foreach (string record in _records)
        {
            Console.WriteLine(record);
        }
    }
}
