using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int[] powerAndSpecialBomb = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            int bomb = powerAndSpecialBomb[0];
            int power = powerAndSpecialBomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNum = numbers[i];
                if (bomb == currentNum)
                {
                    int startIndex = i - power;
                    int lastIndex = i + power;
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (lastIndex > numbers.Count - 1)
                    {
                        lastIndex = numbers.Count - 1;
                    }
                    int lastIndexToRemove = lastIndex - startIndex + 1;
                    numbers.RemoveRange(startIndex, lastIndexToRemove);
                    i = startIndex - 1;
                }

            }
            int sum = numbers.Sum();

            Console.WriteLine(sum);
        }
    }
}
