using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        while (true)
        {
            Console.WriteLine($"You have {_score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoalNames();
                    ListGoalDetails();
                    break;
                case 3:
                    SaveGoals();
                    break;
                case 4:
                    Console.Write("Enter the filename to load goals from: ");
                    string filename = Console.ReadLine();
                    LoadGoals(filename);
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
    }
    public void ListGoalNames()
    {
        Console.WriteLine("Your goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("Goal completion status:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals to create are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("Which type of goal would you like to create? ");

        int type = int.Parse(Console.ReadLine());
        Console.WriteLine("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.WriteLine("What is a short description of the goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                Console.WriteLine("Enter target amount:");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish? ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= _goals.Count)
        {
            Goal goal = _goals[choice - 1];
            if (goal is SimpleGoal simpleGoal)
            {
                if (simpleGoal.IsComplete())
                {
                    Console.WriteLine("Simple Goals can only be completed once, and you have already been awarded the points for this goal.");
                    return; // Exit the method without further action
                }
            }

            goal.RecordEvent(); // Call RecordEvent to mark the goal as complete
            int pointsEarned = goal.GetPoints(); // Call the GetPoints method of the selected goal
            _score += pointsEarned; // Add the points earned to the total score
            Console.WriteLine($"Congratulations! Event recorded successfully! You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved to file goals.txt.");
    }
    public void LoadGoals(string filename)
    {
        try
        {
            string[] lines = File.ReadAllLines(filename); // Read all lines from the file

            foreach (string line in lines)
            {
                string[] parts = line.Split(','); // Split the line into parts using comma as delimiter

                string type = parts[0]; // Get the type of goal
                string name = parts[1]; // Get the name of the goal
                string description = parts[2]; // Get the description of the goal
                int points = int.Parse(parts[3]); // Get the points associated with the goal

                // Create the appropriate type of goal based on the type string
                Goal goal;
                switch (type)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(name, description, points);
                        break;
                    case "EternalGoal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "ChecklistGoal":
                        int target = int.Parse(parts[4]); // Get the target for the checklist goal
                        int bonus = int.Parse(parts[5]); // Get the bonus for the checklist goal
                        int amountCompleted = int.Parse(parts[6]); // Get the amount completed for the checklist goal
                        goal = new ChecklistGoal(name, description, points, target, bonus);
                        ((ChecklistGoal)goal).SetAmountCompleted(amountCompleted); // Set the amount completed and update points
                        break;
                    default:
                        // Handle unrecognized goal types
                        Console.WriteLine($"Unrecognized goal type: {type}");
                        continue; // Skip to the next line
                }

                _goals.Add(goal); // Add the goal to the list of goals
            }

            // Update the total score based on points of all loaded goals
            _score = _goals.Sum(goal => goal.GetPoints());

            Console.WriteLine("Goals loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filename}' not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}