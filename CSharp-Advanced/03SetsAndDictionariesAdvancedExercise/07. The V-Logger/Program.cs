using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheVlogger
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new SortedDictionary<string, Dictionary<string, SortedSet<string>>>();
            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] cmdArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstVlogger = cmdArr[0];
                string commit = cmdArr[1];

                if (commit == "joined")
                {
                    if (!vloggers.ContainsKey(firstVlogger))
                    {
                        vloggers.Add(firstVlogger, new Dictionary<string, SortedSet<string>>());
                        vloggers[firstVlogger].Add("followers", new SortedSet<string>());
                        vloggers[firstVlogger].Add("following", new SortedSet<string>());
                    }
                    else
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                }
                else if (commit == "followed")
                {
                    string secondVlogger = cmdArr[2];
                    if (!vloggers.ContainsKey(firstVlogger) || !vloggers.ContainsKey(secondVlogger) || firstVlogger == secondVlogger)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    vloggers[firstVlogger]["following"].Add(secondVlogger);
                    vloggers[secondVlogger]["followers"].Add(firstVlogger);

                }

                command = Console.ReadLine();
            }
           


            int count = vloggers.Count;
            int countVloggers = 0;
            Console.WriteLine($"The V-Logger has a total of { count} vloggers in its logs.");

            foreach (var vlogger in vloggers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count))
            {
                int followingCount = vlogger.Value["following"].Count;
                int followersCount = vlogger.Value["followers"].Count;
                Console.WriteLine($"{++countVloggers}. {vlogger.Key} : {followersCount} followers, {followingCount} following");

                if (countVloggers == 1)
                {
                    foreach(string follower in vlogger.Value["followers"].OrderBy(f => f))
                    {
                    Console.WriteLine($"*  {follower}");
                    }
                    
                }
            }
        }
    }
}
