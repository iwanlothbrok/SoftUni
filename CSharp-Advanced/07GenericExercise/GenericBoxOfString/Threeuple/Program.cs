using System;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] nameAdressTown = Console.ReadLine().Split();
            string fullName = $"{nameAdressTown[0]} {nameAdressTown[1]}";
            string adress = $"{nameAdressTown[2]}";
            string town = string.Empty;
            if (nameAdressTown.Length > 4)
            {
                town = $"{nameAdressTown[3]} {nameAdressTown[4]}";
            }
            else
            {
                town = $"{nameAdressTown[3]}";
            }
            string[] personWithBeer = Console.ReadLine().Split(" ");
            string person = personWithBeer[0];
            int quantityBeer = int.Parse(personWithBeer[1]);
            string inputDrunk = personWithBeer[2];

           
          

            string[] nameAndBankInfo = Console.ReadLine().Split();
            string name = nameAndBankInfo[0];
            double balance = double.Parse(nameAndBankInfo[1]);
            string bankName = nameAndBankInfo[2];

            Threeuple<string, string, string> outputNameAdressTown = new Threeuple<string, string, string>(fullName, adress, town);
            Threeuple<string, int, bool> threeupleTwo
                 = new Threeuple<string, int, bool>(personWithBeer[0], int.Parse(personWithBeer[1]), personWithBeer[2] == "drunk" ? true : false);
            Threeuple<string, double, string> bankInff = new Threeuple<string, double, string>(name, balance, bankName);

            Console.WriteLine(outputNameAdressTown);
            Console.WriteLine(threeupleTwo);
            Console.WriteLine(bankInff);
        }
    }
}
