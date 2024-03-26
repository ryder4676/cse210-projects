using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes (Hint: The data type should be List<Shape>).
        List<Shape> shapes = new List<Shape>();
        // Create a Square instance
        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 2, 4);
        shapes.Add(s2);

        Circle s3 = new Circle("Orange", 6);
        shapes.Add(s3);


        foreach (Shape s in shapes)
        {
            // call the GetColor() and GetArea() methods and make sure they return the values you expect.
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}