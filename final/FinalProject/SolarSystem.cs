// SolarSystem.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolarSystemSimulator
{
    public class SolarSystem
    {
        private List<CelestialBody> bodies;
        private Stack<List<CelestialBody>> history;

        public SolarSystem()
        {
            bodies = new List<CelestialBody>();
            history = new Stack<List<CelestialBody>>();
        }

        public void AddBody(CelestialBody body)
        {
            SaveState();
            bodies.Add(body);
            NotificationSystem.Notify($"Added a new body: {body.GetType().Name} with mass {body.Mass}");
        }

        public void RemoveBody(CelestialBody body)
        {
            SaveState();
            bodies.Remove(body);
            NotificationSystem.Notify($"Removed a body: {body.GetType().Name}");
        }

        public List<CelestialBody> GetAllBodies()
        {
            return bodies;
        }

        public void PrintState()
        {
            foreach (var body in bodies)
            {
                Console.WriteLine($"{body.GetType().Name} - Mass: {body.Mass}, Position: {body.Position.X}, {body.Position.Y}, {body.Position.Z}, Velocity: {body.Velocity.X}, {body.Velocity.Y}, {body.Velocity.Z}");
            }
        }

        private void SaveState()
        {
            // Deep copy the current state
            var stateCopy = bodies.Select(b => (CelestialBody)b.Clone()).ToList();
            history.Push(stateCopy);
        }

        public void RevertState()
        {
            if (history.Count > 0)
            {
                bodies = history.Pop();
                NotificationSystem.Notify("Reverted to previous state.");
            }
            else
            {
                NotificationSystem.Notify("No previous state to revert to.");
            }
        }
    }
}
