using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LD3
{
    public static class TaskUtils
    {
        /// <summary>
        /// Method selects players based on their position
        /// </summary>
        /// <param name="player">linked list of players</param>
        /// <param name="position">Player positiomn (GURAD/FORWARD/CENTER)</param>
        /// <returns>linked list of players</returns>
        public static LinkList<Player> SelectedByPositions(LinkList<Player> player, string position)
        {
            LinkList<Player> positionList = new LinkList<Player>();

            foreach(Player play in player)
            {
                if(play.Position == position)
                {
                    positionList.Add(play);
                }
            }
            return positionList;
        }

        /// <summary>
        /// Method selects the best team, which has the most wins
        /// </summary>
        /// <param name="team">linked list of teams</param>
        /// <returns>all data of one team</returns>
        public static Team BestTeam(LinkList<Team> teams)
        {
            Team bestTeam = null;
            int maximum = Int32.MinValue;

            foreach(Team team in teams)
            {
                if(team.WonGames > maximum)
                {
                    maximum = team.WonGames;
                    bestTeam = team;
                }
            }
            return bestTeam;
        }

        /// <summary>
        /// Method selects the best team players
        /// </summary>
        /// <param name="players">linked list of players</param>
        /// <param name="teams">linked list of teams</param>
        /// <returns>linked list of the best team players</returns>
        public static LinkList<Player> BestTeamPlayers(LinkList<Player> players, Team team)
        {
           LinkList<Player> player = new LinkList<Player>();
           foreach(Player play in players)
           {
                if(play.Equals(team))
                {
                    player.Add(play);
                }
           }

            return player;
        }
        /// <summary>
        /// Method selects which team players we want to see
        /// </summary>
        /// <param name="players">linked list of players</param>
        /// <param name="textbox">textbox</param>
        /// <returns>linked list of players</returns>
        public static LinkList<Player> SelectedTeamsPlayers(LinkList<Player> players, TextBox textbox)
        {
            LinkList<Player> selected = new LinkList<Player>();

            foreach(Player play in players)
            {
                if(textbox.Text != null && play.Team == textbox.Text)
                {
                    selected.Add(play);
                }
            }   

            return selected;
        }
    }
}