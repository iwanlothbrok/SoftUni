namespace Raiding.Heroes
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name)
        {
            this.Power = 80;
        }
       // public int Power => 80;

        public override string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }
    }
}
