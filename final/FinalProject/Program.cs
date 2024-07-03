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
                Console.WriteLine("4: Quit");
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
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (solarSystem != null)
                {
                    Console.WriteLine("Simulating solar system...");
                    // Simulate the solar system for a given duration
                    for (int i = 0; i < 1000; i++)
                    {
                        physicsEngine.Simulate(solarSystem, 1.0);
                    }
                }
            }
        }

        private static SolarSystem CreateNewSolarSystem()
        {
            SolarSystem solarSystem = new SolarSystem();
            Console.WriteLine("Creating a new solar system...");
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
            Console.WriteLine("Training mode: Creating the Sol system...");
            // Add code to create the Sol system (Earth's real-life solar system)
            return solarSystem;
        }
    }
}
