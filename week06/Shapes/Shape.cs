namespace ShapeProgram
{
    public class Shape
    {
        // Private member variable
        private string _color;

        // Constructor
        public Shape(string color)
        {
            _color = color;
        }

        // Getter for color
        public string GetColor()
        {
            return _color;
        }

        // Setter for color
        public void SetColor(string color)
        {
            _color = color;
        }

        // Virtual method for GetArea() - intended to be overridden by derived classes
        public virtual double GetArea()
        {
            // The base class implementation returns 0.0 as it's an abstract concept
            return 0.0;
        }
    }
}