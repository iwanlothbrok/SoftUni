using System;
using System.Linq;

namespace _05._Sum_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int sum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNum = arr[i];
                if (currentNum % 2 == 0)
                {
                    sum = currentNum + sum;
                }


            }
            Console.WriteLine(sum);

        }
    }
}
