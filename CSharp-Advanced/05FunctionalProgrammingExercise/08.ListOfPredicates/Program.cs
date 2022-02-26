
using System;
using System.Linq;
using System.Collections.Generic;


namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ')
                          .Select(int.Parse).ToList();

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;

            var evenNums = numbers.FindAll(isEven);
            var oddNums = numbers.FindAll(isOdd);
            List<int> result = new List<int>();

            for (int i = 0; i < evenNums.Count; i++)
            {
                result.Add(evenNums[i]);
            }
            for (int i = 0; i < oddNums.Count; i++)
            {
                result.Add(oddNums[i]);
            }
          //  result.Sort();
            Console.WriteLine(String.Join(" ",result));
        }
    }
}
