public class Moon : CelestialBody
{
    public Planet OrbitalPlanet { get; set; }

    public Moon(double mass, Vector3D position, Vector3D velocity, Planet orbitalPlanet)
        : base(mass, position, velocity)
    {
        OrbitalPlanet = orbitalPlanet;
    }

    public void ImpactTides()
    {
        // Impact tides on the orbital planet
        // Example implementation
        // ...
    }
}
