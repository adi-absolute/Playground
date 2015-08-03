using System;
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
    public partial class Form1 : Form
    {
        TeamList teamList;
        int selectedTeamIndex = 0;
        public Form1()
        {
            InitializeComponent();

            teamList = new TeamList();
            Team ind = new Team("India");
            Team aus = new Team("Australia");

            teamList.AddTeam(ind);
            teamList.AddTeam(aus);
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
            listbox_TeamSelection.Items.Clear();
            button_TeamSelection.Text = "Select Second Team";
            listbox_TeamSelection.Items.AddRange(teamList.GetAllButOne(n));
        }

        private void listbox_TeamSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeamIndex = listbox_TeamSelection.SelectedIndex;
        }
    }
}
