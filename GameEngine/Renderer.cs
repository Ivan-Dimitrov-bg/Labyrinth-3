using System;
using Labyrinth.Interfaces;

namespace Labyrinth.GameEngine
{
    public static class Renderer
    {
        public static void RenderMaze(IMaze maze)
        {
            maze.DisplayMaze();
        }

        public static void RenderScore(IScoreBoard scores, IPlayer player)
        {
            scores.AddScore(player.Score);
            Renderer.RenderMessage(GameConstants.CONGRATULATIONS_MESSAGE, player.Score.Moves);            
            scores.ShowScore();
        }

        public static void RenderMessage(string message, params object[] args)
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