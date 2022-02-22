using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> towns = new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();
            while (command != "Sail")
            {
                string[] tokens = command
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string town = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);
                if (towns.ContainsKey(town))
                {
                    towns[town]["population"] += population;
                    towns[town]["gold"] += gold;
                }
                else
                {
                    towns.Add(town, new Dictionary<string, int>()
                        {
                        { "population",population },
                        { "gold", gold}
                        });

                }
                command = Console.ReadLine();
            }
            command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split("=>");
                string cmdArr = tokens[0];
                string town = tokens[1];
                int population;
                int gold;
                switch (cmdArr)
                {
                    case "Plunder":

                        population = int.Parse(tokens[2]);
                        gold = int.Parse(tokens[3]);

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {population} citizens killed.");
                        towns[town]["population"] -= population;
                        towns[town]["gold"] -= gold;
                        if (towns[town]["gold"] <= 0 || towns[town]["population"] <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            towns.Remove(town);
                        }
                        break;

                    case "Prosper":
                        gold = int.Parse(tokens[2]);
                        int sum;
                        if (gold <= 0)
                        {
                            Console.WriteLine($"Gold added cannot be a negative number!");
                            break;
                        }
                        else
                        {
                            
                            towns[town]["gold"] += gold;
                            sum = towns[town]["gold"];
                        }
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {sum} gold.");
                        break;

                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Ahoy, Captain! There are {towns.Count} wealthy settlements to go to:");
            foreach (var item in towns)
            {
                string town = item.Key;
                int gold = towns[town]["gold"];
                int population = towns[town]["population"];
                Console.WriteLine($"{town} -> Population: {population} citizens, Gold: {gold} kg");
            }
        }
    }
}