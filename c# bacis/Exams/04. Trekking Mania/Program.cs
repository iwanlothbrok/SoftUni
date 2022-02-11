using System;

namespace po_04._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            double musalaPeople = 0;
            double monblanPeople = 0;
            double kilimandjaroPeople = 0;
            double k2People = 0;
            double everestPeople = 0;
            double allPeople = 0;

            for (int i = 1; i <= group; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                allPeople += peopleInGroup;
                if (peopleInGroup <= 5)
                {
                    musalaPeople += peopleInGroup;
                    peopleInGroup = 0;
                }
                else if (peopleInGroup <= 12)
                {
                    monblanPeople += peopleInGroup;
                    peopleInGroup = 0;
                }
                else if (peopleInGroup <= 25)
                {
                    kilimandjaroPeople += peopleInGroup;
                    peopleInGroup = 0;
                }
                else if (peopleInGroup <= 40)
                {
                    k2People += peopleInGroup;
                    peopleInGroup = 0;

                }
                else
                {
                    everestPeople += peopleInGroup;
                    peopleInGroup = 0;
                }

            }
            double afterMusalaPeople = musalaPeople / allPeople * 100;
            double afterMonblanPeople = monblanPeople / allPeople * 100;
            double afterKilimandjaroPeople = kilimandjaroPeople / allPeople * 100;
            double afterK2People = k2People / allPeople * 100;
            double afterEverestPeople = everestPeople / allPeople * 100;



            Console.WriteLine($"{afterMusalaPeople:f2}%");
            Console.WriteLine($"{afterMonblanPeople:f2}%");
            Console.WriteLine($"{afterKilimandjaroPeople:f2}%");
            Console.WriteLine($"{afterK2People:f2}%");
            Console.WriteLine($"{afterEverestPeople:f2}%");
        }
    }
}
