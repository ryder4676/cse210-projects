using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries;

    // Constructor to initialize the list of journal entries.
    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    // Method to add a new journal entry to the list.
    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    // Method to display all journal entries in the console.
    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    // Method to save journal entries to a file.
    public void SaveToFile(string filename)
    {
        // Using StreamWriter to write entries to a specified file.
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                // Writing formatted entry data to the file.
                writer.WriteLine($"{entry.Date}, {entry.Prompt}, {entry.Response}");
            }
        }
    }

    // Method to load journal entries from a file.
    public void LoadFromFile(string filename)
    {
        // Clearing existing entries before loading new ones.
        entries.Clear();
        
        try
        {
            // Using StreamReader to read entries from the specified file.
            using (StreamReader reader = new StreamReader(filename))
            {
                // Reading lines until the end of the file.
                while (!reader.EndOfStream)
                {
                    // Splitting the line into parts based on commas.
                    string[] parts = reader.ReadLine().Split(",");
                    
                    // Checking if the line has three parts (Date, Prompt, Response).
                    if (parts.Length == 3)
                    {
                        // Creating a new JournalEntry object and adding it to the list.
                        JournalEntry entry = new JournalEntry(parts[1], parts[2], parts[0]);
                        entries.Add(entry);
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            // Handling the case where the file is not found.
            Console.WriteLine("File not found. Creating a new journal.");
        }
    }
}
