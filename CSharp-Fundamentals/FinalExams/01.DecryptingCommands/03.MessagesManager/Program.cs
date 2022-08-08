using System;
using System.Collections.Generic;

namespace _03.MessagesManager
{
    public class StartUp
    {
        public class Stats
        {
            public int Sent { get; set; }
            public int Recieve { get; set; }
        }

        static void Main(string[] args)
        {
            var dictonary = new Dictionary<string, Stats>();
            int maxCapacity = int.Parse(Console.ReadLine());

            var cmd = Console.ReadLine();
            while (cmd != "Statistics")
            {
                var cmdSplitted = cmd.Split("=");
                var command = cmdSplitted[0];
                if (command == "Add")
                {
                    var name = cmdSplitted[1];
                    var sent = int.Parse(cmdSplitted[2]);
                    var recieve = int.Parse(cmdSplitted[3]);

                    if (dictonary.ContainsKey(name) == false)
                    {
                        var stats = new Stats()
                        {
                            Sent = sent,
                            Recieve = recieve
                        };
                        dictonary.Add(name, stats);
                    }
                }
                else if (command == "Message")
                {
                    var sender = cmdSplitted[1];
                    var reciever = cmdSplitted[2];

                    if (dictonary.ContainsKey(sender) && dictonary.ContainsKey(reciever))
                    {
                        dictonary[sender].Sent++;
                        dictonary[reciever].Recieve++;
                        var senderCapacity = dictonary[sender].Sent + dictonary[sender].Recieve;
                        if (senderCapacity >= maxCapacity)
                        {
                            dictonary.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        var recieverCapacity = dictonary[reciever].Sent + dictonary[reciever].Recieve;
                        if (recieverCapacity >= maxCapacity)
                        {
                            dictonary.Remove(reciever);
                            Console.WriteLine($"{reciever} reached the capacity!");
                        }
                    }
                }
                else if (command == "Empty")
                {
                    var username = cmdSplitted[1];

                    if (dictonary.ContainsKey(username))
                    {
                        dictonary.Remove(username);

                    }
                    if (username == "All")
                    {
                        dictonary.Clear();
                    }
                }

                cmd = Console.ReadLine();
            }
            Console.WriteLine($"Users count: {dictonary.Count}");

            foreach (var guy in dictonary)
            {
                var countOfAllStats = guy.Value.Sent + guy.Value.Recieve;
                Console.WriteLine($"{guy.Key} - {countOfAllStats}");
            }
         
        }
    }
}
