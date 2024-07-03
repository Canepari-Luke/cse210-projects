using System.Collections.Generic;

namespace SolarSystemSimulator
{
    public class SolarSystem
    {
        public List<CelestialBody> Bodies { get; set; } = new List<CelestialBody>();

        public void AddBody(CelestialBody body)
        {
            Bodies.Add(body);
        }

        public void RemoveBody(CelestialBody body)
        {
            Bodies.Remove(body);
        }

        public void Simulate(double timeStep)
        {
            foreach (var body in Bodies)
            {
                body.UpdatePosition(timeStep);
            }
        }

        public List<CelestialBody> GetAllBodies()
        {
            return Bodies;
        }
    }
}
