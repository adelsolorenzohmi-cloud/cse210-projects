using System;
using System.Collections.Generic;

namespace ShapeProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Individual Shapes ---");

            // Test the Square class
            Square mySquare = new Square("Red", 5.0);
            Console.WriteLine($"Square Color: {mySquare.GetColor()}"); // Should be Red
            Console.WriteLine($"Square Area: {mySquare.GetArea()}");   // Should be 25.0
            mySquare.SetColor("Crimson");
            Console.WriteLine($"Square New Color: {mySquare.GetColor()}");
            Console.WriteLine();

            // Test the Rectangle class
            Rectangle myRectangle = new Rectangle("Blue", 10.0, 4.0);
            Console.WriteLine($"Rectangle Color: {myRectangle.GetColor()}"); // Should be Blue
            Console.WriteLine($"Rectangle Area: {myRectangle.GetArea()}");   // Should be 40.0
            Console.WriteLine();

            // Test the Circle class
            Circle myCircle = new Circle("Green", 3.0);
            Console.WriteLine($"Circle Color: {myCircle.GetColor()}");       // Should be Green
            // Area should be approximately 28.27 (π * 3^2)
            Console.WriteLine($"Circle Area: {myCircle.GetArea():F2}"); // :F2 formats to 2 decimal places
            Console.WriteLine();

            Console.WriteLine("--- Building and Iterating Through List<Shape> ---");

            // Build a List<Shape>
            List<Shape> shapes = new List<Shape>();
            shapes.Add(mySquare);
            shapes.Add(myRectangle);
            shapes.Add(myCircle);
            // Add another one for good measure!
            shapes.Add(new Rectangle("Yellow", 2.0, 1.5));

            // Iterate through the list of shapes
            int count = 1;
            foreach (Shape shape in shapes)
            {
                // The correct GetArea() is called automatically based on the actual object type
                // (Square, Rectangle, or Circle), even though the variable is of type Shape.
                Console.WriteLine($"Shape {count}:");
                Console.WriteLine($"- Type: {shape.GetType().Name}");
                Console.WriteLine($"- Color: {shape.GetColor()}");
                Console.WriteLine($"- Area: {shape.GetArea():F2}");
                Console.WriteLine();
                count++;
            }
        }
    }
}