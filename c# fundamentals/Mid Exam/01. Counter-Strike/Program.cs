using System;

namespace _01.Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wins = 0;
            bool isNotEnought = false;
            string distance = Console.ReadLine();

            while (distance != "End of battle")
            {
                int distanceNum = int.Parse(distance);
                if (distanceNum > energy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {wins} won battles and {energy} energy");
                    isNotEnought = true;
                    return;
                }
                energy -= distanceNum;
                wins++;
                if (wins % 3 == 0)
                {
                    energy += wins;
                }

                distance = Console.ReadLine();
            }
            if (!isNotEnought)
            {
                Console.WriteLine($"Won battles: {wins}. Energy left: {energy}");

            }
        }
    }
}
