using System;
using System.Linq;

namespace _02.MuOnline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var health = 100;
            var bitcoins = 0;

            var cmd = Console.ReadLine().Split(new char[] {'|', ' '  } ).ToList();
          
            int count = 0;
            while (true)
            {

                count++;
                if (cmd.Count < 1)
                {
                    break;
                }
                //string[] currentCmd = cmd.Split(" ");
                string command = cmd[0];
                int num = int.Parse(cmd[1]);

                if (command == "potion")
                {
                    var neededNum = 100 - health;
                    health += num;
                    if (health > 100)
                    {
                        health = 100;
                        Console.WriteLine($"You healed for {neededNum} hp.");
                        Console.WriteLine($"Current health: {health} hp.");

                    }
                    else
                    {

                        Console.WriteLine($"You healed for {num} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                    }

                }
                else if (command == "chest")
                {
                    Console.WriteLine($"You found {num} bitcoins.");
                    bitcoins += num;
                }
                else
                {
                    health -= num;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {command}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {count}");
                        return;
                    }
                }
                cmd.Remove(command);
                string removeNum = num.ToString();
                cmd.Remove(removeNum);
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
