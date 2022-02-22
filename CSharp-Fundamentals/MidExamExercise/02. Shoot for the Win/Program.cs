using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 0;
            string input = Console.ReadLine();
            while (input != "End")
            {

                int index = int.Parse(input);

                if (index < 0 || index > numbers.Length - 1 || index == -1)
                {
                    input = Console.ReadLine();
                    continue;
                }
                int afterIndexator = numbers[index];
                count++;
                for (int i = 0; i < numbers.Length; i++)
                {
                    int currentN = numbers[i];

                    if (afterIndexator >= currentN && currentN != -1)
                    {
                        numbers[i] += afterIndexator;
                    }
                    else if (afterIndexator < currentN && currentN != -1)
                    {
                        numbers[i] -= afterIndexator;
                    }

                }
                numbers[index] = -1;

                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {count} -> {string.Join(" ", numbers)}");
        }
    }
}
