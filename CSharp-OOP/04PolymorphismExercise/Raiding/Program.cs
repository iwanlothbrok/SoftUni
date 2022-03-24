using Raiding.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBaseHero> listOfHeroes = new List<IBaseHero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                IBaseHero hero = null;
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if (type == "Paladin")
                {
                    hero = new Paladin(name);
                }
                else if (type == "Druid")
                {
                    hero = new Druid(name);
                }
                else if (type == "Rogue")
                {
                    hero = new Rogue(name);
                }
                else if (type == "Warrior")
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }

                listOfHeroes.Add(hero);
                

               // hero = MakeHero(listOfHeroes, hero, name, type);
            }
            int bossPower = int.Parse(Console.ReadLine());

            int sumOfPower = 0;
            foreach (var heroOutput in listOfHeroes)
            {
                Console.WriteLine(heroOutput.CastAbility());
                sumOfPower += heroOutput.Power;
            }
            ChekIfWeWin(bossPower, sumOfPower);
        }

        private static IBaseHero MakeHero(List<IBaseHero> listOfHeroes, IBaseHero hero, string name, string type)
        {
            if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                Console.WriteLine("Invalid hero!");
               
            }
            if (hero != null)
            {
                listOfHeroes.Add(hero);
            }

            return hero;
        }

        private static void ChekIfWeWin(int bossPower, int sumOfPower)
        {
            if (sumOfPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
