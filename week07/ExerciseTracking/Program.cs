using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity type
        Running run1 = new Running(new DateTime(2025, 12, 1), 30, 5.0);
        Cycling cycle1 = new Cycling(new DateTime(2025, 12, 2), 45, 20.0);
        Swimming swim1 = new Swimming(new DateTime(2025, 12, 3), 60, 40);

        // Put activities into a list of the base type (Polymorphism)
        List<Activity> activities = new List<Activity>
        {
            run1,
            cycle1,
            swim1
        };

        Console.WriteLine("--- Exercise Summary Report (km) ---");

        // Iterate and call GetSummary() on each object
        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }

        Console.WriteLine("--------------------------------------");
    }
}