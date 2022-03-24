namespace Wild_Farm.Animals
{
    public abstract class Feline : Mammal
    {
     

        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }
        public string Breed { get; set; }
        public override string ToString()
        {
            //CHEK IF GET IS CORRECT
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
