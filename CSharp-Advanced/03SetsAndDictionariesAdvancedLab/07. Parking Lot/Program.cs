using System;
using System.Linq;
using System.Collections.Generic;
namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            HashSet<string> numbersOfCars = new HashSet<string>();
            while (cmd != "END")
            {
                string[] cmdArr = cmd.Split(", ");
                string command = cmdArr[0];
                string numberOfTheCar = cmdArr[1];
                if (command == "IN")
                {
                    numbersOfCars.Add(numberOfTheCar);
                }
                else
                {
                    numbersOfCars.Remove(numberOfTheCar);
                }

                cmd = Console.ReadLine();
            }
            if (numbersOfCars.Count<=0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }
            foreach (var numbers in numbersOfCars)
            {
                Console.WriteLine(numbers);
            }
        }
    }
}