using System;
using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight,  double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                this.Weight += food.FoodQuantity * 0.25;
                this.FoodEaten += food.FoodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
