using System;
using System.Collections.Generic;
using System.Linq;

namespace p05BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirtdable> everyone = new List<IBirtdable>();
            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                string[] tokens = cmd.Split();
                string action = tokens[0];
                if (action == "Pet")
                {
                    string name = tokens[1];
                    string birthDate = tokens[2];
                    Pet pet = new Pet(name, birthDate);
                    everyone.Add(pet);
                }
                else if (action == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthDate = tokens[4];
                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    everyone.Add(citizen);
                }
              //else if (action == "Robot")
              //{
              //    string model = tokens[1];
              //    string id = tokens[2];
              //    Robot robot = new Robot(model, id);
              //    everyone.Add(robot);
              //}
                cmd = Console.ReadLine();
            }
            string searchingDate = Console.ReadLine();
         
            foreach (var item in everyone)
            {
                if (item.BirthDate.EndsWith(searchingDate))
                {
                    Console.WriteLine(item.BirthDate);
                   
                }
            }
            
        }
    }
}
