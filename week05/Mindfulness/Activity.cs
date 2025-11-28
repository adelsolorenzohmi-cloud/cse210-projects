using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine("\n------------------------------------------------");
        Console.WriteLine($"Welcome to the {_activityName} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");

        if (int.TryParse(Console.ReadLine(), out int durationSeconds))
        {
            _duration = durationSeconds;
        }
        else
        {
            _duration = 30;
            Console.WriteLine("Invalid input. Defaulting to 30 seconds.");
        }

        Console.WriteLine("\nGet ready to begin...");
        ShowSimpleDelay(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSimpleDelay(3);

        Console.WriteLine($"\nYou have completed the {_activityName} activity for {_duration} seconds.");
        ShowSimpleDelay(3);
        Console.WriteLine("------------------------------------------------");
    }

    public abstract void Run();

    public void ShowSimpleDelay(int seconds)
    {
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(".");
            Thread.Sleep(250);
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.Write("\r" + new string(' ', 15) + "\r");
    }
}