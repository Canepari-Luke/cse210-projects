using System;
using System.Collections.Generic;
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
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);
        Thread.Sleep(5000);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("List an item: ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {items.Count} items.");
        base.End();
    }
}
