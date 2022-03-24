using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(" ");
            double carQuantity = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            Vehicle car = new Car(carQuantity, carConsumption);

            string[] truckInfo = Console.ReadLine().Split(" ");
            double truckQuantity = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            Vehicle truck = new Truck(truckQuantity, truckConsumption);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");
                string action = tokens[0];
                string vehicle = tokens[1];
                double liters = double.Parse(tokens[2]);
                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        Console.WriteLine(car.Drive(liters));
                    }
                    else if (vehicle == "Truck")
                    {
                        Console.WriteLine(truck.Drive(liters));
                    }
                }
                else if (action == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(liters);

                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(liters);

                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
