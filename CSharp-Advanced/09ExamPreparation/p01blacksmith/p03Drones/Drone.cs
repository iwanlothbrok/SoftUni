using System;
using System.Collections.Generic;
using System.Text;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Avaible = true;
        }

        public string Name;
        public string Brand;
        public int Range;
        public bool Avaible;


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.AppendLine($"Range: {Range} kilometers");
            return sb.ToString().TrimEnd();
        }
        
    }
}
