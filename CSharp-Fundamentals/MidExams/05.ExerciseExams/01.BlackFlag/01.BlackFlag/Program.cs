using System;

namespace _01.BlackFlag
{
    public class Program
    {
        static void Main(string[] args)
        {
            var days = double.Parse(Console.ReadLine());
            var dailyPlunder = double.Parse(Console.ReadLine());
            var expectPlunder = double.Parse(Console.ReadLine());

            var currentPlunder = 0.0;
            var countDays = 0;


            for (int i = 0; i < days; i++)
            {
                countDays++;
                currentPlunder += dailyPlunder;
                if (countDays % 3 == 0)
                {
                    var bonus = dailyPlunder / 2;
                    currentPlunder += bonus;
                }
                if (countDays % 5 == 0)
                {
                    var lose = currentPlunder * 0.3;
                    currentPlunder -= lose;
                }
            }

            if (currentPlunder >= expectPlunder)
            {
                Console.WriteLine($"Ahoy! {currentPlunder:0.00} plunder gained.");
            }

            else
            {
                var percentage = (currentPlunder / expectPlunder) * 100;
                Console.WriteLine($"Collected only {percentage:F2}% of the plunder.");
            }
        }
    }
}
