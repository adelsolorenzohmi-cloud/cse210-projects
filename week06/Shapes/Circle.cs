using System;

namespace ShapeProgram
{
    public class Circle : Shape // Inheritance
    {
        // Private member variable
        private double _radius;

        // Constructor
        public Circle(string color, double radius) : base(color) // Call base class constructor
        {
            _radius = radius;
        }

        // Override the GetArea() method
        public override double GetArea()
        {
            // Area = π * r^2
            return Math.PI * _radius * _radius;
        }
    }
}