using System;
using System.Linq;
using System.Collections.Generic;
namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int count = 0;
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            while (command != "end")
            {
                if (command == "green")
                {
                    if (number>cars.Count)
                    {
                        number = cars.Count;
                    }
                    for (int i = 0; i < number; i++)
                    {
                        count++;
                        string car = cars.Peek();
                        Console.WriteLine($"{car} passed!");
                        cars.Dequeue();
                        
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}