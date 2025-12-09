using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    // Overrides GetDistance, calculated from laps: Distance (km) = laps * 50 / 1000
    public override double GetDistance()
    {
        return (double)_laps * 50 / 1000;
    }
}