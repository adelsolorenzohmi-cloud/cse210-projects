using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Testing Constructors and Representations ---");

        // Test Case 1: Constructor with no parameters (Should be 1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        // Test Case 2: Constructor with one parameter (Should be 5/1)
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        // Test Case 3: Constructor with two parameters (Should be 3/4)
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        // Test Case 4: Constructor with two parameters (Should be 1/3)
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        // The output for 1/3 demonstrates the precision of the double return type.
        Console.WriteLine(f4.GetDecimalValue());


        Console.WriteLine("\n--- Testing Getters and Setters ---");

        // Use an existing fraction (f3: 3/4)
        Console.WriteLine($"Original f3: {f3.GetFractionString()}");

        // Use Setters to change the values (modifying f3 to 7/8)
        f3.Top = 7;
        f3.Bottom = 8;

        // Use Getters to retrieve and display the new values
        Console.WriteLine($"New Numerator (Top): {f3.Top}");
        Console.WriteLine($"New Denominator (Bottom): {f3.Bottom}");
        Console.WriteLine($"Updated f3 Fraction: {f3.GetFractionString()} ({f3.GetDecimalValue()})");

        // Test the Denominator Setter Guardrail: Set Bottom to 0, which should be automatically reset to 1 by the property setter logic.
        f3.Bottom = 0;
        Console.WriteLine($"Denominator after attempting to set 0: {f3.Bottom}"); // Expected output: 1
    }
}