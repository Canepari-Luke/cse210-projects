public class Planet : CelestialBody
{
    public string Atmosphere { get; set; }
    public double OrbitalRadius { get; set; }

    public Planet(double mass, Vector3D position, Vector3D velocity, string atmosphere, double orbitalRadius)
        : base(mass, position, velocity)
    {
        Atmosphere = atmosphere;
        OrbitalRadius = orbitalRadius;
    }

    public bool SupportLife()
    {
        // Check if the planet can support life
        // Example implementation
        // ...
        return false;
    }
}
