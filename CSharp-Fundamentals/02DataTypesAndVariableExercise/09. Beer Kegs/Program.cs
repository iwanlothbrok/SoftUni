using System;

namespace _08._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int counter = 0;
            double theBiggestKeg = 0;
            string theBiggestKegName = "";
            while (lines != counter)
            {
                string nameOfKeg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                counter++;
                double piAndHeight = Math.PI * height;
                double volume = piAndHeight * Math.Pow(radius, 2);


                if (volume > theBiggestKeg)
                {
                    theBiggestKegName = nameOfKeg;
                    theBiggestKeg = volume;
                }
            }
            Console.WriteLine(theBiggestKegName);
        }
    }
}
