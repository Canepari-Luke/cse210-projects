using System;
using System.Threading;

class Activity
{
    protected string _title;
    protected string _description;
    protected int _duration;

    public Activity(string title, string description, int duration)
    {
        _title = title;
        _description = description;
        _duration = duration;
    }

    public virtual void Start()
    {
        Console.Clear();
        Program.TypeOut($"Starting {_title}");
        Console.WriteLine();  // New line for formatting
        Program.TypeOut(_description);
        Console.WriteLine();  // New line for formatting
        Program.TypeOut($"This activity will last for {_duration} seconds.");
        Console.WriteLine();  // New line for formatting
        Thread.Sleep(3000);  // Pause before starting
    }

    public virtual void End()
    {
        Console.Clear();
        Program.TypeOut("Good job! You have completed the activity.");
        Console.WriteLine();  // New line for formatting
        Program.TypeOut($"You completed {_title} for {_duration} seconds.");
        Thread.Sleep(3000);  // Pause before ending
    }

    protected void DisplayAnimation()
    {
        string[] spinner = { "/", "-", "\\", "|" };
        for (int i = 0; i < 10; i++)
        {
            foreach (string s in spinner)
            {
                Console.Write(s);
                Thread.Sleep(100);
                Console.Write("\b \b");  // Erase the character
            }
        }
    }
}
