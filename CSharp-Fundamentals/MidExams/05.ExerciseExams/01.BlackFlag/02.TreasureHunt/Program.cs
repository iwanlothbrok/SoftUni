using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.TreasureHunt
{
    public class Program
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Split('|').ToList();


            var cmd = Console.ReadLine();
            while (cmd != "Yohoho!")
            {
                var cmdSplit = cmd.Split(" ");
                var command = cmdSplit[0];


                if (command == "Loot")
                {
                    foreach (var item in cmdSplit.Skip(1))
                    {
                        if (items.Contains(item) == false)
                        {
                            items.Insert(0, item);
                        }
                    }
                }
                else if (command == "Drop")
                {
                    var index = int.Parse(cmdSplit[1]);
                    if (index < items.Count && index > 0)
                    {
                        var neededItem = items[index];
                        items.RemoveAt(index);
                        items.Add(neededItem);
                    }

                }
                else if (command == "Steal")
                {
                    var index = int.Parse(cmdSplit[1]);
                    var neededItems = items.TakeLast(index); //CHECK IF THIS IS RIGHT
                    Console.WriteLine(String.Join(", ", neededItems));
                    int count = 0;
                    for (int i = items.Count - 1; i >= 0; i--)
                    {
                        count++;
                        items.Remove(items[i]);
                        if (count == index || items.Count == 0)
                        {

                            break;
                        }
                    }

                }

                cmd = Console.ReadLine();
            }
            if (items.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                decimal lengthSum = items.Sum(item => item.Length);
                decimal result = lengthSum / items.Count;

                Console.WriteLine($"Average treasure gain: {result:f2} pirate credits.");
            }

        }
    }
}
//In the end, output the average treasure gain, which is 
//    the sum of all treasure items length divided by the count of all items inside the chest formatted to the second decimal point: