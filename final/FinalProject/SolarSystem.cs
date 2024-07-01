public class SolarSystem
{
    public List<Star> Stars { get; private set; }
    public List<Planet> Planets { get; private set; }
    public List<Moon> Moons { get; private set; }

    public SolarSystem()
    {
        Stars = new List<Star>();
        Planets = new List<Planet>();
        Moons = new List<Moon>();
    }

    public void AddStar(Star star)
    {
        Stars.Add(star);
    }

    public void AddPlanet(Planet planet)
    {
        Planets.Add(planet);
    }

    public void AddMoon(Moon moon)
    {
        Moons.Add(moon);
    }

    public void Clear()
    {
        Stars.Clear();
        Planets.Clear();
        Moons.Clear();
    }
}
