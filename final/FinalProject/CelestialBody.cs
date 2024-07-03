namespace SolarSystemSimulator
{
    public class CelestialBody
    {
        public double Mass { get; set; }
        public Vector3D Position { get; set; }
        public Vector3D Velocity { get; set; }
        public double Radius { get; set; } // Add radius property

        public CelestialBody(double mass, Vector3D position, Vector3D velocity)
        {
            Mass = mass;
            Position = position;
            Velocity = velocity;
        }

        public void UpdatePosition(double timeStep)
        {
            Position += Velocity * timeStep;
        }
    }
}
