using System;
using System.Collections.Generic;

namespace p06ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
           Engine();
        }

        private static void Engine()
        {
            var name = Console.ReadLine().Split();

            while (name[0] != "End")
            {
                var human = new Citizen(name[0]);
                Console.WriteLine(((IPerson)human).GetName());
                Console.WriteLine(((IResident)human).GetName());

                name = Console.ReadLine().Split();
            }
        }
    }
}
