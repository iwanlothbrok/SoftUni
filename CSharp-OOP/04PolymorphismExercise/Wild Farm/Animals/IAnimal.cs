using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

       abstract string ProduceSound();
       abstract void Eat(IFood food);
    }
}
