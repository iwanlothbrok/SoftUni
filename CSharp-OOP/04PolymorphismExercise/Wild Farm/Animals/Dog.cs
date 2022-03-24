using System;
using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.FoodQuantity * 0.40;
                this.FoodEaten += food.FoodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Woof";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
