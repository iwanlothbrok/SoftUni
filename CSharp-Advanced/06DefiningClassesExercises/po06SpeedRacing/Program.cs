using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionForOnekm = double.Parse(tokens[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionForOnekm);

                cars.Add(car);
            }
            string command = Console.ReadLine();
            ;
            while (command != "End")
            {
                string[] tokens = command.Split();
                string model = tokens[1];
                double kilometers = double.Parse(tokens[2]);

                Car carForDriving = cars
                       .Where(x => x.Model == model)
                       .ToList()
                       .First();


                carForDriving.CanIReachTheDistance(model, kilometers);

                command = Console.ReadLine();
            }
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
