﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace LD3
{
    public partial class Laboratorinis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //----------------------------------------------------------------------------------------------------------------------------

            string playersFile = Server.MapPath("App_Data/U11a.txt");
            string teamsFile = Server.MapPath("App_Data/U11b.txt");
            string resultsFile = Server.MapPath("App_Data/Rezultatai.txt");

            //----------------------------------------------------------------------------------------------------------------------------

            LinkList<Player> Players = InOut.ReadPlayers(playersFile);
            LinkList<Team> Teams = InOut.ReadTeams(teamsFile);

            //----------------------------------------------------------------------------------------------------------------------------

            if(File.Exists(resultsFile))
            {
                File.Delete(resultsFile);
            }

            //----------------------------------------------------------------------------------------------------------------------------

            InOut.PrintPlayers(Players, resultsFile, "Pradiniai žaidėjų duomenys: ");
            InOut.WritePlayersToTable(Table1, Players, "Pradiniai žaidėjų duomenys: ");

            InOut.PrintTeams(Teams, resultsFile, "Pradiniai komandų duomenys :");
            InOut.WriteTeamsToTable(Table2, Teams, "Pradiniai komandų duomenys: ");

            //----------------------------------------------------------------------------------------------------------------------------

            LinkList<Player> guards = TaskUtils.SelectedByPositions(Players, " gynėjas");
            InOut.PrintPlayers(guards, resultsFile, "Gynėjai:");
            InOut.WritePlayersToTable(Table3, guards, "Gynėjai:");
            guards.Sort();

            LinkList<Player> forwards = TaskUtils.SelectedByPositions(Players, " puolėjas");
            InOut.PrintPlayers(forwards, resultsFile, "Puolėjai: ");
            InOut.WritePlayersToTable(Table4, forwards, "Puolėjai: ");
            forwards.Sort();

            LinkList<Player> centers = TaskUtils.SelectedByPositions(Players, " centras");
            InOut.PrintPlayers(centers, resultsFile, "Centrai: ");
            InOut.WritePlayersToTable(Table5, centers, "Centrai: ");
            centers.Sort();

            //----------------------------------------------------------------------------------------------------------------------------

            Team bestTeam = TaskUtils.BestTeam(Teams);
            InOut.PrintBestTeam(bestTeam, resultsFile, "Geriausia komanda: ");
            InOut.WriteBestTeamToTable(Table6, bestTeam, "Geriausia komanda: ");

            LinkList<Player> bestTeamPlayers = TaskUtils.BestTeamPlayers(Players, bestTeam);
            InOut.PrintPlayers(bestTeamPlayers, resultsFile, "Geriausios komandos žaidėjai: ");
            InOut.WritePlayersToTable(Table7, bestTeamPlayers, "Geriausios komandos žaidėjai: ");

            //----------------------------------------------------------------------------------------------------------------------------

            LinkList<Player> selectedPlayers = TaskUtils.SelectedTeamsPlayers(Players, TextBox1);
            InOut.PrintPlayers(selectedPlayers, resultsFile, "Pasirinktos komandos žaidėjai: ");
            InOut.WritePlayersToTable(Table8, selectedPlayers, "Pasirinktos komandos žaidėjai: ");
        }
    }
}