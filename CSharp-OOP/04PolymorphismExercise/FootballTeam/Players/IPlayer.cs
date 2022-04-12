namespace FootballTeam.Players
{
    public interface IPlayer
    {
        public Stats Endurance { get; }
        public Stats Sprint { get; }
        public Stats Dribble { get; }
        public Stats Passing { get; }
        public Stats Shooting { get; }
    }
}
