namespace TennisGame.Class {
    public static class Utils {
        public static string GetPointDescription(int point) {
            return ((Enum.ScoreType)point).ToString();
        }
    }
}
