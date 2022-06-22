using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split("!", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

           

            string cmd = Console.ReadLine();

            while (cmd != "Go Shopping!")
            {
                var cmdArr = cmd.Split(" ");

                string command = cmdArr[0];

                if (command == "Urgent")
                {
                    if (input.Contains(cmdArr[1]) == false)
                    {
                        input.Insert(0,cmdArr[1]);
                    }

                }
                else if (command == "Unnecessary")
                {
                    if (input.Contains(cmdArr[1]))
                    {
                        input.Remove(cmdArr[1]);
                    }
                }
                else if (command == "Correct")
                {
                    if (input.Contains(cmdArr[1]))
                    {
                        var index = input.IndexOf(cmdArr[1]);
                        input.Remove(cmdArr[1]);
                        input.Insert(index, cmdArr[2]);// check if you have this item wwhat to do ?
                    }
                }
                else if (command == "Rearrange")
                {
                    if (input.Contains(cmdArr[1]))
                    {
                        input.Remove(cmdArr[1]);
                        input.Add(cmdArr[1]);
                    }
                }


                cmd = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ", input));
        }
    }
}
