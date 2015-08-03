using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CricketSharp;

namespace CricketSharpTests
{
    [TestClass]
    public class TeamListTests
    {
        [TestMethod]
        public void GetListOfTeams()
        {
            TeamList teamList = new TeamList();
            string[] teams = { "England", "Pakistan" };

            teamList.AddTeam(new Team(teams[0]));
            teamList.AddTeam(new Team(teams[1]));
            
            string[] actualNames = teamList.GetAllNames();

            CollectionAssert.AreEqual(teams, actualNames);
        }

        [TestMethod]
        public void GetAllTeamsExceptOne()
        {
            TeamList teamList = new TeamList();
            string[] teams = { "England", "Pakistan" };

            teamList.AddTeam(new Team(teams[0]));
            teamList.AddTeam(new Team(teams[1]));

            string[] actualNames = teamList.GetAllButOne(teams[0]);

            Assert.AreEqual(teams[1], actualNames[0]);
        }
    }
}
