using System;

class JournalEntry
{
    public string Prompt {get; set;}
    public string Response {get; set;}
    public string Date {get; set;}

    public JournalEntry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public override string ToString()
    {
        return $"{Date} - {Prompt}\n{Response}\n";
    }
}