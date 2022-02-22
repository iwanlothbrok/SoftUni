
using System;
using System.Linq;
using System.Collections.Generic;
namespace SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            var peoples = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArr = Console.ReadLine().Split();
                string command = cmdArr[0];
                string name = cmdArr[1];


                if (command == "register")
                {
                    string carNumber = cmdArr[2];
                    if (peoples.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {carNumber}");
                    }
                    else
                    {
                        peoples.Add(name, carNumber);
                        Console.WriteLine($"{name} registered {carNumber} successfully");
                    }
                }
                else
                {
                    if (peoples.ContainsKey(name) == false)
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{name} unregistered successfully");
                        peoples.Remove(name);

                    }
                }
            }
            foreach (var people in peoples)
            {
                Console.WriteLine($"{people.Key} => {people.Value}");
            }
        }
    }
}