using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD3
{
    public class Player : IComparable<Player>, IEquatable<Team>
    {
        public string Team { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birth { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public int Games { get; set; }
        public int Points { get; set; }

        public Player(string team, string name, string surname, string birth, int height, string position,
        int games, int points)
        {
            this.Team = team;
            this.Name = name;
            this.Surname = surname;
            this.Birth = birth;
            this.Height = height;
            this.Position = position;
            this.Games = games;
            this.Points = points;
        }

        public Player()
        {

        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4} {5} {6} {7}", Team, Name, Surname, Birth, Height, Position, Games, Points);
        }

        static public bool operator >(Player player, Player other)
        {
            return player.CompareTo(other) == 1;
        }

        static public bool operator <(Player player, Player other)
        {
            return player.CompareTo(other) == -1;
        }

        static public bool operator >=(Player player, Player other)
        {
            return !(player < other);
        }

        static public bool operator <=(Player player, Player other)
        {
            return !(player > other);
        }

        public int CompareTo(Player other)
        {
            if(other == null)
            {
                return 1;
            }

            if (this.Points.CompareTo(other.Points) != 0)
                return this.Points.CompareTo(other.Points);

            else
                return this.Games.CompareTo(other.Games);
        }

        public bool Equals(Team other)
        {
            if(other == null)
                return false;
            
            if(this.Team == other.TeamName)
                return true;

            return false;
        }

    }

    
}