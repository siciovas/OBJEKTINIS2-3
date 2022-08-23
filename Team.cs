using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD3
{
    public class Team : IComparable<Team>, IEquatable<Team>
    {
        public string TeamName { get; set; }
        public int Games { get; set; }
        public int WonGames { get; set; }


        public Team(string teamName, int games, int wonGames)
        {
            this.TeamName = teamName;
            this.Games = games;
            this.WonGames = wonGames;   
        }

        public Team()
        {

        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} ", TeamName, Games, WonGames);
        }

        public int CompareTo(Team other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Team other)
        {
           if(other == null)
            {
                return false;
            }

           if(TeamName == other.TeamName)
            {
                return true;
            }

            return false;
        }
    }
}