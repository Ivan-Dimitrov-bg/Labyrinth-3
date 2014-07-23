namespace Labyrinth.Factories
{
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    public static class ScoreBoardCreator
    {
        private static IScoreBoard scoreBoard;

        public static IScoreBoard CreateScoreBoard()
        {
            if (scoreBoard == null)
            {
                scoreBoard = new ScoreBoard();
            }

            return scoreBoard;
        }

        public static IScore CreatePlayerScore()
        {
            return new PlayerScore();
        }
    }
}