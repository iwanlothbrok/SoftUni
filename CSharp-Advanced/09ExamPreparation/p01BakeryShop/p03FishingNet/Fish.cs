

namespace FishingNet
{
    public class Fish
    {
        public Fish(string type, double lenght, double weight)
        {
            FishType = type;
            Lenght = lenght;
            Weight = weight;

        }
        public string FishType;
        public double Lenght;
        public double Weight;


        public override string ToString()
        {
            return $"There is a {FishType}, {Lenght} cm. long, and {Weight} gr. in weight.";
        }
    }
}
