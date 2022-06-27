using System;

namespace _01.TheBiscuitFactory
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double biscPerDay = double.Parse(Console.ReadLine());
            double workerkersCount = double.Parse(Console.ReadLine());
            double neededBisc = double.Parse(Console.ReadLine());
            double ownBisc = 0;
            int days = 0;
            for (int i = 0; i < 30; i++)
            {
                days++;    
                if (days % 3 == 0)
                {
                    var losses = biscPerDay * 0.75;


                    ownBisc += Math.Floor(losses * workerkersCount) ;
                }
                else
                {
                    
                    ownBisc += Math.Floor(biscPerDay * workerkersCount); 
                }

            }
            ownBisc = Math.Floor(ownBisc);
            Console.WriteLine($"You have produced {ownBisc} biscuits for the past month.");
            if (ownBisc > neededBisc)
            {
                //1160 / 16000 * 100 = 7.25 %
                var diff = ownBisc - neededBisc;
                var percent = (diff / neededBisc) * 100;

                Console.WriteLine($"You produce {percent:F2} percent more biscuits.");
            }
            else
            {
                var diff = neededBisc - ownBisc;
                var percent = diff / neededBisc * 100;
                Console.WriteLine($"You produce {percent:F2} percent less biscuits.");
            }
        }
    }
}
