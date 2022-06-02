using System;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public Team HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }


        public Team AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        public DateTime DateTime { get; set; }

        public Bet HomeTeamBetRate { get; set; }
        public Bet AwayTeamBetRate { get; set; }
        public Bet DrawBetRate { get; set; }

        public int Result { get; set; }
    }
}
//GameId, HomeTeamId, AwayTeamId, HomeTeamGoals, AwayTeamGoals, DateTime, HomeTeamBetRate, AwayTeamBetRate, DrawBetRate, Result)
