using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Heroes

{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var heroes = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] cmd = Console.ReadLine().Split(' ');
                string name = cmd[0];
                int hp = int.Parse(cmd[1]);
                int mana = int.Parse(cmd[2]);
                if (heroes.ContainsKey(name))
                {
                    heroes[name]["hp"] = hp;// тук няма нужда от +
                    heroes[name]["mp"] = mana;
                }
                else
                {
                    heroes.Add(name, new Dictionary<string, int>()
                        {
                        { "hp",hp },//>!100
                        { "mana", mana}//!>200
                        });
                }
                
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArr = command.Split(" - ");
                string cmd = cmdArr[0];
                switch (cmd)
                {
                    case "CastSpell":
                        string name = cmdArr[1];
                        int mp = int.Parse(cmdArr[2]);
                        string spell = cmdArr[3];


                        if (heroes[name]["mana"] >= mp)
                        {
                            heroes[name]["mana"] = heroes[name]["mana"] - mp;
                            Console.WriteLine($"{name} has successfully cast {spell} and now has {heroes[name]["mana"]} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} does not have enough MP to cast {spell}!");
                        }

                        break;

                    case "TakeDamage":
                        name = cmdArr[1];
                        int dmg = int.Parse(cmdArr[2]);
                        string attacker = cmdArr[3];
                        heroes[name]["hp"] = heroes[name]["hp"] - dmg;
                        if (heroes[name]["hp"] > 0)
                        {
                            Console.WriteLine($"{name} was hit for {dmg} HP by {attacker} and now has {heroes[name]["hp"]} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{name} has been killed by {attacker}!");
                            heroes.Remove(name);
                        }
                        break;

                    case "Recharge":
                        name = cmdArr[1];
                        int recharge = int.Parse(cmdArr[2]);
                        int mana = heroes[name]["mana"];
                        heroes[name]["mana"] = heroes[name]["mana"] + recharge;
                        if (heroes[name]["mana"] > 200)
                        {
                            heroes[name]["mana"] = 200;
                        }
                        int rechargeAmount = heroes[name]["mana"] - mana;
                        Console.WriteLine($"{name} recharged for {rechargeAmount} MP!");

                        break;

                    case "Heal":
                        name = cmdArr[1];
                        int rechargeHeal = int.Parse(cmdArr[2]);
                        int hp = heroes[name]["hp"];
                        heroes[name]["hp"] = heroes[name]["hp"] + rechargeHeal;
                        if (heroes[name]["hp"] >= 100)
                        {
                            heroes[name]["hp"] = 100;
                        }
                        rechargeAmount = heroes[name]["hp"] - hp;
                        Console.WriteLine($"{name} healed for {rechargeAmount} HP!");

                        break;

                    default:
                        break;
                }

                command = Console.ReadLine();
            }
            foreach (var heroe in heroes)
            {
                string name = heroe.Key;
                int hp = heroes[name]["hp"];
                int mana = heroes[name]["mana"];

                Console.WriteLine($"{name}");
                Console.WriteLine($" HP: {hp}");
                Console.WriteLine($" MP: {mana}");
            }
        }
    }
}
