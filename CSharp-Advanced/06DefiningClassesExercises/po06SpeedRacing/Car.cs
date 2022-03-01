using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private double fuelConsumptionForOnekm;

        public Car(string model, double fuelAmount, double fuelConsumptionForOnekm)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionForOnekm;
            TravelledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumptionPerKilometer { get; set; }

        public double TravelledDistance { get; set; }


        public void CanIReachTheDistance(string model, double kilometers)
        {
            double neededLiters = kilometers * this.FuelConsumptionPerKilometer;


            if (neededLiters > this.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.TravelledDistance += kilometers;
                FuelAmount -= neededLiters;
            }

        }

    }
}
