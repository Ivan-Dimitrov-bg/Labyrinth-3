using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Labyrinth.GameEngine;
using Labyrinth.Interfaces;

namespace Labyrinth.ScoreUtils
{
    public class ScoreBoard : IScoreBoard
    {
        private readonly List<PlayerScore> scores;

        public ScoreBoard()
        {
            this.scores = new List<PlayerScore>();
        }

        public void AddScore(PlayerScore currentPlayerScore)
        {
            if (scores.Count == GameConstants.MAX_SCORELIST_SIZE)
            {
                if (scores[GameConstants.MAX_SCORELIST_SIZE - 1].Moves > currentPlayerScore.Moves)
                {
                    scores.Remove(scores[4]);
                    Renderer.RenderMessage(GameConstants.NICKNAME_INPUT_MESSAGE);
                    currentPlayerScore.Name = Console.ReadLine();
                    scores.Add(currentPlayerScore);
                }
            }
            if (scores.Count < GameConstants.MAX_SCORELIST_SIZE)
            {
               Renderer.RenderMessage(GameConstants.NICKNAME_INPUT_MESSAGE);
                currentPlayerScore.Name = Console.ReadLine();
                scores.Add(currentPlayerScore);
            }

            this.SortScores();
        }

        public void ShowScore()
        {
            Renderer.RenderMessage(GameConstants.NEW_LINE);
            if (this.scores.Count == 0)
            {
                Renderer.RenderMessage(GameConstants.EMPTY_SCOREBOARD_MESSAGE);
            }
            else
            {
                int playerPosition = 1;
                Renderer.RenderMessage(GameConstants.TOP_FIVE_MESSAGE);
                this.scores.ForEach((s) =>
                {
                    Renderer.RenderMessage(String.Format(playerPosition + ". {1} ---> {0} moves", s.Moves, s.Name));
                    playerPosition++;   
                });
               Renderer.RenderMessage(GameConstants.NEW_LINE);
            }
        }

        private void SortScores()
        {
            this.scores.Sort((s1, s2) => s1.Moves.CompareTo(s2.Moves));
        }
    }
}