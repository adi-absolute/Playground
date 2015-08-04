using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketSharp
{
    public class TeamList
    {
        private List<Team> teamList = new List<Team>();

        public string[] GetAllNames()
        {
            List<string> teamNames = new List<string>();

            foreach (Team t in teamList)
            {
                teamNames.Add(t.teamName);
            }

            return teamNames.ToArray();
        }

        public string[] GetAllButOne(string teamName)
        {
            List<string> teamNames = new List<string>();

            foreach (Team t in teamList)
            {
                string name = t.teamName;
                if (name == teamName)
                    continue;

                teamNames.Add(name);
            }

            return teamNames.ToArray();
        }

        public void AddTeam(Team team)
        {
            teamList.Add(team);
        }

        public Team GetTeam(string name)
        {
            return teamList.Find(item => (item.teamName == name));
        }
    }
}
