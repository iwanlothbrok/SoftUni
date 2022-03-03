using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                numbers.Add(num);
            }
            Box<double> box = new Box<double>(numbers);
            double comprateNum = double.Parse(Console.ReadLine());

            int counter = box.CompareNumbers(numbers, comprateNum);
            Console.WriteLine(counter);
        }
    }
}
