using System;

namespace EternalQuestProgram
{
    // Derived class for goals that can be repeated indefinitely
    public class EternalGoal : Goal
    {
        public int Count { get; set; } // Count of how many times the goal has been recorded

        public override void RecordEvent()
        {
            Count++;
            Console.WriteLine($"Recorded '{Name}'! You earned {Points} points. Total count: {Count}.");
        }

        public override string GetProgress()
        {
            return $"[∞] Count: {Count}";
        }

        public override string Serialize()
        {
            return $"EternalGoal:{Name},{Points},{Count}";
        }

        public override void Deserialize(string data)
        {
            var parts = data.Split(',');
            Name = parts[0];
            Points = int.Parse(parts[1]);
            Count = int.Parse(parts[2]);
        }
    }
}
