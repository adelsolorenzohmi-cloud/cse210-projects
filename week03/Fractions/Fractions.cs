public class Fraction
{
    // Private fields for the numerator and denominator.
    private int _top;
    private int _bottom;

    // Constructor 1: Defaults to 1/1.
    public Fraction() : this(1, 1) { }

    // Constructor 2: Denominator defaults to 1.
    public Fraction(int top) : this(top, 1) { }

    // Constructor 3: Full parameters.
    public Fraction(int top, int bottom)
    {
        _top = top;
        // Denominator guard: If zero is passed, set to 1.
        _bottom = bottom != 0 ? bottom : 1;
    }

    // --- Public Properties (Getters and Setters) ---

    public int Top
    {
        get { return _top; }
        set { _top = value; }
    }

    public int Bottom
    {
        get { return _bottom; }
        set
        {
            // Denominator guard: ensures value is never zero.
            _bottom = value != 0 ? value : 1;
        }
    }

    // --- Representation Methods ---

    // Returns the fraction as a string (e.g., "3/4").
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns the decimal value.
    public double GetDecimalValue()
    {
        // Casts to double for floating-point division.
        return (double)_top / _bottom;
    }
}