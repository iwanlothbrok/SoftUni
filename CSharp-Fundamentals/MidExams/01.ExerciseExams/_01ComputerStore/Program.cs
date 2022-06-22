using System;

namespace _01ComputerStore
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double totalSum = 0;
            bool isFound = false;
            double special = 1;

            while (!isFound)
            {
                if (command == "special" || command == "regular")
                {
                    isFound = true;
                    if (command == "special")
                    {
                        special = 0.9;
                    }
                    continue;
                }
                double price = double.Parse(command);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    command = Console.ReadLine();
                    continue;

                }
                totalSum += price;
                command = Console.ReadLine();
            }
            if (totalSum==0)
            {
                Console.WriteLine("Invalid order!");
                return;
            }
            double totalValue = totalSum;
            double taxes = totalSum - totalSum * 0.8;
            double sum = totalSum + taxes;

            var a = sum * special;
            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalValue:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {a:f2}$");
        }
    }
}
