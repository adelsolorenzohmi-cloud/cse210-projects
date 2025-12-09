using System;

public class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    // Base methods are declared virtual to allow overriding (Polymorphism)
    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        // Speed (kph) = (distance / minutes) * 60
        double distance = GetDistance();
        if (distance == 0) return 0;
        return (distance / _minutes) * 60;
    }

    public virtual double GetPace()
    {
        // Pace (min per km) = minutes / distance
        double distance = GetDistance();
        if (distance == 0) return 0;
        return (double)_minutes / distance;
    }

    public string GetSummary()
    {
        string dateStr = _date.ToString("dd MMM yyyy");
        string typeName = this.GetType().Name;

        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        return $"{dateStr} {typeName} ({_minutes} min): " +
               $"Distance {distance:F2} km, Speed: {speed:F2} kph, Pace: {pace:F2} min per km";
    }
}