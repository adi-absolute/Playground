﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CricketSharp
{
    public partial class MainWindow : Form
    {
        TeamList teamList;
        int selectedTeamIndex = 0;
        bool firstTeamPicked = false;
        List<string> playingTeams = new List<string>();
        Game game;

        public MainWindow()
        {
            InitializeComponent();

            teamList = new TeamList();
            Team ind = new Team("India");
            Team aus = new Team("Australia");
            Team pak = new Team("Pakistan");
            Team eng = new Team("England");

            teamList.AddTeam(ind);
            teamList.AddTeam(aus);
            teamList.AddTeam(pak);
            teamList.AddTeam(eng);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartTeamSelectionList();
            newGameToolStripMenuItem.Enabled = false;
        }

        private void StartTeamSelectionList()
        {
            button_TeamSelection.Visible = true;
            listbox_TeamSelection.Visible = true;
            listbox_TeamSelection.Items.AddRange(teamList.GetAllNames());
            listbox_TeamSelection.SelectedIndex = selectedTeamIndex;
        }

        private void button_TeamSelection_Click(object sender, EventArgs e)
        {
            string n = listbox_TeamSelection.Items[selectedTeamIndex].ToString();
            playingTeams.Add(n);

            if (!firstTeamPicked)
            {
                listbox_TeamSelection.Items.Clear();
                button_TeamSelection.Text = "Select Second Team";
                listbox_TeamSelection.Items.AddRange(teamList.GetAllButOne(n));
                selectedTeamIndex = 0;
                listbox_TeamSelection.SelectedIndex = selectedTeamIndex;

                firstTeamPicked = true;
                return;
            }

            game = new Game();

            game.AddTeam(teamList.GetTeam(playingTeams.ElementAt(0)));
            game.AddTeam(teamList.GetTeam(playingTeams.ElementAt(1)));

            listbox_TeamSelection.Visible = false;
            button_TeamSelection.Visible = false;

            this.Hide();
            var gw = new GameWindow(game);
            gw.Closed += (s, args) => this.Close();
            gw.Show();
        }

        private void listbox_TeamSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeamIndex = listbox_TeamSelection.SelectedIndex;
        }
    }
}