using System;

namespace po_07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            int priceOfTicket = 0;
            if (typeOfDay == "Weekday")
            {
                if (age <= 18 && age >= 0)
                {
                    priceOfTicket += 12;
                }
                else if (18 < age && age <= 64)
                {
                    priceOfTicket += 18;
                }
                else if (age <= 122 && age > 64)
                {
                    priceOfTicket += 12;
                }
            }
            else if (typeOfDay == "Weekend")
            {
                if (age <= 18 && age >= 0)
                {
                    priceOfTicket += 15;
                }
                else if (18 < age && age <= 64)
                {
                    priceOfTicket += 20;
                }
                else if (age <= 122 && age > 64)
                {
                    priceOfTicket += 15;
                }
            }
            else if (typeOfDay == "Holiday")
            {
                if (age <= 18 && age >= 0)
                {
                    priceOfTicket += 5;
                }
                else if (18 < age && age <= 64)
                {
                    priceOfTicket += 12;
                }
                else if (age <= 122 && age > 64)
                {
                    priceOfTicket += 10;
                }


            }
            if (priceOfTicket != 0)
            {
                Console.WriteLine($"{priceOfTicket}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
