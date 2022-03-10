

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity) // maybe not // maybe add Capacity and Type to ctor 
        {
            Type = type;
            Capacity = capacity;
            data = new List<Car>();
        }

        private List<Car> data;
        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count { get => data.Count; }

        public void Add(Car car)
        {
            if (data.Count < Capacity)
            {
                data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(x => x.Manufacturer == manufacturer
                                                       && x.Model == model);

            if (carToRemove != null)
            {
                data.Remove(carToRemove);
                return true;
            }
            return false;
        }
        public Car GetLatestCar()
        {
            Car carTheOldest = data.OrderByDescending(y => y.Year).FirstOrDefault();

            return carTheOldest;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car neededCar = data.FirstOrDefault(x => x.Manufacturer == manufacturer
                                                      && x.Model == model);
            return neededCar;
        }
       // public int Count()
       // {
       //     return carsCount;
       // }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");
            sb.AppendLine(string.Join(Environment.NewLine, data));
            return sb.ToString();

        }
    }
}
