using System;
using System.Linq;
using System.Collections.Generic;
namespace SuperMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string command = Console.ReadLine();
            while (command != "Paid")
            {
                if (command=="End")
                {
                    Console.WriteLine($"{queue.Count} people remaining.");
                    return;
                }
                queue.Enqueue(command);
                command = Console.ReadLine();
            }


            if (command == "Paid")
            {
                Console.WriteLine(string.Join(Environment.NewLine, queue));
                for (int i = 0; i < queue.Count; i++)
                {
                    queue.Dequeue();
                    i--;
                }
                command = Console.ReadLine();
            }
           
            while (command != "End")
            {
                queue.Enqueue(command);

                command = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");

        }
    }
}