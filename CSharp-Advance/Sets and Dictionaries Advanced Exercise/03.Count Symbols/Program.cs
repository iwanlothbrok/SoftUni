using System;
using System.Linq;
using System.Collections.Generic;
namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {

            string words = Console.ReadLine();

            SortedDictionary<char, int> dictonary = new SortedDictionary<char, int>();
            for (int i = 0; i < words.Length; i++)
            {
                char c = words[i];
                if (!dictonary.ContainsKey(c))
                {
                    dictonary.Add(c, 0);
                }
                dictonary[c]++;
            }
            foreach (var item in dictonary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}