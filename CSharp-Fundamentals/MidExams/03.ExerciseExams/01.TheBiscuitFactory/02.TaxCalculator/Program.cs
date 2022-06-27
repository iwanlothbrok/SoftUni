using System;
using System.Linq;

namespace _02.TaxCalculator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var vehicleInfo = Console.ReadLine().Split(">>").ToList();


            double totalTaxes = 0.0;
            foreach (var vehicles in vehicleInfo)
            {
                var car = vehicles.Split(" ");
                var currentTaxes = 0.0;

                var type = car[0];
                if (type == "family")
                {
                    currentTaxes += 50;
                    var year = int.Parse(car[1]);
                    var km = int.Parse(car[2]);
                    for (int i = 0; i < year; i++)
                    {
                        currentTaxes -= 5;
                    }

                    km /= 3000;
                    if (km > 0)
                    {
                        for (int i = 0; i < km; i++)
                        {
                            currentTaxes += 12;
                        }

                    }

                }
                else if (type == "heavyDuty")
                {
                    currentTaxes += 80;
                    var year = int.Parse(car[1]);
                    var km = int.Parse(car[2]);
                    for (int i = 0; i < year; i++)
                    {
                        currentTaxes -= 8;
                    }

                    km /= 9000;
                    if (km > 0)
                    {
                        for (int i = 0; i < km; i++)
                        {
                            currentTaxes += 14;
                        }
                    }
                }
                else if (type == "sports")
                {
                    currentTaxes += 100;
                    var year = int.Parse(car[1]);
                    var km = int.Parse(car[2]);
                    for (int i = 0; i < year; i++)
                    {
                        currentTaxes -= 9;
                    }

                    km /= 2000;
                    if (km > 0)
                    {
                        for (int i = 0; i < km; i++)
                        {
                            currentTaxes += 18;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid car type.");
                    continue;
                }
                totalTaxes += currentTaxes;
                Console.WriteLine($"A {type} car will pay {currentTaxes:f2} euros in taxes.");
            }
            Console.WriteLine($"The National Revenue Agency will collect {totalTaxes:f2} euros in taxes.");
        }
    }
}
