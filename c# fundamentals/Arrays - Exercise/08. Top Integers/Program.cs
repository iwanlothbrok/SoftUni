using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                                   .Split(" ")
                                   .Select(int.Parse)
                                   .ToArray();
            bool theBiggest = true;
            for (int i = 0; i < number.Length; i++)
            {
                int currentNum = number[i];
                int numberBest = 0;
                for (int j = i + 1; j < number.Length; j++)
                {
                    int secondNum = number[j];

                    if (currentNum <= secondNum)
                    {
                        theBiggest = false;
                        break;
                    }

                }
                if (theBiggest == true)
                {
                    Console.Write(currentNum + " ");
                }
                theBiggest = true;
            }

        }
    }
}
