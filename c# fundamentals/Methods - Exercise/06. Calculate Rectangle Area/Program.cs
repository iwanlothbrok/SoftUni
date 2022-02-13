using System;

namespace _06.Calculate_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double area = GetReactangleArea(width, height);
            Console.WriteLine(area);

        }
        static double GetReactangleArea(double width, double height)
        {
            return width * height;
        }
    }
}
