using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    public class StartUp
    {
        public class Plant
        {
            public int Rarity { get; set; }
            public List<double> Rating { get; set; }
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dictonary = new Dictionary<string, Plant>();
            for (int i = 0; i < n; i++)
            {
                var cmd = Console.ReadLine().Split("<->");
                var name = cmd[0];

                var rarity = int.Parse(cmd[1]);

                var plant = new Plant()
                {
                    Rarity = rarity,
                    Rating = new List<double>()
                };

                dictonary.Add(name, plant);
            }

            var input = Console.ReadLine();
            while (input != "Exhibition")
            {
                var cmdSplitted = input.Split(new char[] { ':', '-',' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = cmdSplitted[0];

                if (command == "Rate")
                {
                    var name = cmdSplitted[1];
                    var rating = (double.Parse(cmdSplitted[2]));
                    if (dictonary.ContainsKey(name) == false)
                    {
                        Console.WriteLine("error");
                    }
                    foreach (var item in dictonary)
                    {
                        if (item.Key==name)
                        {
                            dictonary[name].Rating.Add(rating);

                        }
                    }
                     
                    
                }
                else if (command == "Update")
                {
                    var name = cmdSplitted[1];
                    var newRarity = int.Parse(cmdSplitted[2]);
                    if (dictonary.ContainsKey(name) == false)
                    {
                        Console.WriteLine("error");
                    }
                    dictonary[name].Rarity = newRarity;
                }
                else if (command == "Reset")
                {
                    var name = cmdSplitted[1];
                    if (dictonary.ContainsKey(name) == false)
                    {
                        Console.WriteLine("error");
                    }
                    dictonary[name].Rating = new List<double>(); // chek if is right 
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var item in dictonary)
            {
                var rating = 0.0;

                if (item.Value.Rating.Count != 0)
                {
                    rating = item.Value.Rating.Average();

                }
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; Rating: {rating:f2}");
            }
            

        }
    }
}
