namespace Labyrinth.ScoreUtils
{
    using System.Collections.Generic;
    using Labyrinth.Interfaces;

    public class ScoreBoard : IScoreBoard
    {
        private const string NEW_LINE = "\n";

        private const string TOP_FIVE_MESSAGE = "Top 5: \n";
        private const string EMPTY_SCOREBOARD_MESSAGE = "The scoreboard is empty! ";
        private const int MAX_SCORELIST_SIZE = 5;

        private readonly List<PlayerScore> scores;

        public int Count
        {
            get
            {
                return this.scores.Count;
            }
        }

        public ScoreBoard()
        {
            this.scores = new List<PlayerScore>();
        }

        public void AddScore(PlayerScore currentPlayerScore)
        {
            if (scores.Count == MAX_SCORELIST_SIZE)
            {
                if (scores[MAX_SCORELIST_SIZE - 1].Moves > currentPlayerScore.Moves)
                {
                    scores.Remove(scores[4]);                  
                }
            }
            if (scores.Count < MAX_SCORELIST_SIZE)
            {
                scores.Add(currentPlayerScore);
            }

            this.scores.Sort((currentPlayer, otherPlayer) => currentPlayer.Moves.CompareTo(otherPlayer.Moves));
        }

        //Bridge pattern.The object recieves particular implementation of the renderer.
        public void Render(IRenderer renderer)
        {
            renderer.Render(NEW_LINE);
            if (scores.Count == 0)
            {
                renderer.Render(EMPTY_SCOREBOARD_MESSAGE);
            }
            else
            {
                int playerPosition = 1;
                renderer.Render(TOP_FIVE_MESSAGE);
                this.scores.ForEach((currentPlayerScore) =>
                {
                    currentPlayerScore.Position = playerPosition;

                    //Composite pattern... rendering the score list renders all the scores in it 
                    currentPlayerScore.Render(renderer);
                    playerPosition++;   
                     renderer.Render(NEW_LINE);
                });
                
               
            }
        }
    }
}