using System;
using System.Linq;

namespace _02TheLift
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var peopleCount = int.Parse(Console.ReadLine());

            var wagons = Console.ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToList();
            for (int i = 0; i < wagons.Count; i++)
            {
                if (peopleCount <= 0)
                {
                    break;
                }
            
                while (wagons[i] < 4)
                {
                    if (peopleCount==0)
                    {
                        break;
                    }
                    wagons[i]++;
                    peopleCount--;
                }
            }
            
            if (peopleCount > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleCount} people in a queue!");
            }
            else
            {
                Console.WriteLine("The lift has empty spots!");
            }
            
            Console.WriteLine(String.Join(" ",wagons));
        }
    }
}
