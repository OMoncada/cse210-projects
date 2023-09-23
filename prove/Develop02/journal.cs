using System;
using System.Collections.Generic;
using System.IO;
using Generator;

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private QuestionGenerator questionGenerator = new QuestionGenerator(); // Create an instance of the question generator

    public void WriteEntry()
    {
        Console.WriteLine("Write a new entry in your journal:");
        string prompt = questionGenerator.GetRandomPrompt(); // Get a random question from the question generator

        Console.WriteLine(prompt);
        string response = Console.ReadLine();

        Entry entry = new Entry(prompt, response);
        entries.Add(entry);
    }

    public void ShowEntries()
    {
        Console.WriteLine("Your diary entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }

            Console.WriteLine("Journal successfully saved to file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
        }
    }

    public void LoadFromFile(string fileName)
    {
        try
        {
            List<Entry> loadedEntries = new List<Entry>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string dateStr = parts[0];
                        string prompt = parts[1];
                        string response = parts[2];

                        if (DateTime.TryParse(dateStr, out DateTime date))
                        {
                            Entry entry = new Entry(prompt, response);
                            entry.Date = date;
                            loadedEntries.Add(entry);
                        }
                    }
                }
            }

        // If the file upload was successful, you have to update the list again.
            entries = loadedEntries;

            Console.WriteLine("Journal successfully loaded from file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from file: {ex.Message}");
        }
    }
    public void WriteNotes()
    {
        Console.WriteLine("What additional notes do you want to add?:");
        string notes = Console.ReadLine();

        Entry entry = new Entry("Additional notes", notes);
        entries.Add(entry);
    }

}
