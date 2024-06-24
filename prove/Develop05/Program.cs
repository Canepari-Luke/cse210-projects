using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuestProgram
{
    // Class responsible for managing goals and user interactions
    class Program
    {
        static List<Goal> goals = new List<Goal>(); // List to store goals
        static int totalScore = 0; // Total score of the user

        static void Main(string[] args)
        {
            LoadGoals(); // Load goals from file
            bool running = true;

            while (running)
            {
                Console.Clear();
                ShowGoals(); // Display the list of goals
                Console.WriteLine($"\nTotal Score: {totalScore}");
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Save and Exit");

                Console.Write("\nSelect an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewGoal(); // Create a new goal
                        break;
                    case "2":
                        RecordEvent(); // Record an event for a goal
                        break;
                    case "3":
                        SaveGoals(); // Save goals and exit
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateNewGoal()
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

            goals.Add(newGoal);
        }

        static void RecordEvent()
        {
            ShowGoals();
            Console.Write("Select a goal to record an event: ");
            int goalIndex = int.Parse(Console.ReadLine()) - 1;

            if (goalIndex >= 0 && goalIndex < goals.Count)
            {
                var goal = goals[goalIndex];
                goal.RecordEvent();
                totalScore += goal.Points;
                if (goal is ChecklistGoal checklistGoal && checklistGoal.IsCompleted)
                {
                    totalScore += checklistGoal.BonusPoints;
                }
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        static void ShowGoals()
        {
            Console.WriteLine("\nGoals:");
            for (int i = 0; i < goals.Count; i++)
            {
                var goal = goals[i];
                Console.WriteLine($"{i + 1}. {goal.Name} - {goal.GetProgress()}");
            }
        }

        static void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                var lines = File.ReadAllLines("goals.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    Goal goal = null;

                    switch (parts[0])
                    {
                        case "SimpleGoal":
                            goal = new SimpleGoal();
                            break;
                        case "EternalGoal":
                            goal = new EternalGoal();
                            break;
                        case "ChecklistGoal":
                            goal = new ChecklistGoal();
                            break;
                    }

                    if (goal != null)
                    {
                        goal.Deserialize(parts[1]);
                        goals.Add(goal);
                    }
                }
            }
        }

        static void SaveGoals()
        {
            using (StreamWriter outputFile = new StreamWriter("goals.txt"))
            {
                foreach (var goal in goals)
                {
                    outputFile.WriteLine(goal.Serialize());
                }
            }
        }
    }
}
