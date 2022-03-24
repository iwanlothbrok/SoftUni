using System;
using System.Collections.Generic;
using System.Text;
using Wild_Farm.Animals;
using Wild_Farm.Food;

namespace Wild_Farm
{
    public class Engine
    {

        public void Run()
        {
            List<IAnimal> animals = new List<IAnimal>();
            string info = Console.ReadLine();
            while (info != "End")
            {
                try
                {
                    string[] animalInfo = info.Split();
                    string animalType = animalInfo[0];
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    IAnimal animal = null;
                    string[] foodInfo = Console.ReadLine().Split();
                    string foodType = foodInfo[0];
                    int foodQuantity = int.Parse(foodInfo[1]);

                    animal = CheckAnimalType(animalInfo, animalType, name, weight, animal);
                    Console.WriteLine(animal.ProduceSound());
                    animals.Add(animal);

                    IFood food = null;
                    food = ChekFoodType(foodType, foodQuantity, food);
                    animal.Eat(food);

                    info = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    info = Console.ReadLine();
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animalOutput in animals)
            {
                Console.WriteLine(animalOutput.ToString());
            }
        }

        private static IFood ChekFoodType(string foodType, int foodQuantity, IFood food)
        {
            if (foodType == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQuantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuantity);

            }

            return food;
        }

        private static IAnimal CheckAnimalType(string[] animalInfo, string animalType, string name, double weight, IAnimal animal)
        {
            if (animalType == "Cat" || animalType == "Tiger")
            {
                //"{Type} {Name} {Weight} {LivingRegion} {Breed}"
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];
                if (animalType == "Cat")
                {
                    animal = new Cat(name, weight, livingRegion, breed);
                }
                else
                {
                    animal = new Tiger(name, weight, livingRegion, breed);
                }
            }
            else if (animalType == "Mouse" || animalType == "Dog")
            {
                //"{Type} {Name} {Weight} {LivingRegion}"
                string livingRegion = animalInfo[3];
                if (animalType == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
                else
                {
                    animal = new Dog(name, weight, livingRegion);
                }
            }
            else if (animalType == "Owl" || animalType == "Hen")
            {
                //"{Type} {Name} {Weight} {WingSize}"
                double wingSize = double.Parse(animalInfo[3]);
                if (animalType == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }
                else
                {
                    animal = new Owl(name, weight, wingSize);
                }
            }

            return animal;
        }
    }

}


