namespace Animals.AniamlsInfo
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public string ProduceSound();
    }
}
