namespace SolarSystemSimulator
{
    public static class TrainingData
    {
        public static Star Sun = new Star(1.989e30, new Vector3D(0, 0, 0), new Vector3D(0, 0, 0)) { Radius = 696340 };
        
        public static Planet[] Planets = new Planet[]
        {
            new Planet(3.285e23, new Vector3D(5.791e10, 0, 0), new Vector3D(0, 4.79e4, 0)) { Radius = 2439.7 },
            new Planet(4.867e24, new Vector3D(1.082e11, 0, 0), new Vector3D(0, 3.5e4, 0)) { Radius = 6051.8 },
            new Planet(5.972e24, new Vector3D(1.496e11, 0, 0), new Vector3D(0, 2.98e4, 0)) { Radius = 6371.0 },
            new Planet(6.39e23, new Vector3D(2.279e11, 0, 0), new Vector3D(0, 2.41e4, 0)) { Radius = 3389.5 },
            new Planet(1.898e27, new Vector3D(7.785e11, 0, 0), new Vector3D(0, 1.31e4, 0)) { Radius = 69911 },
            new Planet(5.683e26, new Vector3D(1.433e12, 0, 0), new Vector3D(0, 9.7e3, 0)) { Radius = 58232 },
            new Planet(8.681e25, new Vector3D(2.871e12, 0, 0), new Vector3D(0, 6.8e3, 0)) { Radius = 25362 },
            new Planet(1.024e26, new Vector3D(4.495e12, 0, 0), new Vector3D(0, 5.4e3, 0)) { Radius = 24622 }
        };
    }
}
