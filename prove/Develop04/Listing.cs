using System;
using System.Threading;

class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity(string title, string description, int duration) : base(title, description, duration)
    {
    }

    public override void Start()
    {
        base.Start();
        Random rand = new Random();
        Console.Clear();
        Program.TypeOut(prompts[rand.Next(prompts.Length)]);
        Console.WriteLine();  // New line for formatting
        Program.TypeOut("You have a few seconds to start listing...");
        Thread.Sleep(5000);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now < endTime)
        {
            Program.TypeOut("Enter an item: ");
            Console.ReadLine();
            count++;
        }

        Console.Clear();
        Program.TypeOut($"You listed {count} items.");
        Thread.Sleep(3000);
        base.End();
    }
}
