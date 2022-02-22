using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstDaySpicyEarned = int.Parse(Console.ReadLine());
            int daysCount = 0;
            double TotalSpicy = 0;
            double spicy = firstDaySpicyEarned;

            while (firstDaySpicyEarned >= 100)
            {
                daysCount++;
                TotalSpicy = firstDaySpicyEarned + TotalSpicy;
                TotalSpicy -= 26;
                firstDaySpicyEarned -= 10;

            }
            if (spicy >= 100)
            {
                TotalSpicy -= 26;
            }
            Console.WriteLine(daysCount);
            Console.WriteLine(TotalSpicy);
        }
    }
}
