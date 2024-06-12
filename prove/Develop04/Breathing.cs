using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity(string title, string description, int duration) : base(title, description, duration)
    {
    }

    public override void Start()
    {
        base.Start();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Program.TypeOut("Breathe in...");
            Thread.Sleep(4000);
            Console.Clear();
            Program.TypeOut("Breathe out...");
            Thread.Sleep(4000);
        }
        base.End();
    }
}
