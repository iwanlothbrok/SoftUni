using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace p01blacksmith
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] inputSteel = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();
            int[] carbonSteel = Console.ReadLine().Split(' ')
                .Select(int.Parse).ToArray();
            Queue<int> steel = new Queue<int>(inputSteel);
            Stack<int> carbon = new Stack<int>(carbonSteel);

            int gladius = 0;
            int shamshir = 0;
            int katana = 0;
            int sabre = 0;
            int broadsword = 0;
            int count = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Peek();
                int currentCarbon = carbon.Peek();

                int totalSum = currentSteel + currentCarbon;
                if (totalSum == 70)
                {
                    gladius++;
                    count++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (totalSum == 80)
                {
                    shamshir++;
                    count++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (totalSum == 90)
                {
                    katana++;
                    count++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (totalSum == 110)
                {
                    sabre++;
                    count++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (totalSum == 150)
                {
                    broadsword++;
                    count++;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    currentCarbon += 5;
                    carbon.Pop();
                    carbon.Push(currentCarbon);
                }
            }
            if (count >= 1)
            {
                Console.WriteLine($"You have forged {count} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }

           //var dictonary = new Dictionary<string, int>();
           //dictonary["Broadsword"] = broadsword;
           //dictonary["Sabre"] = sabre;
           //dictonary["Katana"] = katana;
           //dictonary["Shamshir"] = shamshir;
           //dictonary["Gladius"] = gladius;


            if (broadsword > 0)
            {
                Console.WriteLine($"Broadsword: {broadsword}");
            }
            if (gladius > 0)
            {
                Console.WriteLine($"Gladius: {gladius}");
            }
            if (katana > 0)
            {
                Console.WriteLine($"Katana: {katana}");
            }
            if (sabre > 0)
            {
                Console.WriteLine($"Sabre: {sabre}");
            }
            if (shamshir > 0)
            {
                Console.WriteLine($"Shamshir: {shamshir}");
            }

        }
    }
}
