using System;

public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}\n");
    }

    public string GetSaveString(string separator)
    {
        return $"{Date}{separator}{PromptText}{separator}{EntryText}";
    }
}