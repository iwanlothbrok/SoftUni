
using System;
using System.Linq;
using System.Collections.Generic;
namespace CharMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console.ReadLine().Split(' ');

            string biggestWord = words[0];
            string smallestWord = words[1];
            int sum = 0;

            if (smallestWord.Length > biggestWord.Length)
            {
                smallestWord = words[0];
                biggestWord = words[1];
            }

            for (int i = 0; i < smallestWord.Length; i++)
            {
                char charFirst = (char)biggestWord[i];
                char charSecond = smallestWord[i];
                
                    sum += charFirst * charSecond;
            }
            if (biggestWord.Length != smallestWord.Length)
            {
                for (int j = smallestWord.Length; j < biggestWord.Length; j++)
                {
                    char first = biggestWord[j];
                    sum += first;
                }
            }

            Console.WriteLine(sum);

            }
        }
    }