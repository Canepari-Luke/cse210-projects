public class CelestialBody
{
    public double Mass { get; set; }
    public Vector3D Position { get; set; }
    public Vector3D Velocity { get; set; }
    public Vector3D Acceleration { get; set; }

    public CelestialBody(double mass, Vector3D position, Vector3D velocity)
    {
        Mass = mass;
        Position = position;
        Velocity = velocity;
        Acceleration = new Vector3D(0, 0, 0);
    }

    public void UpdatePosition(double timeStep)
    {
        // Update position based on current velocity and time step
        Position.X += Velocity.X * timeStep;
        Position.Y += Velocity.Y * timeStep;
        Position.Z += Velocity.Z * timeStep;
    }

    public void ResetAcceleration()
    {
        Acceleration.X = 0;
        Acceleration.Y = 0;
        Acceleration.Z = 0;
    }

    public void AddForce(Vector3D force)
    {
        // Calculate acceleration based on force and current mass
        Acceleration.X += force.X / Mass;
        Acceleration.Y += force.Y / Mass;
        Acceleration.Z += force.Z / Mass;
    }
}
