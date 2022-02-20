using System;
using System.Linq;
using System.Collections.Generic;
namespace Workout
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int trainingDays = int.Parse(Console.ReadLine());
            double kilometers = double.Parse(Console.ReadLine());
            double upgrade = 0;
            double totalKilometers = 0;
            totalKilometers += kilometers;
            for (int i = 0; i < trainingDays; i++)
            {
               
                double percentUpgrade = double.Parse(Console.ReadLine());
                percentUpgrade /= 100;
                kilometers = kilometers + kilometers * percentUpgrade;
                totalKilometers += kilometers;
            }
            if (totalKilometers >= 1000)
            {
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalKilometers -1000)} more kilometers!");
            }
            else
            {
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(1000-totalKilometers)} more kilometers");
            }
        }
    }
}
