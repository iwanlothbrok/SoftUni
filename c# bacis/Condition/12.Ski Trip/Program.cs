using System;

namespace _09._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = int.Parse(Console.ReadLine());
            string place = Console.ReadLine();
            string feedback = Console.ReadLine();

            double sum = 0;

            if (place == "room for one person")
            {
                sum = 18 * (day - 1);

            }
            else if (place == "apartment")
            {
                sum = 25 * (day - 1);
                if (day < 10)
                {
                    sum *= 0.7;
                }
                else if (day >= 10 && day <= 15)
                {
                    sum *= 0.65;
                }
                else
                {
                    sum *= 0.5;
                }
            }
            else if (place == "president apartment")
            {
                sum = 35 * (day - 1);
                if (day < 10)
                {
                    sum *= 0.9;
                }
                else if (day >= 10 && day <= 15)
                {
                    sum *= 0.85;
                }
                else
                {
                    sum *= 0.8;
                }
            }
            if (feedback == "negative")
            {
                sum *= 0.9;
            }
            else
            {
                sum *= 1.25;
            }
            Console.WriteLine($"{sum:f2}");

        }
    }
}
