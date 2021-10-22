using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyTeam.Models
{
    // Represents an ESPN Fantasy Football fantasy team.
    public class FantasyTeam
    {
        // Overall team rank.
        public int PlayoffSeed { get; set; }

        // Represents the first part of the team name.
        public string Location { get; set; }

        // Represents the first part of the team name.
        public string Nickname { get; set; }

        // Represents the team's logo.
        public string Logo { get; set; }

        // Represents the team's overall record.
        public Record Record { get; set; }

        // Constructor
        public FantasyTeam(int playoffSeed, string location, string nickname, string logo, Record record)
        {
            PlayoffSeed = playoffSeed;
            Location = location;
            Nickname = nickname;
            Logo = logo;
            Record = record;
        }
    }

    // Represents a FantasyTeam record.
    public class Record
    {
        // Represents the team's overall record.
        public OverallRecord Overall { get; set; }

        // Constructor
        public Record(OverallRecord overall)
        {
            Overall = overall;
        }
    }

    public class OverallRecord
    {
        // Number of games back.
        public double GamesBack { get; set; }

        // Total number of losses.
        public int Losses { get; set; }

        // Winning percentage.
        public double Percentage { get; set; }

        // Total points against.
        public double PointsAgainst { get; set; }

        // Total points for.
        public double PointsFor { get; set; }

        // Streak length.
        public int StreakLength { get; set; }

        // Streak type.
        public string StreakType { get; set; }

        // Total number of ties.
        public int Ties { get; set; }

        // Total number of wins.
        public int Wins { get; set; }

        // Constructor
        public OverallRecord(double gamesBack, int losses, double percentage, double pointsAgainst, double pointsFor, int streakLength, string streakType, int ties, int wins)
        {
            GamesBack = gamesBack;
            Losses = losses;
            Percentage = percentage;
            PointsAgainst = pointsAgainst;
            PointsFor = pointsFor;
            StreakLength = streakLength;
            StreakType = streakType;
            Ties = ties;
            Wins = wins;
        }
    }
}
