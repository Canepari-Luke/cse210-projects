using System;

namespace EternalQuestProgram
{
    // Derived class for simple one-time goals
    public class SimpleGoal : Goal
    {
        public override void RecordEvent()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points.");
            }
            else
            {
                Console.WriteLine($"Goal '{Name}' is already completed.");
            }
        }

        public override string GetProgress()
        {
            return IsCompleted ? "[X]" : "[ ]";
        }

        public override string Serialize()
        {
            return $"SimpleGoal:{Name},{Points},{IsCompleted}";
        }

        public override void Deserialize(string data)
        {
            var parts = data.Split(',');
            Name = parts[0];
            Points = int.Parse(parts[1]);
            IsCompleted = bool.Parse(parts[2]);
        }
    }
}
