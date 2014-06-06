using System;
using System.Collections;
using System.Collections.Generic;
using Labyrinth.Interfaces;
using Labyrinth.GameObjects;

namespace Labyrinth.ScoreUtils
{
    public class ScoreBoard : IScoreBoard, IRenderable
    {
        private const string NEW_LINE = "\n";

        private const string TOP_FIVE_MESSAGE = "Top 5: \n";
        private const string EMPTY_SCOREBOARD_MESSAGE = "The scoreboard is empty! ";
        private const string SCORELIST_ROW_TEMPLATE = "{0}. {1} ---> {2} moves";
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

        public void Render()
        {
            new GameMessage(NEW_LINE).Render();
            if (scores.Count == 0)
            {
                new GameMessage(EMPTY_SCOREBOARD_MESSAGE).Render();
            }
            else
            {
                int playerPosition = 1;
                new GameMessage(TOP_FIVE_MESSAGE).Render();
                this.scores.ForEach((currentPlayer) =>
                {
                    new GameMessage(SCORELIST_ROW_TEMPLATE, playerPosition, currentPlayer.Name, currentPlayer.Moves).Render();
                    playerPosition++;   
                });
                
                new GameMessage(NEW_LINE).Render();
            }
        }
    }
}