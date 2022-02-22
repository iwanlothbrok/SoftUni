using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string command = Console.ReadLine();
            while (command != "Generate")
            {
                string[] tokens = command.Split(">>>");
                string cmdArr = tokens[0];
                switch (cmdArr)
                {
                    case "Contains":
                        string substring = tokens[1];
                        if (activationKey.IndexOf(substring) != -1)
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine($"Substring not found!");
                        }
                        break;

                    case "Flip":
                        string cmd = tokens[1];
                        int firstIndex = int.Parse(tokens[2]);
                        int secondIndex = int.Parse(tokens[3]);
                        string first = activationKey.Substring(0, firstIndex);
                        string second = activationKey.Substring(firstIndex, secondIndex - firstIndex);
                        string third = activationKey.Substring(secondIndex);
                        if (cmd == "Upper")
                        {
                            second = second.ToUpper();
                        }
                        else
                        {
                            second = second.ToLower();
                        }
                        activationKey = first + second + third;
                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        int indexOne = int.Parse(tokens[1]);
                        int indexTwo = int.Parse(tokens[2]);

                        activationKey = activationKey.Remove(indexOne, indexTwo - indexOne);
                        Console.WriteLine(activationKey);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {activationKey}");

        }
    }
}