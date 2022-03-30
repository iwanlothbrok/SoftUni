using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = new Circle(5);
            Console.WriteLine(shape.CalculatePerimeter()); 
            Console.WriteLine(shape.Draw()); 
            Console.WriteLine(shape.CalculateArea()); 
         
            shape = new Rectangle(5, 5);
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());
            Console.WriteLine(shape.CalculateArea());
        }
    }
}
