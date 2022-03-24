using System;
using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight,  string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat|| food is Vegetable)
            {
                this.Weight += food.FoodQuantity * 0.30;
                this.FoodEaten += food.FoodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
        public override string ToString()
        {
            //CHEK IF GET IS CORRECT
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
