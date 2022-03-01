﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Car[] cars = new Car[count];

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                int speed = int.Parse(tokens[1]);
                int power = int.Parse(tokens[2]);
                int weight = int.Parse(tokens[3]);
                string type = tokens[4];
                double tyre1Pressure = double.Parse(tokens[5]);
                int tyre1Age = int.Parse(tokens[6]);
                double tyre2Pressure = double.Parse(tokens[7]);
                int tyre2Age = int.Parse(tokens[8]);
                double tyre3Pressure = double.Parse(tokens[9]);
                int tyre3Age = int.Parse(tokens[10]);
                double tyre4Pressure = double.Parse(tokens[11]);
                int tyre4Age = int.Parse(tokens[12]);

                cars[i] = new Car(model, new Engine(speed, power)
                    , new Cargo(type, weight)
                    , new List<Tires> { new Tires(tyre1Pressure, tyre1Age)
                    , new Tires(tyre2Pressure, tyre2Age)
                    , new Tires(tyre3Pressure, tyre3Age)
                    , new Tires(tyre4Pressure, tyre4Age) });
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(c => c.cargo.type == "fragile")
                    .Where(c => c.tires.Any(t => t.pressure < 1))
                    .Select(c => c.model).ToList().ForEach(m => Console.WriteLine(m));
            }
            else if (command == "flammable")
            {
                cars.Where(c => c.cargo.type == "flammable")
                    .Where(c => c.engine.power > 250)
                    .Select(c => c.model).ToList()
                    .ForEach(m => Console.WriteLine(m));
            }
        }
    }
}