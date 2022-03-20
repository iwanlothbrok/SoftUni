using System;
using System.Collections.Generic;

namespace p04BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> everyone = new List<IIdentifiable>();
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] tokens = cmd.Split();
                if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    Robot robot = new Robot(model, id);
                    everyone.Add(robot);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    Citizen citizen = new Citizen(name, age, id);
                    everyone.Add(citizen);
                }

                cmd = Console.ReadLine();
            }
            string lastSymb = Console.ReadLine();
            foreach (var item in everyone)
            {
                if (item.Id.EndsWith(lastSymb))
                {
                    Console.WriteLine(item.Id);
                }

            }
        }
    }
}
