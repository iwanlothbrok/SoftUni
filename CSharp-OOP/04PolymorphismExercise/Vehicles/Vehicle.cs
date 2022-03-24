namespace Vehicles
{
    public class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }

        public string Drive(double km)
        {
            if (km * this.FuelConsumption > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.FuelQuantity -= km * this.FuelConsumption;

            return $"{this.GetType().Name} travelled {km} km";

        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }
}
