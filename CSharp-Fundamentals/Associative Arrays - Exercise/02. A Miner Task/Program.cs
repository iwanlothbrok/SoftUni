
using System;
using System.Linq;
using System.Collections.Generic;
namespace MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var minerValues = new Dictionary<string, int>();
            string command = Console.ReadLine();

            while (command != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (minerValues.ContainsKey(command) == false)
                {
                    minerValues.Add(command, 0);
                }
                minerValues[command] += quantity;

                command = Console.ReadLine();
            }
            foreach (var item in minerValues)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}