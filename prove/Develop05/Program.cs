using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    public static List<Goal> goals = new List<Goal>(); // Changed to public

    static void Main(string[] args)
    {
        UserInterface.Initialize();
    }

    public static void SaveGoals()
    {
        SaveGoalsToFile("simpleGoals.txt", goals.FindAll(g => g is SimpleGoal));
        SaveGoalsToFile("eternalGoals.txt", goals.FindAll(g => g is EternalGoal));
        SaveGoalsToFile("checklistGoals.txt", goals.FindAll(g => g is ChecklistGoal));
    }

    public static void LoadGoals()
    {
        LoadGoalsFromFile("simpleGoals.txt");
        LoadGoalsFromFile("eternalGoals.txt");
        LoadGoalsFromFile("checklistGoals.txt");
    }

    private static void SaveGoalsToFile(string fileName, List<Goal> goals)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (var goal in goals)
            {
                outputFile.WriteLine(goal.Serialize());
            }
        }
    }

    private static void LoadGoalsFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            var lines = File.ReadAllLines(fileName);
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
}
