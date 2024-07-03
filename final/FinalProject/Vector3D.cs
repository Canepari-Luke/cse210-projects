using System;

namespace SolarSystemSimulator
{
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z); // Fixed syntax error
        }

        public Vector3D Normalize()
        {
            double magnitude = Magnitude();
            return new Vector3D(X / magnitude, Y / magnitude, Z / magnitude);
        }

        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3D operator *(Vector3D a, double b)
        {
            return new Vector3D(a.X * b, a.Y * b, a.Z * b);
        }

        public static Vector3D operator *(double a, Vector3D b)
        {
            return new Vector3D(a * b.X, a * b.Y, a * b.Z);
        }

        // Overloading the division operator
        public static Vector3D operator /(Vector3D a, double b)
        {
            return new Vector3D(a.X / b, a.Y / b, a.Z / b);
        }
    }
}
