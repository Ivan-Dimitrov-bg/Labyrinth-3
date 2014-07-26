namespace Labyrinth.Factories
{
    using Labyrinth.Interfaces;
    using Labyrinth.ScoreUtils;

    public static class ScoreBoardCreator
    {
        private static IScoreBoard scoreBoard;

        // <summary>
        /// ScoreBoard creation method
        /// </summary>
        /// <remarks>
        /// Will return instance of IScoreBoard
        /// </remarks>      

        public static IScoreBoard CreateScoreBoard()
        {
            if (scoreBoard == null)
            {
                scoreBoard = new ScoreBoard();
            }

            return scoreBoard;
        }

        // <summary>
        /// PlayerScore creation method
        /// </summary>
        /// <remarks>
        /// Will return instance of IScore
        /// </remarks>  
        public static IScore CreatePlayerScore()
        {
            return new PlayerScore();
        }
    }
}