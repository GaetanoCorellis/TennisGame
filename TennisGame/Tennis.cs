using System.IO;
using TennisGame.Enum;
using TennisGame.Class;

namespace TennisGame {
    public class Tennis {
        private Player FirstPlayer;
        private Player SecondPlayer;
        private GameSettings GameSettings;

        /// <summary>
        /// Tennis constructor with params.
        /// </summary>
        /// <param name="player1">FirstPlayer init.</param>
        /// <param name="player2">SecondPlayer init.</param>
        public Tennis(Player player1, Player player2) {
            FirstPlayer = player1;
            SecondPlayer = player2;
            GameSettings = Utils.GetClassFromEmbeddedJson<GameSettings>(nameof(GameSettings));
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
            if (IsDeuce()) {
                return nameof(SpecialScoreType.Deuce);
            }
            if (IsAdvantage()) {
                return $"{nameof(SpecialScoreType.Advantage)} {(FirstPlayer.Points > SecondPlayer.Points ? FirstPlayer.Name : SecondPlayer.Name)}";
            }
            return $"{FirstPlayer.Name} : {Utils.GetPointDescription(FirstPlayer.Points)} - {SecondPlayer.Name} : {Utils.GetPointDescription(SecondPlayer.Points)}";
        }

        /// <summary>
        /// Check if the game is deuce.
        /// </summary>
        /// <returns>True if the game is Deuce, false if the game isn't.</returns>
        private bool IsDeuce() {
            return FirstPlayer.Points >= GameSettings.DeucePointsMin && SecondPlayer.Points == FirstPlayer.Points;
        }

        /// <summary>
        /// Check if a player is in Advantage.
        /// </summary>
        /// <returns>True if a player is in Advantage, false if there isn't advantage.</returns>
        private bool IsAdvantage() {
            return FirstPlayer.Points >= GameSettings.AdvantagePointsMin && FirstPlayer.Points == SecondPlayer.Points + GameSettings.AdvantagePointsGap || SecondPlayer.Points >= GameSettings.AdvantagePointsMin && SecondPlayer.Points == FirstPlayer.Points + GameSettings.AdvantagePointsGap;
        }
    }
}
