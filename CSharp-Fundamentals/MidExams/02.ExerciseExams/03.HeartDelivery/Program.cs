using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeartDelivery
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                     .Split("@", StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToList();

            var input = Console.ReadLine();

            var lastIndex = 0;


            while (input != "Love!")
            {
                var cmdSpl = input.Split(" ");
                int jumpIndex = int.Parse(cmdSpl[1]);
                jumpIndex += lastIndex;
                if (jumpIndex > list.Count - 1 || jumpIndex < 0)
                {
                    jumpIndex = 0;
                }

                lastIndex = jumpIndex;

                var house = list.ElementAt(jumpIndex);
                if (house <= 0)
                {
                    Console.WriteLine($"Place {jumpIndex} already had Valentine's day.");
                    input = Console.ReadLine();
                    continue;
                }
                else
                {
                    house -= 2;
                    list.RemoveAt(jumpIndex);

                }

                if (house <= 0)
                {
                    Console.WriteLine($"Place {jumpIndex} has Valentine's day.");
                    house = 0;
                }

                list.Insert(jumpIndex, house);

                input = Console.ReadLine();
            }
            int count = 0;
            foreach (var item in list)
            {
                if (item != 0)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                Console.WriteLine($"Cupid's last position was {lastIndex}.");
                Console.WriteLine($"Cupid has failed {count} places.");
            }
            else
            {
                Console.WriteLine($"Cupid's last position was {lastIndex}.");
                Console.WriteLine("Mission was successful.");
            }

        }
    }
}
