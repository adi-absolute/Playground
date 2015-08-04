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
    public partial class GameWindow : Form
    {
        public GameWindow(Game game)
        {
            //bool tossWinnerSelected = false;
            //bool sideBattingFirstSelected = false;

            InitializeComponent();

            button_startGame.Enabled = false;

            string firstTeamName = game.GetFirstTeamName();
            string secondTeamName = game.GetSecondTeamName();

            listBox_selectTossWinner.Items.Add(firstTeamName);
            listBox_selectTossWinner.Items.Add(secondTeamName);
            listBox_battingFirstSide.Items.Add(firstTeamName);
            listBox_battingFirstSide.Items.Add(secondTeamName);
        }

        private void ValidateStartGameButton()
        {
            button_startGame.Enabled =
                ((listBox_selectTossWinner.SelectedIndex != -1)
                && (listBox_battingFirstSide.SelectedIndex != -1));
        }

        private void listBox_selectTossWinner_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateStartGameButton();
        }

        private void listBox_battingFirstSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateStartGameButton();
        }
    }
}
