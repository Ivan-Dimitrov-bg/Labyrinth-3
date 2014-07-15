namespace Labyrinth.ScoreUtils
{
    using System.Collections.Generic;
    using Labyrinth.Interfaces;

    public class ScoreBoard : IScoreBoard
    {
        private const string NEW_LINE = "\n";

        private const string TOP_FIVE_MESSAGE = "Top 5: \n";
        private const string EMPTY_SCOREBOARD_MESSAGE = "The scoreboard is empty!\n";
        private const int MAX_SCORELIST_SIZE = 5;

        private readonly List<IScore> scores;

        public ScoreBoard()
        {
            this.scores = new List<IScore>();
        }

        public int Count
        {
            get
            {
                return this.scores.Count;
            }
        }

        public void AddScore(IScore currentPlayerScore)
        {
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