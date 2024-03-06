using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shape_list = new List<Shape>{};

        Square square = new Square("blue", 5);
        Circle circle = new Circle("red", 5);
        Rectangle rectangle = new Rectangle("orange", 10, 15);

        shape_list.Add(square);
        shape_list.Add(circle);
        shape_list.Add(rectangle);

        foreach (Shape shape in shape_list)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}