using Wild_Farm.Food;

namespace Wild_Farm.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight,double wingSize) : base(name, weight)
        {
            WingSize=wingSize;
        }

        public double WingSize { get; set; }

        public abstract override void Eat(IFood food);

        public abstract override string ProduceSound();
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
