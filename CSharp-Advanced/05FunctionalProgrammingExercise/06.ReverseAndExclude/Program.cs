
using System;
using System.Linq;
using System.Collections.Generic;


namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ')
                            .Select(int.Parse).ToArray();

            int n = int.Parse(Console.ReadLine());


            Func<int[], int, List<int>> func = (x, n) =>
             {
                 List<int> list = new List<int>();
                 for (int i = 0; i < numbers.Length; i++)
                 {
                     if (numbers[i] % n != 0)
                     {
                         list.Add(numbers[i]);
                     }
                 }
                 return list;
             };
            List<int> list = func(numbers, n);
            list.Reverse();
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
