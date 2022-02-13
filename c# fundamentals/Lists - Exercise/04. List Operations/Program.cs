using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
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

            while (command != "End")
            {
                string[] cmdArr = command.Split();
                string currentCommand = cmdArr[0];
                if (currentCommand == "Add")
                {
                    numbers.Add(int.Parse(cmdArr[1]));
                }
                else if (currentCommand == "Remove")
                {
                    int index = int.Parse(cmdArr[1]);
                    if (IsValidIndex(index, numbers.Count))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (currentCommand == "Insert")//check for invalid
                {
                    int index = int.Parse(cmdArr[2]);
                    int num = int.Parse(cmdArr[1]);
                    if (IsValidIndex(index, num))
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, num);
                    }


                }
                else if (currentCommand == "Shift")//!!!
                {
                    int rotations = int.Parse(cmdArr[2]);
                    if (cmdArr[1] == "left")
                    {
                        for (int i = 0; i < rotations; i++)
                        {
                            int firstElement = numbers[0];
                            for (int j = 0; j < numbers.Count - 1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }
                            numbers[numbers.Count - 1] = firstElement;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < rotations; i++)//!!!
                        {
                            int lastElement = numbers[numbers.Count - 1];
                            for (int j = numbers.Count - 1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }
                            numbers[0] = lastElement;
                        }
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
        public static bool IsValidIndex(int index, int count)
        {
            return index > count || index < 0;
        }
    }
}
