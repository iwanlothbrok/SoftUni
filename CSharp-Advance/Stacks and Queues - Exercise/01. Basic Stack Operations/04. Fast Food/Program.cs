using System;
using System.Linq;
using System.Collections.Generic;
namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {

            int quantity = int.Parse(Console.ReadLine());
            int[] foodOrders = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(foodOrders);
            Console.WriteLine(queue.Max());
            while (queue.Any())
            {
                int foodOrded = queue.Peek();

                if (quantity >= foodOrded)
                {
                    queue.Dequeue();
                    quantity -= foodOrded;
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(' ', queue)}");
                    return;
                }

            }
            Console.WriteLine("Orders complete");
        }
    }
}

