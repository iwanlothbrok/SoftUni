namespace Raiding.Heroes
{
    public interface IBaseHero
    {
        public string Name { get; set; }

        public int Power { get; set; }

        public string CastAbility();
    }
}
