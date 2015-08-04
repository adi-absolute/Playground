using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketSharp
{
    public class Game
    {
        List<Team> teams = new List<Team>();

        public void AddTeam(Team t)
        {
            teams.Add(t);
        }

        public string GetFirstTeamName()
        {
            return teams.ElementAt(0).teamName;
        }

        public string GetSecondTeamName()
        {
            return teams.ElementAt(1).teamName;
        }
    }
}
