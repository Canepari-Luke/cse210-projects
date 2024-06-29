using System;
using System.Collections.Generic;

public static class UserInterface
{
    private static int totalScore = 0;

    public static void Initialize()
    {
        Program.LoadGoals();
        CalculateTotalScore();
        ShowMenu();
    }

    public static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. View current goals");
            Console.WriteLine("4. Exit");

            Console.Write("\nSelect an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateNewGoal();
                    break;
                case "2":
                    RecordEvent();
                    break;
                case "3":
                    ViewGoalsMenu();
                    break;
                case "4":
                    Program.SaveGoals();
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private static void CalculateTotalScore()
    {
        totalScore = 0;
        foreach (var goal in Program.goals)
        {
            if (goal is SimpleGoal simpleGoal)
            {
                if (simpleGoal.IsCompleted)
                {
                    totalScore += simpleGoal.Points;
                }
            }
            else if (goal is EternalGoal eternalGoal)
            {
                totalScore += eternalGoal.Points * eternalGoal.Count;
            }
            else if (goal is ChecklistGoal checklistGoal)
            {
                totalScore += checklistGoal.Points * checklistGoal.CurrentCount;
                if (checklistGoal.IsCompleted)
                {
                    totalScore += checklistGoal.BonusPoints;
                }
            }
        }
    }

    public static void CreateNewGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("\nSelect an option: ");
        string input = Console.ReadLine();

        Goal newGoal = null;

        switch (input)
        {
            case "1":
                newGoal = new SimpleGoal();
                break;
            case "2":
                newGoal = new EternalGoal();
                break;
            case "3":
                newGoal = new ChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid option. Goal not created.");
                return;
        }

        Console.Write("Enter goal name: ");
        newGoal.Name = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        newGoal.Points = int.Parse(Console.ReadLine());

        if (newGoal is ChecklistGoal checklistGoal)
        {
            Console.Write("Enter the target count for this goal: ");
            checklistGoal.TargetCount = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points for completing this goal: ");
            checklistGoal.BonusPoints = int.Parse(Console.ReadLine());
        }

        Program.goals.Add(newGoal);
    }

    public static void RecordEvent()
    {
        Console.WriteLine("\nSelect Goal Type to Record Event:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("\nSelect an option: ");
        string input = Console.ReadLine();

        List<Goal> selectedGoals = null;

        switch (input)
        {
            case "1":
                selectedGoals = Program.goals.FindAll(g => g is SimpleGoal);
                break;
            case "2":
                selectedGoals = Program.goals.FindAll(g => g is EternalGoal);
                break;
            case "3":
                selectedGoals = Program.goals.FindAll(g => g is ChecklistGoal);
                break;
            default:
                Console.WriteLine("Invalid option.");
                return;
        }

        if (selectedGoals.Count == 0)
        {
            Console.WriteLine("No goals of this type found.");
            return;
        }

        Console.WriteLine("\nSelect a goal to record event:");
        for (int i = 0; i < selectedGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {selectedGoals[i].Name}");
        }

        Console.Write("\nSelect an option: ");
        input = Console.ReadLine();
        int goalIndex;
        if (int.TryParse(input, out goalIndex) && goalIndex > 0 && goalIndex <= selectedGoals.Count)
        {
            selectedGoals[goalIndex - 1].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid option.");
        }
    }

    public static void ViewGoalsMenu()
    {
        Console.WriteLine("\nView Goals Menu:");
        Console.WriteLine("1. View Simple Goals");
        Console.WriteLine("2. View Eternal Goals");
        Console.WriteLine("3. View Checklist Goals");

        Console.Write("\nSelect an option: ");
        string input = Console.ReadLine();

        List<Goal> selectedGoals = null;

        switch (input)
        {
            case "1":
                selectedGoals = Program.goals.FindAll(g => g is SimpleGoal);
                break;
            case "2":
                selectedGoals = Program.goals.FindAll(g => g is EternalGoal);
                break;
            case "3":
                selectedGoals = Program.goals.FindAll(g => g is ChecklistGoal);
                break;
            default:
                Console.WriteLine("Invalid option.");
                return;
        }

        if (selectedGoals.Count == 0)
        {
            Console.WriteLine("No goals of this type found.");
            return;
        }

        Console.WriteLine("\nCurrent Goals:");
        foreach (var goal in selectedGoals)
        {
            Console.WriteLine($"- {goal.Name} ({goal.Points} points)");
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"  Progress: {checklistGoal.CurrentCount}/{checklistGoal.TargetCount}");
            }
        }
    }
}
