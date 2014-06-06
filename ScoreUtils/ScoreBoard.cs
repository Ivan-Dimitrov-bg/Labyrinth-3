using System;
using System.Collections;
using System.Collections.Generic;
using Labyrinth.Interfaces;

namespace Labyrinth.ScoreUtils
{
    public class ScoreBoard : IScoreBoard, IEnumerable<PlayerScore>
    {
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<PlayerScore> GetEnumerator()
        {
            foreach (var item in this.scores)
            {
                yield return item;
            }
        }

    }
}