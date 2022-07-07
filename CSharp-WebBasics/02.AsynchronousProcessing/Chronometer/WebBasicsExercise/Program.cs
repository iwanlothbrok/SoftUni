using System;
using System.Collections.Generic;
using WebBasicsExercise.Models;

namespace WebBasicsExercise
{
    public class Start
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi,write your command!");

            var chronometer = new Chronometer();
            int lapCount = -1;
            var cmd = Console.ReadLine();
            while (cmd != "exit")
            {
                if (cmd == "start")
                {
                    chronometer.Start();
                }
                else if (cmd == "stop")
                {
                    chronometer.Stop();
                }
                else if (cmd == "lap")
                {

                    lapCount++;
                    string lap = chronometer.Lap();


                    Console.WriteLine($"{lapCount}. {lap}");

                }
                else if (cmd == "laps")
                {
                    var laps = chronometer.Laps;
                    if (laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                    else
                    {
                        int count = 0;
                        Console.WriteLine("Laps:");
                        foreach (var lap in laps)
                        {
                            Console.WriteLine($"{count}. {lap}");
                            count++;
                        }
                    }
                }
                else if (cmd == "time")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (cmd == "reset")
                {
                    chronometer.Reset();
                    lapCount = -1;
                }
                cmd = Console.ReadLine();
            }
        }
    }
}
