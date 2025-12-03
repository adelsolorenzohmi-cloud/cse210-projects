namespace ShapeProgram
{
    public class Rectangle : Shape // Inheritance
    {
        // Private member variables
        private double _length;
        private double _width;

        // Constructor
        public Rectangle(string color, double length, double width) : base(color) // Call base class constructor
        {
            _length = length;
            _width = width;
        }

        // Override the GetArea() method
        public override double GetArea()
        {
            return _length * _width;
        }
    }
}