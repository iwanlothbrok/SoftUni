using System;
using System.Linq;
using System.Collections.Generic;
namespace OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');

            var oddWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string wordInCase = word.ToLower();

                if (oddWords.ContainsKey(wordInCase))
                {
                    oddWords[wordInCase]++;
                }
                else
                {
                    oddWords.Add(wordInCase, 1);
                }
            }
            foreach (var word in oddWords)
            {
                if (word.Value % 2 == 1)
                {
                    Console.Write(word.Key + " ");
                }
            }

        }
    }
}
