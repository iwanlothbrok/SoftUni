using System;

namespace po_03._Fitness_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            double inputMoney = double.Parse(Console.ReadLine());
            char gender = Console.ReadLine()[0];
            int age = int.Parse(Console.ReadLine());
            string sport = Console.ReadLine();
            double priceOfSports = 0;

            if (gender == 'm')
            {
                if (sport == "Gym")
                {
                    priceOfSports = 42;
                }
                else if (sport == "Boxing")
                {
                    priceOfSports = 41;
                }
                else if (sport == "Yoga")
                {
                    priceOfSports = 45;
                }
                else if (sport == "Zumba")
                {
                    priceOfSports = 34;
                }
                else if (sport == "Dances")
                {
                    priceOfSports = 51;
                }
                else if (sport == "Pilates")
                {
                    priceOfSports = 39;
                }

            }
            else if (gender == 'f')
            {
                if (sport == "Gym")
                {
                    priceOfSports = 35;
                }
                else if (sport == "Boxing")
                {
                    priceOfSports = 37;
                }
                else if (sport == "Yoga")
                {
                    priceOfSports = 42;
                }
                else if (sport == "Zumba")
                {
                    priceOfSports = 31;
                }
                else if (sport == "Dances")
                {
                    priceOfSports = 53;
                }
                else if (sport == "Pilates")
                {
                    priceOfSports = 37;
                }
            }
            if (age <= 19)
            {
                priceOfSports *= 0.8;
            }
            if (inputMoney >= priceOfSports)
            {
                Console.WriteLine($"You purchased a 1 month pass for {sport}.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money! You need ${priceOfSports - inputMoney:f2} more.");

            }


        }
    }
}
