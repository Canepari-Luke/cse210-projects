using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            TypeOut("Mindfulness Program");
            Console.WriteLine();  // New line for formatting
            TypeOut("1. Breathing Activity");
            Console.WriteLine();  // New line for formatting
            TypeOut("2. Reflection Activity");
            Console.WriteLine();  // New line for formatting
            TypeOut("3. Listing Activity");
            Console.WriteLine();  // New line for formatting
            TypeOut("4. Exit");
            Console.WriteLine();  // New line for formatting
            TypeOut("Choose an activity (1-4): ");
            string choice = Console.ReadLine();

            if (choice == "4")
            {
                TypeOut("Good luck with your future endeavors...");
                Thread.Sleep(2000);
                break;
            }

            if (choice != "1" && choice != "2" && choice != "3")
            {
                TypeOut("Invalid choice. Please select a valid option.");
                Thread.Sleep(2000);
                continue;
            }

            TypeOut("Enter duration of the activity in seconds: ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                TypeOut("Please enter a valid duration in seconds: ");
            }

            switch (choice)
            {
                case "1":
                    var breathingActivity = new BreathingActivity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", duration);
                    breathingActivity.Start();
                    break;
                case "2":
                    var reflectionActivity = new ReflectionActivity("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", duration);
                    reflectionActivity.Start();
                    break;
                case "3":
                    var listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", duration);
                    listingActivity.Start();
                    break;
            }
        }
    }

    public static void TypeOut(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(60);  // 0.06 seconds per character
        }
    }
}
