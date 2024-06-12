using System;
using System.Threading;

class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you learned something new.",
        "Think of a time when you took a risk.",
        "Think of a time when you made someone smile.",
        "Think of a time when you made something beautiful.",
        "Think of a time when you struggled with something.",
        "Think of a time when you fell short.",
        "Think of a time when you realized you were wrong.",
        "Think of a time when you built something with your own hands.",
        "Think of a time when you made someone else happy.",
        "Think of the most important person in your life.",
        "Think of someone you have struggled with in the past.",
        "Think of someone you are struggling to get along with."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
        "What went wrong with this experience?",
        "What did you learn from this experience?",
        "What will you do differently next time?",
        "What would you do differently if you could do it again?",
        "Who are you thinking about?",
        "What makes this person important in your life?",
        "What can you say about this person?",
        "Who are they to you?"
    };

    public ReflectionActivity(string title, string description, int duration) : base(title, description, duration)
    {
    }

    public override void Start()
    {
        base.Start();
        Random rand = new Random();
        Console.Clear();
        Program.TypeOut(prompts[rand.Next(prompts.Length)]);
        Console.WriteLine();  // New line for formatting
        Thread.Sleep(5000);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Program.TypeOut(questions[rand.Next(questions.Length)]);
            Console.WriteLine();  // New line for formatting
            DisplayAnimation();
        }
        base.End();
    }
}
