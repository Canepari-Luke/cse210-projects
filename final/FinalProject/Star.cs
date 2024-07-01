public class Star : CelestialBody
{
    public double Luminosity { get; set; }
    public double Temperature { get; set; }

    public Star(double mass, Vector3D position, Vector3D velocity, double luminosity, double temperature)
        : base(mass, position, velocity)
    {
        Luminosity = luminosity;
        Temperature = temperature;
    }

    public void GenerateHeat()
    {
        // Generate heat based on luminosity and temperature
        // Example implementation
        // ...
    }
}
