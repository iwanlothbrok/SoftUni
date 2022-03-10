using System;
using System.Collections.Generic;
using System.Linq;

namespace p01Bombs
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] bmbEff = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                 .Select(int.Parse).ToArray();

            int[] bmbCas = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse).ToArray();

            Queue<int> bombEffect = new Queue<int>(bmbEff);
            Stack<int> bombCasing = new Stack<int>(bmbCas);

            int cherry = 0;//40
            int datura = 0;//60
            int smoke = 0;//120
            bool isAll = false;

            while (bombEffect.Count > 0 && bombCasing.Count > 0)
            {
                int currentEff = bombEffect.Peek();
                int currentCas = bombCasing.Peek();
                int sum = currentCas + currentEff;

                if (sum == 40)
                {
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    datura++;

                }
                else if (sum == 60)
                {
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    cherry++;

                }
                else if (sum == 120)
                {
                    bombEffect.Dequeue();
                    bombCasing.Pop();
                    smoke++;

                }
                else
                {
                    currentCas -= 5;
                    bombCasing.Pop();
                    bombCasing.Push(currentCas);
                }
                if (cherry >= 3 && datura >= 3 && smoke >= 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    isAll = true;
                    break;
                }
            }
            if (isAll == false)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffect)}");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: empty");
            }
            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: empty");
            }
            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");
        }
    }
}
