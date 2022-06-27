using System;
using System.Linq;

namespace _03.Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine().Split(", ").ToList();


            var cmd = Console.ReadLine();


            while (cmd != "Craft!")
            {
                var cmdSpl = cmd.Split(" - ");
                var command = cmdSpl[0];
                var item = cmdSpl[1];

                if (command == "Collect")
                {
                    if (items.Contains(item) == false)
                    {
                        items.Add(item);
                    }
                }
                else if (command == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (command == "Combine Items")
                {
                    var newItem = item.Split(":");
                    var firstItem = newItem[0];
                    var secondItem = newItem[1];
                    if (items.Contains(firstItem))
                    {
                        var index = items.IndexOf(firstItem);
                        
                        items.Insert(index + 1, secondItem);
                    }
                }
                else if (command == "Renew")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                        items.Add(item);
                    }
                }

                cmd = Console.ReadLine();
            }
            Console.WriteLine(String.Join(", ",items));
        }
    }
}
