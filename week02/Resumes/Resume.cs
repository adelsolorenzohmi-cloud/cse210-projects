using System.Collections.Generic;

public class Resume
{
    public string _name = "";
    // List to hold Job objects
    public List<Job> _jobs = new List<Job>();

    // Displays the person's name and then iterates through all jobs
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}