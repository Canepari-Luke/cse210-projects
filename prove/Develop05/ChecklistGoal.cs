using System;

namespace EternalQuestProgram
{
    // Derived class for goals that need to be completed multiple times with a bonus
    public class ChecklistGoal : Goal
    {
        public int TargetCount { get; set; } // Number of times the goal needs to be completed
        public int CurrentCount { get; set; } // Current progress count
        public int BonusPoints { get; set; } // Bonus points awarded on completion

        public override void RecordEvent()
        {
            if (CurrentCount < TargetCount)
            {
                CurrentCount++;
                Console.WriteLine($"Recorded '{Name}'! You earned {Points} points. Progress: {CurrentCount}/{TargetCount}.");
                if (CurrentCount == TargetCount)
                {
                    IsCompleted = true;
                    Console.WriteLine($"Goal '{Name}' completed! You earned a bonus of {BonusPoints} points.");
                }
            }
            else
            {
                Console.WriteLine($"Goal '{Name}' is already completed.");
            }
        }

        public override string GetProgress()
        {
            return IsCompleted ? $"[X] Completed {CurrentCount}/{TargetCount}" : $"[ ] Progress {CurrentCount}/{TargetCount}";
        }

        public override string Serialize()
        {
            return $"ChecklistGoal:{Name},{Points},{CurrentCount},{TargetCount},{BonusPoints},{IsCompleted}";
        }

        public override void Deserialize(string data)
        {
            var parts = data.Split(',');
            Name = parts[0];
            Points = int.Parse(parts[1]);
            CurrentCount = int.Parse(parts[2]);
            TargetCount = int.Parse(parts[3]);
            BonusPoints = int.Parse(parts[4]);
            IsCompleted = bool.Parse(parts[5]);
        }
    }
}
