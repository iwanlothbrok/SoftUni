using System;
using System.Collections.Generic;
using Animals.AniamlsInfo;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string info = Console.ReadLine();
            List<IAnimal> animals = new List<IAnimal>();

            while (info != "Beast!")
            {
                try
                {
                    Animal animal = null;

                    string[] typeAnimal = info.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                    string animalType = typeAnimal[0];

                    string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = animalInfo[2];

                    animal = CreateAnimal(animal, animalType, name, age, gender);

                    animals.Add(animal);

                    info = Console.ReadLine();
                }

                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    info = Console.ReadLine();
                }

            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }


        private static Animal CreateAnimal(Animal animal, string animalType, string name, int age, string gender)
        {
            if (animalType == "Cat")
            {
                animal = new Cat(name, age, gender);
            }
            else if (animalType == "Dog")
            {
                animal = new Dog(name, age, gender);
            }
            else if (animalType == "Frog")
            {
                animal = new Frog(name, age, gender);
            }
            else if (animalType == "Tomcat")
            {
                animal = new Tomcat(name, age, gender);
            }
            else if (animalType == "Kitten")
            {
                animal = new Kitten(name, age, gender);
            }
            else
            {
                throw new ArgumentException("Invalid input!");
            }

            return animal;
        }
    }
}
