
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public List<Fish> Fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get => Fish.Count; }

        public string AddFish(Fish fish)
        {
            if (Fish.Count + 1 > Capacity) // >=
            {
                return "Fishing net is full.";
            }
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.FishType == "" || fish.Weight <= 0 || fish.Lenght <= 0) //  chek whiteSpace 
            {
                return "Invalid fish.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            Fish fishToRemove = Fish.FirstOrDefault(x => x.Weight == weight);

            if (fishToRemove != null)
            {
                Fish.Remove(fishToRemove);
                return true;
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            Fish fishToReturn = Fish.FirstOrDefault(f => f.FishType == fishType);

            if (fishToReturn == null)
            {
                return null;
            }
            return fishToReturn;
        }
        public Fish GetBiggestFish()
        {
            Fish biggestFish = Fish.OrderByDescending(x => x.Lenght).FirstOrDefault();
            return biggestFish;
        }
        public string Report()
        {

             StringBuilder sb = new StringBuilder();
            
             sb.AppendLine($"Into the {this.Material}:");
             foreach (var item in Fish.OrderByDescending(l => l.Lenght))
             {
                 sb.AppendLine($"There is a {item.FishType}, {item.Lenght} cm. long, and {item.Weight} gr. in weight."); // chek if you need that
             }
             return sb.ToString().Trim();
           

        }
    }
}
