using NUnit.Framework;
using System.Numerics;
using System;
using System.Xml.Linq;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Goalkeeper")]
        [TestCase("Midfielder")]
        [TestCase("Forward")]
        public void CreatePlayerNormaly(string possition)
        {
            FootballPlayer player = new FootballPlayer("name", 1, possition);
            Assert.That(player.Name, Is.EqualTo("name"));
            Assert.That(player.PlayerNumber, Is.EqualTo(1));
            Assert.That(player.Position, Is.EqualTo(possition));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TryCreatePlayerWithWrongName(string name)
        {

            Assert.Throws<ArgumentException>(() =>
            { FootballPlayer player = new FootballPlayer(name,1, "Goalkeeper"); });

        }
        [Test]
        [TestCase(0)]
        [TestCase(22)]
        public void TryCreatePlayerWithWrongNumber(int number)
        {

            Assert.Throws<ArgumentException>(() =>
            { FootballPlayer player = new FootballPlayer("name",number, "Goalkeeper"); });

        }
        [Test]
        public void TryCreatePlayerWithWrongPossition()
        {

            Assert.Throws<ArgumentException>(() =>
            { FootballPlayer player = new FootballPlayer("name",1, "Wrong"); });

        }
        [Test]
        public void TryScore()
        {

             FootballPlayer player = new FootballPlayer("name",1, "Goalkeeper");
            player.Score();
            Assert.That(player.ScoredGoals, Is.EqualTo(1));
        }
        [Test]
        public void TryCreateTeamNormaly()
        {
            FootballTeam team = new FootballTeam("team", 20);
            Assert.That(team.Name, Is.EqualTo("team"));
            Assert.That(team.Capacity, Is.EqualTo(20));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TryCreateTeamWithWrongName(string name)
        {

            Assert.Throws<ArgumentException>(() =>
            { FootballTeam team = new FootballTeam(name, 20); });

        }
        [Test]
        [TestCase(14)]
        public void TryCreateTeamWrongCapacity(int number)
        {

            Assert.Throws<ArgumentException>(() =>
            { FootballTeam team = new FootballTeam("team", number); });

        }
        [Test]
        [TestCase(20)]
        public void TryCreateTeamNormalCapacity(int number)
        {
            FootballTeam team = new FootballTeam("team", number);
            Assert.That(team.Capacity, Is.EqualTo(number));

        }
        [Test]
        public void TeamAddPlahyerNormaly()
        {
            FootballTeam team = new FootballTeam("team", 15);
            FootballPlayer player = new FootballPlayer("player", 1, "Goalkeeper");
            team.AddNewPlayer(player);
            Assert.That(team.Players.Count, Is.EqualTo(1));
        }
        [Test]
        public void TeamAddPlahyerNormalyMessage()
        {
            FootballTeam team = new FootballTeam("team", 15);
            FootballPlayer player = new FootballPlayer("player", 1, "Goalkeeper");
            string message = "Added player player in position Goalkeeper with number 1";

            Assert.That(message, Is.EqualTo(team.AddNewPlayer(player)));
        }
        [Test]
        public void TeamAddMorePlayers()
        {
            FootballTeam team = new FootballTeam("team", 15);
            FootballPlayer player = new FootballPlayer("player", 1, "Goalkeeper");
            string message = "No more positions available!";
            for (int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(player);
            }
            Assert.That(message, Is.EqualTo(team.AddNewPlayer(player)));
        }
        [Test]
        public void TeamPickPlayer()
        {
            FootballTeam team = new FootballTeam("team", 15);
            FootballPlayer player = new FootballPlayer("player", 1, "Goalkeeper");
                team.AddNewPlayer(player);
            FootballPlayer player2 = team.PickPlayer("player");
            Assert.That(player2.Name, Is.EqualTo("player"));
        }
        [Test]
        public void GetPlayerScore()
        {
            FootballTeam team = new FootballTeam("team", 15);
            FootballPlayer player = new FootballPlayer("player", 1, "Goalkeeper");
                team.AddNewPlayer(player);
            string message = "player scored and now has 1 for this season!";
            Assert.That(message, Is.EqualTo(team.PlayerScore(1)));
        }
    }
}