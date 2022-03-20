namespace p06FoodShortage
{
    public interface IBuyer 
    {
        public int Food { get; }
        string Name { get; }

        public void BuyFood();
    }
}
