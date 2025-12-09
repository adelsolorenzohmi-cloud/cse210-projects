using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    // Overrides GetDistance, calculated from speed and time: Distance = (Speed * minutes) / 60
    public override double GetDistance()
    {
        return (_speedKph * GetMinutes()) / 60;
    }

    // Overrides GetSpeed to return the stored value
    public override double GetSpeed()
    {
        return _speedKph;
    }
}