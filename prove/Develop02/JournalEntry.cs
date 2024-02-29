using System;

// JournalEntry class represents an individual entry in the journal with a prompt, response, and date.
public class JournalEntry
{
    
    // Properties to store the prompt, response, and date of the journal entry.
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date{ get; set; }
    
    // Constructor to initialize a new JournalEntry with the specified prompt, response, and date.
    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
    
    // Overrides the ToString method to provide a formatted string representation of the journal entry.
    public override string ToString()
    {
        return $"{Date} | Prompt: {Prompt} | Response: {Response}";

    }
}