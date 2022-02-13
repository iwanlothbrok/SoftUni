using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayer = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();


            while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {
                int firstPlayerCard = firstPlayer[0];
                int secondPlayerCard = secondPlayer[0];

                if (firstPlayerCard > secondPlayerCard)
                {
                    firstPlayer.Add(firstPlayerCard);
                    firstPlayer.Add(secondPlayerCard);

                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else if (secondPlayerCard > firstPlayerCard)
                {
                    secondPlayer.Add(secondPlayerCard);
                    secondPlayer.Add(firstPlayerCard);
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                else
                {
                    firstPlayer.RemoveAt(0);
                    secondPlayer.RemoveAt(0);
                }
                //  firstPlayerCard = firstPlayer[+1];
                //  secondPlayerCard = secondPlayer[+1];
            }
            int firstPlayerSum = firstPlayer.Sum();
            int secondPlayerSum = secondPlayer.Sum();
            if (firstPlayerSum > secondPlayerSum)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerSum}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerSum}");
            }
        }
    }
}
