using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landStrip;
            Drones = new List<Drone>();

        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public List<Drone> Drones;
        public int Count { get => Drones.Count; }



        public string AddDrone(Drone drone)
        {
            if (Capacity < Count + 1)
            {
                return "Airfield is full.";
            }
            if (string.IsNullOrWhiteSpace(drone.Name) || string.IsNullOrWhiteSpace(drone.Brand))
            {
                return "Invalid drone.";
            }
            if (drone.Range <= 5 && drone.Range <= 15) // < / <
            {
                return "Invalid drone.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            Drone droneToRemove = Drones.FirstOrDefault(n => n.Name == name);
            if (droneToRemove == null)
            {
                return false;
            }
            Drones.Remove(droneToRemove);
            return true;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = 0;
            List<Drone> dronesToRemove = Drones.Where(b => b.Brand == brand).ToList();
            if (dronesToRemove == null)
            {
                return 0;
            }
            foreach (var item in dronesToRemove)
            {
                count++;
                Drones.Remove(item);
            }
            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(n => n.Name == name);
            if (drone == null)
            {
                return null;
            }
            drone.Avaible = false;
            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            List<Drone> drones = Drones.Where(r => r.Range >= range).ToList();
            foreach (var item in drones)
            {
                item.Avaible = false;

            }
            return drones;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            List<Drone> drones = Drones.Where(a => a.Avaible == true).ToList();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var item in drones)
            {
                sb.AppendLine($"{item}");
            }
            return sb.ToString().TrimEnd();
        }

    }
}
