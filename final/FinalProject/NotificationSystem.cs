using System;

namespace SolarSystemSimulator
{
    public static class NotificationSystem
    {
        public static void Notify(string message)
        {
            Console.WriteLine($"Notification: {message}");
        }
    }
}
