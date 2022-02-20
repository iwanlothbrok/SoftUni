using System;

namespace trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string place = "";
            string hotelOrCamp = "";



            if (budget <= 100)
            {
                place = "Bulgaria";

                if (season == "summer")
                {
                    budget = budget * 30 / 100;
                    hotelOrCamp = "Camp";
                }
                else if (season == "winter")
                {
                    budget = budget * 70 / 100;
                    hotelOrCamp = "Hotel";
                }

            }
            else if (budget <= 1000)
            {
                place = "Balkans";
                if (season == "summer")
                {
                    budget = budget * 40 / 100;
                    hotelOrCamp = "Camp";
                }
                else if (season == "winter")
                {
                    budget = budget * 80 / 100;
                    hotelOrCamp = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                budget = budget * 90 / 100;
                place = "Europe";
                hotelOrCamp = "Hotel";
            }
            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{hotelOrCamp} - {budget:f2}");

        }
    }
}
