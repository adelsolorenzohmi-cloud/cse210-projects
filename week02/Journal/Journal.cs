using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string SEPARATOR = "|";

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("-----------------------\n");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetSaveString(SEPARATOR));
                }
            }
            Console.WriteLine($"Journal saved successfully to {filename}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the file: {ex.Message}\n");
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();

        try
        {
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(SEPARATOR);

                if (parts.Length == 3)
                {
                    Entry newEntry = new Entry
                    {
                        Date = parts[0],
                        PromptText = parts[1],
                        EntryText = parts[2]
                    };
                    _entries.Add(newEntry);
                }
            }
            Console.WriteLine($"Journal loaded successfully from {filename}. Total entries: {_entries.Count}\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: File not found at {filename}. The journal is empty.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the file: {ex.Message}\n");
        }
    }
}