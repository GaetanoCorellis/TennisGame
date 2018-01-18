using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TennisGame;
using TennisGame.Class;
using TennisGame.Enum;


namespace TennisGameUnitTests
{
    [TestClass]
    public class UnitTests
    {

        /// <summary>
        /// Initialization new player's name and points.
        /// </summary>
        [TestMethod]
        public void InitPlayer() {
            string playerName = "Player1";
            Player player = new Player(playerName);
            Assert.AreEqual(playerName, player.Name);
            Assert.AreEqual(0, player.Points);
        }

        /// <summary>
        /// Adding points to players.
        /// </summary>
        [TestMethod]
        public void AddPlayerPoint() {
            Player firstPlayer = new Player("Player1");
            Player secondPlayer = new Player("Player2");

            Tennis tennis = new Tennis(firstPlayer, secondPlayer);

            for (uint point = 1; point <= 10; point++) {
                tennis.SetPoints(firstPlayer);
                Assert.AreEqual(point, firstPlayer.Points);

                tennis.SetPoints(secondPlayer);
                Assert.AreEqual(point, secondPlayer.Points);
            }
        }

        /// <summary>
        /// Checking player winner with pre-established value.
        /// </summary>
        [TestMethod]
        public void HaveWinner() {
            Player firstPlayer = new Player("Player1");
            Player secondPlayer = new Player("Player2");

            Tennis tennis = new Tennis(firstPlayer, secondPlayer);
            Assert.AreEqual(null, tennis.HaveWinner());

            firstPlayer.Points = 4;
            secondPlayer.Points = 6;
            Assert.AreEqual(secondPlayer, tennis.HaveWinner());

            firstPlayer.Points = 4;
            secondPlayer.Points = 0;
            Assert.AreEqual(firstPlayer, tennis.HaveWinner());
        }

        /// <summary>
        /// Checking player winner with SetPoints.
        /// </summary>
        [TestMethod]
        public void HaveWinnerWithSetPoints() {
            Player firstPlayer = new Player("Player1");
            Player secondPlayer = new Player("Player2");

            Tennis tennis = new Tennis(firstPlayer, secondPlayer);
            Assert.AreEqual(null, tennis.HaveWinner());

            for(ushort point = 1; point < 6; point++) {
                tennis.SetPoints(firstPlayer);
                Assert.AreEqual(point < 4 ? point : 4, firstPlayer.Points);
                Assert.AreEqual(point < 4 ? null : firstPlayer, tennis.HaveWinner());
            }
        }

        /// <summary>
        /// Checking SetPoints doesn't update player points after 4 turns.
        /// </summary>
        [TestMethod]
        public void StopSetPoints() {
            Player firstPlayer = new Player("Player1");
            Player secondPlayer = new Player("Player2");

            Tennis tennis = new Tennis(firstPlayer, secondPlayer);
            Assert.AreEqual(null, tennis.HaveWinner());

            for (ushort point = 1; point < 6; point++) {
                tennis.SetPoints(firstPlayer);
                Assert.AreEqual(point < 4 ? point : 4, firstPlayer.Points);
            }
        }

        /// <summary>
        /// Checking GetPointDescription convertion is correct from number to ScoreType.
        /// </summary>
        [TestMethod]
        public void GetPointDescriptionTest() {
            Assert.AreEqual(nameof(ScoreType.Fifteen), Utils.GetPointDescription(1));
            Assert.AreNotEqual(nameof(ScoreType.Love), Utils.GetPointDescription(1));
        }

        /// <summary>
        /// Checking GetReportGameScore convertion is correct from number to ScoreType.
        /// </summary>
        [TestMethod]
        public void GetReportGameScoreFromNumberToScoreType() {
            //TODO - Add test logic.
            throw new NotImplementedException();
        }
    }
}
