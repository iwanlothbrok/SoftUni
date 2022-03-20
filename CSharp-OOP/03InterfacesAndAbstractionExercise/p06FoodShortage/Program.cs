using System;
using System.Collections.Generic;
using System.Linq;

namespace p06FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> people = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    Rebel rebel = new Rebel(name, age, group);
                    people.Add(rebel);
                }
                else if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birdthDate = tokens[3];

                    Citizen citizen = new Citizen(name, age, id, birdthDate);
                    people.Add(citizen);
                }
            }
            string cmd = Console.ReadLine();
            
            while (cmd != "End")
            {
                var buyer = people.FirstOrDefault(n => n.Name == cmd);
                if (buyer != null)
                {
                    buyer.BuyFood();

                }
                cmd = Console.ReadLine();
            }
            Console.WriteLine(people.Sum(b => b.Food));
        }
    }
}
