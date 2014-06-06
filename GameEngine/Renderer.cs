using System;
using Labyrinth.Interfaces;
using System.Text;

namespace Labyrinth.GameEngine
{
    public class Renderer : IRenderer
    { 
        private const string NEW_LINE = "\n";

        private const string TOP_FIVE_MESSAGE = "Top 5: \n";
        private const string EMPTY_SCOREBOARD_MESSAGE = "The scoreboard is empty! ";
        private const string SCORELIST_ROW_TEMPLATE = "{0}. {1} ---> {2} moves";

        public void RenderMaze(IMaze maze)
        {
            for (int i = 0; i < maze.Rows; i++)
            {
                StringBuilder row = new StringBuilder();
                for (int j = 0; j < maze.Cols; j++)
                {
                    row.Append(maze[i, j] + " ");
                }
                this.RenderMessage(row.ToString());
            }
            this.RenderMessage(string.Empty);
        }

        public void RenderScore(IScoreBoard scores, IPlayer player)
        {
            this.RenderMessage(NEW_LINE);
            if (scores.Count == 0)
            {
                this.RenderMessage(EMPTY_SCOREBOARD_MESSAGE);
            }
            else
            {
                int playerPosition = 1;
                this.RenderMessage(TOP_FIVE_MESSAGE);
                foreach (var currentPlayer in scores)
                {
                    this.RenderMessage(SCORELIST_ROW_TEMPLATE, playerPosition, currentPlayer.Name, currentPlayer.Moves);
                    playerPosition++;   
                }
                this.RenderMessage(NEW_LINE);
            }
        }

        public void RenderMessage(string message, params object[] args)
        {
            if (args == null)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine(message, args);
            }
        }
    }
}