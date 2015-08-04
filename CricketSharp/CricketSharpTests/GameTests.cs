using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CricketSharp;

namespace CricketSharpTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GetTeamNames()
        {
            Game game = new Game();
            string team1 = "India";
            string team2 = "Pakistan";

            game.AddTeam(new Team(team1));
            game.AddTeam(new Team(team2));

            Assert.AreEqual(team1, game.GetFirstTeamName());
            Assert.AreEqual(team2, game.GetSecondTeamName());
        }
    }
}
