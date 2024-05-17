using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "What was the best part of your day?",
        "What was the worst part of your day?",
        "What did you regret the most?",
        "What is something you wish you could have done differently, What would you change?",
        "What is something you're proud of? Something you accomplished or achieved?",
        "did you accomplish or progress a goal today?",
        "did you fall short of a goal today?",
        "What's a goal that you set or will continue for tommorrow?",
        "What's something you're grateful for?",
        "Who is someone you're most grateful for? What did they do that you respect or appreciate?",
        "How has the Lord helped you today?",
        "What have you done for the Lord today?",
        "What have you learned from the Lord today?",
        "What are you grateful for in the Lord?",
        "Did you take on any responsibilties today?",
        "Will you take on any new responsibilties tomorrow?",
    };

    public void AddEntry()
    {
        Random random = new Random();
        int PromptIndex = random.Next(prompts.Count);
        string Prompt = prompts[PromptIndex];

        Console.WriteLine(Prompt);
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry(Prompt, response);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.WriteLine("Please enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date} | {entry.Prompt} | {entry.Response}");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile()
    {
        Console.Write("Please enter filename: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split("|");
                    if (parts.Length == 3)
                    {
                        JournalEntry entry = new JournalEntry(parts[1], parts[2])
                        {
                            Date = parts[0]
                        };
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    
}

