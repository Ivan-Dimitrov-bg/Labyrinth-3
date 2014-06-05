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
        private const string NEW_LINE = "\n";
        private const int MAX_SCORELIST_SIZE = 5;
        private const string NICKNAME_INPUT_MESSAGE = "Please enter your nickname";
        private const string TOP_FIVE_MESSAGE = "Top 5: \n";
        private const string EMPTY_SCOREBOARD_MESSAGE = "The scoreboard is empty! ";
        private const string SCORELIST_ROW_TEMPLATE = "{0}. {1} ---> {2} moves";

        private readonly List<PlayerScore> scores;

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
                    Renderer.RenderMessage(NICKNAME_INPUT_MESSAGE);
                    currentPlayerScore.Name = Console.ReadLine();
                    scores.Add(currentPlayerScore);
                }
            }
            if (scores.Count < MAX_SCORELIST_SIZE)
            {
                Renderer.RenderMessage(NICKNAME_INPUT_MESSAGE);
                currentPlayerScore.Name = Console.ReadLine();
                scores.Add(currentPlayerScore);
            }

            this.SortScores();
        }

        public void ShowScore()
        {
            Renderer.RenderMessage(NEW_LINE);
            if (this.scores.Count == 0)
            {
                Renderer.RenderMessage(EMPTY_SCOREBOARD_MESSAGE);
            }
            else
            {
                int playerPosition = 1;
                Renderer.RenderMessage(TOP_FIVE_MESSAGE);
                this.scores.ForEach((s) =>
                {
                    Renderer.RenderMessage(SCORELIST_ROW_TEMPLATE, playerPosition, s.Name, s.Moves);
                    playerPosition++;   
                });
                Renderer.RenderMessage(NEW_LINE);
            }
        }

        private void SortScores()
        {
            this.scores.Sort((s1, s2) => s1.Moves.CompareTo(s2.Moves));
        }
    }
}