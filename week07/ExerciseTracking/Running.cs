using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm)
        : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    // Overrides GetDistance to return the stored value
    public override double GetDistance()
    {
        return _distanceKm;
    }
}