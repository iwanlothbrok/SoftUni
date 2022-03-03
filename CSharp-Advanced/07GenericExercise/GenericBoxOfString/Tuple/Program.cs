using System;

namespace Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAdress = Console.ReadLine().Split();
            string fullName = $"{nameAndAdress[0]} {nameAndAdress[1]}";
            string adress = $"{nameAndAdress[2]}";


            string[] personAndBeerQuantity = Console.ReadLine().Split(" ");
            string person = personAndBeerQuantity[0];
            int quantityBeer = int.Parse(personAndBeerQuantity[1]);

            string[] intAndDouble = Console.ReadLine().Split();
            int integerNum = int.Parse(intAndDouble[0]);
            double doubleNum = double.Parse(intAndDouble[1]);

            Tuple<string, string> nameAndAdrresTuple = new Tuple<string, string>(fullName, adress);
            Tuple<string, int> personAndBeer = new Tuple<string, int>(person, quantityBeer);
            Tuple<int, double> nums = new Tuple<int, double>(integerNum, doubleNum);

            Console.WriteLine(nameAndAdrresTuple);
            Console.WriteLine(personAndBeer);
            Console.WriteLine(nums);
        }
    }
}
