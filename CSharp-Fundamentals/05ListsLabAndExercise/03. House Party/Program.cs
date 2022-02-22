using System;
using System.Collections.Generic;
using System.Linq;
namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            int persons = int.Parse(Console.ReadLine());

            //string command = Console.ReadLine();
            for (int i = 0; i < persons; i++)
            {
                string command = Console.ReadLine();
                string[] cmdArr = command.Split();
                string name = cmdArr[0];

                if (cmdArr.Length == 3)
                {

                    if (!names.Contains(name))
                    {
                        names.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
                else
                {
                    if (names.Contains(name))
                    {
                        names.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join(System.Environment.NewLine, names));//new line
        }
    }
}
