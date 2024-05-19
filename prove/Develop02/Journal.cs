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
        "Did you accomplish or progress a goal today?",
        "Did you fall short of a goal today?",
        "What's a goal that you set or will continue for tomorrow?",
        "What's something you're grateful for?",
        "Who is someone you're most grateful for? What did they do that you respect or appreciate?",
        "How has the Lord helped you today?",
        "What have you done for the Lord today?",
        "What have you learned from the Lord today?",
        "What are you grateful for in the Lord?",
        "Did you take on any responsibilities today?",
        "Will you take on any new responsibilities tomorrow?"
    };

    public const string DefaultFilename = "JournalEntries.txt";

    public void AddEntry()
    {
        Random random = new Random();
        int promptIndex = random.Next(prompts.Count);
        string prompt = prompts[promptIndex];

        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        JournalEntry entry = new JournalEntry(prompt, response);
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
    Console.WriteLine("Please enter filename (default is 'JournalEntries.txt'): ");
    string filename = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(filename))
    {
        filename = DefaultFilename;
    }

    // Debugging output
    Console.WriteLine($"Saving journal to file: {filename}");

    using (StreamWriter writer = new StreamWriter(filename))
    {
        writer.WriteLine("Date|Prompt|Response"); // TXT header
        foreach (var entry in entries)
        {
            writer.WriteLine($"{EscapeTxt(entry.Date)}|{EscapeTxt(entry.Prompt)}|{EscapeTxt(entry.Response)}");
        }
    }

    // Debugging output
    Console.WriteLine($"Journal saved to {filename}.");
}


    public void LoadFromFile()
    {
        Console.WriteLine("Please enter filename (default is 'JournalEntries.txt'): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = DefaultFilename;
        }

        if (File.Exists(filename))
        {
            entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line = reader.ReadLine(); // Skip the header line
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = ParseTxtLine(line);
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

    // Method to escape TXT field
    public string EscapeTxt(string field)
    {
        if (field.Contains("|") || field.Contains("\""))
        {
            field = field.Replace("\"", "\"\"");
            field = $"\"{field}\"";
        }
        return field;
    }

    // Method to parse TXT line
    public string[] ParseTxtLine(string line)
    {
        var fields = new List<string>();
        var field = new System.Text.StringBuilder();
        bool inQuotes = false;

        for (int i = 0; i < line.Length; i++)
        {
            char current = line[i];
            if (inQuotes)
            {
                // Look ahead to see if the next character is also a quote (escape quote)
                if (current == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        field.Append('"'); // Add a single quote to the field
                        i++; // Skip the next quote character by incrementing the index
                    }
                    else
                    {
                        inQuotes = false; // End of quoted section
                    }
                }
                else
                {
                    field.Append(current); // Add the current character to the field
                }
            }
            else
            {
                if (current == '"')
                {
                    inQuotes = true; // Start of quoted section
                }
                else if (current == '|')
                {
                    fields.Add(field.ToString()); // Add the completed field to the list
                    field.Clear(); // Clear the field builder for the next field
                }
                else
                {
                    field.Append(current); // Add the current character to the field
                }
            }
        }
        fields.Add(field.ToString()); // Add the last field to the list

        return fields.ToArray(); // Return the list of fields as an array
    }
}
