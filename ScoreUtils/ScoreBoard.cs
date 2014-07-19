namespace Labyrinth.ScoreUtils
{
    using System;
    using System.Collections.Generic;
    using Labyrinth.Interfaces;

    public class ScoreBoard : IScoreBoard
    {
        private const string NEW_LINE = "\n";

        private const string TOP_FIVE_MESSAGE = "Top 5: \n";
        private const string EMPTY_SCOREBOARD_MESSAGE = "The scoreboard is empty!\n";
        private const int MAX_SCORELIST_SIZE = 5;

        private readonly List<IScore> scores;

        /// <summary>
        /// Constructor for the scoreboard
        /// <remarks>
        /// Uses a list with IScore element
        /// <returns>
        /// Does not return anything, this is a constructor
        /// </returns>
        /// </remarks>
        /// </summary>
        public ScoreBoard()
        {
            this.scores = new List<IScore>();
        }

        /// <summary>
        /// Getter for the current count, will be used for the high score
        /// <remarks>
        /// None
        /// <returns>
        /// Returns the count with a getter
        /// </returns>
        /// </remarks>
        /// </summary>
        public int Count
        {
            get
            {
                return this.scores.Count;
            }
        }

        public void AddScore(IScore currentPlayerScore)
        {
            if (currentPlayerScore == null)
            {
                throw new ArgumentNullException("Cannot add null to ScoreBoard scores");
            }

            if (this.scores.Count == MAX_SCORELIST_SIZE)
            {
                if (this.scores[MAX_SCORELIST_SIZE - 1].Moves > currentPlayerScore.Moves)
                {
                    this.scores.Remove(this.scores[4]);
                }
            }

            if (this.scores.Count < MAX_SCORELIST_SIZE)
            {
                this.scores.Add(currentPlayerScore);
            }

            this.scores.Sort((currentPlayer, otherPlayer) => currentPlayer.Moves.CompareTo(otherPlayer.Moves));
        }

        // Strategy pattern.The object recieves concrete strategy implementation of the renderer.
        public void Render(IRenderer renderer)
        {
            if (this.scores.Count == 0)
            {
                renderer.Render(EMPTY_SCOREBOARD_MESSAGE);
            }
            else
            {
                int playerPosition = 1;
                renderer.Render(TOP_FIVE_MESSAGE);

                // Composite pattern... rendering the score list renders all the score items in it 
                foreach (IScore score in this.scores)
                {
                    score.Position = playerPosition;
                    score.Render(renderer);
                    playerPosition++;
                    renderer.Render(NEW_LINE);
                }
            }
        }
    }
}