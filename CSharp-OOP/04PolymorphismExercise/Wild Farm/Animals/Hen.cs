using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            this.Weight += food.FoodQuantity * 0.35;
            this.FoodEaten += food.FoodQuantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
