using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int nums = int.Parse(Console.ReadLine());
                numbers.Add(nums);
            }
            Box<int> box = new Box<int>(numbers);

            int[] swappers = Console.ReadLine().Split(' ')
                            .Select(int.Parse).ToArray();
            int firstIndex = swappers[0];
            int secondIndex = swappers[1];

            box.Swap(numbers, firstIndex, secondIndex);
            Console.WriteLine(box);

        }
    }
}
