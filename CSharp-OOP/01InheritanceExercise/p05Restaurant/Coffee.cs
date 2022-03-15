

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeeMililiters = 50;
        private const decimal CoffePrice = 3.5m;
        public Coffee(string name,double caffeine) : base(name, CoffePrice, CoffeeMililiters)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
