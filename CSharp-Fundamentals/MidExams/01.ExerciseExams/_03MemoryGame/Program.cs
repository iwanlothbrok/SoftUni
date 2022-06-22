using System;
using System.Linq;

namespace _03MemoryGame
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine()
                         .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                         .ToList();


            var cmd = Console.ReadLine();


            int steps = 0;

            while (cmd != "end")
            {
                var cmdSplitted = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                var firstIndex = int.Parse(cmdSplitted[0]);
                var secondIndex = int.Parse(cmdSplitted[1]);
                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {steps} turns!");
                    return;
                }
                if (firstIndex == secondIndex
                    || firstIndex < 0 || secondIndex < 0 
                    || firstIndex > elements.Count || secondIndex > elements.Count)
                {
                    steps++;
                    Console.WriteLine("Invalid input! Adding additional elements to the board");

                  
                    elements.Insert(elements.Count / 2, $"-{steps}a");
                    elements.Insert(elements.Count / 2, $"-{steps}a");
                    

                    cmd = Console.ReadLine();
                    continue;
                }
                if (elements[firstIndex] == elements[secondIndex])
                {
                    var neededElement = elements[firstIndex];
                    Console.WriteLine($"Congrats! You have found matching elements - {neededElement}!");
                    if (firstIndex > secondIndex)
                    {
                        elements.RemoveAt(firstIndex);
                        elements.RemoveAt(secondIndex);
                    }
                    else
                    {
                        elements.RemoveAt(secondIndex);
                        elements.RemoveAt(firstIndex);
                    }
                    
                }
                else
                {
                    Console.WriteLine("Try again!");
                }

                steps++;
                cmd = Console.ReadLine();
            }
            if ( elements.Count > 0)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(String.Join(" ", elements));
            }
          
        }
    }
}
