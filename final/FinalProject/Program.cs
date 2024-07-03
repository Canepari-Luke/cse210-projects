// Program.cs
using System;

namespace SolarSystemSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            SolarSystem solarSystem = new SolarSystem();
            SaveLoadManager saveLoadManager = new SaveLoadManager();
            PhysicsEngine physicsEngine = new PhysicsEngine();

            while (true)
            {
                Console.WriteLine("1: New Solar System");
                Console.WriteLine("2: Load Solar System");
                Console.WriteLine("3: Training");
                Console.WriteLine("4: Revert Last Change");
                Console.WriteLine("5: Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        solarSystem = CreateNewSolarSystem();
                        break;
                    case "2":
                        solarSystem = LoadSolarSystem(saveLoadManager);
                        break;
                    case "3":
                        solarSystem = TrainingMode();
                        break;
                    case "4":
                        solarSystem.RevertState();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (solarSystem != null)
                {
                    NotificationSystem.Notify("Starting simulation of solar system...");
                    for (int i = 0; i < 1000; i++)
                    {
                        physicsEngine.Simulate(solarSystem, 1.0);
                        if (i % 100 == 0)
                        {
                            solarSystem.PrintState();
                        }
                    }
                    NotificationSystem.Notify("Simulation complete.");
                }
            }
        }

        private static SolarSystem CreateNewSolarSystem()
        {
            SolarSystem solarSystem = new SolarSystem();
            NotificationSystem.Notify("Creating a new solar system...");
            // Add code to create new celestial bodies and add them to the solar system
            return solarSystem;
        }

        private static SolarSystem LoadSolarSystem(SaveLoadManager saveLoadManager)
        {
            string[] savedSystems = saveLoadManager.GetSavedSystems();
            if (savedSystems.Length == 0)
            {
                Console.WriteLine("No solar system saved.");
                return null;
            }

            Console.WriteLine("Available saved solar systems:");
            for (int i = 0; i < savedSystems.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {savedSystems[i]}");
            }

            Console.Write("Choose a solar system to load: ");
            int choice = int.Parse(Console.ReadLine());
            return saveLoadManager.LoadSystem(savedSystems[choice - 1]);
        }

        private static SolarSystem TrainingMode()
        {
            SolarSystem solarSystem = new SolarSystem();
            NotificationSystem.Notify("Training mode: Creating the Sol system...");

            // Step 1: Add the Sun
            solarSystem.AddBody(TrainingData.Sun);
            NotificationSystem.Notify("Step 1: Added the Sun");

            // Step 2: Add Planets
            for (int i = 0; i < TrainingData.Planets.Length; i++)
            {
                Planet planet = TrainingData.Planets[i];
                solarSystem.AddBody(planet);
                NotificationSystem.Notify($"Step {i + 2}: Added planet {i + 1} with mass {planet.Mass} kg, position {planet.Position.X}m, {planet.Position.Y}m, {planet.Position.Z}m and velocity {planet.Velocity.X}m/s, {planet.Velocity.Y}m/s, {planet.Velocity.Z}m/s");
            }

            // Additional steps for moons and other details can be added here
            Moon moon = new Moon(7.35e22, new Vector3D(1.496e11 + 3.84e8, 0, 0), new Vector3D(0, 2.98e4 + 1.02e3, 0)) { Radius = 1737.4 };
            solarSystem.AddBody(moon);
            NotificationSystem.Notify("Added the Moon");

            NotificationSystem.Notify("Training complete. Review the system state below:");
            solarSystem.PrintState();

            return solarSystem;
        }
    }
}
