namespace Hi
{
    public class StartUp
    {
        public class Car
        {
            public int Milage { get; set; }
            public int Fuel { get; set; }
        }
        static void Main(string[] args)
        {
            var car = new Dictionary<string, Car>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var cmd = Console.ReadLine().Split('|');
                var carName = cmd[0];
                var milage = int.Parse(cmd[1]);
                var fuel = int.Parse(cmd[2]);
                var carInput = new Car()
                {
                    Milage = milage,
                    Fuel = fuel,
                };
                car.Add(carName, carInput);
            }

            var command = Console.ReadLine();
            while (command != "Stop")
            {
                var cmd = command.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                var cmdSplitted = cmd[0];

                if (cmdSplitted == "Drive")
                {
                    var carModel = cmd[1];
                    var distance = int.Parse(cmd[2]);
                    var fuel = int.Parse(cmd[3]);

                    if (car[carModel].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        car[carModel].Fuel -= fuel;
                        car[carModel].Milage += distance;
                        Console.WriteLine($"{carModel} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (car[carModel].Milage >= 100_000)
                    {
                        Console.WriteLine($"Time to sell the {carModel}!");
                        car.Remove(carModel);
                    }
                }
                else if (cmdSplitted == "Refuel")
                {
                    var carModel = cmd[1];
                    var fuel = int.Parse(cmd[2]);
                    var refueledFuel = fuel;
                    var oldFuel = car[carModel].Fuel;
                    car[carModel].Fuel += fuel;
                    if (car[carModel].Fuel >= 75)
                    {
                        refueledFuel = 75 - oldFuel;
                        car[carModel].Fuel = 75;

                    }
                    Console.WriteLine($"{carModel} refueled with {refueledFuel} liters");
                }
                else if (cmdSplitted == "Revert")
                {
                    var carModel = cmd[1];
                    var km = int.Parse(cmd[2]);

                    car[carModel].Milage -= km;
                    if (car[carModel].Milage < 10_000)
                    {
                        car[carModel].Milage = 10_000;
                    }
                    else
                    {
                        Console.WriteLine($"{carModel} mileage decreased by {km} kilometers");
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var item in car)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Milage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }
        }
    }
}
