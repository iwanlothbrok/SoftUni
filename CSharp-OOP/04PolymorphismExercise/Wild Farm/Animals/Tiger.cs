using System;
using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                //TODO: CHEK WEIGHT
                this.FoodEaten += food.FoodQuantity;
            }
            else
            {
                throw new InvalidOperationException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
        public override string ToString()
        {
            //CHEK IF GET IS CORRECT
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
