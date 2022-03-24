using System;
using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight,  string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
            {
                this.Weight += food.FoodQuantity * 0.10;
                this.FoodEaten += food.FoodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
