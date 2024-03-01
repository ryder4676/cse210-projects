using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;

public class Journal
{
    // private keyword is an access modifier that restricts the visibility of a member (variable, method, or property) to the containing class
    private List<JournalEntry> entries;
     private MongoClient mongoClient;
    private IMongoDatabase database;
    private IMongoCollection<JournalEntry> collection;

    // Constructor to initialize the list of journal entries.
     public Journal(string connectionString, string databaseName)
    {
        entries = new List<JournalEntry>();
        mongoClient = new MongoClient(connectionString);
        database = mongoClient.GetDatabase(databaseName);
        collection = database.GetCollection<JournalEntry>("JournalEntries");
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
                writer.WriteLine($"{entry.Date}   {entry.Prompt}   {entry.Response}");
                
            }
        }Console.WriteLine($"Sucessfully saved to: {filename}!");
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
                    // Splitting the line into parts based on colons. Based on the text file
                    string[] parts = reader.ReadLine().Split(new[] {"   "}, StringSplitOptions.None);
                    
                    // Checking if the line has three parts (Date, Prompt, Response). In the text file.
                    if (parts.Length == 3)
                    {
                        // Creating a new JournalEntry object and adding it to the list.
                        JournalEntry entry = new JournalEntry(parts[1], parts[2], parts[0]);
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine($"Sucessfully Loaded: {filename}");
        }
        catch (FileNotFoundException)
        {
            // Handling the case where the file is not found.
            Console.WriteLine("File not found. Please enter a correct filename");
        }
    }
    public void SaveToMongoDB()
    {
        var collection = database.GetCollection<JournalEntry>("JournalEntries");
        foreach (var entry in entries){
            collection.InsertOne(entry);
        }
        Console.WriteLine("Sucessfully wrote to mongoDB!");
    }
    public List<JournalEntry> GetEntriesFromMongoDB()
        {
            var filter = Builders<JournalEntry>.Filter.Empty;
            var entriesFromMongoDB = collection.Find(filter).ToList();
            return entriesFromMongoDB;
        }
   

}
