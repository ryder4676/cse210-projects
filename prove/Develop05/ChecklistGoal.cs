public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    public override void RecordEvent()
    {
        if (_amountCompleted < _target) // Check if the target has been reached
        {
            _amountCompleted++; // Increment the completed count

            // Check if the target has been reached after incrementing the count
            if (_amountCompleted == _target)
            {
                _points += _bonus; // Add the bonus points
                Console.WriteLine($"Congratulations! Goal '{_shortName}' completed {_amountCompleted} times. Bonus points added: {_bonus}");
            }
            Console.WriteLine($"Goal '{_shortName}' completed {_amountCompleted} times.");
        }
        else
        {
            Console.WriteLine($"Goal '{_shortName}' already completed {_target} times. No further progress can be made.");
        }
    }
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public override string GetDetailsString()
    {
        
        string completeness = IsComplete() ? "[x]" : "[ ]";
        return $"{completeness} {_shortName} - ({_description}) | {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
    // Method to set the amount completed
    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
        if (_amountCompleted >= _target)
        {
            _points += _bonus; // Add the bonus points if the target is reached
        }
    }
    

}