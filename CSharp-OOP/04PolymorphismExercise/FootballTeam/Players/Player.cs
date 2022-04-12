using System;

namespace FootballTeam.Players
{
    public class Player : IPlayer
    {


        private string name;
        private double overalSkillLevel;

        public Player(string name, Stats endurance, Stats sprint, Stats dribble, Stats passing, Stats shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.CalcAverageStat();
        }

        public Stats Endurance { get; }
        public Stats Sprint { get; }
        public Stats Dribble { get; }
        public Stats Passing { get; }
        public Stats Shooting { get; }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format($"A {this.Name} should not be empty."));
                }
                this.name = value;
            }
        }

        public double OveralSkillLevel
        {
            get { return this.overalSkillLevel; }
            set { this.overalSkillLevel = value; }
        }

        public void CalcAverageStat()
        {
            double sum = this.Endurance.Level + this.Sprint.Level + this.Dribble.Level + this.Passing.Level + this.Shooting.Level;
            this.OveralSkillLevel = Math.Round(sum / 5,0);
        }



    }
}
