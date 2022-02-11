using System;

namespace po_05._Suitcases_Load
{
    class Program
    {
        static void Main(string[] args)
        {
            double trunkSpace = double.Parse(Console.ReadLine());

            int counter = 0;
            double freeSpace = 0;

            string suitcase = Console.ReadLine();
            while (suitcase != "End")
            {
                double volumeSuitcase = double.Parse(suitcase);
                counter++;
                if (counter == 3 || counter == 6 || counter == 9)
                {
                    volumeSuitcase *= 1.1;
                }
                freeSpace += volumeSuitcase;

                if (freeSpace > trunkSpace)//>
                {
                    Console.WriteLine($"No more space!");
                    counter -= 1;
                    break;
                }


                suitcase = Console.ReadLine();
            }
            if (suitcase == "End")
            {
                Console.WriteLine($"Congratulations! All suitcases are loaded!");

            }
            Console.WriteLine($"Statistic: {counter} suitcases loaded.");

        }
    }
}
// counter,freeSpace