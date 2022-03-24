namespace Vehicles
{
    public class Truck : Vehicle
    {
        private static double ADDITIONAL_CONSUMPTION = 1.6;
        private static double THE_PROBLEM_TANK = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity , fuelConsumption + ADDITIONAL_CONSUMPTION)
        {
        }
        public override void Refuel(double fuel)
        {
            this.FuelQuantity += fuel * THE_PROBLEM_TANK;
        }
    }
}
