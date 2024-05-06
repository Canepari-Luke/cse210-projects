using System;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course1 = new Course();
            course1._courseCode = "CSE210";
            course1._courseName = "Programming with Classes";
            course1._creditHours = 2; // Corrected property name
            course1._color = "green";
            course1.Display();

            Console.WriteLine("Howdy Sandbox World!"); // Moved outside the block
        }
    }
}
//Changed it for in class practice