using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();


            while (command != "end")
            {
                string[] cmdArr = command.Split();
                string currentComand = cmdArr[0];

                if (currentComand == "Delete")//!!!
                {
                    int incomingNum = int.Parse(cmdArr[1]);

                    numbers.RemoveAll(x => x == incomingNum);
                }
                else
                {
                    int incomingNum = int.Parse(cmdArr[1]);
                    int index = int.Parse(cmdArr[2]);

                    numbers.Insert(index, incomingNum);
                }

                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ", numbers));
        }

    }
}