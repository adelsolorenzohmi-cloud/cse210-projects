namespace ShapeProgram
{
    public class Square : Shape // Inheritance
    {
        // Private member variable
        private double _side;

        // Constructor
        public Square(string color, double side) : base(color) // Call base class constructor
        {
            _side = side;
        }

        // Override the GetArea() method
        public override double GetArea()
        {
            return _side * _side;
        }
    }
}