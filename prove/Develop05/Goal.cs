using System;

namespace EternalQuestProgram
{
    // Abstract base class representing a generic goal
    public abstract class Goal
    {
        public string Name { get; set; } // Name of the goal
        public int Points { get; set; } // Points awarded for completing the goal
        public bool IsCompleted { get; set; } // Indicates if the goal is completed

        // Abstract method to record an event (to be implemented by derived classes)
        public abstract void RecordEvent();

        // Abstract method to get progress of the goal (to be implemented by derived classes)
        public abstract string GetProgress();

        // Abstract method to serialize the goal for saving
        public abstract string Serialize();

        // Abstract method to deserialize the goal for loading
        public abstract void Deserialize(string data);
    }
}
