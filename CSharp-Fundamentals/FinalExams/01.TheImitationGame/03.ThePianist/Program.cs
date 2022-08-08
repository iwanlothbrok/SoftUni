using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    public class StartUp
    {
        public class Musician
        {
            public string Name { get; set; }
            public string Key { get; set; }
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dictonary = new Dictionary<string, Musician>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split('|');

                var musician = new Musician()
                {
                    Name = input[1],
                    Key = input[2]
                };

                dictonary.Add(input[0], musician);
            }
            var command = Console.ReadLine();

            while (command != "Stop")
            {
                var cmdSpl = command.Split("|");
                var cmd = cmdSpl[0];

                if (cmd == "Add")
                {
                    if (dictonary.ContainsKey(cmdSpl[1]))
                    {
                        Console.WriteLine($"{cmdSpl[1]} is already in the collection!");
                    }
                    else
                    {
                        var musician = new Musician()
                        {
                            Name = cmdSpl[2],
                            Key = cmdSpl[3]
                        };

                        dictonary.Add(cmdSpl[1], musician);

                        Console.WriteLine($"{cmdSpl[1]} by {musician.Name} in {musician.Key} added to the collection!");
                    }
                }
                else if (cmd == "Remove")
                {
                    if (dictonary.ContainsKey(cmdSpl[1]))
                    {
                        dictonary.Remove(cmdSpl[1]);
                        Console.WriteLine($"Successfully removed {cmdSpl[1]}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {cmdSpl[1]} does not exist in the collection.");
                    }
                }
                else if (cmd == "ChangeKey")
                {
                    var neededName = cmdSpl[1];
                    var keyName = cmdSpl[2];
                   // bool rfidExists = dictonary.Key.Any(a => a.Name.Equals(neededName));
                    if (dictonary.ContainsKey(neededName))
                    {
                        foreach (var item in dictonary)
                        {
                            
                            if (item.Key==neededName)
                            {
                                item.Value.Key = keyName;
                                Console.WriteLine($"Changed the key of {neededName} to {keyName}!");
                            }
                        }
                    }

                    else
                    {
                        Console.WriteLine($"Invalid operation! {neededName} does not exist in the collection.");
                    }
                }
                command = Console.ReadLine();
            }
            foreach (var item in dictonary)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.Name}, Key: {item.Value.Key}");
            }
        }
    }
}
