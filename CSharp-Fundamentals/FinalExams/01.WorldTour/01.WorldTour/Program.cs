using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.WorldTour
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           var input = Console.ReadLine();

            var sb = new StringBuilder(input);

            var cmd = Console.ReadLine();

            while (cmd != "Travel")
            {
                var cmdSpl = cmd.Split(":");

                var command = cmdSpl[0].Split();
                if (command[0] == "Add")
                {
                    var index = int.Parse(cmdSpl[1]);
                    if (index < sb.Length && index >= 0)
                    {
                        var place = cmdSpl[2];
                        sb.Insert(index, place);
                    }

                }

                else if (command[0] == "Remove")
                {
                    var startIndex = int.Parse(cmdSpl[1]);
                    var endIndex = int.Parse(cmdSpl[2]);
                    if (startIndex < sb.Length && startIndex >= 0 && endIndex <= sb.Length && endIndex >= 0)
                    {
                        var count = endIndex - startIndex;

                        sb.Remove(startIndex, count + 1);
                    }
                }
                else if (command[0] == "Switch")
                {
                    var oldPlace = cmdSpl[1];
                    var newPlace = cmdSpl[2];
                    if (input.Contains(oldPlace))
                    {
                        sb.Replace(oldPlace, newPlace);

                    }
                }

                Console.WriteLine(sb.ToString());
                cmd = Console.ReadLine();
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {sb.ToString().TrimEnd()}");
        }
    }
}
