using System;

namespace Animals.AniamlsInfo
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender= "Female") : base(name, age, gender)
        {
        }
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
