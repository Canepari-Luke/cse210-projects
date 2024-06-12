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

    protected void DisplayMessage(string message)
    {
        Console.Clear();
        Program.TypeOut(message);
        Console.WriteLine();  // New line for formatting
    }

    protected void DisplayAnimation()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    public virtual void Start()
    {
        DisplayMessage($"Starting {_title}. {_description}");
        Program.TypeOut($"The activity will last for {_duration} seconds. Prepare to begin...");
        Console.WriteLine();  // New line for formatting
        DisplayAnimation();
        Program.TypeOut("Starting now...");
        Console.WriteLine();  // New line for formatting
        Thread.Sleep(2000);
        End();
    }

    protected void End()
    {
        DisplayMessage($"Well done! You have completed the {_title} for {_duration} seconds.");
        DisplayAnimation();
        Program.TypeOut("Activity completed.");
        Console.WriteLine();  // New line for formatting
        Thread.Sleep(2000);
    }
}
