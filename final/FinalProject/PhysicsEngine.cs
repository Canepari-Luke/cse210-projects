namespace SolarSystemSimulator
{
    public class PhysicsEngine
    {
        public void Simulate(SolarSystem solarSystem, double timeStep)
        {
            // Update velocities based on gravitational forces
            foreach (var body in solarSystem.GetAllBodies())
            {
                Vector3D totalForce = new Vector3D(0, 0, 0);
                foreach (var otherBody in solarSystem.GetAllBodies())
                {
                    if (body != otherBody)
                    {
                        totalForce += CalculateGravitationalForce(body, otherBody);
                    }
                }
                Vector3D acceleration = totalForce / body.Mass; // Fixed division issue
                body.Velocity += acceleration * timeStep;
            }

            // Update positions and handle collisions
            foreach (var body in solarSystem.GetAllBodies())
            {
                body.UpdatePosition(timeStep);
                HandleCollisions(solarSystem, body);
            }
        }

        private Vector3D CalculateGravitationalForce(CelestialBody body1, CelestialBody body2)
        {
            double G = 6.67430e-11; // Gravitational constant
            Vector3D distanceVector = body2.Position - body1.Position;
            double distance = distanceVector.Magnitude();
            double forceMagnitude = G * body1.Mass * body2.Mass / (distance * distance);
            return distanceVector.Normalize() * forceMagnitude;
        }

        private void HandleCollisions(SolarSystem solarSystem, CelestialBody body)
        {
            foreach (var otherBody in solarSystem.GetAllBodies())
            {
                if (body != otherBody && IsColliding(body, otherBody))
                {
                    ResolveCollision(solarSystem, body, otherBody);
                }
            }
        }

        private bool IsColliding(CelestialBody body1, CelestialBody body2)
        {
            double distance = (body1.Position - body2.Position).Magnitude();
            // Assuming each body has a radius property for simplicity
            return distance < (body1.Radius + body2.Radius);
        }

        private void ResolveCollision(SolarSystem solarSystem, CelestialBody body1, CelestialBody body2)
        {
            // Simple collision resolution: merge bodies into a new one
            double newMass = body1.Mass + body2.Mass;
            Vector3D newPosition = (body1.Position * body1.Mass + body2.Position * body2.Mass) / newMass;
            Vector3D newVelocity = (body1.Velocity * body1.Mass + body2.Velocity * body2.Mass) / newMass;

            CelestialBody newBody = new CelestialBody(newMass, newPosition, newVelocity)
            {
                Radius = Math.Max(body1.Radius, body2.Radius) // Assuming the new radius is the larger of the two
            };

            solarSystem.AddBody(newBody);
            solarSystem.RemoveBody(body1);
            solarSystem.RemoveBody(body2);
        }
    }
}
