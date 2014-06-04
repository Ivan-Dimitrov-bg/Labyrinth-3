using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Labyrinth.Interfaces;

namespace Labyrinth.ScoreUtils
{
    public class ScoreBoard : IScoreBoard
    {
        private const int MAX_SCORELIST_SIZE = 5;
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
                    Console.WriteLine("Please enter your nickname");
                    currentPlayerScore.Name = Console.ReadLine();
                    scores.Add(currentPlayerScore);
                }
            }
            if (scores.Count < MAX_SCORELIST_SIZE)
            {
                Console.WriteLine("Please enter your nickname");
                currentPlayerScore.Name = Console.ReadLine();
                scores.Add(currentPlayerScore);
            }

            this.SortScores();
        }

        public void ShowScore()
        {
            Console.WriteLine("\n");
            if (this.scores.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty! ");
            }
            else
            {
                int playerPosition = 1;
                Console.WriteLine("Top 5: \n");
                this.scores.ForEach((s) =>
                {
                    Console.WriteLine(String.Format(playerPosition + ". {1} ---> {0} moves", s.Moves, s.Name));
                    playerPosition++;   
                });
                Console.WriteLine("\n");
            }
        }

        private void SortScores()
        {
            this.scores.Sort((s1, s2) => s1.Moves.CompareTo(s2.Moves));
        }
    }
}