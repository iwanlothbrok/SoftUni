using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrainList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] arrCmd = command.Split();
                string currentComand = arrCmd[0];

                if (currentComand == "Add") //not so sure
                {
                    wagons.Add(int.Parse(arrCmd[1]));
                }
                else
                {
                    int comingPassagers = int.Parse(arrCmd[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {
                        int passagers = wagons[i];
                        bool isEnoughtSpace = passagers + comingPassagers <= maxCapacity;
                        if (isEnoughtSpace)
                        {
                            wagons[i] += comingPassagers;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));





        }
    }
}
