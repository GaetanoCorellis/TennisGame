using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TennisGame.Enum;
using TennisGame.Class;

namespace TennisGame {
    public class Tennis {
        private Player FirstPlayer;
        private Player SecondPlayer;

        /// <summary>
        /// Tennis constructor with params.
        /// </summary>
        /// <param name="player1">FirstPlayer init.</param>
        /// <param name="player2">SecondPlayer init.</param>
        public Tennis(Player player1, Player player2) {
            FirstPlayer = player1;
            SecondPlayer = player2;
        }

        /// <summary>
        /// Update Player's point if the game isn't finished yet.
        /// </summary>
        /// <param name="player">Player to update points.</param>
        public void SetPoints(Player player) {
            if (HaveWinner() == null) {
                player.Points++;
            }
        }

        /// <summary>
        /// Check if the game isn't finished yet.
        /// </summary>
        /// <returns>Return player if the game is finished or null value if the game is running.</returns>
        public Player HaveWinner() {
            if (FirstPlayer.Points >= GameSettings.WinPointsMin && FirstPlayer.Points >= SecondPlayer.Points + GameSettings.WinPointsGap) {
                return FirstPlayer;
            }
            if (SecondPlayer.Points >= GameSettings.WinPointsMin && SecondPlayer.Points >= FirstPlayer.Points + GameSettings.WinPointsGap) {
                return SecondPlayer;
            }
            return null;
        }

        /// <summary>
        /// Check players points and determines the value to show.
        /// </summary>
        /// <returns>Message that report's the game score.</returns>
        public string ReportGameScore() {
            if (FirstPlayer.Points >= GameSettings.DeucePointsMin && SecondPlayer.Points == FirstPlayer.Points) {
                return "Deuce";
            }
            if (FirstPlayer.Points >= GameSettings.AdvantagePointsMin && FirstPlayer.Points == SecondPlayer.Points + GameSettings.AdvantagePointsGap) {
                return $"Advantage {FirstPlayer.Name}";
            }
            if (SecondPlayer.Points >= GameSettings.AdvantagePointsMin && SecondPlayer.Points == FirstPlayer.Points + GameSettings.AdvantagePointsGap) {
                return $"Advantage {SecondPlayer.Name}";
            }
            return $"{FirstPlayer.Name} : {Utils.GetPointDescription(FirstPlayer.Points)} - {SecondPlayer.Name} : {Utils.GetPointDescription(SecondPlayer.Points)}";
        }
    }
}
