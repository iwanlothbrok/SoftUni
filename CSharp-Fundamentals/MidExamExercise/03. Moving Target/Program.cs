using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();




            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string cmdArr = tokens[0]?.ToLower();
                int index = int.Parse(tokens[1]);
                int power = int.Parse(tokens[2]);


                switch (cmdArr)
                {
                    case "shoot":
                        if (index >= 0 && index < targets.Count)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)//<
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;

                    case "strike":
                        if (index - power >= 0 && index + power < targets[targets.Count - 1])
                        {
                            targets.RemoveRange(index - power, power * 2 + 1);
                        }
                        else
                        {
                            Console.WriteLine($"Strike missed!");
                        }
                        break;

                    case "add":
                        if (index >= 0 && index < tokens.Length)
                        {

                            targets.Insert(index, power);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join('|', targets));
        }
    }
}
